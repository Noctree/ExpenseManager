namespace ExpenseManager.UI.Components;

public partial class TextboxDialog : Form
{
    private const string DefaultInvalidInputMessage = "Invalid input";

    /// <summary>
    /// Title of the dialog
    /// </summary>
    public string Title {
        get => base.Text;
        set => base.Text = value;
    }
    /// <summary>
    /// Message that gets displayed when InputVerifier returns false
    /// </summary>
    public string InvalidInputMessage { get; set; } = DefaultInvalidInputMessage;
    /// <summary>
    /// Text entered by the user
    /// </summary>
    public new string Text { get; private set; } = String.Empty;
    /// <summary>
    /// If not null then this method is used to verify the text input, if the method returns false a messagebox with the InvalidInputMessage is shown
    /// </summary>
    public Func<string, bool>? InputVerifier { get; set; }
    public TextboxDialog() {
        InitializeComponent();
    }

    public new DialogResult ShowDialog() {
        Textbox.Clear();
        Textbox.ClearUndo();
        return base.ShowDialog();
    }

    private void OnCancel(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void OnConfirm(object sender, EventArgs e) {
        if (InputVerifier != null && !InputVerifier(Textbox.Text)) {
            MessageBoxUtils.ShowError(InvalidInputMessage);
            return;
        }
        DialogResult = DialogResult.OK;
        Text = Textbox.Text;
        Close();
    }
}
