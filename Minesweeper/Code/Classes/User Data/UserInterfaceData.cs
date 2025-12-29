using Newtonsoft.Json;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    class UserInterfaceData : ISave
    {
        public UserInterfaceData() { }

        public UserInterfaceData(Form form)
        {
            Size = form.Size;
            Location = form.Location;
            WindowState = form.WindowState;
        }

        [JsonConstructor]
        public UserInterfaceData(Size size, Point location, FormWindowState windowState)
        {
            Size = size;
            Location = location;
            WindowState = windowState;
        }

        public Size Size { get; } = new Size(450, 450);
        public Point Location { get; } = new Point(100, 100);
        public FormWindowState WindowState { get; } = FormWindowState.Normal;

        public void Save()
        {
            FileWriter.Save(this, GameDirectory.UserInterfaceDataFilePath);
        }
    }
}
