
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
            this._flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // _chbRandomTheme
            // 
            this._chbRandomTheme.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._chbRandomTheme.AutoSize = true;
            this._chbRandomTheme.Location = new System.Drawing.Point(12, 142);
            this._chbRandomTheme.Name = "_chbRandomTheme";
            this._chbRandomTheme.Size = new System.Drawing.Size(173, 19);
            this._chbRandomTheme.TabIndex = 5;
            this._chbRandomTheme.Text = "Выбрать случайный цвет";
            this._chbRandomTheme.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnOK.Location = new System.Drawing.Point(83, 167);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(83, 23);
            this._btnOK.TabIndex = 6;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.OnOKClick);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(172, 167);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(83, 23);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Отмена";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _flowLayoutPanel
            // 
            this._flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._flowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this._flowLayoutPanel.Name = "_flowLayoutPanel";
            this._flowLayoutPanel.Size = new System.Drawing.Size(313, 119);
            this._flowLayoutPanel.TabIndex = 11;
            this._flowLayoutPanel.WrapContents = false;
            // 
            // FormDesign
            // 
            this.AcceptButton = this._btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(337, 198);
            this.Controls.Add(this._flowLayoutPanel);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox _chbRandomTheme;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanel;
    }
}