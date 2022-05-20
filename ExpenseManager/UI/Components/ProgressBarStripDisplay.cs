namespace ExpenseManager.UI;

public class ProgressBarStripDisplay : ToolStrip
{
    private List<ProgressBarContainer> progressBars = new List<ProgressBarContainer>();
    public int ProgressBarWidth { get; set; } = 100;

    public ProgressBarContainer AddProgressBar(string taskName, ProgressBarStyle progressBarStyle = ProgressBarStyle.Continuous) {
        var label = new ToolStripLabel(taskName);
        var separator = new ToolStripSeparator();
        var progressbar = new ToolStripProgressBar(taskName + "progressBar");

        progressbar.ProgressBar.Step = 1;
        progressbar.ProgressBar.Style = progressBarStyle;
        progressbar.AutoSize = true;
        progressbar.ProgressBar.MaximumSize = new Size(ProgressBarWidth, progressbar.ProgressBar.MaximumSize.Height);
        progressbar.Width = ProgressBarWidth;

        Items.Add(label);
        Items.Add(progressbar);
        Items.Add(separator);

        var container = new ProgressBarContainer(this, progressbar, separator, label);
        progressBars.Add(container);
        return container;
    }

    public void DestroyProgressBar(ProgressBarContainer container) {
        foreach (var control in container.GetControls()) {
            Items.Remove(control);
            control.Dispose();
        }
        progressBars.Remove(container);
    }

    public void RemoveAllProgressBars() {
        int barCount = progressBars.Count;
        for (int i = 0; i < barCount; i++)
            progressBars[0].Dispose();
    }

    protected override void Dispose(bool disposing) {
        RemoveAllProgressBars();
        base.Dispose(disposing);
    }

    public class ProgressBarContainer : IDisposable
    {
        private ProgressBarStripDisplay parent;
        private ToolStripProgressBar progressBar;
        private ToolStripSeparator separator;
        private ToolStripLabel label;
        private bool disposedValue;

        public ProgressBarContainer(ProgressBarStripDisplay parent, ToolStripProgressBar progressBar, ToolStripSeparator separator, ToolStripLabel label) {
            this.parent = parent;
            this.progressBar = progressBar;
            this.separator = separator;
            this.label = label;
        }

        public IEnumerable<ToolStripItem> GetControls() {
            if (disposedValue)
                yield break;
            yield return progressBar;
            yield return separator;
            yield return label;
        }

        public void SetProgress(float progress, float maxValue) => progressBar.ProgressBar.Value = (int)Math.Floor(100 * (progress / maxValue));
        public void SetLabelText(string text) => label.Text = text;
        public void SetLabelColor(Color color) => label.ForeColor = color;
        public void SetProgressBarColor(Color color) => progressBar.ForeColor = color;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects)
                }

                parent.DestroyProgressBar(this);
                disposedValue = true;
            }
        }

        ~ProgressBarContainer() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
