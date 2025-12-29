using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Minesweeper
{
    class BrushesFactory
    {
        private readonly Color[] _colors;

        public BrushesFactory()
        {
            _colors = new Color[]
            {
                Color.Blue, Color.Green, Color.Red, Color.DarkBlue,
                Color.DarkRed, Color.DarkCyan, Color.OrangeRed, Color.Purple
            };
        }

        public List<SolidBrush> GetBrushes()
        {
            return _colors.Select(color => new SolidBrush(color)).ToList();
        }

        public Dictionary<int, Brush> GetAlphaBrushes(Color color, int deltaAlpha)
        {
            var brushes = new Dictionary<int, Brush>();

            for (int alpha = 0; alpha <= byte.MaxValue; alpha += deltaAlpha)
                brushes.Add(alpha, new SolidBrush(Color.FromArgb(alpha, color)));

            return brushes;
        }
    }
}
