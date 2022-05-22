using System.Threading;

namespace ExpenseManager.Utilities;
internal static class MessageBoxUtils
{
    public static void ShowMessageBoxNonBlocking(string message, string caption = "Message", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information) {
        var thread = new Thread(() => MessageBox.Show(message, caption, buttons, icon));
        thread.Start();
    }
}
