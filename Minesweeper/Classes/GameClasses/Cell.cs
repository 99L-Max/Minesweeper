using System;
using System.Drawing;

namespace Minesweeper
{
    enum Mark { Empty, Flag, Question }

    class Cell
    {
        public readonly int X;
        public readonly int Y;
        public readonly Rectangle ImageRectangle;

        public Action<Cell> CellOpen;

        public Mark Mark { get; private set; }
        public bool IsClose { get; private set; }
        public virtual int CountMinesNearby { set; get; }

        public Cell(Size sizeImg, int x, int y)
        {
            X = x;
            Y = y;
            ImageRectangle = new Rectangle(x * sizeImg.Width, y * sizeImg.Height, sizeImg.Width, sizeImg.Height);

            Reset();
        }

        public Cell(Size sizeImg, int x, int y, bool isClose, Mark mark) : this(sizeImg, x, y)
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
                CellOpen?.Invoke(this);
            }
        }

        public void ChangeMark(bool isShowQuestionMarks)
        {
            if (IsClose)
                switch (Mark)
                {
                    case Mark.Empty:
                        Mark = Mark.Flag;
                        break;

                    case Mark.Flag:
                        Mark = isShowQuestionMarks ? Mark.Question : Mark.Empty;
                        break;

                    default:
                        Mark = Mark.Empty;
                        break;
                }
        }
    }
}