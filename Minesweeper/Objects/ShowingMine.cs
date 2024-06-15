using System;
using System.Drawing;

namespace Minesweeper
{
    class ShowingMine : Mine
    {
        private int _delay;

        public int Alpha { get; private set; } = 0;
        public bool Visible { get; private set; } = false;
        public bool IsShowed { get; private set; } = false;

        public ShowingMine(Size imgSize, int x, int y, int delay) : base(imgSize, x, y, Mark.Empty)
        {
            _delay = delay;
        }

        public void Update(int deltaTime, int dAlpha)
        {
            if (!IsShowed)
                if (_delay > 0)
                {
                    _delay -= deltaTime;
                }
                else if (Visible)
                {
                    Alpha = Math.Max(Alpha - dAlpha, 0);
                    IsShowed = Alpha == 0;
                }
                else
                {
                    Alpha = Math.Min(Alpha + dAlpha, byte.MaxValue);
                    Visible = Alpha == byte.MaxValue;
                }
        }
    }
}
