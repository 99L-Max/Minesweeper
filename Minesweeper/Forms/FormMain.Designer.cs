
namespace Minesweeper
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._statisticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._parametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._designToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._lookReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._otherGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tableMap = new System.Windows.Forms.TableLayoutPanel();
            this._tableInfo = new System.Windows.Forms.TableLayoutPanel();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._gameToolStripMenuItem,
            this._referenceToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(415, 24);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this._gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newGameToolStripMenuItem,
            this._toolStripSeparator1,
            this._statisticToolStripMenuItem,
            this._parametersToolStripMenuItem,
            this._designToolStripMenuItem,
            this._toolStripSeparator2,
            this._exitToolStripMenuItem});
            this._gameToolStripMenuItem.Name = "играToolStripMenuItem";
            this._gameToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this._gameToolStripMenuItem.Text = "Игра";
            // 
            // новаяИграToolStripMenuItem
            // 
            this._newGameToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this._newGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this._newGameToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this._newGameToolStripMenuItem.Text = "Новая игра";
            this._newGameToolStripMenuItem.Click += new System.EventHandler(this.OnNewGameToolClick);
            // 
            // toolStripSeparator1
            // 
            this._toolStripSeparator1.Name = "toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size(219, 6);
            // 
            // статистикаToolStripMenuItem
            // 
            this._statisticToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            this._statisticToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this._statisticToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this._statisticToolStripMenuItem.Text = "Статистика";
            this._statisticToolStripMenuItem.Click += new System.EventHandler(this.OnStatisticsToolClick);
            // 
            // параметрыToolStripMenuItem
            // 
            this._parametersToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this._parametersToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._parametersToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this._parametersToolStripMenuItem.Text = "Параметры";
            this._parametersToolStripMenuItem.Click += new System.EventHandler(this.OnSettingsToolClick);
            // 
            // изменитьОформлениеToolStripMenuItem
            // 
            this._designToolStripMenuItem.Name = "изменитьОформлениеToolStripMenuItem";
            this._designToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this._designToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this._designToolStripMenuItem.Text = "Изменить оформление";
            this._designToolStripMenuItem.Click += new System.EventHandler(this.OnChangeDesignToolClick);
            // 
            // toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(219, 6);
            // 
            // выходToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Name = "выходToolStripMenuItem";
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this._exitToolStripMenuItem.Text = "Выход";
            this._exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolClick);
            // 
            // справкаToolStripMenuItem
            // 
            this._referenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lookReferenceToolStripMenuItem,
            this._toolStripSeparator3,
            this._aboutProgramToolStripMenuItem,
            this._toolStripSeparator4,
            this._otherGamesToolStripMenuItem});
            this._referenceToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this._referenceToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this._referenceToolStripMenuItem.Text = "Справка";
            // 
            // посмотретьСправкуToolStripMenuItem
            // 
            this._lookReferenceToolStripMenuItem.Name = "посмотретьСправкуToolStripMenuItem";
            this._lookReferenceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this._lookReferenceToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._lookReferenceToolStripMenuItem.Text = "Посмотреть справку";
            this._lookReferenceToolStripMenuItem.Click += new System.EventHandler(this.OnViewHelpToolClick);
            // 
            // toolStripSeparator3
            // 
            this._toolStripSeparator3.Name = "toolStripSeparator3";
            this._toolStripSeparator3.Size = new System.Drawing.Size(209, 6);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this._aboutProgramToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this._aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._aboutProgramToolStripMenuItem.Text = "О программе";
            this._aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolClick);
            // 
            // toolStripSeparator4
            // 
            this._toolStripSeparator4.Name = "toolStripSeparator4";
            this._toolStripSeparator4.Size = new System.Drawing.Size(209, 6);
            // 
            // другиеИгрыВИнтернетеToolStripMenuItem
            // 
            this._otherGamesToolStripMenuItem.Name = "другиеИгрыВИнтернетеToolStripMenuItem";
            this._otherGamesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this._otherGamesToolStripMenuItem.Text = "Другие игры в интернете";
            this._otherGamesToolStripMenuItem.Click += new System.EventHandler(this.OnOtherGamesClick);
            // 
            // tableMap
            // 
            this._tableMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tableMap.ColumnCount = 1;
            this._tableMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableMap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableMap.Location = new System.Drawing.Point(0, 27);
            this._tableMap.Name = "tableMap";
            this._tableMap.RowCount = 1;
            this._tableMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableMap.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableMap.Size = new System.Drawing.Size(415, 333);
            this._tableMap.TabIndex = 1;
            // 
            // tableInfo
            // 
            this._tableInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tableInfo.ColumnCount = 1;
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.62745F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.37255F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 129F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this._tableInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._tableInfo.Location = new System.Drawing.Point(0, 359);
            this._tableInfo.Name = "tableInfo";
            this._tableInfo.RowCount = 1;
            this._tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableInfo.Size = new System.Drawing.Size(415, 82);
            this._tableInfo.TabIndex = 2;
            // 
            // _timer
            // 
            this._timer.Interval = 1000;
            this._timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(415, 441);
            this.Controls.Add(this._tableInfo);
            this.Controls.Add(this._tableMap);
            this.Controls.Add(this._menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сапёр";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.ResizeEnd += new System.EventHandler(this.OnResizeEnd);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.TableLayoutPanel _tableInfo;
        private System.Windows.Forms.TableLayoutPanel _tableMap;
        private System.Windows.Forms.Timer _timer;
        private System.Windows.Forms.ToolStripMenuItem _aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _designToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _lookReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _otherGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _parametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _referenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _statisticToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator _toolStripSeparator4;
    }
}

