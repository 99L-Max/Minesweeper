
namespace Minesweeper
{
    partial class FormSettings
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
            this._gb = new System.Windows.Forms.GroupBox();
            this._numSpecialCountMines = new System.Windows.Forms.NumericUpDown();
            this._numSpecialWidth = new System.Windows.Forms.NumericUpDown();
            this._numSpecialHeight = new System.Windows.Forms.NumericUpDown();
            this._lblCountMines = new System.Windows.Forms.Label();
            this._lblWidth = new System.Windows.Forms.Label();
            this._lblHeight = new System.Windows.Forms.Label();
            this._rbSpecial = new System.Windows.Forms.RadioButton();
            this._rbHard = new System.Windows.Forms.RadioButton();
            this._rbMedium = new System.Windows.Forms.RadioButton();
            this._rbEasy = new System.Windows.Forms.RadioButton();
            this._chbShowAnimation = new System.Windows.Forms.CheckBox();
            this._chbPlaySounds = new System.Windows.Forms.CheckBox();
            this._chbContinueSavedGame = new System.Windows.Forms.CheckBox();
            this._chbShowQuestionMarks = new System.Windows.Forms.CheckBox();
            this._chbSaveGameExiting = new System.Windows.Forms.CheckBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialCountMines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // _gb
            // 
            this._gb.Controls.Add(this._numSpecialCountMines);
            this._gb.Controls.Add(this._numSpecialWidth);
            this._gb.Controls.Add(this._numSpecialHeight);
            this._gb.Controls.Add(this._lblCountMines);
            this._gb.Controls.Add(this._lblWidth);
            this._gb.Controls.Add(this._lblHeight);
            this._gb.Controls.Add(this._rbSpecial);
            this._gb.Controls.Add(this._rbHard);
            this._gb.Controls.Add(this._rbMedium);
            this._gb.Controls.Add(this._rbEasy);
            this._gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._gb.Location = new System.Drawing.Point(14, 14);
            this._gb.Name = "_gb";
            this._gb.Size = new System.Drawing.Size(402, 218);
            this._gb.TabIndex = 0;
            this._gb.TabStop = false;
            this._gb.Text = "Уровень";
            // 
            // _numCountMines
            // 
            this._numSpecialCountMines.Enabled = false;
            this._numSpecialCountMines.Location = new System.Drawing.Point(317, 148);
            this._numSpecialCountMines.Name = "_numCountMines";
            this._numSpecialCountMines.Size = new System.Drawing.Size(73, 21);
            this._numSpecialCountMines.TabIndex = 9;
            // 
            // _numWidth
            // 
            this._numSpecialWidth.Enabled = false;
            this._numSpecialWidth.Location = new System.Drawing.Point(317, 104);
            this._numSpecialWidth.Name = "_numWidth";
            this._numSpecialWidth.Size = new System.Drawing.Size(73, 21);
            this._numSpecialWidth.TabIndex = 8;
            this._numSpecialWidth.ValueChanged += new System.EventHandler(this.OnSpecialSizeChanged);
            // 
            // _numHeight
            // 
            this._numSpecialHeight.Enabled = false;
            this._numSpecialHeight.Location = new System.Drawing.Point(317, 60);
            this._numSpecialHeight.Name = "_numHeight";
            this._numSpecialHeight.Size = new System.Drawing.Size(73, 21);
            this._numSpecialHeight.TabIndex = 7;
            this._numSpecialHeight.ValueChanged += new System.EventHandler(this.OnSpecialSizeChanged);
            // 
            // _lblCountMines
            // 
            this._lblCountMines.AutoSize = true;
            this._lblCountMines.Location = new System.Drawing.Point(167, 150);
            this._lblCountMines.Name = "_lblCountMines";
            this._lblCountMines.Size = new System.Drawing.Size(110, 15);
            this._lblCountMines.TabIndex = 6;
            this._lblCountMines.Text = "Число мин (xx-xx):";
            // 
            // _lblWidth
            // 
            this._lblWidth.AutoSize = true;
            this._lblWidth.Location = new System.Drawing.Point(167, 106);
            this._lblWidth.Name = "_lblWidth";
            this._lblWidth.Size = new System.Drawing.Size(95, 15);
            this._lblWidth.TabIndex = 5;
            this._lblWidth.Text = "Ширина (xx-xx):";
            // 
            // _lblHeight
            // 
            this._lblHeight.AutoSize = true;
            this._lblHeight.Location = new System.Drawing.Point(167, 62);
            this._lblHeight.Name = "_lblHeight";
            this._lblHeight.Size = new System.Drawing.Size(93, 15);
            this._lblHeight.TabIndex = 4;
            this._lblHeight.Text = "Высота (xx-xx):";
            // 
            // _rbSpecial
            // 
            this._rbSpecial.AutoSize = true;
            this._rbSpecial.Location = new System.Drawing.Point(159, 23);
            this._rbSpecial.Name = "_rbSpecial";
            this._rbSpecial.Size = new System.Drawing.Size(70, 19);
            this._rbSpecial.TabIndex = 3;
            this._rbSpecial.TabStop = true;
            this._rbSpecial.Text = "Особый";
            this._rbSpecial.UseVisualStyleBackColor = true;
            this._rbSpecial.CheckedChanged += new System.EventHandler(this.OnLevelChanged);
            // 
            // _rbProfessional
            // 
            this._rbHard.AutoSize = true;
            this._rbHard.Location = new System.Drawing.Point(7, 150);
            this._rbHard.Name = "_rbProfessional";
            this._rbHard.Size = new System.Drawing.Size(101, 49);
            this._rbHard.TabIndex = 2;
            this._rbHard.TabStop = true;
            this._rbHard.Text = "Уровень\n00 мин\n00 x 00 ячеек";
            this._rbHard.UseVisualStyleBackColor = true;
            this._rbHard.CheckedChanged += new System.EventHandler(this.OnLevelChanged);
            // 
            // _rbAmateur
            // 
            this._rbMedium.AutoSize = true;
            this._rbMedium.Location = new System.Drawing.Point(7, 87);
            this._rbMedium.Name = "_rbAmateur";
            this._rbMedium.Size = new System.Drawing.Size(101, 49);
            this._rbMedium.TabIndex = 1;
            this._rbMedium.TabStop = true;
            this._rbMedium.Text = "Уровень\n00 мин\n00 x 00 ячеек";
            this._rbMedium.UseVisualStyleBackColor = true;
            this._rbMedium.CheckedChanged += new System.EventHandler(this.OnLevelChanged);
            // 
            // _rbBeginner
            // 
            this._rbEasy.AutoSize = true;
            this._rbEasy.Location = new System.Drawing.Point(7, 23);
            this._rbEasy.Name = "_rbBeginner";
            this._rbEasy.Size = new System.Drawing.Size(101, 49);
            this._rbEasy.TabIndex = 0;
            this._rbEasy.TabStop = true;
            this._rbEasy.Text = "Уровень\n00 мин\n00 x 00 ячеек";
            this._rbEasy.UseVisualStyleBackColor = true;
            this._rbEasy.CheckedChanged += new System.EventHandler(this.OnLevelChanged);
            // 
            // _chbShowAnimation
            // 
            this._chbShowAnimation.AutoSize = true;
            this._chbShowAnimation.Location = new System.Drawing.Point(14, 239);
            this._chbShowAnimation.MaximumSize = new System.Drawing.Size(400, 50);
            this._chbShowAnimation.Name = "_chbShowAnimation";
            this._chbShowAnimation.Size = new System.Drawing.Size(186, 19);
            this._chbShowAnimation.TabIndex = 1;
            this._chbShowAnimation.Text = "Воспроизводить анимацию";
            this._chbShowAnimation.UseVisualStyleBackColor = true;
            // 
            // _chbPlaySounds
            // 
            this._chbPlaySounds.AutoSize = true;
            this._chbPlaySounds.Location = new System.Drawing.Point(14, 264);
            this._chbPlaySounds.MaximumSize = new System.Drawing.Size(400, 50);
            this._chbPlaySounds.Name = "_chbPlaySounds";
            this._chbPlaySounds.Size = new System.Drawing.Size(175, 19);
            this._chbPlaySounds.TabIndex = 2;
            this._chbPlaySounds.Text = "Звуковое сопровождение";
            this._chbPlaySounds.UseVisualStyleBackColor = true;
            // 
            // _chbContinueSavedGame
            // 
            this._chbContinueSavedGame.AutoSize = true;
            this._chbContinueSavedGame.Location = new System.Drawing.Point(14, 289);
            this._chbContinueSavedGame.MaximumSize = new System.Drawing.Size(400, 50);
            this._chbContinueSavedGame.Name = "_chbContinueSavedGame";
            this._chbContinueSavedGame.Size = new System.Drawing.Size(246, 19);
            this._chbContinueSavedGame.TabIndex = 4;
            this._chbContinueSavedGame.Text = "Всегда продолжать сохранённую игру";
            this._chbContinueSavedGame.UseVisualStyleBackColor = true;
            // 
            // _chbShowQuestionMarks
            // 
            this._chbShowQuestionMarks.AutoSize = true;
            this._chbShowQuestionMarks.Location = new System.Drawing.Point(14, 339);
            this._chbShowQuestionMarks.MaximumSize = new System.Drawing.Size(400, 50);
            this._chbShowQuestionMarks.MinimumSize = new System.Drawing.Size(0, 35);
            this._chbShowQuestionMarks.Name = "_chbShowQuestionMarks";
            this._chbShowQuestionMarks.Size = new System.Drawing.Size(400, 35);
            this._chbShowQuestionMarks.TabIndex = 6;
            this._chbShowQuestionMarks.Text = "Показывать знаки вопроса (двойной щелчок правой кнопкой мыши)";
            this._chbShowQuestionMarks.UseVisualStyleBackColor = true;
            // 
            // _chbSaveGameExiting
            // 
            this._chbSaveGameExiting.AutoSize = true;
            this._chbSaveGameExiting.Location = new System.Drawing.Point(14, 314);
            this._chbSaveGameExiting.MaximumSize = new System.Drawing.Size(400, 50);
            this._chbSaveGameExiting.Name = "_chbSaveGameExiting";
            this._chbSaveGameExiting.Size = new System.Drawing.Size(227, 19);
            this._chbSaveGameExiting.TabIndex = 5;
            this._chbSaveGameExiting.Text = "Всегда сохранять игру при выходе";
            this._chbSaveGameExiting.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(304, 380);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(112, 23);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Отмена";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(186, 380);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(112, 23);
            this._btnOK.TabIndex = 8;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.OnOKClick);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 414);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._chbShowQuestionMarks);
            this.Controls.Add(this._chbSaveGameExiting);
            this.Controls.Add(this._chbContinueSavedGame);
            this.Controls.Add(this._chbPlaySounds);
            this.Controls.Add(this._chbShowAnimation);
            this.Controls.Add(this._gb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры";
            this._gb.ResumeLayout(false);
            this._gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialCountMines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _gb;
        private System.Windows.Forms.RadioButton _rbEasy;
        private System.Windows.Forms.RadioButton _rbHard;
        private System.Windows.Forms.RadioButton _rbMedium;
        private System.Windows.Forms.RadioButton _rbSpecial;
        private System.Windows.Forms.Label _lblCountMines;
        private System.Windows.Forms.Label _lblWidth;
        private System.Windows.Forms.Label _lblHeight;
        private System.Windows.Forms.NumericUpDown _numSpecialCountMines;
        private System.Windows.Forms.NumericUpDown _numSpecialWidth;
        private System.Windows.Forms.NumericUpDown _numSpecialHeight;
        private System.Windows.Forms.CheckBox _chbShowAnimation;
        private System.Windows.Forms.CheckBox _chbPlaySounds;
        private System.Windows.Forms.CheckBox _chbContinueSavedGame;
        private System.Windows.Forms.CheckBox _chbShowQuestionMarks;
        private System.Windows.Forms.CheckBox _chbSaveGameExiting;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
    }
}