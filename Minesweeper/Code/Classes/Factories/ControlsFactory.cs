using Minesweeper.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    static class ControlsFactory
    {
        public static Dictionary<Theme, ButtonTheme> CreateThemeButtons(int totalWidth, Padding margin)
        {
            var images = ResourceImage.CutImagesByEnum<Theme>(Resources.Cell);
            var size = (totalWidth - margin.All * (images.Count + 2)) / images.Count;
            return images.ToDictionary(theme => theme.Key, button => new ButtonTheme(button.Key, button.Value, size));
        }

        public static CheckBoxSettings[] CreateCheckBoxSettings(int parentWidth, int height = 30)
        {
            var dictionary = FileReader.GetDictionary<GameSettings, string>(Resources.DescriptionSettings);
            var width = parentWidth - SystemInformation.VerticalScrollBarWidth;
            var size = new Size(width, height);
            return dictionary.Select(box => new CheckBoxSettings(box.Key) { Text = box.Value, Size = size }).ToArray();
        }

        public static RadioButtonLevel[] CreateRadioButtonLevel(int width, int heigth, Level selectedLevel)
        {
            var levels = EnumFactory.GetValues<Level>();
            var size = new Size(width, heigth);
            return levels.Select(level => new RadioButtonLevel(level) { Size = size, Checked = selectedLevel == level }).ToArray();
        }
    }
}
