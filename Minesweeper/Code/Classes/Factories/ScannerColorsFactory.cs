using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper
{
    class ScannerColorsFactory
    {
        private readonly Dictionary<Theme, Color> _colors;

        public ScannerColorsFactory() 
        {
            _colors = new Dictionary<Theme, Color>
            {
                { Theme.Blue, Color.Blue },
                { Theme.Green, Color.Lime },
                { Theme.Purple, Color.Magenta }
            };
        }

        public Color GetColor(Theme theme)
        {
            return _colors.ContainsKey(theme) ? _colors[theme] : Color.Gray;
        }
    }
}
