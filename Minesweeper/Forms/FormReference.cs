using Minesweeper.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class FormReference : Form
    {
        public FormReference()
        {
            InitializeComponent();

            var foreColor = Color.DarkBlue;
            var image = Resources.Reference;
            var date = DateTime.Now;

            using (var g = Graphics.FromImage(image))
            using (var font = new Font("System", 18))
            using (var fontTitle = new Font("System", 20))
            using (var smile = Resources.Smile)
            {
                TextRenderer.DrawText(g, Environment.UserName, fontTitle, new Rectangle(225, 235, 600, 40), foreColor);

                TextRenderer.DrawText(g, $"{date.Day:d2}", font, new Rectangle(95, 550, 50, 32), foreColor);
                TextRenderer.DrawText(g, $"{date:MMMM}", font, new Rectangle(155, 550, 160, 32), foreColor);
                TextRenderer.DrawText(g, $"{date.Year % 100:d2}", font, new Rectangle(335, 550, 50, 32), foreColor);

                g.DrawImage(smile, 800, 515, 60, 60);

                _pb.Image = image;
            }
        }
    }
}
