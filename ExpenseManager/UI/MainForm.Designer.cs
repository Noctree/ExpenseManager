namespace ExpenseManager.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusBarContainer = new ExpenseManager.UI.Components.ProgressBarStripDisplay();
            this.TopToolStrip = new System.Windows.Forms.ToolStrip();
            this.OpenAccountButton = new System.Windows.Forms.ToolStripButton();
            this.ImportUserButton = new System.Windows.Forms.ToolStripButton();
            this.ExportUserButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ExportAsCsvButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseProgramButton = new System.Windows.Forms.ToolStripButton();
            this.AccountTabsContainer = new System.Windows.Forms.TabControl();
            this.label1 = new System.Windows.Forms.Label();
            this.ExportDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.TopToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBarContainer
            // 
            this.StatusBarContainer.AllowMerge = false;
            this.StatusBarContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBarContainer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.StatusBarContainer.Location = new System.Drawing.Point(0, 436);
            this.StatusBarContainer.Name = "StatusBarContainer";
            this.StatusBarContainer.ProgressBarWidth = 150;
            this.StatusBarContainer.Size = new System.Drawing.Size(984, 25);
            this.StatusBarContainer.TabIndex = 0;
            this.StatusBarContainer.Text = "progressBarStripDisplay1";
            // 
            // TopToolStrip
            // 
            this.TopToolStrip.AllowMerge = false;
            this.TopToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TopToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenAccountButton,
            this.ImportUserButton,
            this.ExportUserButton,
            this.toolStripSeparator1,
            this.CloseProgramButton});
            this.TopToolStrip.Location = new System.Drawing.Point(0, 0);
            this.TopToolStrip.Name = "TopToolStrip";
            this.TopToolStrip.ShowItemToolTips = false;
            this.TopToolStrip.Size = new System.Drawing.Size(984, 25);
            this.TopToolStrip.TabIndex = 1;
            this.TopToolStrip.Text = "TopToolStrip";
            // 
            // OpenAccountButton
            // 
            this.OpenAccountButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OpenAccountButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenAccountButton.Image")));
            this.OpenAccountButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenAccountButton.Name = "OpenAccountButton";
            this.OpenAccountButton.Size = new System.Drawing.Size(40, 22);
            this.OpenAccountButton.Text = "Open";
            this.OpenAccountButton.Click += new System.EventHandler(this.OnOpenAccount);
            // 
            // ImportUserButton
            // 
            this.ImportUserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ImportUserButton.Image = ((System.Drawing.Image)(resources.GetObject("ImportUserButton.Image")));
            this.ImportUserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImportUserButton.Name = "ImportUserButton";
            this.ImportUserButton.Size = new System.Drawing.Size(47, 22);
            this.ImportUserButton.Text = "Import";
            // 
            // ExportUserButton
            // 
            this.ExportUserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExportUserButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportAsCsvButton});
            this.ExportUserButton.Image = ((System.Drawing.Image)(resources.GetObject("ExportUserButton.Image")));
            this.ExportUserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportUserButton.Name = "ExportUserButton";
            this.ExportUserButton.Size = new System.Drawing.Size(54, 22);
            this.ExportUserButton.Text = "Export";
            // 
            // ExportAsCsvButton
            // 
            this.ExportAsCsvButton.Name = "ExportAsCsvButton";
            this.ExportAsCsvButton.Size = new System.Drawing.Size(180, 22);
            this.ExportAsCsvButton.Text = "As CSV";
            this.ExportAsCsvButton.Click += new System.EventHandler(this.ExportAsCsvButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CloseProgramButton
            // 
            this.CloseProgramButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CloseProgramButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseProgramButton.Image")));
            this.CloseProgramButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseProgramButton.Name = "CloseProgramButton";
            this.CloseProgramButton.Size = new System.Drawing.Size(40, 22);
            this.CloseProgramButton.Text = "Close";
            this.CloseProgramButton.Click += new System.EventHandler(this.CloseProgramButton_Click);
            // 
            // AccountTabsContainer
            // 
            this.AccountTabsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountTabsContainer.Location = new System.Drawing.Point(0, 28);
            this.AccountTabsContainer.Name = "AccountTabsContainer";
            this.AccountTabsContainer.SelectedIndex = 0;
            this.AccountTabsContainer.Size = new System.Drawing.Size(984, 405);
            this.AccountTabsContainer.TabIndex = 2;
            this.AccountTabsContainer.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(984, 461);
            this.label1.TabIndex = 3;
            this.label1.Text = "No document open";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExportDatabaseDialog
            // 
            this.ExportDatabaseDialog.DefaultExt = "csv";
            this.ExportDatabaseDialog.Filter = "CSV Files (*.csv)|*.csv";
            this.ExportDatabaseDialog.Title = "Export Location";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.TopToolStrip);
            this.Controls.Add(this.StatusBarContainer);
            this.Controls.Add(this.AccountTabsContainer);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Expense Manager";
            this.Shown += new System.EventHandler(this.OnUIInitialized);
            this.Resize += new System.EventHandler(this.OnResize);
            this.TopToolStrip.ResumeLayout(false);
            this.TopToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExpenseManager.UI.Components.ProgressBarStripDisplay StatusBarContainer;
        private ToolStrip TopToolStrip;
        private TabControl AccountTabsContainer;
        private Label label1;
        private ToolStripButton OpenAccountButton;
        private ToolStripButton ImportUserButton;
        private ToolStripDropDownButton ExportUserButton;
        private ToolStripMenuItem ExportAsCsvButton;
        private ToolStripButton CloseProgramButton;
        private ToolStripSeparator toolStripSeparator1;
        private SaveFileDialog ExportDatabaseDialog;
    }
}