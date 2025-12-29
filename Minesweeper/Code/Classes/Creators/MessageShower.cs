using System;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{
    static class MessageShower
    {
        public static DialogResult ShowQuestion(string resourceText, bool isCancel = false)
        {
            return Show(resourceText, isCancel ? MessageBoxButtons.YesNoCancel : MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowInformation(string resourceText)
        {
            return Show(resourceText, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static DialogResult Show(string resourceText, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            var lines = resourceText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            var caption = lines.Length > 0 ? lines[0] : string.Empty;
            var text = lines.Length > 1 ? string.Join("\n", lines.Skip(1)) : string.Empty;

            return MessageBox.Show(text, caption, buttons, icon);
        }
    }
}
