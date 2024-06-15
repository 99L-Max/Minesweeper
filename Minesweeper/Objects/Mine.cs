using System.Drawing;

namespace Minesweeper
{
    class Mine : Cell
    {
        public override int CountMinesNearby { get => -1; set => _ = -1; }

        public bool IsActivated { get; private set; } = false;

        public Mine(Size imgSize, int x, int y, Mark mark) : base(imgSize, x, y, true, mark) { }

        public override void Reset()
        {
            base.Reset();
            IsActivated = false;
        }

        public void Activate() =>
            IsActivated = true;
    }
}