using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Mine : Cell
    {
        private const int DeltaAlpha = 15;

        public const int CountStagesBoom = 3;

        public override int CountMinesNearby { get => -1; set => _ = -1; }
        public int DetonationTime { private set; get; }
        public int StageBoom { private set; get; }
        public int Alpha { private set; get; }
        public bool Visible { private set; get; }

        public Mine(Size imgSize, int x, int y, Mark mark) : base(imgSize, x, y, true, mark)
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            StageBoom = -1;
            DetonationTime = -1;
            Visible = false;
        }

        public override void Reset()
        {
            base.Reset();
            SetDefaultValues();
        }

        public void SetUpBoom(int detonationTime) => DetonationTime = detonationTime;

        public void ReduceTime(int deltaTime) => DetonationTime -= deltaTime;

        public async void Boom(int frame)
        {
            while (StageBoom < CountStagesBoom)
            {
                StageBoom++;
                await Task.Delay(frame);
            }
        }

        public async void ShowYourself(int frame)
        {
            Alpha = 0;
            int da = DeltaAlpha;

            do
            {
                Alpha += da;

                if (Alpha == byte.MaxValue)
                {
                    da = -da;
                    Visible = true;
                }

                await Task.Delay(frame);
            }
            while (Alpha != 0);
        }

        public static Dictionary<int, Brush> GetFillBrushes()
        {
            Dictionary<int, Brush> brushes = new Dictionary<int, Brush>();

            for (int alpha = 0; alpha <= byte.MaxValue; alpha += DeltaAlpha)
                brushes.Add(alpha, new SolidBrush(Color.FromArgb(alpha, Color.White)));

            return brushes;
        }
    }
}