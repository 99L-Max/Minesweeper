using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class FormReference : Form
    {
        public FormReference()
        {
            InitializeComponent();

            _labelUserName.Text = Environment.UserName;
            _labelDay.Text = $"{DateTime.Now.Day:d2}";
            _labelMonth.Text = $"{DateTime.Now:MMMM}";
            _labelYear.Text = $"{DateTime.Now.Year % 100:d2}";
        }
    }
}
