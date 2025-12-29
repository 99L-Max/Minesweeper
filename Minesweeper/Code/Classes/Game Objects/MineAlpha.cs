using System;

namespace Minesweeper
{
    class MineAlpha : Mine
    {
        private readonly int _deltaAlpha;

        public MineAlpha(Cell cell, int delay, int deltaAlpha) : base(cell, delay)
        {
            _deltaAlpha = deltaAlpha;
        }

        public int Alpha { get; private set; } = 0;
        public bool Visible { get; private set; } = false;
        public bool IsShowed { get; private set; } = false;

        public override void Update(int deltaTime)
        {
            if (IsShowed == false)
            {
                if (Delay > 0)
                {
                    Delay -= deltaTime;
                }
                else if (Visible)
                {
                    Alpha = Math.Max(Alpha - _deltaAlpha, 0);
                    IsShowed = Alpha == 0;
                }
                else
                {
                    Alpha = Math.Min(Alpha + _deltaAlpha, byte.MaxValue);
                    Visible = Alpha == byte.MaxValue;
                }
            }
        }
    }
}
