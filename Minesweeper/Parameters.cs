using Minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    enum Level
    {
        Beginner,
        Amateur,
        Professional,
        Special
    }
    partial class Parameters : Form
    {
        private static readonly Dictionary<Level, int> countMines;
        private static readonly Dictionary<Level, Size> sizes;

        private static int specialWidth;
        private static int specialHeight;
        private static int specialCountMines;

        private const int MinWidth = 9;
        private const int MinHeight = 9;
        private const int MinCountMines = 10;
        private const int MaxWidth = 30;
        private const int MaxHeight = 24;

        private readonly bool isFirstMove;
        private Level selectedLevel;

        public delegate void EventDataUpdate();
        public event EventDataUpdate UpdateData;

        public static Level Level { private set; get; }
        public static bool IsShowAnimation { private set; get; }
        public static bool IsContinueSavedGame { private set; get; }
        public static bool IsSaveGameExiting { private set; get; }
        public static bool IsShowQuestionMarks { private set; get; }
        public static Size MapSize => sizes[Level];
        public static int CountMines => countMines[Level];

        static Parameters()
        {
            //Восстановление настроек пользователя
            Level = (Level)Settings.Default.Level;
            IsShowAnimation = Settings.Default.IsShowAnimation;
            Sound.IsPlaySounds = Settings.Default.IsPlaySounds;
            IsContinueSavedGame = Settings.Default.IsContinueSavedGame;
            IsSaveGameExiting = Settings.Default.IsSaveGameExiting;
            IsShowQuestionMarks = Settings.Default.IsShowQuestionMarks;

            specialWidth = Settings.Default.SpecialWidth;
            specialHeight = Settings.Default.SpecialHeight;
            specialCountMines = Settings.Default.SpecialCountMines;

            countMines = new Dictionary<Level, int>()
            {
                { Level.Beginner, 10 },
                { Level.Amateur, 40 },
                { Level.Professional, 99 },
                { Level.Special, specialCountMines }
            };
            sizes = new Dictionary<Level, Size>()
            {
                { Level.Beginner, new Size(MinWidth, MinHeight) },
                { Level.Amateur, new Size(16, 16) },
                { Level.Professional, new Size(MaxWidth, 16) },
                { Level.Special, new Size(specialWidth, specialHeight) }
            };
        }

        public Parameters(bool isFirstMove)
        {
            InitializeComponent();

            this.isFirstMove = isFirstMove;

            Dictionary<Level, RadioButton> radioButtons = new Dictionary<Level, RadioButton>()
            {
                { Level.Beginner, radioButtonBeginner },
                { Level.Amateur, radioButtonAmateur },
                { Level.Professional, radioButtonProfessional },
                { Level.Special, radioButtonSpecial }
            };

            foreach (var key in radioButtons.Keys)
                radioButtons[key].Tag = key;

            radioButtons[Level].Checked = true;

            radioButtonBeginner.Text = $"Новичок\n{countMines[Level.Beginner]} мин\n поле {sizes[Level.Beginner].Width} x {sizes[Level.Beginner].Height} ячеек";
            radioButtonAmateur.Text = $"Любитель\n{countMines[Level.Amateur]} мин\n поле {sizes[Level.Amateur].Width} x {sizes[Level.Amateur].Height} ячеек";
            radioButtonProfessional.Text = $"Профессионал\n{countMines[Level.Professional]} мин\n поле {sizes[Level.Professional].Width} x {sizes[Level.Professional].Height} ячеек";

            numericUpDownWidth.Minimum = MinWidth;
            numericUpDownHeight.Minimum = MinHeight;
            numericUpDownCountMines.Minimum = MinCountMines;

            numericUpDownWidth.Maximum = MaxWidth;
            numericUpDownHeight.Maximum = MaxHeight;

            numericUpDownWidth.Minimum = MinWidth;
            numericUpDownHeight.Minimum = MinHeight;
            numericUpDownCountMines.Minimum = MinCountMines;

            numericUpDownWidth.Maximum = MaxWidth;
            numericUpDownHeight.Maximum = MaxHeight;

            numericUpDownHeight.Value = specialHeight;
            numericUpDownWidth.Value = specialWidth;
            numericUpDownCountMines.Value = specialCountMines;

            labelHeight.Text = $"Высота ({MinHeight}-{MaxHeight}):";
            labelWidth.Text = $"Ширина ({MinWidth}-{MaxWidth}):";
            labelCountMines.Text = $"Число мин ({MinCountMines}-{MaxCountMines(MaxWidth * MaxHeight)}):";

            checkBoxShowAnimation.Checked = IsShowAnimation;
            checkBoxPlaySounds.Checked = Sound.IsPlaySounds;
            checkBoxContinueSavedGame.Checked = IsContinueSavedGame;
            checkBoxSaveGameExiting.Checked = IsSaveGameExiting;
            checkBoxShowQuestionMarks.Checked = IsShowQuestionMarks;
        }

        //Через регрессионый анализ оригинала вычислено
        private decimal MaxCountMines(decimal countCells) => Math.Round(0.94m * countCells - 8.91m); 

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Name == radioButtonSpecial.Name)
            {
                bool enabled = radioButtonSpecial.Checked;
                numericUpDownHeight.Enabled = enabled;
                numericUpDownWidth.Enabled = enabled;
                numericUpDownCountMines.Enabled = enabled;
            }
            selectedLevel = (Level)radioButton.Tag;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCountMines.Maximum = MaxCountMines(numericUpDownWidth.Value * numericUpDownHeight.Value);
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (
                selectedLevel != Level ||
                numericUpDownWidth.Value != specialWidth ||
                numericUpDownHeight.Value != specialHeight ||
                numericUpDownCountMines.Value != specialCountMines
                )
            {
                Level = selectedLevel;

                specialWidth = (int)numericUpDownWidth.Value;
                specialHeight = (int)numericUpDownHeight.Value;
                specialCountMines = (int)numericUpDownCountMines.Value;

                sizes[Level.Special] = new Size(specialWidth, specialHeight);
                countMines[Level.Special] = specialCountMines;

                if (isFirstMove)
                {
                    UpdateData.Invoke();
                }
                else
                {
                    DialogResult dr = MessageBox.Show(
                    "Эти параметры нельзя применить к текущей игре.\n" +
                    "Новые параметры будут применены к следующей игре.\n" +
                    "Завершение игры сейчас будет защитано как поражение\n" +
                    "Завершить текущую игру и начать новую?",
                    "Изменение настроеек игры",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                    if (dr == DialogResult.Yes)
                    {
                        UpdateData.Invoke();
                        Statistics.WriteStatistics(Level, false);
                    }
                }
            }

            IsShowAnimation = checkBoxShowAnimation.Checked;
            Sound.IsPlaySounds = checkBoxPlaySounds.Checked;
            IsContinueSavedGame = checkBoxContinueSavedGame.Checked;
            IsSaveGameExiting = checkBoxSaveGameExiting.Checked;
            IsShowQuestionMarks = checkBoxShowQuestionMarks.Checked;

            Close();
        }

        public static void WriteSettings()
        {
            Settings.Default.Level = (int)Level;
            Settings.Default.IsShowAnimation = IsShowAnimation;
            Settings.Default.IsPlaySounds = Sound.IsPlaySounds;
            Settings.Default.IsContinueSavedGame = IsContinueSavedGame;
            Settings.Default.IsSaveGameExiting = IsSaveGameExiting;
            Settings.Default.IsShowQuestionMarks = IsShowQuestionMarks;
            Settings.Default.SpecialWidth = specialWidth;
            Settings.Default.SpecialHeight = specialHeight;
            Settings.Default.SpecialCountMines = specialCountMines;
        }
    }
}
