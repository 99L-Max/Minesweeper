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
        private const int Frame = 50;

        private readonly Size sizeCell;
        private readonly Bitmap emptyImage;
        private readonly Focus focus;
        private readonly Dictionary<(int, int), Cell> cells;

        private bool isFinishAnimation;
        private bool isWin;
        private int countOpenCells;
        private Bitmap imgMap;
        private Bitmap imgMine;
        private Dictionary<Mark, Bitmap> imgCells;
        private Graphics g;
        private Mine[] mines;

        public delegate void EventGameStarted();
        public delegate void EventGameOver(Level level, bool isWin, Cell sender);
        public delegate void EventCounterChanged(bool isIncreased);

        public event EventGameStarted GameStarted;
        public event EventGameOver GameOver;
        public event EventCounterChanged CounterChanged;

        public Level Level { private set; get; }
        public Size SizeInCells { private set; get; }
        public bool IsFirstMove { private set; get; }
        public bool IsGameOver { private set; get; }
        public bool IsGameStarted { private set; get; }
        public int CountMines => mines.Length;

        public Map()
        {
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.Zoom;
            BackgroundImageLayout = ImageLayout.Zoom;
            Dock = DockStyle.Fill;
            Font = new Font("", 32, FontStyle.Bold);

            sizeCell = new Size(50, 50);
            emptyImage = new Bitmap(sizeCell.Width, sizeCell.Height);
            focus = new Focus();
            cells = new Dictionary<(int, int), Cell>();

            focus.MouseDoubleClick += OnCellMouseDoubleClick;
            focus.MouseUp += OnCellMouseUp;
            focus.CheckCell += (x, y) => cells[(x, y)].IsClose;

            SizeChanged += (s, e) => focus.Visible = false;
            MouseMove += (s, e) => focus.SetLocation(e.X, e.Y);
            Click += (s, e) => isFinishAnimation = true;

            SetDesign();
        }

        private void SetBackground(Bitmap bitmap)
        {
            BackgroundImage?.Dispose();
            BackgroundImage = bitmap;
        }

        private async void Start(bool isSaved, bool areMinesSet)
        {
            ClearFocus();
            IsGameStarted = IsGameOver = false;

            imgMap?.Dispose();
            g?.Dispose();

            imgMap = new Bitmap(sizeCell.Width * SizeInCells.Width, sizeCell.Height * SizeInCells.Height);
            g = Graphics.FromImage(imgMap);
            g.CompositingMode = CompositingMode.SourceCopy;

            if (!isSaved && Parameters.IsShowAnimation)
            {
                using (Bitmap openCell = new Bitmap(Resources.OpenCell, sizeCell))
                    foreach (var c in cells.Values)
                        g.DrawImage(openCell, c.Rectangle);

                Image = imgMap;

                Random rnd = new Random();
                Stack<Cell> stack = new Stack<Cell>(cells.Values.OrderBy(c => rnd.Next()));

                Sound.Play(Resources.Start);

                int i = 0, iMax = cells.Count / 8;

                do
                {
                    g.DrawImage(imgCells[Mark.Empty], stack.Pop().Rectangle);

                    if (++i > iMax)
                    {
                        i = 0;
                        Image = imgMap;
                        await Task.Delay(Frame);
                    }
                } while (stack.Count > 0);
            }
            else
            {
                cells.Values.Where(c => c.IsClose).ToList().ForEach(c => g.DrawImage(imgCells[c.Mark], c.Rectangle));
            }

            Image = imgMap;

            if (!areMinesSet)
                focus.MouseClick += SetMines;

            focus.MouseClick += OnCellMouseClick;
            Controls.Add(focus);

            IsGameStarted = true;
        }

        public void NewGame()
        {
            Level = Parameters.Level;

            if (cells.Count > 0)
            {
                foreach (var cell in cells.Values)
                    cell.CellOpen -= CellOpen;

                cells.Clear();
            }

            SizeInCells = new Size(Parameters.MapSize.Width, Parameters.MapSize.Height);

            for (int x = 0; x < SizeInCells.Width; x++)
            {
                for (int y = 0; y < SizeInCells.Height; y++)
                {
                    cells.Add((x, y), new Cell(sizeCell, x, y));
                    cells[(x, y)].CellOpen += CellOpen;
                }
            }

            mines = new Mine[Parameters.CountMines];

            countOpenCells = 0;
            IsFirstMove = true;

            Start(false, false);
        }

        public void Restart()
        {
            foreach (var cell in cells.Values)
                cell.Reset();

            IsFirstMove = true;
            countOpenCells = 0;

            Start(false, true);
        }

        private void FinishGame(bool isWin, Cell sender)
        {
            ClearFocus();

            IsGameOver = true;
            this.isWin = isWin;

            GameOver.Invoke(Level, isWin, sender);
        }

        private List<Cell> GetNeighbors(Cell cell)
        {
            List<Cell> list = new List<Cell>();

            for (int x = cell.X - 1; x <= cell.X + 1; x++)
                for (int y = cell.Y - 1; y <= cell.Y + 1; y++)
                    if ((x != cell.X || y != cell.Y) && cells.ContainsKey((x, y)))
                        list.Add(cells[(x, y)]);

            return list;
        }

        private void SetNumbers()
        {
            foreach (var mine in mines)
                GetNeighbors(mine).ForEach(c => c.CountMinesNearby++);

            Color[] colors = new Color[]
            {
                Color.Blue, Color.Green, Color.Red, Color.DarkBlue,
                Color.DarkRed, Color.DarkCyan, Color.OrangeRed, Color.Purple
            };

            List<SolidBrush> brushes = colors.Select(c => new SolidBrush(c)).ToList();

            Bitmap background = new Bitmap(sizeCell.Width * SizeInCells.Width, sizeCell.Height * SizeInCells.Height);

            using (Graphics g = Graphics.FromImage(background))
            using (Bitmap openCell = new Bitmap(Resources.OpenCell, sizeCell))
            using (Bitmap mine = new Bitmap(Resources.Mine_Exploded, sizeCell))
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                foreach (var cell in cells.Values)
                {
                    g.DrawImage(openCell, cell.Rectangle);

                    if (cell.CountMinesNearby > 0)
                        g.DrawString($"{cell.CountMinesNearby}", Font, brushes[cell.CountMinesNearby - 1], cell.Rectangle, format);
                    else if (cell is Mine)
                        g.DrawImage(mine, cell.Rectangle);
                }

                SetBackground(background);
            }

            brushes.ForEach(b => b.Dispose());
        }

        private void ClearFocus()
        {
            focus.MouseClick -= SetMines;
            focus.MouseClick -= OnCellMouseClick;

            Controls.Clear();
        }

        private void CellOpen(Cell sender)
        {
            focus.BackColor = Color.Transparent;
            IsFirstMove = false;

            if (sender is Mine)
            {
                FinishGame(false, sender);
            }
            else
            {
                g.DrawImage(emptyImage, sender.Rectangle);
                Image = imgMap;

                if (++countOpenCells == cells.Count - mines.Length)
                    FinishGame(true, sender);
            }
        }

        private void OnCellMouseClick(object sender, MouseEventArgs e)
        {
            Cell cell = cells[focus.KeyCell];
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
            Cell cell = cells[focus.KeyCell];
            if (cell.IsClose && e.Button == MouseButtons.Right)
            {
                if (cell.Mark != Mark.Question)
                    CounterChanged.Invoke(cell.Mark != Mark.Empty);

                cell.ChangeMark();

                g.DrawImage(imgCells[cell.Mark], cell.Rectangle);
                Image = imgMap;
            }
        }

        private async void OnCellMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Cell cell = cells[focus.KeyCell];

            if (!cell.IsClose && cell.CountMinesNearby > 0 && cell.CountMinesNearby < 8)
            {
                List<Cell> list = GetNeighbors(cell);

                if (list.Where(c => c.Mark == Mark.Flag).Count() == cell.CountMinesNearby)
                {
                    foreach (var c in list)
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

                    if (Parameters.IsShowAnimation)
                        using (Bitmap cross = new Bitmap(Resources.Cross, sizeCell))
                            for (int i = 0; i < 6; i++)
                            {
                                g.DrawImage((i & 1) == 0 ? cross : emptyImage, cell.Rectangle);
                                Image = imgMap;
                                await Task.Delay(100);
                            }
                }
            }
        }

        private void SetMines(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                focus.MouseClick -= SetMines;

                Cell cell = cells[focus.KeyCell];

                int x1 = cell.X - 1;
                int x2 = cell.X + 1;
                int y1 = cell.Y - 1;
                int y2 = cell.Y + 1;

                Random rnd = new Random();
                List<Cell> listMines = cells.Values.Where(m => m.X < x1 || m.X > x2 || m.Y < y1 || m.Y > y2).OrderBy(m => rnd.Next()).Take(mines.Length).ToList();
                Cell mine;

                for (int i = 0; i < mines.Length; i++)
                {
                    mine = listMines[i];
                    mine.CellOpen -= CellOpen;
                    cells[(mine.X, mine.Y)] = mines[i] = new Mine(sizeCell, mine.X, mine.Y, mine.Mark);
                    mines[i].CellOpen += CellOpen;
                }

                SetNumbers();

                GameStarted.Invoke();
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

            Image = imgMap;
        }

        private void DrawMines(bool isWin)
        {
            if (isWin)
                foreach (var mine in mines)
                    g.DrawImage(mine.Mark == Mark.Flag ? imgCells[Mark.Flag] : imgMine, mine.Rectangle);
            else
                foreach (var mine in mines)
                    g.DrawImage(emptyImage, mine.Rectangle);

            Image = imgMap;
        }

        public async Task ShowGameOver(Cell sender)
        {
            if (!isWin)
            {
                Bitmap background = new Bitmap(BackgroundImage);

                using (Bitmap mine = new Bitmap(Resources.Mine_Activated, sizeCell))
                using (Graphics g = Graphics.FromImage(background))
                {
                    g.DrawImage(mine, sender.Rectangle);
                    SetBackground(background);
                }

                using (Bitmap notMine = new Bitmap(Resources.NotMine))
                    foreach (var cell in cells.Values)
                        if (cell.Mark == Mark.Flag && !(cell is Mine))
                            g.DrawImage(notMine, cell.Rectangle);
            }

            if (Parameters.IsShowAnimation)
                await (isWin ? Victory() : Loss(sender));
            else
                DrawMines(isWin);
        }

        private async Task Victory()
        {
            isFinishAnimation = false;

            g.CompositingMode = CompositingMode.SourceOver;

            Dictionary<int, Brush> brushes = Mine.GetFillBrushes();

            using (Bitmap imgScan = Scanner.GetBitmap(imgMap.Width, sizeCell.Height, Design.Theme))
            using (Bitmap imgFrame = new Bitmap(imgMap.Width, imgMap.Height))
            using (Graphics graphics = Graphics.FromImage(imgFrame))
            {
                int dy = imgMap.Height * Frame / 3000;
                int yScan = imgMap.Height;

                foreach (var mine in mines)
                    g.DrawImage(imgCells[Mark.Empty], mine.Rectangle);

                Image = imgMap;

                Stack<Mine> stack = new Stack<Mine>(mines.OrderBy(m => m.Y));
                Queue<Mine> queue = new Queue<Mine>();

                Sound.Play(Resources.Win);

                do
                {
                    foreach (var mine in queue)
                    {
                        g.DrawImage(mine.Visible ? imgMine : imgCells[Mark.Empty], mine.Rectangle);
                        g.FillRectangle(brushes[mine.Alpha], mine.Rectangle);
                    }

                    graphics.Clear(Color.Transparent);
                    graphics.DrawImage(imgMap, 0, 0);

                    if (yScan > -imgScan.Height)
                    {
                        graphics.DrawImage(imgScan, 0, yScan);

                        while (stack.Count > 0 && yScan <= stack.Peek().Rectangle.Y)
                        {
                            stack.Peek().ShowYourself(Frame);
                            queue.Enqueue(stack.Pop());
                        }

                        yScan -= dy;
                    }

                    Image = imgFrame;

                    while (queue.Count > 0 && queue.Peek().Alpha == 0)
                        queue.Dequeue();

                    await Task.Delay(Frame);

                    if (isFinishAnimation)
                    {
                        DrawMines(true);
                        break;
                    }
                } while (yScan > -imgScan.Height || queue.Count > 0);

                foreach (var b in brushes.Values)
                    b.Dispose();
            }
        }

        private async Task Loss(Cell sender)
        {
            isFinishAnimation = false;

            List<Bitmap> stagesBoom = new List<Bitmap>();

            for (int i = 0; i < Mine.CountStagesBoom; i++)
                stagesBoom.Add(new Bitmap((Image)Resources.ResourceManager.GetObject($"Boom_Stage{i}"), sizeCell));

            int dx, dy;

            foreach (var mine in mines)
            {
                dx = sender.X - mine.X;
                dy = sender.Y - mine.Y;

                mine.SetUpBoom(7 * Frame * (int)Math.Sqrt(dx * dx + dy * dy));

                g.DrawImage(imgMine, mine.Rectangle);
            }

            Image = imgMap;

            Stack<Mine> stack = new Stack<Mine>(mines.OrderByDescending(m => m.DetonationTime));
            Queue<Mine> queue = new Queue<Mine>();
            bool isPlaySound;
            int delayBoom = 4 * Frame;

            do
            {
                foreach (var mine in stack)
                    mine.ReduceTime(Frame);

                isPlaySound = true;

                while (stack.Count > 0 && stack.Peek().DetonationTime <= 0)
                {
                    stack.Peek().Boom(delayBoom);
                    queue.Enqueue(stack.Pop());

                    if (isPlaySound)
                    {
                        isPlaySound = false;
                        Sound.Play(Resources.Boom);
                    }
                }

                foreach (var mine in queue)
                    if (mine.StageBoom < Mine.CountStagesBoom)
                        g.DrawImage(stagesBoom[mine.StageBoom], mine.Rectangle);

                while (queue.Count > 0 && queue.Peek().StageBoom >= Mine.CountStagesBoom)
                    g.DrawImage(emptyImage, queue.Dequeue().Rectangle);

                Image = imgMap;

                await Task.Delay(Frame);

                if (isFinishAnimation)
                {
                    DrawMines(false);
                    break;
                }
            }
            while (stack.Count > 0 || queue.Count > 0);

            stagesBoom.ForEach(s => s.Dispose());
        }

        private void SetDesign()
        {
            imgCells?.Values.ToList().ForEach(c => c.Dispose());
            imgCells = new Dictionary<Mark, Bitmap>();

            using (Image theme = (Image)Resources.ResourceManager.GetObject($"Cell_{Design.Theme}"))
                foreach (Mark key in Enum.GetValues(typeof(Mark)))
                    imgCells.Add(key, new Bitmap(theme, sizeCell.Width, sizeCell.Height));

            Graphics g;
            g = Graphics.FromImage(imgCells[Mark.Flag]);

            using (Bitmap flag = new Bitmap(Resources.Flag, sizeCell))
                g.DrawImage(flag, 0, 0);

            g = Graphics.FromImage(imgCells[Mark.Question]);

            using (Bitmap question = new Bitmap(Resources.QuestionMark, sizeCell))
                g.DrawImage(question, 0, 0);

            imgMine?.Dispose();
            imgMine = new Bitmap(imgCells[Mark.Empty]);

            g = Graphics.FromImage(imgMine);

            using (Bitmap mine = new Bitmap(Resources.Mine, sizeCell))
                g.DrawImage(mine, 0, 0);

            g.Dispose();
        }

        public void ChangeDesign()
        {
            SetDesign();
            cells.Values.Where(c => c.IsClose).ToList().ForEach(c => g.DrawImage(imgCells[c.Mark], c.Rectangle));
            Image = imgMap;
        }

        public new void Resize() => focus.Resize(ClientSize, imgMap.Size, SizeInCells);

        public void OpenSavedGame(JObject jObj)
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
                    cell = new Mine(sizeCell, x, y, (Mark)jCell["Mark"].Value<int>());
                else
                    cell = new Cell(sizeCell, x, y, jCell["IsClose"].Value<bool>(), (Mark)jCell["Mark"].Value<int>());

                if (!cell.IsClose && cell is Mine)
                    throw new Exception();

                cell.CellOpen += CellOpen;

                cells.Add((x, y), cell);
            }

            countOpenCells = cells.Values.Where(c => !c.IsClose).Count();
            mines = cells.Values.Where(c => c is Mine).Select(c => c as Mine).ToArray();

            SetNumbers();
            Start(true, true);
        }

        public void SaveGame(string path, int seconds, int flags)
        {
            var dataCells = cells.Values.Select(cell => new
            {
                cell.X,
                cell.Y,
                cell.IsClose,
                cell.Mark,
                cell.CountMinesNearby,
                IsMine = cell is Mine
            });

            string data = JsonConvert.SerializeObject(new
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