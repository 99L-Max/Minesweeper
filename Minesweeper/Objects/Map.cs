using Minesweeper.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    class Map : PictureBox
    {
        private const int DeltaTime = 40;

        private readonly Size _sizeCell;
        private readonly Image _emptyImage;
        private readonly FocusCell _focus;
        private readonly Dictionary<(int, int), Cell> _cells;

        private bool _isFinishAnimation;
        private int _countOpenCells;
        private Image _backgroundImage;
        private Image _image;
        private Image _imgMine;
        private Graphics _g;
        private Dictionary<Mark, Image> _imgCells;
        private Mine[] _mines;

        public Action GameStarted;
        public Action<bool> CounterChanged;
        public Action<Level, bool> GameOver;
        public Action<Level, bool> AnimationCompleted;

        public Level Level { get; private set; }
        public Theme Theme { get; private set; }
        public Size SizeInCells { get; private set; }
        public bool IsShowAnimation { get; private set; }
        public bool IsShowQuestionMarks { get; private set; }
        public bool IsFirstMove { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool IsGameStarted { get; private set; }
        public int CountMines => _mines.Length;

        public Map(SettingsData data, Theme theme)
        {
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.Zoom;
            BackgroundImageLayout = ImageLayout.Zoom;
            Dock = DockStyle.Fill;
            Font = new Font("", 32, FontStyle.Bold);

            _sizeCell = new Size(50, 50);
            _emptyImage = new Bitmap(_sizeCell.Width, _sizeCell.Height);
            _focus = new FocusCell();
            _cells = new Dictionary<(int, int), Cell>();

            _focus.MouseDoubleClick += OnCellMouseDoubleClick;
            _focus.MouseUp += OnCellMouseUp;
            _focus.CheckCell += (x, y) => _cells[(x, y)].IsClose;

            MouseClick += (s, e) => _isFinishAnimation = true;
            SizeChanged += (s, e) => _focus.Visible = false;
            MouseMove += (s, e) => _focus.SetLocation(e.X, e.Y);

            SetSettings(data);
            SetDesign(theme);
        }

        public void SetSettings(SettingsData data)
        {
            IsShowAnimation = data.GetSettings(GameSettings.IsShowAnimation);
            IsShowQuestionMarks = data.GetSettings(GameSettings.IsShowQuestionMarks);
        }

        private void DrawClosedCells()
        {
            foreach (var cell in _cells.Values)
                if (cell.IsClose)
                    _g.DrawImage(_imgCells[cell.Mark], cell.ImageRectangle);
        }

        private async void Start(bool isSaved, bool areMinesSet)
        {
            ClearFocus();
            IsGameStarted = IsGameOver = false;

            _image?.Dispose();
            _g?.Dispose();

            _image = new Bitmap(_sizeCell.Width * SizeInCells.Width, _sizeCell.Height * SizeInCells.Height);
            _g = Graphics.FromImage(_image);
            _g.CompositingMode = CompositingMode.SourceCopy;

            if (!isSaved && IsShowAnimation)
                await ShowAnimationStart();
            else
                DrawClosedCells();

            Image = _image;

            if (!areMinesSet)
                _focus.MouseClick += SetMines;

            _focus.MouseClick += OnCellMouseClick;
            Controls.Add(_focus);

            IsGameStarted = true;
        }

        public void NewGame(SettingsData data)
        {
            Level = data.Level;
            SizeInCells = data.MapSize;
            IsFirstMove = true;
            BackgroundImage = null;

            if (_cells.Count > 0)
            {
                foreach (var cell in _cells.Values)
                    cell.CellOpen -= OnCellOpen;

                _cells.Clear();
            }

            for (int x = 0; x < SizeInCells.Width; x++)
                for (int y = 0; y < SizeInCells.Height; y++)
                {
                    _cells.Add((x, y), new Cell(_sizeCell, x, y));
                    _cells[(x, y)].CellOpen += OnCellOpen;
                }

            _mines = new Mine[data.CountMines];
            _countOpenCells = 0;
            _backgroundImage?.Dispose();

            Start(false, false);
        }

        public void Restart()
        {
            using (var mine = Resources.Mine_Exploded)
            using (var g = Graphics.FromImage(_backgroundImage))
                foreach (var cell in _cells.Values)
                {
                    if (cell is Mine m && m.IsActivated)
                        g.DrawImage(mine, m.ImageRectangle);

                    cell.Reset();
                }

            BackgroundImage = _backgroundImage;
            IsFirstMove = true;
            _countOpenCells = 0;

            Start(false, true);
        }

        private async void FinishGame(bool isWin, Cell sender)
        {
            IsGameOver = true;
            GameOver?.Invoke(Level, isWin);

            ClearFocus();

            if (!isWin)
            {
                using (var mine = new Bitmap(Resources.Mine_Activated, _sizeCell))
                using (var g = Graphics.FromImage(_backgroundImage))
                {
                    g.DrawImage(mine, sender.ImageRectangle);
                    BackgroundImage = _backgroundImage;
                }

                using (var notMine = new Bitmap(Resources.NotMine, _sizeCell))
                    foreach (var cell in _cells.Values)
                        if (cell.Mark == Mark.Flag && !(cell is Mine))
                            _g.DrawImage(notMine, cell.ImageRectangle);
            }

            if (IsShowAnimation)
                await (isWin ? ShowAnimationVictory() : ShowAnimationLoss(sender));

            DrawEndGame(isWin);
            AnimationCompleted?.Invoke(Level, isWin);
        }

        private List<Cell> GetNeighbors(Cell cell)
        {
            var neighbors = new List<Cell>();

            for (int x = cell.X - 1; x <= cell.X + 1; x++)
                for (int y = cell.Y - 1; y <= cell.Y + 1; y++)
                    if ((x != cell.X || y != cell.Y) && _cells.ContainsKey((x, y)))
                        neighbors.Add(_cells[(x, y)]);

            return neighbors;
        }

        private void SetNumbers()
        {
            foreach (var mine in _mines)
                GetNeighbors(mine).ForEach(c => c.CountMinesNearby++);

            var colors = new Color[]
            {
                Color.Blue, Color.Green, Color.Red, Color.DarkBlue,
                Color.DarkRed, Color.DarkCyan, Color.OrangeRed, Color.Purple
            };

            var brushes = colors.Select(c => new SolidBrush(c)).ToList();

            _backgroundImage?.Dispose();
            _backgroundImage = new Bitmap(_sizeCell.Width * SizeInCells.Width, _sizeCell.Height * SizeInCells.Height);

            using (var g = Graphics.FromImage(_backgroundImage))
            using (var format = new StringFormat())
            using (var openCell = new Bitmap(Resources.OpenCell, _sizeCell))
            using (var mine = new Bitmap(Resources.Mine_Exploded, _sizeCell))
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                foreach (var cell in _cells.Values)
                {
                    g.DrawImage(openCell, cell.ImageRectangle);

                    if (cell.CountMinesNearby > 0)
                        g.DrawString($"{cell.CountMinesNearby}", Font, brushes[cell.CountMinesNearby - 1], cell.ImageRectangle, format);
                    else if (cell is Mine)
                        g.DrawImage(mine, cell.ImageRectangle);
                }
            }

            brushes.ForEach(b => b.Dispose());
            BackgroundImage = _backgroundImage;
        }

        private void ClearFocus()
        {
            Controls.Clear();

            _focus.MouseClick -= SetMines;
            _focus.MouseClick -= OnCellMouseClick;
        }

        private void OnCellOpen(Cell sender)
        {
            _focus.BackColor = Color.Transparent;
            IsFirstMove = false;

            if (sender is Mine mine)
            {
                mine.Activate();
                FinishGame(false, sender);
            }
            else
            {
                _g.DrawImage(_emptyImage, sender.ImageRectangle);
                Image = _image;

                if (++_countOpenCells == _cells.Count - _mines.Length)
                    FinishGame(true, sender);
            }
        }

        private void OnCellMouseClick(object sender, MouseEventArgs e)
        {
            Cell cell = _cells[_focus.KeyCell];
            if (e.Button == MouseButtons.Left && cell.IsClose && cell.Mark != Mark.Flag)
            {
                if (cell.CountMinesNearby == 0)
                    Fill(cell);
                else
                    cell.Open();
            }
        }

        private void OnCellMouseUp(object sender, MouseEventArgs e)
        {
            var cell = _cells[_focus.KeyCell];

            if (cell.IsClose && e.Button == MouseButtons.Right)
            {
                if (cell.Mark != Mark.Question)
                    CounterChanged?.Invoke(cell.Mark != Mark.Empty);

                cell.ChangeMark(IsShowQuestionMarks);

                _g.DrawImage(_imgCells[cell.Mark], cell.ImageRectangle);
                Image = _image;
            }
        }

        private async void OnCellMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Cell cell = _cells[_focus.KeyCell];

            if (!cell.IsClose && cell.CountMinesNearby > 0 && cell.CountMinesNearby < 8)
            {
                var neighbors = GetNeighbors(cell);

                if (neighbors.Where(c => c.Mark == Mark.Flag).Count() == cell.CountMinesNearby)
                {
                    foreach (var c in neighbors)
                        if (c.IsClose && c.Mark != Mark.Flag)
                        {
                            if (c.CountMinesNearby == 0)
                                Fill(c);
                            else
                                c.Open();
                        }
                }
                else
                {
                    Sound.Play(Resources.Error);

                    if (IsShowAnimation)
                        using (var cross = new Bitmap(Resources.Cross, _sizeCell))
                            for (int i = 0; i < 6; i++)
                            {
                                _g.DrawImage((i & 1) == 0 ? cross : _emptyImage, cell.ImageRectangle);
                                Image = _image;
                                await Task.Delay(100);
                            }
                }
            }
        }

        private void SetMines(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _focus.MouseClick -= SetMines;

                var cell = _cells[_focus.KeyCell];

                var x1 = cell.X - 1;
                var x2 = cell.X + 1;
                var y1 = cell.Y - 1;
                var y2 = cell.Y + 1;

                var rnd = new Random();
                var listMines = _cells.Values.Where(m => m.X < x1 || m.X > x2 || m.Y < y1 || m.Y > y2).OrderBy(m => rnd.Next()).Take(_mines.Length).ToList();
                Cell mine;

                for (int i = 0; i < _mines.Length; i++)
                {
                    mine = listMines[i];
                    mine.CellOpen -= OnCellOpen;
                    _cells[(mine.X, mine.Y)] = _mines[i] = new Mine(_sizeCell, mine.X, mine.Y, mine.Mark);
                    _mines[i].CellOpen += OnCellOpen;
                }

                SetNumbers();
                GameStarted?.Invoke();
            }
        }

        private void Fill(Cell sender)
        {
            Sound.Play(Resources.Open);

            Stack<Cell> stack = new Stack<Cell>();
            Cell currentCell;

            stack.Push(sender);

            do
            {
                currentCell = stack.Pop();
                currentCell.Open();

                foreach (var cell in GetNeighbors(currentCell))
                {
                    if (cell.Mark == Mark.Flag)
                        continue;

                    if (cell.CountMinesNearby > 0)
                        cell.Open();
                    else if (cell.IsClose && !(cell is Mine))
                        stack.Push(cell);
                }
            } while (stack.Count > 0);
        }

        private void DrawEndGame(bool isWin)
        {
            if (isWin)
            {
                _g.Clear(Color.Transparent);

                foreach (var mine in _mines)
                    _g.DrawImage(mine.Mark == Mark.Flag ? _imgCells[Mark.Flag] : _imgMine, mine.ImageRectangle);
            }
            else
            {
                foreach (var mine in _mines)
                    _g.DrawImage(_emptyImage, mine.ImageRectangle);
            }

            Image = _image;
        }

        private async Task ShowAnimationStart()
        {
            using (var openCell = new Bitmap(Resources.OpenCell, _sizeCell))
                foreach (var c in _cells.Values)
                    _g.DrawImage(openCell, c.ImageRectangle);

            Image = _image;

            var rnd = new Random();
            var stack = new Stack<Cell>(_cells.Values.OrderBy(c => rnd.Next()));

            Sound.Play(Resources.Start);

            int i = 0, iMax = _cells.Count / 8;

            do
            {
                _g.DrawImage(_imgCells[Mark.Empty], stack.Pop().ImageRectangle);

                if (++i > iMax)
                {
                    i = 0;
                    Image = _image;
                    await Task.Delay(DeltaTime);
                }
            } while (stack.Count > 0);
        }

        private async Task ShowAnimationVictory()
        {
            _isFinishAnimation = false;
            _g.CompositingMode = CompositingMode.SourceOver;

            foreach (var mine in _mines)
                _g.DrawImage(_imgCells[Mark.Empty], mine.ImageRectangle);

            Image = _image;

            using (var scanner = new Scanner(Theme, _image.Width, _sizeCell.Height, _image.Height))
            using (var sourceImg = new Bitmap(_image))
            {
                var dyScanner = -_image.Height * DeltaTime / 3000;
                var dAlpha = 15;
                var brushes = Painter.GetFillBrushes(Color.White, dAlpha);
                var showingMines = _mines.Select(m => new ShowingMine(_sizeCell, m.X, m.Y, (_image.Height - m.ImageRectangle.Y) / -dyScanner * DeltaTime)).ToArray();

                Sound.Play(Resources.Win);

                do
                {
                    _g.Clear(Color.Transparent);
                    _g.DrawImage(sourceImg, 0, 0);

                    foreach (var mine in showingMines)
                    {
                        mine.Update(DeltaTime, dAlpha);

                        _g.DrawImage(mine.Visible ? _imgMine : _imgCells[Mark.Empty], mine.ImageRectangle);
                        _g.FillRectangle(brushes[mine.Alpha], mine.ImageRectangle);
                    }

                    scanner.Update(dyScanner);
                    _g.DrawImage(scanner.Image, 0, scanner.Y);

                    Image = _image;
                    await Task.Delay(DeltaTime);

                    if (_isFinishAnimation)
                    {
                        DrawEndGame(true);
                        break;
                    }
                } while (scanner.Y > -scanner.Image.Height || !showingMines.All(m => m.IsShowed));

                foreach (var b in brushes.Values)
                    b.Dispose();
            }
        }

        private async Task ShowAnimationLoss(Cell sender)
        {
            _isFinishAnimation = false;

            var explodingMines = new List<ExplodingMine>();
            var stagesBoom = ExplodingMine.GetStagesBoom(_sizeCell);
            var rnd = new Random();
            int dx, dy, distance;

            stagesBoom.Insert(0, new Bitmap(_imgMine));

            foreach (var mine in _mines)
            {
                dx = sender.X - mine.X;
                dy = sender.Y - mine.Y;
                distance = (int)Math.Sqrt(dx * dx + dy * dy);

                explodingMines.Add(new ExplodingMine(_sizeCell, mine.X, mine.Y, (4 * distance + rnd.Next(4)) * DeltaTime, stagesBoom.Count));
                _g.DrawImage(_imgMine, mine.ImageRectangle);
            }

            Image = _image;
            
            do
            {
                foreach (var mine in explodingMines)
                {
                    mine.Update(DeltaTime);
                    _g.DrawImage(mine.IsExploded ? _emptyImage : stagesBoom[mine.StageBoom], mine.ImageRectangle);
                }

                Image = _image;

                await Task.Delay(DeltaTime);

                if (_isFinishAnimation)
                {
                    DrawEndGame(false);
                    break;
                }
            }
            while (!explodingMines.All(m => m.IsExploded));

            stagesBoom.ForEach(s => s.Dispose());
        }

        private void SetDesign(Theme theme)
        {
            Theme = theme;

            var imgCell = new Bitmap((Image)Resources.ResourceManager.GetObject($"Cell_{Theme}"), _sizeCell);

            using (var flag = Resources.Flag)
            using (var mark = Resources.QuestionMark)
            using (var mine = Resources.Mine)
            {
                if (_imgCells != null)
                    foreach (var img in _imgCells.Values)
                        img.Dispose();

                _imgCells = new Dictionary<Mark, Image>()
                {
                    { Mark.Empty, imgCell },
                    { Mark.Flag, Painter.OverlayImages(imgCell, flag, _sizeCell) },
                    { Mark.Question, Painter.OverlayImages(imgCell, mark, _sizeCell) }
                };

                _imgMine?.Dispose();
                _imgMine = Painter.OverlayImages(imgCell, mine, _sizeCell);
            }
        }

        public void ChangeDesign(Theme theme)
        {
            if (Theme != theme)
            {
                SetDesign(theme);
                DrawClosedCells();
                Image = _image;
            }
        }

        public void ChangeSizeFocus() =>
            _focus.ChangeSize(ClientSize, _image.Size, SizeInCells);

        public void Open(JObject jObj)
        {
            Level = (Level)jObj["Level"].Value<int>();
            SizeInCells = new Size(jObj["Width"].Value<int>(), jObj["Height"].Value<int>());

            JArray jArr = JArray.Parse(JToken.FromObject(jObj.SelectToken("DataCells")).ToString());

            Cell cell;
            int x, y;

            foreach (JObject jCell in jArr)
            {
                x = jCell["X"].Value<int>();
                y = jCell["Y"].Value<int>();

                if (jCell["IsMine"].Value<bool>())
                    cell = new Mine(_sizeCell, x, y, (Mark)jCell["Mark"].Value<int>());
                else
                    cell = new Cell(_sizeCell, x, y, jCell["IsClose"].Value<bool>(), (Mark)jCell["Mark"].Value<int>());

                cell.CellOpen += OnCellOpen;

                _cells.Add((x, y), cell);
            }

            _countOpenCells = _cells.Values.Where(c => !c.IsClose).Count();
            _mines = _cells.Values.Where(c => c is Mine).Select(c => c as Mine).ToArray();

            SetNumbers();
            Start(true, true);
        }

        public void Save(string path, int seconds, int flags)
        {
            var dataCells = _cells.Values.Select(cell => new
            {
                cell.X,
                cell.Y,
                cell.IsClose,
                cell.Mark,
                cell.CountMinesNearby,
                IsMine = cell is Mine
            });

            var data = JsonConvert.SerializeObject(new
            {
                Level,
                SizeInCells.Width,
                SizeInCells.Height,
                Seconds = seconds,
                Flags = flags,
                DataCells = dataCells
            });

            File.WriteAllText(path, data);
        }
    }
}