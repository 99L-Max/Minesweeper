using Minesweeper.Properties;
using System.Collections.Generic;
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

        public static List<Image> GetStagesBoom(Size imgSize)
        {
            var stagesBoom = new List<Image>();

            for (int i = 0; i < 24; i++)
                stagesBoom.Add(new Bitmap((Image)Resources.ResourceManager.GetObject($"Boom_Stage{i:d2}"), imgSize));

            return stagesBoom;
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
