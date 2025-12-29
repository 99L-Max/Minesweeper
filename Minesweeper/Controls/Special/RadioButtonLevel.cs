using System.Windows.Forms;

namespace Minesweeper
{
    class RadioButtonLevel : RadioButton
    {
        public RadioButtonLevel(Level level)
        {
            Level = level;
            Text = SettingsData.GetLevelDescription(level);
        }

        public Level Level { get; }
    }
}
