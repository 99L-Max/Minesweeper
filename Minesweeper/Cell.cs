using System.Drawing;

namespace Minesweeper
{
    enum Mark
    {
        Empty,
        Flag,
        Question
    }

    class Cell
    {
        public readonly int X;
        public readonly int Y;
        public readonly Rectangle Rectangle;

        public delegate void EventCellOpen(Cell sender);
        public event EventCellOpen CellOpen;

        public bool IsClose { private set; get; }
        public Mark Mark { private set; get; }
        public virtual int CountMinesNearby { set; get; }

        public Cell(Size imgSize, int x, int y)
        {
            X = x;
            Y = y;
            Rectangle = new Rectangle(x * imgSize.Width, y * imgSize.Height, imgSize.Width, imgSize.Height);

            Reset();
        }

        public Cell(Size imgSize, int x, int y, bool isClose, Mark mark) : this(imgSize, x, y)
        {
            IsClose = isClose;
            Mark = mark;
        }

        public virtual void Reset()
        {
            IsClose = true;
            Mark = Mark.Empty;
        }

        public void Open()
        {
            if (IsClose)
            {
                IsClose = false;
                Mark = Mark.Empty;
                CellOpen.Invoke(this);
            }
        }

        public void ChangeMark()
        {
            if (IsClose)
                switch (Mark)
                {
                    case Mark.Empty:
                        Mark = Mark.Flag;
                        break;
                    case Mark.Flag:
                        Mark = Parameters.IsShowQuestionMarks ? Mark.Question : Mark.Empty;
                        break;
                    default:
                        Mark = Mark.Empty;
                        break;
                }
        }
    }
}