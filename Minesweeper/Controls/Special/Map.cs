using Minesweeper.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    class Map : PictureBox, ISave, ISetTheme, ISetSettings
    {
        private readonly FocusCell _focus = new FocusCell();
        private readonly SoundPlayer _soundPlayer = new SoundPlayer();
        private readonly MapAnimator _animator = new MapAnimator();
        private readonly MapView _mapView;

        private Dictionary<(int, int), MapCell> _cells = new Dictionary<(int, int), MapCell>();

        public Map(SettingsData data)
        {
            Dock = DockStyle.Fill;
            SizeMode = PictureBoxSizeMode.Zoom;
            BackColor = Color.Transparent;

            _mapView = new MapView(data.Theme);

            _focus.MouseDoubleClick += OnFocusCellMouseDoubleClick;
            _focus.MouseUp += OnCellMouseUp;
            _focus.CheckCell += (x, y) => _cells[(x, y)].IsClosed;

            _animator.FrameUpdated += () => Image = _mapView.Image;

            MouseClick += (s, e) => _animator.CancelAnimation();
            MouseMove += (s, e) => _focus.SetLocation(e.X, e.Y);
            SizeChanged += (s, e) => _focus.Visible = false;

            SetSettings(data);
        }

        public event Action GameStarted;
        public event Action<int> UnmarkedMinesCountChanged;
        public event Action<bool> StatisticsChanged;
        public event Action<bool> GameOver;

        public Size SizeInCells { get; private set; }
        public bool IsShowAnimation { get; private set; }
        public bool IsShowQuestionMarks { get; private set; }
        public bool IsGameRunning { get; private set; }
        public int MinesCount { get; private set; }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                base.CreateParams.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public void SetSettings(in SettingsData data)
        {
            _animator.SetSettings(data);
            _soundPlayer.IsPlaySounds = data.GetSettings(GameSettings.IsPlaySounds);

            IsShowAnimation = data.GetSettings(GameSettings.IsShowAnimation);
            IsShowQuestionMarks = data.GetSettings(GameSettings.IsShowQuestionMarks);
        }

        public void SetTheme(Theme theme)
        {
            if (_mapView.Theme != theme)
            {
                _mapView.SetTheme(theme);
                DrawClosedCells();
            }
        }

        public void StartNewGame(Size sizeInCells, int minesCount)
        {
            SizeInCells = sizeInCells;
            MinesCount = minesCount;

            _cells.Clear();
            _mapView.ChangeLayers(sizeInCells);

            for (int x = 0; x < SizeInCells.Width; x++)
                for (int y = 0; y < SizeInCells.Height; y++)
                    _cells.Add((x, y), new MapCell(x, y, _mapView.CellImageSize));

            StartGame(false, false);
        }

        public void Restart()
        {
            foreach (var cell in _cells.Values)
                cell.Reset();

            using (var mineImage = ResourceImage.CutImageByEnum(Resources.Mine, MineState.Exploded))
            {
                _mapView.DrawCells(MapLayers.Numbers, mineImage, _cells.Values.Where(cell => cell.HasMine));
                _mapView.ClearLayer(MapLayers.Marks);
            }

            Image = _mapView.Image;

            StartGame(false, true);
        }

        public void ChangeFocusSize()
        {
            _focus.ChangeSize(_mapView.Image.Size, ClientSize, SizeInCells);
        }

        public void ContinueSavedGame(MapCell[] cells)
        {
            var widthInCells = cells.Max(cell => cell.X) + 1;
            var heightInCells = cells.Max(cell => cell.X) + 1;

            SizeInCells = new Size(widthInCells, heightInCells);
            MinesCount = cells.Count(cell => cell.HasMine);

            _cells = cells.ToDictionary(cell => (cell.X, cell.Y), cell => cell);

            _mapView.ChangeLayers(SizeInCells);
            _mapView.DrawNumbers(_cells.Values, SizeInCells);
            _mapView.DrawClosedCells(cells);
            _mapView.DrawMarks(cells);

            _focus.ChangeSize(_mapView.Image.Size, ClientSize, SizeInCells);

            Image = _mapView.Image;
            StartGame(true, true);
        }

        public void Save()
        {
            FileWriter.Save(_cells.Values, GameDirectory.MapFilePath);
        }

        private async void StartGame(bool isSavedGame, bool isRestart)
        {
            ClearFocus();
            IsGameRunning = isSavedGame || isRestart;

            if (isSavedGame == false && IsShowAnimation)
                await _animator.ShowStart(_mapView, _cells.Values);
            else
                DrawClosedCells();

            if (isRestart == false)
                _focus.MouseClick += SetMines;

            _focus.MouseClick += InvokeStartGame;
            _focus.MouseClick += OnFocusCellMouseClick;

            Controls.Add(_focus);
        }

        private async void FinishGame(bool isWin, MapCell sender)
        {
            IsGameRunning = false;
            StatisticsChanged?.Invoke(isWin);

            ClearFocus();

            if (isWin == false)
            {
                using (var mineImage = ResourceImage.CutImageByEnum(Resources.Mine, MineState.Activated))
                {
                    _mapView.DrawCell(MapLayers.Numbers, mineImage, sender);
                    _mapView.DrawNotMines(_cells.Values);

                    Image = _mapView.Image;
                }
            }

            if (IsShowAnimation)
            {
                if (isWin)
                    await _animator.ShowVictory(_mapView, _cells.Values);
                else
                    await _animator.ShowLoss(_mapView, _cells.Values, sender);
            }

            _mapView.DrawEndGame(_cells.Values, isWin);

            Image = _mapView.Image;
            GameOver?.Invoke(isWin);
        }

        private List<MapCell> GetNeighbors(MapCell cell)
        {
            var neighbors = new List<MapCell>();

            for (int x = cell.X - 1; x <= cell.X + 1; x++)
                for (int y = cell.Y - 1; y <= cell.Y + 1; y++)
                    if ((x != cell.X || y != cell.Y) && _cells.ContainsKey((x, y)))
                        neighbors.Add(_cells[(x, y)]);

            return neighbors;
        }

        private void ClearFocus()
        {
            Controls.Clear();

            _focus.MouseClick -= SetMines;
            _focus.MouseClick -= OnFocusCellMouseClick;
        }

        private void SetNumbers()
        {
            foreach (MapCell mine in _cells.Values.Where(cell => cell.HasMine))
                GetNeighbors(mine).ForEach(cell => cell.UpdateMinesCount());

            _mapView.DrawNumbers(_cells.Values, SizeInCells);
            Image = _mapView.Image;
        }

        private void DrawClosedCells()
        {
            _mapView.DrawClosedCells(_cells.Values);
            Image = _mapView.Image;
        }

        private void DrawOpenCellsAndTryShowVictory(MapCell sender, params MapCell[] openCells)
        {
            _mapView.DrawOpenCells(openCells);
            Image = _mapView.Image;

            if (_cells.Values.Count(cell => cell.IsClosed == false) == _cells.Count - MinesCount)
                FinishGame(true, sender);
        }

        private void OpenEmptyCells(MapCell sender)
        {
            _soundPlayer.Play(Resources.Open);

            Stack<MapCell> stack = new Stack<MapCell>();
            MapCell currentCell;

            stack.Push(sender);

            do
            {
                currentCell = stack.Pop();
                currentCell.Open();

                foreach (var cell in GetNeighbors(currentCell))
                {
                    if (cell.Mark == CellMark.Flag)
                        continue;
                    else if (cell.MinesNearbyCount > 0)
                        cell.Open();
                    else if (cell.IsClosed && cell.HasMine == false)
                        stack.Push(cell);
                }
            }
            while (stack.Count > 0);
        }

        private void InvokeStartGame(object sender, MouseEventArgs e)
        {
            _focus.MouseClick -= InvokeStartGame;
            GameStarted?.Invoke();
        }

        private void SetMines(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsGameRunning = true;

                _focus.MouseClick -= SetMines;

                foreach (var location in CellsHandler.GetMinesLocation(SizeInCells, MinesCount, _focus.CellKey))
                    _cells[location].AddMine();

                SetNumbers();
            }
        }

        private void OnFocusCellMouseClick(object sender, MouseEventArgs e)
        {
            MapCell cell = _cells[_focus.CellKey];

            if (e.Button == MouseButtons.Left && cell.IsClosed && cell.Mark != CellMark.Flag)
            {
                _focus.BackColor = Color.Transparent;

                if (cell.MinesNearbyCount == 0)
                {
                    OpenEmptyCells(cell);
                    DrawOpenCellsAndTryShowVictory(cell, _cells.Values.ToArray());
                }
                else if (cell.HasMine)
                {
                    FinishGame(false, cell);
                }
                else
                {
                    cell.Open();
                    DrawOpenCellsAndTryShowVictory(cell, cell);
                }
            }
        }

        private async void OnFocusCellMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var maxNeighborsCount = 8;
            var currentCell = _cells[_focus.CellKey];

            if (currentCell.IsClosed == false && currentCell.MinesNearbyCount > 0 && currentCell.MinesNearbyCount < maxNeighborsCount)
            {
                var neighbors = GetNeighbors(currentCell);

                if (neighbors.Count(cell => cell.Mark == CellMark.Flag) == currentCell.MinesNearbyCount)
                {
                    foreach (var cell in neighbors)
                    {
                        if (cell.IsClosed && cell.Mark != CellMark.Flag)
                        {
                            if (cell.HasMine)
                            {
                                FinishGame(false, cell);
                                return;
                            }
                            else if (cell.MinesNearbyCount == 0)
                            {
                                OpenEmptyCells(cell);
                            }
                            else
                            {
                                cell.Open();
                            }
                        }
                    }

                    DrawOpenCellsAndTryShowVictory(neighbors.First(), _cells.Values.ToArray());
                }
                else
                {
                    await _animator.ShowError(_mapView, currentCell);
                }
            }
        }

        private void OnCellMouseUp(object sender, MouseEventArgs e)
        {
            _focus.Visible = false;

            var currentCell = _cells[_focus.CellKey];

            if (currentCell.IsClosed && e.Button == MouseButtons.Right)
            {
                currentCell.ChangeMark(IsShowQuestionMarks);

                var counterValue = MinesCount - _cells.Values.Count(cell => cell.Mark == CellMark.Flag);
                UnmarkedMinesCountChanged?.Invoke(counterValue);

                _mapView.DrawMark(currentCell);
                Image = _mapView.Image;
            }
        }
    }
}