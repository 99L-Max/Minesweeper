
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
            this._pb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this._pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pb.Location = new System.Drawing.Point(0, 0);
            this._pb.Name = "pictureBox";
            this._pb.Size = new System.Drawing.Size(902, 656);
            this._pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pb.TabIndex = 0;
            this._pb.TabStop = false;
            // 
            // Reference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 656);
            this.Controls.Add(this._pb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reference";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            ((System.ComponentModel.ISupportInitialize)(this._pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pb;
    }
}