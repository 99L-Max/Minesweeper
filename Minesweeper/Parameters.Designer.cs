
namespace Minesweeper
{
    partial class Parameters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.numericUpDownCountMines = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelCountMines = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.radioButtonSpecial = new System.Windows.Forms.RadioButton();
            this.radioButtonProfessional = new System.Windows.Forms.RadioButton();
            this.radioButtonAmateur = new System.Windows.Forms.RadioButton();
            this.radioButtonBeginner = new System.Windows.Forms.RadioButton();
            this.checkBoxShowAnimation = new System.Windows.Forms.CheckBox();
            this.checkBoxPlaySounds = new System.Windows.Forms.CheckBox();
            this.checkBoxContinueSavedGame = new System.Windows.Forms.CheckBox();
            this.checkBoxShowQuestionMarks = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveGameExiting = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountMines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.numericUpDownCountMines);
            this.groupBox.Controls.Add(this.numericUpDownWidth);
            this.groupBox.Controls.Add(this.numericUpDownHeight);
            this.groupBox.Controls.Add(this.labelCountMines);
            this.groupBox.Controls.Add(this.labelWidth);
            this.groupBox.Controls.Add(this.labelHeight);
            this.groupBox.Controls.Add(this.radioButtonSpecial);
            this.groupBox.Controls.Add(this.radioButtonProfessional);
            this.groupBox.Controls.Add(this.radioButtonAmateur);
            this.groupBox.Controls.Add(this.radioButtonBeginner);
            this.groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox.Location = new System.Drawing.Point(14, 14);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(402, 218);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Уровень";
            // 
            // numericUpDownCountMines
            // 
            this.numericUpDownCountMines.Enabled = false;
            this.numericUpDownCountMines.Location = new System.Drawing.Point(317, 148);
            this.numericUpDownCountMines.Name = "numericUpDownCountMines";
            this.numericUpDownCountMines.Size = new System.Drawing.Size(73, 21);
            this.numericUpDownCountMines.TabIndex = 9;
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Enabled = false;
            this.numericUpDownWidth.Location = new System.Drawing.Point(317, 104);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(73, 21);
            this.numericUpDownWidth.TabIndex = 8;
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Enabled = false;
            this.numericUpDownHeight.Location = new System.Drawing.Point(317, 60);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(73, 21);
            this.numericUpDownHeight.TabIndex = 7;
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // labelCountMines
            // 
            this.labelCountMines.AutoSize = true;
            this.labelCountMines.Location = new System.Drawing.Point(167, 150);
            this.labelCountMines.Name = "labelCountMines";
            this.labelCountMines.Size = new System.Drawing.Size(110, 15);
            this.labelCountMines.TabIndex = 6;
            this.labelCountMines.Text = "Число мин (xx-xx):";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(167, 106);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(95, 15);
            this.labelWidth.TabIndex = 5;
            this.labelWidth.Text = "Ширина (xx-xx):";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(167, 62);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(93, 15);
            this.labelHeight.TabIndex = 4;
            this.labelHeight.Text = "Высота (xx-xx):";
            // 
            // radioButtonSpecial
            // 
            this.radioButtonSpecial.AutoSize = true;
            this.radioButtonSpecial.Location = new System.Drawing.Point(159, 23);
            this.radioButtonSpecial.Name = "radioButtonSpecial";
            this.radioButtonSpecial.Size = new System.Drawing.Size(70, 19);
            this.radioButtonSpecial.TabIndex = 3;
            this.radioButtonSpecial.TabStop = true;
            this.radioButtonSpecial.Text = "Особый";
            this.radioButtonSpecial.UseVisualStyleBackColor = true;
            this.radioButtonSpecial.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonProfessional
            // 
            this.radioButtonProfessional.AutoSize = true;
            this.radioButtonProfessional.Location = new System.Drawing.Point(7, 150);
            this.radioButtonProfessional.Name = "radioButtonProfessional";
            this.radioButtonProfessional.Size = new System.Drawing.Size(101, 49);
            this.radioButtonProfessional.TabIndex = 2;
            this.radioButtonProfessional.TabStop = true;
            this.radioButtonProfessional.Text = "Уровень\n00 мин\n00 x 00 ячеек";
            this.radioButtonProfessional.UseVisualStyleBackColor = true;
            this.radioButtonProfessional.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonAmateur
            // 
            this.radioButtonAmateur.AutoSize = true;
            this.radioButtonAmateur.Location = new System.Drawing.Point(7, 87);
            this.radioButtonAmateur.Name = "radioButtonAmateur";
            this.radioButtonAmateur.Size = new System.Drawing.Size(101, 49);
            this.radioButtonAmateur.TabIndex = 1;
            this.radioButtonAmateur.TabStop = true;
            this.radioButtonAmateur.Text = "Уровень\n00 мин\n00 x 00 ячеек";
            this.radioButtonAmateur.UseVisualStyleBackColor = true;
            this.radioButtonAmateur.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonBeginner
            // 
            this.radioButtonBeginner.AutoSize = true;
            this.radioButtonBeginner.Location = new System.Drawing.Point(7, 23);
            this.radioButtonBeginner.Name = "radioButtonBeginner";
            this.radioButtonBeginner.Size = new System.Drawing.Size(101, 49);
            this.radioButtonBeginner.TabIndex = 0;
            this.radioButtonBeginner.TabStop = true;
            this.radioButtonBeginner.Text = "Уровень\n00 мин\n00 x 00 ячеек";
            this.radioButtonBeginner.UseVisualStyleBackColor = true;
            this.radioButtonBeginner.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // checkBoxShowAnimation
            // 
            this.checkBoxShowAnimation.AutoSize = true;
            this.checkBoxShowAnimation.Location = new System.Drawing.Point(14, 239);
            this.checkBoxShowAnimation.MaximumSize = new System.Drawing.Size(400, 50);
            this.checkBoxShowAnimation.Name = "checkBoxShowAnimation";
            this.checkBoxShowAnimation.Size = new System.Drawing.Size(186, 19);
            this.checkBoxShowAnimation.TabIndex = 1;
            this.checkBoxShowAnimation.Text = "Воспроизводить анимацию";
            this.checkBoxShowAnimation.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlaySounds
            // 
            this.checkBoxPlaySounds.AutoSize = true;
            this.checkBoxPlaySounds.Location = new System.Drawing.Point(14, 264);
            this.checkBoxPlaySounds.MaximumSize = new System.Drawing.Size(400, 50);
            this.checkBoxPlaySounds.Name = "checkBoxPlaySounds";
            this.checkBoxPlaySounds.Size = new System.Drawing.Size(175, 19);
            this.checkBoxPlaySounds.TabIndex = 2;
            this.checkBoxPlaySounds.Text = "Звуковое сопровождение";
            this.checkBoxPlaySounds.UseVisualStyleBackColor = true;
            // 
            // checkBoxContinueSavedGame
            // 
            this.checkBoxContinueSavedGame.AutoSize = true;
            this.checkBoxContinueSavedGame.Location = new System.Drawing.Point(14, 289);
            this.checkBoxContinueSavedGame.MaximumSize = new System.Drawing.Size(400, 50);
            this.checkBoxContinueSavedGame.Name = "checkBoxContinueSavedGame";
            this.checkBoxContinueSavedGame.Size = new System.Drawing.Size(246, 19);
            this.checkBoxContinueSavedGame.TabIndex = 4;
            this.checkBoxContinueSavedGame.Text = "Всегда продолжать сохранённую игру";
            this.checkBoxContinueSavedGame.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowQuestionMarks
            // 
            this.checkBoxShowQuestionMarks.AutoSize = true;
            this.checkBoxShowQuestionMarks.Location = new System.Drawing.Point(14, 339);
            this.checkBoxShowQuestionMarks.MaximumSize = new System.Drawing.Size(400, 50);
            this.checkBoxShowQuestionMarks.MinimumSize = new System.Drawing.Size(0, 35);
            this.checkBoxShowQuestionMarks.Name = "checkBoxShowQuestionMarks";
            this.checkBoxShowQuestionMarks.Size = new System.Drawing.Size(400, 35);
            this.checkBoxShowQuestionMarks.TabIndex = 6;
            this.checkBoxShowQuestionMarks.Text = "Показывать знаки вопроса (двойной щелчок правой кнопкой мыши)";
            this.checkBoxShowQuestionMarks.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveGameExiting
            // 
            this.checkBoxSaveGameExiting.AutoSize = true;
            this.checkBoxSaveGameExiting.Location = new System.Drawing.Point(14, 314);
            this.checkBoxSaveGameExiting.MaximumSize = new System.Drawing.Size(400, 50);
            this.checkBoxSaveGameExiting.Name = "checkBoxSaveGameExiting";
            this.checkBoxSaveGameExiting.Size = new System.Drawing.Size(227, 19);
            this.checkBoxSaveGameExiting.TabIndex = 5;
            this.checkBoxSaveGameExiting.Text = "Всегда сохранять игру при выходе";
            this.checkBoxSaveGameExiting.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(304, 380);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(186, 380);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(112, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // Parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(430, 414);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxShowQuestionMarks);
            this.Controls.Add(this.checkBoxSaveGameExiting);
            this.Controls.Add(this.checkBoxContinueSavedGame);
            this.Controls.Add(this.checkBoxPlaySounds);
            this.Controls.Add(this.checkBoxShowAnimation);
            this.Controls.Add(this.groupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Parameters";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCountMines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton radioButtonBeginner;
        private System.Windows.Forms.RadioButton radioButtonProfessional;
        private System.Windows.Forms.RadioButton radioButtonAmateur;
        private System.Windows.Forms.RadioButton radioButtonSpecial;
        private System.Windows.Forms.Label labelCountMines;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownCountMines;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.CheckBox checkBoxShowAnimation;
        private System.Windows.Forms.CheckBox checkBoxPlaySounds;
        private System.Windows.Forms.CheckBox checkBoxContinueSavedGame;
        private System.Windows.Forms.CheckBox checkBoxShowQuestionMarks;
        private System.Windows.Forms.CheckBox checkBoxSaveGameExiting;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}