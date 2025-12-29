using System.Windows.Forms;

namespace Minesweeper
{
    class CheckBoxSettings : CheckBox
    {
        public CheckBoxSettings(GameSettings settings)
        {
            Settings = settings;
            AutoSize = false;
            UseCompatibleTextRendering = true;
        }

        public GameSettings Settings { get; }
    }
}
