
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
            this._lbl1 = new System.Windows.Forms.Label();
            this._rbNewGame = new System.Windows.Forms.RadioButton();
            this._rbRestart = new System.Windows.Forms.RadioButton();
            this._rbContinueGame = new System.Windows.Forms.RadioButton();
            this._btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this._lbl1.AutoSize = true;
            this._lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lbl1.Location = new System.Drawing.Point(66, 9);
            this._lbl1.Name = "label1";
            this._lbl1.Size = new System.Drawing.Size(193, 32);
            this._lbl1.TabIndex = 0;
            this._lbl1.Text = "Текущая игра не закончена.\nЧто нужно сделать?";
            // 
            // radioButtonNewGame
            // 
            this._rbNewGame.AutoSize = true;
            this._rbNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._rbNewGame.Location = new System.Drawing.Point(12, 44);
            this._rbNewGame.MaximumSize = new System.Drawing.Size(380, 100);
            this._rbNewGame.Name = "radioButtonNewGame";
            this._rbNewGame.Size = new System.Drawing.Size(247, 52);
            this._rbNewGame.TabIndex = 1;
            this._rbNewGame.TabStop = true;
            this._rbNewGame.Text = "Закрыть и начать новую игру.\nВ статистике это будет защитано\nкак поражение.";
            this._rbNewGame.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestart
            // 
            this._rbRestart.AutoSize = true;
            this._rbRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._rbRestart.Location = new System.Drawing.Point(12, 102);
            this._rbRestart.MaximumSize = new System.Drawing.Size(380, 100);
            this._rbRestart.Name = "radioButtonRestart";
            this._rbRestart.Size = new System.Drawing.Size(247, 52);
            this._rbRestart.TabIndex = 2;
            this._rbRestart.TabStop = true;
            this._rbRestart.Text = "Перезапустить текущую игру.\nВ статистике это будет защитано\nкак поражение.";
            this._rbRestart.UseVisualStyleBackColor = true;
            // 
            // radioButtonContinueGame
            // 
            this._rbContinueGame.AutoSize = true;
            this._rbContinueGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._rbContinueGame.Location = new System.Drawing.Point(12, 176);
            this._rbContinueGame.MaximumSize = new System.Drawing.Size(380, 100);
            this._rbContinueGame.Name = "radioButtonContinueGame";
            this._rbContinueGame.Size = new System.Drawing.Size(140, 20);
            this._rbContinueGame.TabIndex = 3;
            this._rbContinueGame.TabStop = true;
            this._rbContinueGame.Text = "Продолжить игру";
            this._rbContinueGame.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this._btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this._btnOK.Location = new System.Drawing.Point(104, 223);
            this._btnOK.Name = "buttonOK";
            this._btnOK.Size = new System.Drawing.Size(105, 26);
            this._btnOK.TabIndex = 4;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.OnOKClick);
            // 
            // FormDialogNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 261);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._rbContinueGame);
            this.Controls.Add(this._rbRestart);
            this.Controls.Add(this._rbNewGame);
            this.Controls.Add(this._lbl1);
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

        private System.Windows.Forms.Label _lbl1;
        private System.Windows.Forms.RadioButton _rbNewGame;
        private System.Windows.Forms.RadioButton _rbRestart;
        private System.Windows.Forms.RadioButton _rbContinueGame;
        private System.Windows.Forms.Button _btnOK;
    }
}