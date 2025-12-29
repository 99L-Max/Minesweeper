using Newtonsoft.Json;
using System.Drawing;

namespace Minesweeper
{
    class MapCell : Cell
    {
        public MapCell(int x, int y, Size imageSize) : base(x, y, imageSize) { }

        [JsonConstructor]
        public MapCell(int x, int y, Rectangle imageRectangle, CellMark mark, bool isClosed, bool hasMine, int minesNearbyCount) : base(x, y, imageRectangle)
        {
            Mark = mark;
            IsClosed = isClosed;
            HasMine = hasMine;
            MinesNearbyCount = minesNearbyCount;
        }

        public CellMark Mark { get; private set; } = CellMark.Empty;
        public bool IsClosed { get; private set; } = true;
        public bool HasMine { get; private set; } = false;
        public int MinesNearbyCount { get; private set; } = 0;

        public void Reset()
        {
            IsClosed = true;
            Mark = CellMark.Empty;
        }

        public void Open()
        {
            if (IsClosed)
            {
                IsClosed = false;
                Mark = CellMark.Empty;
            }
        }

        public void ChangeMark(bool isShowQuestionMarks)
        {
            if (IsClosed)
            {
                switch (Mark)
                {
                    case CellMark.Empty:
                        Mark = CellMark.Flag;
                        break;

                    case CellMark.Flag:
                        Mark = isShowQuestionMarks ? CellMark.Question : CellMark.Empty;
                        break;

                    default:
                        Mark = CellMark.Empty;
                        break;
                }
            }
        }

        public void UpdateMinesCount()
        {
            MinesNearbyCount = HasMine ? -1 : MinesNearbyCount + 1;
        }

        public void AddMine()
        {
            HasMine = true;
            MinesNearbyCount = -1;
        }
    }
}