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
        private static readonly string pathSave;

        private readonly Map map;
        private readonly VisualCounter watch;
        private readonly VisualCounter flags;
        private readonly Timer timer;

        private int width;
        private int height;
        private FormWindowState oldWindowState;

        public static readonly string PathLocalAppData;

        static FormMain()
        {
            PathLocalAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $@"\{typeof(FormMain).Namespace}";
            Directory.CreateDirectory(PathLocalAppData);

            pathSave = PathLocalAppData + @"\Saved.json";
        }

        public FormMain()
        {
            InitializeComponent();

            oldWindowState = WindowState;

            width = Settings.Default.Width;
            height = Settings.Default.Height;

            Size = new Size(width, height);

            tableInfo.AutoSize = true;
            tableInfo.ColumnCount = 3;
            tableInfo.ColumnStyles.Clear();
            for (int i = 0; i < tableInfo.ColumnCount; i++)
                tableInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

            map = new Map();
            watch = new VisualCounter(TypeCounter.Watch);
            flags = new VisualCounter(TypeCounter.Flags);
            timer = new Timer();

            timer.Interval = 1000;

            tableMap.Controls.Add(map);
            tableInfo.Controls.Add(watch, 0, 0);
            tableInfo.Controls.Add(flags, 2, 0);

            //События
            ResizeEnd += (s, e) =>
            {
                width = Width;
                height = Height;
                map.Resize();
            };

            SizeChanged += (s, e) =>
            {
                if (oldWindowState != WindowState)
                {
                    oldWindowState = WindowState;
                    map.Resize();
                }
            };

            map.CounterChanged += (isInc) => flags.Value += isInc ? 1 : -1;
            map.GameStarted += () => timer.Start();
            map.GameOver += FinishGame;

            timer.Tick += (s, e) =>
            {
                if (watch.Value < 999)
                    watch.Value++;
                else
                    timer.Stop();
            };

            //Проверка на сохранение
            try
            {
                string jsonStr = File.ReadAllText(pathSave);
                JObject jObj = JObject.Parse(jsonStr);

                DialogResult dr = DialogResult.Yes;

                if (!Parameters.IsContinueSavedGame)
                    dr = MessageBox.Show("Продолжить сохранённую игру?", "Обнаружена сохранённая игра", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (dr == DialogResult.Yes)
                {
                    map.OpenSavedGame(jObj);
                    Reset(jObj["Seconds"].Value<int>(), jObj["Flags"].Value<int>());
                }
                else
                {
                    Statistics.WriteStatistics((Level)jObj["Level"].Value<int>(), false);
                    NewGame();
                }
            }
            catch (Exception)
            {
                NewGame();
            }
        }

        //Перехват ShortcutKeys при заблокированном MenuStrip
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return menuStrip.Enabled && map.IsGameStarted && base.ProcessCmdKey(ref msg, keyData);
        }

        private async void FinishGame(Level level, bool isWin, Cell sender)
        {
            timer.Stop();
            Statistics.WriteStatistics(level, isWin, watch.Value);
            menuStrip.Enabled = false;

            await map.ShowGameOver(sender);

            FormDialogGameOver form = new FormDialogGameOver(level, isWin, watch.Value);
            form.PlayerChose += (des) =>
            {
                if (des == Desicion.Exit)
                {
                    Close();
                }
                else if (des == Desicion.NewGame)
                {
                    NewGame();
                }
                else
                {
                    Reset(0, map.CountMines);
                    map.Restart();
                }
            };
            form.ShowDialog();
            menuStrip.Enabled = true;
        }
        private void NewGame()
        {
            map.NewGame();

            MinimumSize = new Size(map.SizeInCells.Width * 20, map.SizeInCells.Height * 20 + tableInfo.Height);
            map.Resize();

            Reset(0, map.CountMines);
        }

        private void Reset(int seconds, int countFlags)
        {
            timer.Stop();
            watch.Value = seconds;
            flags.Value = countFlags;
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!map.IsFirstMove)
            {
                FormDialogNewGame form = new FormDialogNewGame();

                //При обычном закрытии формы событие НЕ произойдёт вовсе
                form.PlayerChose += (isNewGame) =>
                {
                    Statistics.WriteStatistics(map.Level, false);

                    if (isNewGame)
                    {
                        NewGame();
                    }
                    else
                    {
                        Reset(0, map.CountMines);
                        map.Restart();
                    }
                };

                form.ShowDialog();
            }
            else
            {
                NewGame();
            }
        }

        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Statistics().ShowDialog();
        }

        private void ParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parameters form = new Parameters(map.IsFirstMove);
            form.UpdateData += NewGame;
            form.ShowDialog();
        }

        private void ChangeDesignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Design form = new Design();
            form.DesignChanged += map.ChangeDesign;
            form.DesignChanged += watch.ChangeDesign;
            form.DesignChanged += flags.ChangeDesign;
            form.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Reference().ShowDialog();
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.About, "Сапёр: сведения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OtherGamesOnInternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://cat-bounce.com/"));
        }

        //Ужасная конструкция
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Удалить старое сохранение
            try { File.Delete(pathSave); }
            catch (Exception) { }

            //Создать новое, если надо
            try
            {
                if (!map.IsFirstMove && !map.IsGameOver)
                {
                    if (Parameters.IsSaveGameExiting)
                    {
                        map.SaveGame(pathSave, watch.Value, flags.Value);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show(
                            "Текущая игра не закончена.\n" +
                            "Если не сохранить игру, то будет защитано поражение.\n" +
                            "Сохранить игру?",
                            "Выход из игры", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (dr == DialogResult.Cancel)
                            e.Cancel = true;
                        else if (dr == DialogResult.Yes)
                            map.SaveGame(pathSave, watch.Value, flags.Value);
                        else
                            Statistics.WriteStatistics(map.Level, false);
                    }
                }
            }
            catch (Exception) { }

            Parameters.WriteSettings();
            Design.WriteSettings();

            Settings.Default.Width = width;
            Settings.Default.Height = height;
            Settings.Default.IsMaximized = WindowState == FormWindowState.Maximized;

            Settings.Default.Save();
        }
    }
}
