
namespace Minesweeper
{
    partial class Statistics
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
            this.listBoxLevel = new System.Windows.Forms.ListBox();
            this.groupBoxRecords = new System.Windows.Forms.GroupBox();
            this.textBoxRecords = new System.Windows.Forms.TextBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxRecords.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxLevel
            // 
            this.listBoxLevel.FormattingEnabled = true;
            this.listBoxLevel.ItemHeight = 15;
            this.listBoxLevel.Items.AddRange(new object[] {
            "Новичок",
            "Любитель",
            "Профессионал"});
            this.listBoxLevel.Location = new System.Drawing.Point(12, 12);
            this.listBoxLevel.Name = "listBoxLevel";
            this.listBoxLevel.Size = new System.Drawing.Size(121, 64);
            this.listBoxLevel.TabIndex = 0;
            this.listBoxLevel.SelectedIndexChanged += new System.EventHandler(this.ListBoxLevel_SelectedIndexChanged);
            // 
            // groupBoxRecords
            // 
            this.groupBoxRecords.Controls.Add(this.textBoxRecords);
            this.groupBoxRecords.Location = new System.Drawing.Point(139, 12);
            this.groupBoxRecords.Name = "groupBoxRecords";
            this.groupBoxRecords.Size = new System.Drawing.Size(181, 101);
            this.groupBoxRecords.TabIndex = 1;
            this.groupBoxRecords.TabStop = false;
            this.groupBoxRecords.Text = "Лучшие результаты";
            // 
            // textBoxRecords
            // 
            this.textBoxRecords.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRecords.Location = new System.Drawing.Point(3, 17);
            this.textBoxRecords.Multiline = true;
            this.textBoxRecords.Name = "textBoxRecords";
            this.textBoxRecords.Size = new System.Drawing.Size(175, 81);
            this.textBoxRecords.TabIndex = 0;
            // 
            // textBoxData
            // 
            this.textBoxData.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxData.Location = new System.Drawing.Point(326, 12);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(196, 134);
            this.textBoxData.TabIndex = 2;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(387, 155);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(135, 23);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Сбросить";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(246, 155);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(135, 23);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(534, 190);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.groupBoxRecords);
            this.Controls.Add(this.listBoxLevel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Statistics";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBoxRecords.ResumeLayout(false);
            this.groupBoxRecords.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLevel;
        private System.Windows.Forms.GroupBox groupBoxRecords;
        private System.Windows.Forms.TextBox textBoxRecords;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonClose;
    }
}