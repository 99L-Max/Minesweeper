
namespace Minesweeper
{
    partial class FormReference
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
            this._labelUserName = new System.Windows.Forms.Label();
            this._pictureBoxSignature = new System.Windows.Forms.PictureBox();
            this._labelYear = new System.Windows.Forms.Label();
            this._labelDay = new System.Windows.Forms.Label();
            this._labelMonth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxSignature)).BeginInit();
            this.SuspendLayout();
            // 
            // _labelUserName
            // 
            this._labelUserName.AutoSize = true;
            this._labelUserName.BackColor = System.Drawing.Color.Transparent;
            this._labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._labelUserName.ForeColor = System.Drawing.Color.DarkBlue;
            this._labelUserName.Location = new System.Drawing.Point(228, 231);
            this._labelUserName.MinimumSize = new System.Drawing.Size(500, 35);
            this._labelUserName.Name = "_labelUserName";
            this._labelUserName.Size = new System.Drawing.Size(500, 35);
            this._labelUserName.TabIndex = 0;
            this._labelUserName.Text = "UserName";
            this._labelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pictureBoxSignature
            // 
            this._pictureBoxSignature.BackColor = System.Drawing.Color.Transparent;
            this._pictureBoxSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._pictureBoxSignature.Image = global::Minesweeper.Properties.Resources.Smile;
            this._pictureBoxSignature.Location = new System.Drawing.Point(700, 461);
            this._pictureBoxSignature.Name = "_pictureBoxSignature";
            this._pictureBoxSignature.Size = new System.Drawing.Size(100, 100);
            this._pictureBoxSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pictureBoxSignature.TabIndex = 1;
            this._pictureBoxSignature.TabStop = false;
            // 
            // _labelYear
            // 
            this._labelYear.AutoSize = true;
            this._labelYear.BackColor = System.Drawing.Color.Transparent;
            this._labelYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._labelYear.ForeColor = System.Drawing.Color.DarkBlue;
            this._labelYear.Location = new System.Drawing.Point(314, 538);
            this._labelYear.Name = "_labelYear";
            this._labelYear.Size = new System.Drawing.Size(39, 29);
            this._labelYear.TabIndex = 2;
            this._labelYear.Text = "99";
            this._labelYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _labelDay
            // 
            this._labelDay.AutoSize = true;
            this._labelDay.BackColor = System.Drawing.Color.Transparent;
            this._labelDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._labelDay.ForeColor = System.Drawing.Color.DarkBlue;
            this._labelDay.Location = new System.Drawing.Point(92, 540);
            this._labelDay.Name = "_labelDay";
            this._labelDay.Size = new System.Drawing.Size(39, 29);
            this._labelDay.TabIndex = 3;
            this._labelDay.Text = "99";
            this._labelDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _labelMonth
            // 
            this._labelMonth.AutoSize = true;
            this._labelMonth.BackColor = System.Drawing.Color.Transparent;
            this._labelMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._labelMonth.ForeColor = System.Drawing.Color.DarkBlue;
            this._labelMonth.Location = new System.Drawing.Point(173, 538);
            this._labelMonth.Name = "_labelMonth";
            this._labelMonth.Size = new System.Drawing.Size(86, 29);
            this._labelMonth.TabIndex = 4;
            this._labelMonth.Text = "месяц";
            this._labelMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minesweeper.Properties.Resources.Reference;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(902, 656);
            this.Controls.Add(this._labelMonth);
            this.Controls.Add(this._labelDay);
            this.Controls.Add(this._labelYear);
            this.Controls.Add(this._pictureBoxSignature);
            this.Controls.Add(this._labelUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReference";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxSignature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _labelUserName;
        private System.Windows.Forms.PictureBox _pictureBoxSignature;
        private System.Windows.Forms.Label _labelYear;
        private System.Windows.Forms.Label _labelDay;
        private System.Windows.Forms.Label _labelMonth;
    }
}