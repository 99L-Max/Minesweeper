
namespace Minesweeper
{
    partial class FormDesign
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
            this._chbRandomTheme = new System.Windows.Forms.CheckBox();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._pb0 = new System.Windows.Forms.PictureBox();
            this._pb1 = new System.Windows.Forms.PictureBox();
            this._pb2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._pb0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb2)).BeginInit();
            this.SuspendLayout();
            // 
            // _chbRandomTheme
            // 
            this._chbRandomTheme.AutoSize = true;
            this._chbRandomTheme.Location = new System.Drawing.Point(12, 123);
            this._chbRandomTheme.Name = "_chbRandomTheme";
            this._chbRandomTheme.Size = new System.Drawing.Size(173, 19);
            this._chbRandomTheme.TabIndex = 5;
            this._chbRandomTheme.Text = "Выбрать случайный цвет";
            this._chbRandomTheme.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(83, 148);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(83, 23);
            this._btnOK.TabIndex = 6;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.OnOKClick);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(172, 148);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(83, 23);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Отмена";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _pb0
            // 
            this._pb0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._pb0.Location = new System.Drawing.Point(12, 12);
            this._pb0.Name = "_pb0";
            this._pb0.Size = new System.Drawing.Size(100, 100);
            this._pb0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pb0.TabIndex = 8;
            this._pb0.TabStop = false;
            this._pb0.Tag = 0;
            this._pb0.Click += new System.EventHandler(this.OnThemeClick);
            // 
            // _pb1
            // 
            this._pb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._pb1.Location = new System.Drawing.Point(118, 12);
            this._pb1.Name = "_pb1";
            this._pb1.Size = new System.Drawing.Size(100, 100);
            this._pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pb1.TabIndex = 9;
            this._pb1.TabStop = false;
            this._pb1.Tag = 1;
            this._pb1.Click += new System.EventHandler(this.OnThemeClick);
            // 
            // _pb2
            // 
            this._pb2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._pb2.Location = new System.Drawing.Point(225, 12);
            this._pb2.Name = "_pb2";
            this._pb2.Size = new System.Drawing.Size(100, 100);
            this._pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pb2.TabIndex = 10;
            this._pb2.TabStop = false;
            this._pb2.Tag = 2;
            this._pb2.Click += new System.EventHandler(this.OnThemeClick);
            // 
            // FormDesign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(337, 181);
            this.Controls.Add(this._pb2);
            this.Controls.Add(this._pb1);
            this.Controls.Add(this._pb0);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._chbRandomTheme);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDesign";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменение оформления";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._pb0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pb2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox _chbRandomTheme;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.PictureBox _pb0;
        private System.Windows.Forms.PictureBox _pb1;
        private System.Windows.Forms.PictureBox _pb2;
    }
}