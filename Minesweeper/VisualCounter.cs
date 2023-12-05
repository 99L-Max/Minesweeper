using Minesweeper.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    enum TypeCounter
    {
        Watch,
        Flags
    }
    class VisualCounter : PictureBox
    {
        private readonly Font font;
        private readonly Brush brush;
        private readonly Graphics g;
        private readonly Bitmap image;
        private readonly StringFormat stringFormat;
        private readonly RectangleF rectangle;
        private int value;

        public readonly TypeCounter Type;

        public int Value
        {
            set
            {
                this.value = value;
                g.Clear(Color.Transparent);
                g.DrawString(value.ToString(), font, brush, rectangle, stringFormat);
                Image = image;
            }
            get => value;
        }

        public VisualCounter(TypeCounter type)
        {
            Type = type;

            image = new Bitmap(200, 50);
            g = Graphics.FromImage(image);
            font = new Font("System", 32, FontStyle.Bold);
            brush = new SolidBrush(Color.White);
            stringFormat = new StringFormat();

            rectangle = new RectangleF(0, 0, image.Width, image.Height);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Zoom;
            SizeMode = PictureBoxSizeMode.Zoom;
            Dock = DockStyle.Fill;

            ChangeDesign();
        }

        public void ChangeDesign()
        {
            Bitmap backcgroundImage = new Bitmap((Image)Resources.ResourceManager.GetObject($"Counter_{Design.Theme}"), image.Width, image.Height);

            using (Graphics g = Graphics.FromImage(backcgroundImage))
            {
                Size sizeIcon = new Size(image.Width / 4, image.Height);
                Bitmap icon;
                int xIcon;

                if (Type == TypeCounter.Watch)
                {
                    icon = new Bitmap(Resources.Watch, sizeIcon);
                    xIcon = 0;
                }
                else
                {
                    icon = new Bitmap(Resources.Mine, sizeIcon);
                    xIcon = backcgroundImage.Width - icon.Width;
                    g.FillEllipse(new SolidBrush(Color.White), xIcon, 0, icon.Width, icon.Height);
                }

                g.DrawImage(icon, xIcon, 0);
                icon.Dispose();

                BackgroundImage = backcgroundImage;
            }
        }
    }
}
