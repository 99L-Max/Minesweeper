namespace Minesweeper
{
    abstract class Mine : Cell
    {
        public Mine(Cell cell, int delay) : base(cell)
        {
            Delay = delay;
        }

        public int Delay { get; protected set; }

        public abstract void Update(int deltaTime);
    }
}
