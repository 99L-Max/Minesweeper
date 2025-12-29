namespace Minesweeper
{
    class MineExplosion : Mine
    {
        public const int MaxBoomStage = 24;

        public MineExplosion(Cell cell, int delay) : base(cell, delay) { }

        public int BoomStage { get; private set; } = 0;
        public bool IsExploded { get; private set; } = false;

        public override void Update(int deltaTime)
        {
            if (Delay > 0)
            {
                Delay -= deltaTime;
            }
            else if (IsExploded == false)
            {
                IsExploded = ++BoomStage == MaxBoomStage;
            }
        }
    }
}