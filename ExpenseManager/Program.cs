using ExpenseManager.UI;

namespace ExpenseManager;

internal static class Program
{
    private const string DatabasePath = "Data/";
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}