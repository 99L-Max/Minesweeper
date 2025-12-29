
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
            this._tableGame = new System.Windows.Forms.TableLayoutPanel();
            this._tableInfo = new System.Windows.Forms.TableLayoutPanel();
            this._pbWatch = new System.Windows.Forms.PictureBox();
            this._pbUnmarkedMines = new System.Windows.Forms.PictureBox();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this._menuStrip.SuspendLayout();
            this._tableGame.SuspendLayout();
            this._tableInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbWatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbUnmarkedMines)).BeginInit();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._gameToolStripMenuItem,
            this._referenceToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(434, 24);
            this._menuStrip.TabIndex = 0;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _gameToolStripMenuItem
            // 
            this._gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newGameToolStripMenuItem,
            this._toolStripSeparator1,
            this._statisticToolStripMenuItem,
            this._parametersToolStripMenuItem,
            this._designToolStripMenuItem,
            this._toolStripSeparator2,
            this._exitToolStripMenuItem});
            this._gameToolStripMenuItem.Name = "_gameToolStripMenuItem";
            this._gameToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this._gameToolStripMenuItem.Text = "Игра";
            // 
            // _newGameToolStripMenuItem
            // 
            this._newGameToolStripMenuItem.Name = "_newGameToolStripMenuItem";
            this._newGameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this._newGameToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._newGameToolStripMenuItem.Text = "Новая игра";
            this._newGameToolStripMenuItem.Click += new System.EventHandler(this.OnNewGameToolClick);
            // 
            // _toolStripSeparator1
            // 
            this._toolStripSeparator1.Name = "_toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size(227, 6);
            // 
            // _statisticToolStripMenuItem
            // 
            this._statisticToolStripMenuItem.Name = "_statisticToolStripMenuItem";
            this._statisticToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this._statisticToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._statisticToolStripMenuItem.Text = "Статистика";
            this._statisticToolStripMenuItem.Click += new System.EventHandler(this.OnStatisticsToolClick);
            // 
            // _parametersToolStripMenuItem
            // 
            this._parametersToolStripMenuItem.Name = "_parametersToolStripMenuItem";
            this._parametersToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._parametersToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._parametersToolStripMenuItem.Text = "Параметры";
            this._parametersToolStripMenuItem.Click += new System.EventHandler(this.OnSettingsToolClick);
            // 
            // _designToolStripMenuItem
            // 
            this._designToolStripMenuItem.Name = "_designToolStripMenuItem";
            this._designToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this._designToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._designToolStripMenuItem.Text = "Изменить оформление";
            this._designToolStripMenuItem.Click += new System.EventHandler(this.OnSetThemeToolClick);
            // 
            // _toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "_toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size(227, 6);
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this._exitToolStripMenuItem.Text = "Выход";
            this._exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolClick);
            // 
            // _referenceToolStripMenuItem
            // 
            this._referenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lookReferenceToolStripMenuItem,
            this._toolStripSeparator3,
            this._aboutProgramToolStripMenuItem,
            this._toolStripSeparator4,
            this._otherGamesToolStripMenuItem});
            this._referenceToolStripMenuItem.Name = "_referenceToolStripMenuItem";
            this._referenceToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this._referenceToolStripMenuItem.Text = "Справка";
            // 
            // _lookReferenceToolStripMenuItem
            // 
            this._lookReferenceToolStripMenuItem.Name = "_lookReferenceToolStripMenuItem";
            this._lookReferenceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this._lookReferenceToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this._lookReferenceToolStripMenuItem.Text = "Посмотреть справку";
            this._lookReferenceToolStripMenuItem.Click += new System.EventHandler(this.OnViewHelpToolClick);
            // 
            // _toolStripSeparator3
            // 
            this._toolStripSeparator3.Name = "_toolStripSeparator3";
            this._toolStripSeparator3.Size = new System.Drawing.Size(219, 6);
            // 
            // _aboutProgramToolStripMenuItem
            // 
            this._aboutProgramToolStripMenuItem.Name = "_aboutProgramToolStripMenuItem";
            this._aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this._aboutProgramToolStripMenuItem.Text = "О программе";
            this._aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolClick);
            // 
            // _toolStripSeparator4
            // 
            this._toolStripSeparator4.Name = "_toolStripSeparator4";
            this._toolStripSeparator4.Size = new System.Drawing.Size(219, 6);
            // 
            // _otherGamesToolStripMenuItem
            // 
            this._otherGamesToolStripMenuItem.Name = "_otherGamesToolStripMenuItem";
            this._otherGamesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this._otherGamesToolStripMenuItem.Text = "Другие игры в интернете";
            this._otherGamesToolStripMenuItem.Click += new System.EventHandler(this.OnOtherGamesToolClick);
            // 
            // _tableGame
            // 
            this._tableGame.BackColor = System.Drawing.Color.DarkGray;
            this._tableGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tableGame.ColumnCount = 1;
            this._tableGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableGame.Controls.Add(this._tableInfo, 0, 1);
            this._tableGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableGame.Location = new System.Drawing.Point(0, 24);
            this._tableGame.Name = "_tableGame";
            this._tableGame.RowCount = 2;
            this._tableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this._tableGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tableGame.Size = new System.Drawing.Size(434, 387);
            this._tableGame.TabIndex = 1;
            // 
            // _tableInfo
            // 
            this._tableInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tableInfo.ColumnCount = 7;
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this._tableInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this._tableInfo.Controls.Add(this._pbWatch, 1, 0);
            this._tableInfo.Controls.Add(this._pbUnmarkedMines, 5, 0);
            this._tableInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableInfo.Location = new System.Drawing.Point(3, 331);
            this._tableInfo.Name = "_tableInfo";
            this._tableInfo.RowCount = 1;
            this._tableInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableInfo.Size = new System.Drawing.Size(428, 53);
            this._tableInfo.TabIndex = 2;
            // 
            // _pbWatch
            // 
            this._pbWatch.BackgroundImage = global::Minesweeper.Properties.Resources.Watch;
            this._pbWatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._pbWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pbWatch.Location = new System.Drawing.Point(67, 3);
            this._pbWatch.Name = "_pbWatch";
            this._pbWatch.Size = new System.Drawing.Size(36, 47);
            this._pbWatch.TabIndex = 2;
            this._pbWatch.TabStop = false;
            // 
            // _pbUnmarkedMines
            // 
            this._pbUnmarkedMines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._pbUnmarkedMines.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pbUnmarkedMines.Location = new System.Drawing.Point(321, 3);
            this._pbUnmarkedMines.Name = "_pbUnmarkedMines";
            this._pbUnmarkedMines.Size = new System.Drawing.Size(36, 47);
            this._pbUnmarkedMines.TabIndex = 4;
            this._pbUnmarkedMines.TabStop = false;
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
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.Controls.Add(this._tableGame);
            this.Controls.Add(this._menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this._menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сапёр";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.OnFormMainLoad);
            this.ResizeEnd += new System.EventHandler(this.OnResizeEnd);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._tableGame.ResumeLayout(false);
            this._tableInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pbWatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbUnmarkedMines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.TableLayoutPanel _tableInfo;
        private System.Windows.Forms.TableLayoutPanel _tableGame;
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
        private System.Windows.Forms.PictureBox _pbWatch;
        private System.Windows.Forms.PictureBox _pbUnmarkedMines;
    }
}

