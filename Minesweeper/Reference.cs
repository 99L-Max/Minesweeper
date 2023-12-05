using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Reference : Form
    {
        public Reference()
        {
            InitializeComponent();

            Color foreColor = Color.DarkBlue;
            Bitmap image = Properties.Resources.Reference;
            Graphics g = Graphics.FromImage(image);
            Brush brush = new SolidBrush(foreColor);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(
                Environment.UserName, new Font("System", 20, FontStyle.Bold), brush,
                new RectangleF(225, 235, 600, 40), stringFormat
                );

            DateTime date = DateTime.Now;
            Font font = new Font("System", 18);

            g.DrawString($"{date.Day:d2}", font, brush, new RectangleF(95, 550, 50, 32), stringFormat);
            g.DrawString(date.ToString("MMMM"), font, brush, new RectangleF(155, 550, 160, 32), stringFormat);
            g.DrawString($"{date.Year % 100:d2}", font, brush, new RectangleF(335, 550, 50, 32), stringFormat);

            using (Pen pen = new Pen(foreColor, 3))
            using (Bitmap smile = new Bitmap(60, 60))
            {
                g = Graphics.FromImage(smile);
                g.Clear(Color.Transparent);
                g.DrawEllipse(pen, 0, 0, 50, 50);
                g.FillEllipse(brush, 12, 15, 7, 7);
                g.FillEllipse(brush, 32, 15, 7, 7);
                g.DrawCurve(pen, new PointF[] { new PointF(10, 30), new PointF(25, 40), new PointF(40, 30) });
                g = Graphics.FromImage(image);
                g.DrawImage(smile, 800, 515);
            }

            g.Dispose();
            brush.Dispose();

            pictureBox.Image = image;
        }
    }
}
