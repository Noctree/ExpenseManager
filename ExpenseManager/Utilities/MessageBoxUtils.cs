using System.Threading;

namespace ExpenseManager.Utilities;
internal static class MessageBoxUtils
{
    public static void ShowMessageBoxNonBlocking(string message, string caption = "Message", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information) {
        var thread = new Thread(() => MessageBox.Show(message, caption, buttons, icon));
        thread.Start();
    }

    public static void ShowError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

    public static void ShowException(string message, Exception exception) {
        if (MessageBox.Show($"The following error has occured:\n{message}\n\n\nDo you want to see the technical details of the problem?",
            "Error",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Error) == DialogResult.Yes) {
            MessageBox.Show($"Message: {exception.Message}\n\n\nException Details: {exception}", "Error Details", MessageBoxButtons.OK);
        }
    }

    public static bool ShowConfirmation(string message, bool warning = false) {
        var result = MessageBox.Show(message, "Are you sure?", MessageBoxButtons.OKCancel, warning ? MessageBoxIcon.Warning : MessageBoxIcon.None);
        return result == DialogResult.OK;
    }
}
