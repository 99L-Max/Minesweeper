using Minesweeper.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class FormMain : Form
    {
        private static readonly string s_pathSave;

        private readonly Map _map;
        private readonly StatisticalData _statisticalData;
        private readonly SettingsData _settingsData;
        private readonly VisualCounter _watch;
        private readonly VisualCounter _flags;

        private int _width;
        private int _height;
        private FormWindowState _oldWindowState;

        public static readonly string PathLocalAppData;

        static FormMain()
        {
            PathLocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $@"\{typeof(FormMain).Namespace}";
            Directory.CreateDirectory(PathLocalAppData);

            s_pathSave = PathLocalAppData + @"\Saved.json";
        }

        public FormMain()
        {
            InitializeComponent();

            _oldWindowState = WindowState;

            _width = Settings.Default.Width;
            _height = Settings.Default.Height;

            Size = new Size(_width, _height);

            _tableInfo.AutoSize = true;
            _tableInfo.ColumnCount = 3;
            _tableInfo.ColumnStyles.Clear();

            for (int i = 0; i < _tableInfo.ColumnCount; i++)
                _tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1f));

            _statisticalData = new StatisticalData(PathLocalAppData);
            _settingsData = new SettingsData(PathLocalAppData);
            _watch = new VisualCounter(Resources.Watch, IconPosition.Left, _settingsData.Theme);
            _flags = new VisualCounter(Resources.Mine, IconPosition.Right, _settingsData.Theme);
            _map = new Map(_settingsData, (Theme)Settings.Default.Theme);

            _tableMap.Controls.Add(_map);
            _tableInfo.Controls.Add(_watch, 0, 0);
            _tableInfo.Controls.Add(_flags, 2, 0);

            _map.CounterChanged += (isInc) => _flags.Value += isInc ? 1 : -1;
            _map.GameStarted += () => _timer.Start();
            _map.GameOver += OnMapGameOver;
            _map.AnimationCompleted += OnMapAnimationCompleted;

            //Проверка на сохранение
            try
            {
                var jsonStr = File.ReadAllText(s_pathSave);
                var jObj = JObject.Parse(jsonStr);
                var dr = DialogResult.Yes;

                if (!_settingsData.GetSettings(GameSettings.IsContinueSavedGame))
                    dr = MessageBox.Show("Продолжить сохранённую игру?", "Обнаружена сохранённая игра", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    _map.Open(jObj);
                    ResetCounters(jObj["Seconds"].Value<int>(), jObj["Flags"].Value<int>());
                    _timer.Start();
                }
                else
                {
                    _statisticalData.Write((Level)jObj["Level"].Value<int>(), false);
                    NewGame();
                }
            }
            catch (Exception)
            {
                NewGame();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) =>
            _menuStrip.Enabled && _map.IsGameStarted && base.ProcessCmdKey(ref msg, keyData);

        private void ResetCounters(int seconds, int countFlags)
        {
            _timer.Stop();
            _watch.Value = seconds;
            _flags.Value = countFlags;
        }

        private void NewGame(bool isWriteLoss = false)
        {
            if (isWriteLoss)
                _statisticalData.Write(_map.Level, false);

            _map.NewGame(_settingsData);

            MinimumSize = new Size(_map.SizeInCells.Width * 20, _map.SizeInCells.Height * 20 + _tableInfo.Height);
            _map.ChangeSizeFocus();

            ResetCounters(0, _map.CountMines);
        }

        private void OnPlayerChose(Decision decision)
        {
            if (decision == Decision.Exit)
                Close();
            else if (decision == Decision.NewGame)
                NewGame();
            else
            {
                ResetCounters(0, _map.CountMines);
                _map.Restart();
            }
        }

        private void OnPlayerChose(bool isNewGame)
        {
            _statisticalData.Write(_map.Level, false);

            if (isNewGame)
                NewGame();
            else
            {
                ResetCounters(0, _map.CountMines);
                _map.Restart();
            }
        }

        private void OnMapGameOver(Level level, bool isWin)
        {
            _menuStrip.Enabled = false;
            _timer.Stop();
            _statisticalData.Write(level, isWin, _watch.Value);
        }

        private void OnMapAnimationCompleted(Level level, bool isWin)
        {
            var form = new FormDialogGameOver(level, isWin, _watch.Value, _statisticalData);

            form.PlayerChose += OnPlayerChose;

            void OnFormDialogGameOverClosed(object s, EventArgs e)
            {
                form.PlayerChose -= OnPlayerChose;
                form.FormClosed -= OnFormDialogGameOverClosed;
            }

            form.FormClosed += OnFormDialogGameOverClosed;
            form.ShowDialog();

            _menuStrip.Enabled = true;
        }

        private void OnNewGameToolClick(object sender, EventArgs e)
        {
            if (!_map.IsFirstMove)
            {
                var form = new FormDialogNewGame();

                void OnFormDialogNewGameClosed(object s, EventArgs ev)
                {
                    form.PlayerChose -= OnPlayerChose;
                    form.FormClosed -= OnFormDialogNewGameClosed;
                }

                form.PlayerChose += OnPlayerChose;
                form.FormClosed += OnFormDialogNewGameClosed;
                form.ShowDialog();
            }
            else
            {
                NewGame();
            }
        }

        private void OnStatisticsToolClick(object sender, EventArgs e) =>
            new FormStatistics(_statisticalData).ShowDialog();

        private void OnSettingsToolClick(object sender, EventArgs e)
        {
            var form = new FormSettings(_settingsData, _map.IsFirstMove);

            void OnFormSettingsClosed(object s, EventArgs ev)
            {
                _map.SetSettings(_settingsData);

                form.SettingsChanged -= NewGame;
                form.FormClosed -= OnFormSettingsClosed;
            }

            form.SettingsChanged += NewGame;
            form.FormClosed += OnFormSettingsClosed;
            form.ShowDialog();
        }

        private void OnChangeDesignToolClick(object sender, EventArgs e)
        {
            var form = new FormDesign(_settingsData);

            void OnFormDesignClosed(object s, EventArgs ev)
            {
                _map.ChangeDesign(_settingsData.Theme);
                _watch.ChangeDesign(_settingsData.Theme);
                _flags.ChangeDesign(_settingsData.Theme);

                form.FormClosed -= OnFormDesignClosed;
            }

            form.FormClosed += OnFormDesignClosed;
            form.ShowDialog();
        }

        private void OnViewHelpToolClick(object sender, EventArgs e) =>
            new FormReference().ShowDialog();

        private void OnAboutToolClick(object sender, EventArgs e) =>
            MessageBox.Show(Resources.About, "Сапёр: сведения", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void OnOtherGamesClick(object sender, EventArgs e) =>
            Process.Start(new ProcessStartInfo("https://cat-bounce.com/"));

        private void OnResizeEnd(object sender, EventArgs e)
        {
            _width = Width;
            _height = Height;
            _map.ChangeSizeFocus();
        }

        private void OnExitToolClick(object sender, EventArgs e) =>
            Close();

        private void OnSizeChanged(object sender, EventArgs e)
        {
            if (_oldWindowState != WindowState)
            {
                _oldWindowState = WindowState;
                _map.ChangeSizeFocus();
            }
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (++_watch.Value >= 999)
                _timer.Stop();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            try { File.Delete(s_pathSave); }
            catch (Exception) { }

            try
            {
                if (!_map.IsFirstMove && !_map.IsGameOver)
                {
                    if (_settingsData.GetSettings(GameSettings.IsSaveGameExiting))
                    {
                        _map.Save(s_pathSave, _watch.Value, _flags.Value);
                    }
                    else
                    {
                        var dr = MessageBox.Show(
                            "Текущая игра не закончена.\n" +
                            "Если не сохранить игру, то будет засчитано поражение.\n" +
                            "Сохранить игру?",
                            "Выход из игры", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (dr == DialogResult.Cancel)
                            e.Cancel = true;
                        else if (dr == DialogResult.Yes)
                            _map.Save(s_pathSave, _watch.Value, _flags.Value);
                        else
                            _statisticalData.Write(_map.Level, false);
                    }
                }
            }
            catch (Exception) { }

            _settingsData.Save(PathLocalAppData);
            _statisticalData.Save(PathLocalAppData);

            Settings.Default.Width = _width;
            Settings.Default.Height = _height;
            Settings.Default.IsMaximized = WindowState == FormWindowState.Maximized;

            Settings.Default.Save();
        }
    }
}
