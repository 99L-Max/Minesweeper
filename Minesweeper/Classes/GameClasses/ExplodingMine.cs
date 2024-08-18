using System.Drawing;

namespace Minesweeper
{
    class ExplodingMine : Mine
    {
        private readonly int _maxStageBoom;

        public int Delay { get; private set; }
        public int StageBoom { get; private set; } = 0;
        public bool IsExploded { get; private set; } = false;

        public ExplodingMine(Size imgSize, int x, int y, int delay, int maxStageBoom) : base(imgSize, x, y, Mark.Empty)
        {
            Delay = delay;
            _maxStageBoom = maxStageBoom;
        }

        public void Update(int deltaTime)
        {
            if (Delay > 0)
            {
                Delay -= deltaTime;
            }
            else if (!IsExploded)
            {
                IsExploded = ++StageBoom == _maxStageBoom;
            }
        }
    }
}
