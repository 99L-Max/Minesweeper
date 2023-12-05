
namespace Minesweeper
{
    partial class FormDialogNewGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonNewGame = new System.Windows.Forms.RadioButton();
            this.radioButtonRestart = new System.Windows.Forms.RadioButton();
            this.radioButtonContinueGame = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущая игра не закончена.\nЧто нужно сделать?";
            // 
            // radioButtonNewGame
            // 
            this.radioButtonNewGame.AutoSize = true;
            this.radioButtonNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonNewGame.Location = new System.Drawing.Point(12, 44);
            this.radioButtonNewGame.MaximumSize = new System.Drawing.Size(380, 100);
            this.radioButtonNewGame.Name = "radioButtonNewGame";
            this.radioButtonNewGame.Size = new System.Drawing.Size(247, 52);
            this.radioButtonNewGame.TabIndex = 1;
            this.radioButtonNewGame.TabStop = true;
            this.radioButtonNewGame.Text = "Закрыть и начать новую игру.\nВ статистике это будет защитано\nкак поражение.";
            this.radioButtonNewGame.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestart
            // 
            this.radioButtonRestart.AutoSize = true;
            this.radioButtonRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonRestart.Location = new System.Drawing.Point(12, 102);
            this.radioButtonRestart.MaximumSize = new System.Drawing.Size(380, 100);
            this.radioButtonRestart.Name = "radioButtonRestart";
            this.radioButtonRestart.Size = new System.Drawing.Size(247, 52);
            this.radioButtonRestart.TabIndex = 2;
            this.radioButtonRestart.TabStop = true;
            this.radioButtonRestart.Text = "Перезапустить текущую игру.\nВ статистике это будет защитано\nкак поражение.";
            this.radioButtonRestart.UseVisualStyleBackColor = true;
            // 
            // radioButtonContinueGame
            // 
            this.radioButtonContinueGame.AutoSize = true;
            this.radioButtonContinueGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonContinueGame.Location = new System.Drawing.Point(12, 176);
            this.radioButtonContinueGame.MaximumSize = new System.Drawing.Size(380, 100);
            this.radioButtonContinueGame.Name = "radioButtonContinueGame";
            this.radioButtonContinueGame.Size = new System.Drawing.Size(140, 20);
            this.radioButtonContinueGame.TabIndex = 3;
            this.radioButtonContinueGame.TabStop = true;
            this.radioButtonContinueGame.Text = "Продолжить игру";
            this.radioButtonContinueGame.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonOK.Location = new System.Drawing.Point(104, 223);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(105, 26);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // FormDialogNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 261);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioButtonContinueGame);
            this.Controls.Add(this.radioButtonRestart);
            this.Controls.Add(this.radioButtonNewGame);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialogNewGame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новая игра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonNewGame;
        private System.Windows.Forms.RadioButton radioButtonRestart;
        private System.Windows.Forms.RadioButton radioButtonContinueGame;
        private System.Windows.Forms.Button buttonOK;
    }
}