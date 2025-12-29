
namespace Minesweeper
{
    partial class FormDialogGameOver
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
            this._lblMessage = new System.Windows.Forms.Label();
            this._lblData1 = new System.Windows.Forms.Label();
            this._lblData2 = new System.Windows.Forms.Label();
            this._btnExit = new System.Windows.Forms.Button();
            this._btnNewGame = new System.Windows.Forms.Button();
            this._btnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblMessage
            // 
            this._lblMessage.AutoSize = true;
            this._lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this._lblMessage.Location = new System.Drawing.Point(0, 0);
            this._lblMessage.MaximumSize = new System.Drawing.Size(285, 57);
            this._lblMessage.MinimumSize = new System.Drawing.Size(285, 57);
            this._lblMessage.Name = "_lblMessage";
            this._lblMessage.Size = new System.Drawing.Size(285, 57);
            this._lblMessage.TabIndex = 0;
            this._lblMessage.Text = "Строка 1\nСтрока 2\nСтрока 3\nСтрока 4";
            this._lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblData1
            // 
            this._lblData1.AutoSize = true;
            this._lblData1.Location = new System.Drawing.Point(9, 64);
            this._lblData1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblData1.Name = "_lblData1";
            this._lblData1.Size = new System.Drawing.Size(131, 91);
            this._lblData1.TabIndex = 1;
            this._lblData1.Text = "Время: XXX сек.\n\nЛучшее время: XXX сек.\n\nПроведено игр: XXX\n\nВыиграно: XXX";
            // 
            // _lblData2
            // 
            this._lblData2.AutoSize = true;
            this._lblData2.Location = new System.Drawing.Point(176, 64);
            this._lblData2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblData2.Name = "_lblData2";
            this._lblData2.Size = new System.Drawing.Size(101, 65);
            this._lblData2.TabIndex = 2;
            this._lblData2.Text = "Дата: XX.XX.XXXX\n\n\n\nПроцент: XXX%";
            // 
            // _btnExit
            // 
            this._btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnExit.Location = new System.Drawing.Point(9, 168);
            this._btnExit.Margin = new System.Windows.Forms.Padding(2);
            this._btnExit.Name = "_btnExit";
            this._btnExit.Size = new System.Drawing.Size(86, 20);
            this._btnExit.TabIndex = 3;
            this._btnExit.Text = "Выход";
            this._btnExit.UseVisualStyleBackColor = true;
            this._btnExit.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // _btnNewGame
            // 
            this._btnNewGame.Location = new System.Drawing.Point(193, 168);
            this._btnNewGame.Margin = new System.Windows.Forms.Padding(2);
            this._btnNewGame.Name = "_btnNewGame";
            this._btnNewGame.Size = new System.Drawing.Size(86, 20);
            this._btnNewGame.TabIndex = 4;
            this._btnNewGame.Text = "Новая игра";
            this._btnNewGame.UseVisualStyleBackColor = true;
            this._btnNewGame.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // _btnRestart
            // 
            this._btnRestart.Location = new System.Drawing.Point(100, 168);
            this._btnRestart.Margin = new System.Windows.Forms.Padding(2);
            this._btnRestart.Name = "_btnRestart";
            this._btnRestart.Size = new System.Drawing.Size(86, 20);
            this._btnRestart.TabIndex = 5;
            this._btnRestart.Text = "Повторить";
            this._btnRestart.UseVisualStyleBackColor = true;
            this._btnRestart.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // FormDialogGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnExit;
            this.ClientSize = new System.Drawing.Size(288, 197);
            this.Controls.Add(this._btnRestart);
            this.Controls.Add(this._btnNewGame);
            this.Controls.Add(this._btnExit);
            this.Controls.Add(this._lblData2);
            this.Controls.Add(this._lblData1);
            this.Controls.Add(this._lblMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialogGameOver";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDialogGameOver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblMessage;
        private System.Windows.Forms.Label _lblData1;
        private System.Windows.Forms.Label _lblData2;
        private System.Windows.Forms.Button _btnExit;
        private System.Windows.Forms.Button _btnNewGame;
        private System.Windows.Forms.Button _btnRestart;
    }
}