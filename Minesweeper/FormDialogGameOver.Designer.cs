
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.labelData1 = new System.Windows.Forms.Label();
            this.labelData2 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMessage.Location = new System.Drawing.Point(0, 0);
            this.labelMessage.MaximumSize = new System.Drawing.Size(285, 57);
            this.labelMessage.MinimumSize = new System.Drawing.Size(285, 57);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(285, 57);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Строка 1\nСтрока 2\nСтрока 3\nСтрока 4";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelData1
            // 
            this.labelData1.AutoSize = true;
            this.labelData1.Location = new System.Drawing.Point(9, 64);
            this.labelData1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelData1.Name = "labelData1";
            this.labelData1.Size = new System.Drawing.Size(131, 91);
            this.labelData1.TabIndex = 1;
            this.labelData1.Text = "Время: XXX сек.\n\nЛучшее время: XXX сек.\n\nПроведено игр: XXX\n\nВыиграно: XXX";
            // 
            // labelData2
            // 
            this.labelData2.AutoSize = true;
            this.labelData2.Location = new System.Drawing.Point(166, 64);
            this.labelData2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelData2.Name = "labelData2";
            this.labelData2.Size = new System.Drawing.Size(101, 65);
            this.labelData2.TabIndex = 2;
            this.labelData2.Text = "Дата: XX.XX.XXXX\n\n\n\nПроцент: XXX%";
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(9, 168);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(86, 20);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(193, 168);
            this.buttonNewGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(86, 20);
            this.buttonNewGame.TabIndex = 4;
            this.buttonNewGame.Text = "Новая игра";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(100, 168);
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(86, 20);
            this.buttonRestart.TabIndex = 5;
            this.buttonRestart.Text = "Повторить";
            this.buttonRestart.UseVisualStyleBackColor = true;
            // 
            // FormDialogGameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(288, 197);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelData2);
            this.Controls.Add(this.labelData1);
            this.Controls.Add(this.labelMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialogGameOver";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDialogGameOver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label labelData1;
        private System.Windows.Forms.Label labelData2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonRestart;
    }
}