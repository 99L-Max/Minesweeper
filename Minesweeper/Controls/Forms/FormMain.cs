using Minesweeper.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class FormMain : Form
    {
        private Map _map;
        private StatisticsData _statisticsData;
        private SettingsData _settingsData;
        private VisualCounter _timeCounter;
        private VisualCounter _unmarkedMinesCounter;

        public FormMain()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keyData)
        {
            return _menuStrip.Enabled && _map.IsGameRunning && base.ProcessCmdKey(ref message, keyData);
        }

        private void OnFormMainLoad(object sender, EventArgs e)
        {
            _settingsData = FileReader.GetSettingsOrDefault();
            _statisticsData = FileReader.GetStatisticsOrDefault();

            _map = new Map(_settingsData);
            _timeCounter = new VisualCounter(_settingsData.Theme, 999);
            _unmarkedMinesCounter = new VisualCounter(_settingsData.Theme);

            _tableGame.Controls.Add(_map, 0, 0);
            _tableInfo.Controls.Add(_timeCounter, 2, 0);
            _tableInfo.Controls.Add(_unmarkedMinesCounter, 4, 0);

            _map.UnmarkedMinesCountChanged += (value) => _unmarkedMinesCounter.Value = value;
            _map.GameStarted += () => _timer.Start();
            _map.StatisticsChanged += OnMapGameOver;
            _map.GameOver += OnMapAnimationCompleted;

            _pbUnmarkedMines.BackgroundImage = ResourceImage.CutImageByEnum(Resources.Mine, MineState.Inactive);

            OpenSavedGameOrStartNew();
            SetUserInterfaceDataFromFile();
            OnSizeChanged(this, EventArgs.Empty);

            SizeChanged += OnSizeChanged;
        }

        private void OpenSavedGameOrStartNew()
        {
            if (FileReader.TryOpenSaveFile(out MapCell[] cells, out int gameTimeInSeconds))
            {
                if (_settingsData.GetSettings(GameSettings.IsContinueSavedGame) == false)
                {
                    if (MessageShower.ShowQuestion(Resources.ContinueSavedGame) == DialogResult.Yes)
                    {
                        ContinueSavedGame(cells, gameTimeInSeconds);
                    }
                    else
                    {
                        _statisticsData.Write(_settingsData.Level, false);
                        StartNewGame();
                    }
                }
                else
                {
                    ContinueSavedGame(cells, gameTimeInSeconds);
                }
            }
            else
            {
                StartNewGame();
            }
        }

        private void ContinueSavedGame(MapCell[] cells, int gameTimeInSeconds)
        {
            _timeCounter.Value = gameTimeInSeconds;
            _unmarkedMinesCounter.Value = cells.Count(cell => cell.HasMine) - cells.Count(cell => cell.Mark == CellMark.Flag);
            _map.ContinueSavedGame(cells);
            _timer.Start();
        }

        private void SetUserInterfaceDataFromFile()
        {
            UserInterfaceData data = FileReader.GetUserInterfaceDataOrDefault();
            Size = data.Size;
            Location = data.Location;
            WindowState = data.WindowState;
        }

        private void ResetCounters()
        {
            _timer.Stop();
            _timeCounter.Value = 0;
            _unmarkedMinesCounter.Value = _map.MinesCount;
        }

        private void StartNewGame(bool isWriteLoss = false)
        {
            if (isWriteLoss)
                _statisticsData.Write(_settingsData.Level, false);

            var minCellSizePixels = 20;
            var minWidth = _settingsData.MapSize.Width * minCellSizePixels;
            var minHeight = _settingsData.MapSize.Height * (minCellSizePixels + 3);

            MinimumSize = new Size(minWidth, minHeight);

            _map.StartNewGame(_settingsData.MapSize, _settingsData.MinesCount);
            _map.ChangeFocusSize();

            ResetCounters();
        }

        private void SaveGame()
        {
            _map.Save();
            FileWriter.Save(_timeCounter.Value, GameDirectory.GameTimeInSecondsFilePath);
        }

        private void OnPlayerChose(DialogDecision decision)
        {
            if (decision == DialogDecision.Exit)
            {
                Close();
            }
            else if (decision == DialogDecision.NewGame)
            {
                StartNewGame();
            }
            else
            {
                ResetCounters();
                _map.Restart();
            }
        }

        private void OnPlayerChose(bool isNewGame)
        {
            _statisticsData.Write(_settingsData.Level, false);

            if (isNewGame)
            {
                StartNewGame();
            }
            else
            {
                ResetCounters();
                _map.Restart();
            }
        }

        private void OnMapGameOver(bool isWin)
        {
            _menuStrip.Enabled = false;
            _timer.Stop();
            _statisticsData.Write(_settingsData.Level, isWin, _timeCounter.Value);
        }

        private void OnMapAnimationCompleted(bool isWin)
        {
            var form = new FormDialogGameOver(_settingsData.Level, isWin, _timeCounter.Value, _statisticsData);

            form.PlayerChose += OnPlayerChose;
            form.FormClosed += OnFormDialogGameOverClosed;
            form.ShowDialog();

            _menuStrip.Enabled = true;
        }

        private void OnFormDialogGameOverClosed(object sender, EventArgs e)
        {
            if (sender is FormDialogGameOver form)
            {
                form.PlayerChose -= OnPlayerChose;
                form.FormClosed -= OnFormDialogGameOverClosed;
            }
        }

        private void OnNewGameToolClick(object sender, EventArgs e)
        {
            if (_map.IsGameRunning)
            {
                var form = new FormDialogNewGame();

                form.PlayerChose += OnPlayerChose;
                form.FormClosed += OnFormDialogNewGameClosed;
                form.ShowDialog();
            }
            else
            {
                StartNewGame();
            }
        }

        private void OnFormDialogNewGameClosed(object sender, EventArgs e)
        {
            if (sender is FormDialogNewGame form)
            {
                form.PlayerChose -= OnPlayerChose;
                form.FormClosed -= OnFormDialogNewGameClosed;
            }
        }

        private void OnStatisticsToolClick(object sender, EventArgs e)
        {
            new FormStatistics(_statisticsData).ShowDialog();
        }

        private void OnSettingsToolClick(object sender, EventArgs e)
        {
            var form = new FormSettings(_settingsData, _map.IsGameRunning == false, _map);

            form.LevelDataChanged += StartNewGame;
            form.FormClosed += OnFormSettingsClosed;
            form.ShowDialog();
        }

        private void OnFormSettingsClosed(object sender, EventArgs e)
        {
            if (sender is FormSettings form)
            {
                form.LevelDataChanged -= StartNewGame;
                form.FormClosed -= OnFormSettingsClosed;
            }
        }

        private void OnSetThemeToolClick(object sender, EventArgs e)
        {
            new FormDesign(_settingsData, _map, _unmarkedMinesCounter, _timeCounter).ShowDialog();
        }

        private void OnViewHelpToolClick(object sender, EventArgs e)
        {
            new FormReference().ShowDialog();
        }

        private void OnAboutToolClick(object sender, EventArgs e)
        {
            MessageShower.ShowInformation(Resources.Information);
        }

        private void OnOtherGamesToolClick(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://cat-bounce.com/"));
        }

        private void OnExitToolClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnResizeEnd(object sender, EventArgs e)
        {
            _map.ChangeFocusSize();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            _map.ChangeFocusSize();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (++_timeCounter.Value >= _timeCounter.MaxValue)
                _timer.Stop();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            GameDirectory.CreateSaveDirectory();
            FileWriter.DeleteSavedGame();

            if (_map.IsGameRunning)
            {
                if (_settingsData.GetSettings(GameSettings.IsSaveGameExiting))
                {
                    SaveGame();
                }
                else
                {
                    switch (MessageShower.ShowQuestion(Resources.GameNotSaved, true))
                    {
                        case DialogResult.Yes:
                            SaveGame();
                            break;

                        case DialogResult.No:
                            _statisticsData.Write(_settingsData.Level, false);
                            break;

                        default:
                            e.Cancel = true;
                            break;
                    }
                }
            }

            _settingsData.Save();
            _statisticsData.Save();

            new UserInterfaceData(this).Save();
        }
    }
}
