
namespace Minesweeper
{
    partial class FormStatistics
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
            this._lbxLevel = new System.Windows.Forms.ListBox();
            this._gbRecords = new System.Windows.Forms.GroupBox();
            this._txtRecords = new System.Windows.Forms.TextBox();
            this._txtData = new System.Windows.Forms.TextBox();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._gbRecords.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lbxLevel
            // 
            this._lbxLevel.FormattingEnabled = true;
            this._lbxLevel.ItemHeight = 15;
            this._lbxLevel.Location = new System.Drawing.Point(12, 12);
            this._lbxLevel.Name = "_lbxLevel";
            this._lbxLevel.Size = new System.Drawing.Size(121, 64);
            this._lbxLevel.TabIndex = 0;
            this._lbxLevel.SelectedIndexChanged += new System.EventHandler(this.OnLevelChanged);
            // 
            // _gbRecords
            // 
            this._gbRecords.Controls.Add(this._txtRecords);
            this._gbRecords.Location = new System.Drawing.Point(139, 12);
            this._gbRecords.Name = "_gbRecords";
            this._gbRecords.Size = new System.Drawing.Size(181, 101);
            this._gbRecords.TabIndex = 1;
            this._gbRecords.TabStop = false;
            this._gbRecords.Text = "Лучшие результаты";
            // 
            // _txtRecords
            // 
            this._txtRecords.BackColor = System.Drawing.SystemColors.Control;
            this._txtRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtRecords.Location = new System.Drawing.Point(3, 17);
            this._txtRecords.Multiline = true;
            this._txtRecords.Name = "_txtRecords";
            this._txtRecords.Size = new System.Drawing.Size(175, 81);
            this._txtRecords.TabIndex = 0;
            // 
            // _txtData
            // 
            this._txtData.BackColor = System.Drawing.SystemColors.Control;
            this._txtData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtData.Location = new System.Drawing.Point(326, 12);
            this._txtData.Multiline = true;
            this._txtData.Name = "_txtData";
            this._txtData.Size = new System.Drawing.Size(196, 134);
            this._txtData.TabIndex = 2;
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(387, 155);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(135, 23);
            this._btnReset.TabIndex = 3;
            this._btnReset.Text = "Сбросить";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this.OnResetClick);
            // 
            // _btnClose
            // 
            this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnClose.Location = new System.Drawing.Point(246, 155);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(135, 23);
            this._btnClose.TabIndex = 4;
            this._btnClose.Text = "Закрыть";
            this._btnClose.UseVisualStyleBackColor = true;
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnClose;
            this.ClientSize = new System.Drawing.Size(534, 190);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._txtData);
            this.Controls.Add(this._gbRecords);
            this.Controls.Add(this._lbxLevel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStatistics";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this._gbRecords.ResumeLayout(false);
            this._gbRecords.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _lbxLevel;
        private System.Windows.Forms.GroupBox _gbRecords;
        private System.Windows.Forms.TextBox _txtRecords;
        private System.Windows.Forms.TextBox _txtData;
        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnClose;
    }
}