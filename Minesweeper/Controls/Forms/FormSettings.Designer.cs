
namespace Minesweeper
{
    partial class FormSettings
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
            this._gb = new System.Windows.Forms.GroupBox();
            this._panelRadioButtons = new System.Windows.Forms.FlowLayoutPanel();
            this._panelSpecialLevelData = new System.Windows.Forms.Panel();
            this._numSpecialHeight = new System.Windows.Forms.NumericUpDown();
            this._lblHeight = new System.Windows.Forms.Label();
            this._numSpecialMinesCount = new System.Windows.Forms.NumericUpDown();
            this._lblWidth = new System.Windows.Forms.Label();
            this._lblMinesCount = new System.Windows.Forms.Label();
            this._numSpecialWidth = new System.Windows.Forms.NumericUpDown();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._panelCheckBoxes = new System.Windows.Forms.FlowLayoutPanel();
            this._gb.SuspendLayout();
            this._panelRadioButtons.SuspendLayout();
            this._panelSpecialLevelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialMinesCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // _gb
            // 
            this._gb.Controls.Add(this._panelRadioButtons);
            this._gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._gb.Location = new System.Drawing.Point(14, 14);
            this._gb.Name = "_gb";
            this._gb.Size = new System.Drawing.Size(401, 200);
            this._gb.TabIndex = 0;
            this._gb.TabStop = false;
            this._gb.Text = "Уровень";
            // 
            // _panelRadioButtons
            // 
            this._panelRadioButtons.Controls.Add(this._panelSpecialLevelData);
            this._panelRadioButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelRadioButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._panelRadioButtons.Location = new System.Drawing.Point(3, 17);
            this._panelRadioButtons.Name = "_panelRadioButtons";
            this._panelRadioButtons.Size = new System.Drawing.Size(395, 180);
            this._panelRadioButtons.TabIndex = 10;
            // 
            // _panelSpecialLevelData
            // 
            this._panelSpecialLevelData.Controls.Add(this._numSpecialHeight);
            this._panelSpecialLevelData.Controls.Add(this._lblHeight);
            this._panelSpecialLevelData.Controls.Add(this._numSpecialMinesCount);
            this._panelSpecialLevelData.Controls.Add(this._lblWidth);
            this._panelSpecialLevelData.Controls.Add(this._lblMinesCount);
            this._panelSpecialLevelData.Controls.Add(this._numSpecialWidth);
            this._panelSpecialLevelData.Location = new System.Drawing.Point(3, 3);
            this._panelSpecialLevelData.Name = "_panelSpecialLevelData";
            this._panelSpecialLevelData.Size = new System.Drawing.Size(223, 107);
            this._panelSpecialLevelData.TabIndex = 10;
            // 
            // _numSpecialHeight
            // 
            this._numSpecialHeight.Location = new System.Drawing.Point(141, 13);
            this._numSpecialHeight.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this._numSpecialHeight.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._numSpecialHeight.Name = "_numSpecialHeight";
            this._numSpecialHeight.Size = new System.Drawing.Size(73, 21);
            this._numSpecialHeight.TabIndex = 7;
            this._numSpecialHeight.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._numSpecialHeight.ValueChanged += new System.EventHandler(this.OnSpecialSizeChanged);
            // 
            // _lblHeight
            // 
            this._lblHeight.AutoSize = true;
            this._lblHeight.Location = new System.Drawing.Point(2, 15);
            this._lblHeight.Name = "_lblHeight";
            this._lblHeight.Size = new System.Drawing.Size(93, 15);
            this._lblHeight.TabIndex = 4;
            this._lblHeight.Text = "Высота (xx-xx):";
            // 
            // _numSpecialMinesCount
            // 
            this._numSpecialMinesCount.Location = new System.Drawing.Point(141, 76);
            this._numSpecialMinesCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this._numSpecialMinesCount.Name = "_numSpecialMinesCount";
            this._numSpecialMinesCount.Size = new System.Drawing.Size(73, 21);
            this._numSpecialMinesCount.TabIndex = 9;
            this._numSpecialMinesCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // _lblWidth
            // 
            this._lblWidth.AutoSize = true;
            this._lblWidth.Location = new System.Drawing.Point(2, 46);
            this._lblWidth.Name = "_lblWidth";
            this._lblWidth.Size = new System.Drawing.Size(95, 15);
            this._lblWidth.TabIndex = 5;
            this._lblWidth.Text = "Ширина (xx-xx):";
            // 
            // _lblMinesCount
            // 
            this._lblMinesCount.AutoSize = true;
            this._lblMinesCount.Location = new System.Drawing.Point(2, 78);
            this._lblMinesCount.Name = "_lblMinesCount";
            this._lblMinesCount.Size = new System.Drawing.Size(110, 15);
            this._lblMinesCount.TabIndex = 6;
            this._lblMinesCount.Text = "Число мин (xx-xx):";
            // 
            // _numSpecialWidth
            // 
            this._numSpecialWidth.Location = new System.Drawing.Point(141, 44);
            this._numSpecialWidth.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this._numSpecialWidth.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._numSpecialWidth.Name = "_numSpecialWidth";
            this._numSpecialWidth.Size = new System.Drawing.Size(73, 21);
            this._numSpecialWidth.TabIndex = 8;
            this._numSpecialWidth.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._numSpecialWidth.ValueChanged += new System.EventHandler(this.OnSpecialSizeChanged);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(303, 432);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(112, 23);
            this._btnCancel.TabIndex = 7;
            this._btnCancel.Text = "Отмена";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.Location = new System.Drawing.Point(185, 432);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(112, 23);
            this._btnOK.TabIndex = 8;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Click += new System.EventHandler(this.OnOKClick);
            // 
            // _panelCheckBoxes
            // 
            this._panelCheckBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._panelCheckBoxes.AutoScroll = true;
            this._panelCheckBoxes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._panelCheckBoxes.Location = new System.Drawing.Point(14, 217);
            this._panelCheckBoxes.Margin = new System.Windows.Forms.Padding(0);
            this._panelCheckBoxes.Name = "_panelCheckBoxes";
            this._panelCheckBoxes.Size = new System.Drawing.Size(403, 212);
            this._panelCheckBoxes.TabIndex = 9;
            this._panelCheckBoxes.WrapContents = false;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(429, 464);
            this.Controls.Add(this._panelCheckBoxes);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._gb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры";
            this.Load += new System.EventHandler(this.OnFormLoad);
            this._gb.ResumeLayout(false);
            this._panelRadioButtons.ResumeLayout(false);
            this._panelSpecialLevelData.ResumeLayout(false);
            this._panelSpecialLevelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialMinesCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSpecialWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gb;
        private System.Windows.Forms.Label _lblMinesCount;
        private System.Windows.Forms.Label _lblWidth;
        private System.Windows.Forms.Label _lblHeight;
        private System.Windows.Forms.NumericUpDown _numSpecialMinesCount;
        private System.Windows.Forms.NumericUpDown _numSpecialWidth;
        private System.Windows.Forms.NumericUpDown _numSpecialHeight;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.FlowLayoutPanel _panelCheckBoxes;
        private System.Windows.Forms.FlowLayoutPanel _panelRadioButtons;
        private System.Windows.Forms.Panel _panelSpecialLevelData;
    }
}