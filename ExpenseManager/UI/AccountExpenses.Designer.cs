namespace ExpenseManager.UI
{
    partial class AccountExpenses
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TopUIPanelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ControlsUITableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CloneTransactionButton = new System.Windows.Forms.Button();
            this.DeleteTransactionButton = new System.Windows.Forms.Button();
            this.EditTransactionButton = new System.Windows.Forms.Button();
            this.NewTransactionButton = new System.Windows.Forms.Button();
            this.BallanceUIContainer = new System.Windows.Forms.GroupBox();
            this.BallanceUILayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalBallanceCurrencyDisplay = new System.Windows.Forms.Label();
            this.FilteredBallanceCurrencyDisplay = new System.Windows.Forms.Label();
            this.TotalBallanceDisplay = new System.Windows.Forms.Label();
            this.FilteredBallanceDisplay = new System.Windows.Forms.Label();
            this.ControlsPanelContainer = new System.Windows.Forms.GroupBox();
            this.ControlsUILayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ClearFilters = new System.Windows.Forms.Button();
            this.FilterByCategoryButton = new System.Windows.Forms.Button();
            this.FilterByAmountButton = new System.Windows.Forms.Button();
            this.FilterByDateButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MiscellaneousButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.OpenCategoriesPanel = new System.Windows.Forms.Button();
            this.CloseDatabaseButton = new System.Windows.Forms.Button();
            this.TransactionsDataGridView = new ExpenseManager.UI.Components.TransactionsDataGridView();
            this.TransactionDateView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionAmountView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionCategoryView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionDescriptionView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UILayout = new System.Windows.Forms.TableLayoutPanel();
            this.TopUIPanelLayout.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ControlsUITableLayout.SuspendLayout();
            this.BallanceUIContainer.SuspendLayout();
            this.BallanceUILayoutPanel.SuspendLayout();
            this.ControlsPanelContainer.SuspendLayout();
            this.ControlsUILayoutPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MiscellaneousButtonsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsDataGridView)).BeginInit();
            this.UILayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopUIPanelLayout
            // 
            this.TopUIPanelLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopUIPanelLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TopUIPanelLayout.ColumnCount = 4;
            this.TopUIPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.85714F));
            this.TopUIPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.TopUIPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.TopUIPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.TopUIPanelLayout.Controls.Add(this.groupBox1, 0, 0);
            this.TopUIPanelLayout.Controls.Add(this.BallanceUIContainer, 0, 0);
            this.TopUIPanelLayout.Controls.Add(this.ControlsPanelContainer, 2, 0);
            this.TopUIPanelLayout.Controls.Add(this.groupBox2, 3, 0);
            this.TopUIPanelLayout.Location = new System.Drawing.Point(0, 0);
            this.TopUIPanelLayout.Margin = new System.Windows.Forms.Padding(0);
            this.TopUIPanelLayout.Name = "TopUIPanelLayout";
            this.TopUIPanelLayout.RowCount = 1;
            this.TopUIPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TopUIPanelLayout.Size = new System.Drawing.Size(792, 120);
            this.TopUIPanelLayout.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ControlsUITableLayout);
            this.groupBox1.Location = new System.Drawing.Point(285, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.MinimumSize = new System.Drawing.Size(100, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 118);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // ControlsUITableLayout
            // 
            this.ControlsUITableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlsUITableLayout.BackColor = System.Drawing.SystemColors.Control;
            this.ControlsUITableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.ControlsUITableLayout.ColumnCount = 2;
            this.ControlsUITableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlsUITableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlsUITableLayout.Controls.Add(this.CloneTransactionButton, 1, 1);
            this.ControlsUITableLayout.Controls.Add(this.DeleteTransactionButton, 0, 1);
            this.ControlsUITableLayout.Controls.Add(this.EditTransactionButton, 1, 0);
            this.ControlsUITableLayout.Controls.Add(this.NewTransactionButton, 0, 0);
            this.ControlsUITableLayout.Location = new System.Drawing.Point(6, 22);
            this.ControlsUITableLayout.Name = "ControlsUITableLayout";
            this.ControlsUITableLayout.RowCount = 2;
            this.ControlsUITableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlsUITableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlsUITableLayout.Size = new System.Drawing.Size(177, 90);
            this.ControlsUITableLayout.TabIndex = 0;
            // 
            // CloneTransactionButton
            // 
            this.CloneTransactionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloneTransactionButton.Location = new System.Drawing.Point(92, 48);
            this.CloneTransactionButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloneTransactionButton.Name = "CloneTransactionButton";
            this.CloneTransactionButton.Size = new System.Drawing.Size(80, 37);
            this.CloneTransactionButton.TabIndex = 3;
            this.CloneTransactionButton.Text = "Clone";
            this.CloneTransactionButton.UseVisualStyleBackColor = true;
            this.CloneTransactionButton.Click += new System.EventHandler(this.CloneTransactionButton_Click);
            // 
            // DeleteTransactionButton
            // 
            this.DeleteTransactionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteTransactionButton.Location = new System.Drawing.Point(5, 48);
            this.DeleteTransactionButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteTransactionButton.Name = "DeleteTransactionButton";
            this.DeleteTransactionButton.Size = new System.Drawing.Size(80, 37);
            this.DeleteTransactionButton.TabIndex = 2;
            this.DeleteTransactionButton.Text = "Delete";
            this.DeleteTransactionButton.UseVisualStyleBackColor = true;
            this.DeleteTransactionButton.Click += new System.EventHandler(this.DeleteTransactionButton_Click);
            // 
            // EditTransactionButton
            // 
            this.EditTransactionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditTransactionButton.Location = new System.Drawing.Point(92, 5);
            this.EditTransactionButton.Margin = new System.Windows.Forms.Padding(2);
            this.EditTransactionButton.Name = "EditTransactionButton";
            this.EditTransactionButton.Size = new System.Drawing.Size(80, 36);
            this.EditTransactionButton.TabIndex = 1;
            this.EditTransactionButton.Text = "Edit";
            this.EditTransactionButton.UseVisualStyleBackColor = true;
            this.EditTransactionButton.Click += new System.EventHandler(this.EditTransactionButton_Click);
            // 
            // NewTransactionButton
            // 
            this.NewTransactionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewTransactionButton.Location = new System.Drawing.Point(5, 5);
            this.NewTransactionButton.Margin = new System.Windows.Forms.Padding(2);
            this.NewTransactionButton.Name = "NewTransactionButton";
            this.NewTransactionButton.Size = new System.Drawing.Size(80, 36);
            this.NewTransactionButton.TabIndex = 0;
            this.NewTransactionButton.Text = "New";
            this.NewTransactionButton.UseVisualStyleBackColor = true;
            this.NewTransactionButton.Click += new System.EventHandler(this.NewTransactionButton_Click);
            // 
            // BallanceUIContainer
            // 
            this.BallanceUIContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BallanceUIContainer.Controls.Add(this.BallanceUILayoutPanel);
            this.BallanceUIContainer.Location = new System.Drawing.Point(1, 1);
            this.BallanceUIContainer.Margin = new System.Windows.Forms.Padding(0);
            this.BallanceUIContainer.MinimumSize = new System.Drawing.Size(150, 100);
            this.BallanceUIContainer.Name = "BallanceUIContainer";
            this.BallanceUIContainer.Size = new System.Drawing.Size(283, 118);
            this.BallanceUIContainer.TabIndex = 1;
            this.BallanceUIContainer.TabStop = false;
            this.BallanceUIContainer.Text = "Ballance";
            // 
            // BallanceUILayoutPanel
            // 
            this.BallanceUILayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BallanceUILayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.BallanceUILayoutPanel.ColumnCount = 3;
            this.BallanceUILayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.BallanceUILayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BallanceUILayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BallanceUILayoutPanel.Controls.Add(this.label1, 0, 0);
            this.BallanceUILayoutPanel.Controls.Add(this.label3, 0, 1);
            this.BallanceUILayoutPanel.Controls.Add(this.TotalBallanceCurrencyDisplay, 2, 0);
            this.BallanceUILayoutPanel.Controls.Add(this.FilteredBallanceCurrencyDisplay, 2, 1);
            this.BallanceUILayoutPanel.Controls.Add(this.TotalBallanceDisplay, 1, 0);
            this.BallanceUILayoutPanel.Controls.Add(this.FilteredBallanceDisplay, 1, 1);
            this.BallanceUILayoutPanel.Location = new System.Drawing.Point(6, 22);
            this.BallanceUILayoutPanel.Name = "BallanceUILayoutPanel";
            this.BallanceUILayoutPanel.RowCount = 2;
            this.BallanceUILayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BallanceUILayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BallanceUILayoutPanel.Size = new System.Drawing.Size(271, 90);
            this.BallanceUILayoutPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 39);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filtered:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalBallanceCurrencyDisplay
            // 
            this.TotalBallanceCurrencyDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalBallanceCurrencyDisplay.AutoSize = true;
            this.TotalBallanceCurrencyDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TotalBallanceCurrencyDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TotalBallanceCurrencyDisplay.Location = new System.Drawing.Point(224, 0);
            this.TotalBallanceCurrencyDisplay.Name = "TotalBallanceCurrencyDisplay";
            this.TotalBallanceCurrencyDisplay.Size = new System.Drawing.Size(44, 45);
            this.TotalBallanceCurrencyDisplay.TabIndex = 3;
            this.TotalBallanceCurrencyDisplay.Text = "Kč";
            this.TotalBallanceCurrencyDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FilteredBallanceCurrencyDisplay
            // 
            this.FilteredBallanceCurrencyDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilteredBallanceCurrencyDisplay.AutoSize = true;
            this.FilteredBallanceCurrencyDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FilteredBallanceCurrencyDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FilteredBallanceCurrencyDisplay.Location = new System.Drawing.Point(224, 45);
            this.FilteredBallanceCurrencyDisplay.Name = "FilteredBallanceCurrencyDisplay";
            this.FilteredBallanceCurrencyDisplay.Size = new System.Drawing.Size(44, 45);
            this.FilteredBallanceCurrencyDisplay.TabIndex = 4;
            this.FilteredBallanceCurrencyDisplay.Text = "Kč";
            this.FilteredBallanceCurrencyDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalBallanceDisplay
            // 
            this.TotalBallanceDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalBallanceDisplay.AutoSize = true;
            this.TotalBallanceDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TotalBallanceDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TotalBallanceDisplay.Location = new System.Drawing.Point(78, 0);
            this.TotalBallanceDisplay.Name = "TotalBallanceDisplay";
            this.TotalBallanceDisplay.Size = new System.Drawing.Size(140, 45);
            this.TotalBallanceDisplay.TabIndex = 5;
            this.TotalBallanceDisplay.Text = "0";
            this.TotalBallanceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FilteredBallanceDisplay
            // 
            this.FilteredBallanceDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilteredBallanceDisplay.AutoSize = true;
            this.FilteredBallanceDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FilteredBallanceDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilteredBallanceDisplay.Location = new System.Drawing.Point(78, 45);
            this.FilteredBallanceDisplay.Name = "FilteredBallanceDisplay";
            this.FilteredBallanceDisplay.Size = new System.Drawing.Size(140, 45);
            this.FilteredBallanceDisplay.TabIndex = 6;
            this.FilteredBallanceDisplay.Text = "0";
            this.FilteredBallanceDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ControlsPanelContainer
            // 
            this.ControlsPanelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlsPanelContainer.Controls.Add(this.ControlsUILayoutPanel);
            this.ControlsPanelContainer.Location = new System.Drawing.Point(475, 1);
            this.ControlsPanelContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ControlsPanelContainer.MinimumSize = new System.Drawing.Size(100, 100);
            this.ControlsPanelContainer.Name = "ControlsPanelContainer";
            this.ControlsPanelContainer.Size = new System.Drawing.Size(189, 118);
            this.ControlsPanelContainer.TabIndex = 0;
            this.ControlsPanelContainer.TabStop = false;
            this.ControlsPanelContainer.Text = "Filters";
            // 
            // ControlsUILayoutPanel
            // 
            this.ControlsUILayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlsUILayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ControlsUILayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.ControlsUILayoutPanel.ColumnCount = 2;
            this.ControlsUILayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlsUILayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlsUILayoutPanel.Controls.Add(this.ClearFilters, 1, 1);
            this.ControlsUILayoutPanel.Controls.Add(this.FilterByCategoryButton, 0, 1);
            this.ControlsUILayoutPanel.Controls.Add(this.FilterByAmountButton, 1, 0);
            this.ControlsUILayoutPanel.Controls.Add(this.FilterByDateButton, 0, 0);
            this.ControlsUILayoutPanel.Location = new System.Drawing.Point(6, 22);
            this.ControlsUILayoutPanel.Name = "ControlsUILayoutPanel";
            this.ControlsUILayoutPanel.RowCount = 2;
            this.ControlsUILayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlsUILayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlsUILayoutPanel.Size = new System.Drawing.Size(177, 90);
            this.ControlsUILayoutPanel.TabIndex = 0;
            // 
            // ClearFilters
            // 
            this.ClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearFilters.Location = new System.Drawing.Point(92, 48);
            this.ClearFilters.Margin = new System.Windows.Forms.Padding(2);
            this.ClearFilters.Name = "ClearFilters";
            this.ClearFilters.Size = new System.Drawing.Size(80, 37);
            this.ClearFilters.TabIndex = 3;
            this.ClearFilters.Text = "Clear";
            this.ClearFilters.UseVisualStyleBackColor = true;
            this.ClearFilters.Click += new System.EventHandler(this.ClearFilters_Click);
            // 
            // FilterByCategoryButton
            // 
            this.FilterByCategoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterByCategoryButton.Location = new System.Drawing.Point(5, 48);
            this.FilterByCategoryButton.Margin = new System.Windows.Forms.Padding(2);
            this.FilterByCategoryButton.Name = "FilterByCategoryButton";
            this.FilterByCategoryButton.Size = new System.Drawing.Size(80, 37);
            this.FilterByCategoryButton.TabIndex = 2;
            this.FilterByCategoryButton.Text = "By Category";
            this.FilterByCategoryButton.UseVisualStyleBackColor = true;
            this.FilterByCategoryButton.Click += new System.EventHandler(this.FilterByCategoryButton_Click);
            // 
            // FilterByAmountButton
            // 
            this.FilterByAmountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterByAmountButton.Location = new System.Drawing.Point(92, 5);
            this.FilterByAmountButton.Margin = new System.Windows.Forms.Padding(2);
            this.FilterByAmountButton.Name = "FilterByAmountButton";
            this.FilterByAmountButton.Size = new System.Drawing.Size(80, 36);
            this.FilterByAmountButton.TabIndex = 1;
            this.FilterByAmountButton.Text = "By Amount";
            this.FilterByAmountButton.UseVisualStyleBackColor = true;
            this.FilterByAmountButton.Click += new System.EventHandler(this.FilterByAmountButton_Click);
            // 
            // FilterByDateButton
            // 
            this.FilterByDateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterByDateButton.Location = new System.Drawing.Point(5, 5);
            this.FilterByDateButton.Margin = new System.Windows.Forms.Padding(2);
            this.FilterByDateButton.Name = "FilterByDateButton";
            this.FilterByDateButton.Size = new System.Drawing.Size(80, 36);
            this.FilterByDateButton.TabIndex = 0;
            this.FilterByDateButton.Text = "By Date";
            this.FilterByDateButton.UseVisualStyleBackColor = true;
            this.FilterByDateButton.Click += new System.EventHandler(this.FilterByDateButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.MiscellaneousButtonsLayout);
            this.groupBox2.Location = new System.Drawing.Point(668, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox2.Size = new System.Drawing.Size(120, 112);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // MiscellaneousButtonsLayout
            // 
            this.MiscellaneousButtonsLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MiscellaneousButtonsLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.MiscellaneousButtonsLayout.ColumnCount = 1;
            this.MiscellaneousButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MiscellaneousButtonsLayout.Controls.Add(this.OpenCategoriesPanel, 0, 0);
            this.MiscellaneousButtonsLayout.Controls.Add(this.CloseDatabaseButton, 0, 1);
            this.MiscellaneousButtonsLayout.Location = new System.Drawing.Point(3, 22);
            this.MiscellaneousButtonsLayout.Name = "MiscellaneousButtonsLayout";
            this.MiscellaneousButtonsLayout.RowCount = 2;
            this.MiscellaneousButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MiscellaneousButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MiscellaneousButtonsLayout.Size = new System.Drawing.Size(114, 84);
            this.MiscellaneousButtonsLayout.TabIndex = 1;
            // 
            // OpenCategoriesPanel
            // 
            this.OpenCategoriesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenCategoriesPanel.Location = new System.Drawing.Point(5, 5);
            this.OpenCategoriesPanel.Margin = new System.Windows.Forms.Padding(2);
            this.OpenCategoriesPanel.Name = "OpenCategoriesPanel";
            this.OpenCategoriesPanel.Size = new System.Drawing.Size(104, 33);
            this.OpenCategoriesPanel.TabIndex = 0;
            this.OpenCategoriesPanel.Text = "Categories";
            this.OpenCategoriesPanel.UseVisualStyleBackColor = true;
            this.OpenCategoriesPanel.Click += new System.EventHandler(this.OpenCategoriesPanel_Click);
            // 
            // CloseDatabaseButton
            // 
            this.CloseDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseDatabaseButton.Location = new System.Drawing.Point(5, 45);
            this.CloseDatabaseButton.Margin = new System.Windows.Forms.Padding(2);
            this.CloseDatabaseButton.Name = "CloseDatabaseButton";
            this.CloseDatabaseButton.Size = new System.Drawing.Size(104, 34);
            this.CloseDatabaseButton.TabIndex = 1;
            this.CloseDatabaseButton.Text = "Close";
            this.CloseDatabaseButton.UseVisualStyleBackColor = true;
            this.CloseDatabaseButton.Click += new System.EventHandler(this.CloseDatabaseButton_Click);
            // 
            // TransactionsDataGridView
            // 
            this.TransactionsDataGridView.AllowUserToAddRows = false;
            this.TransactionsDataGridView.AllowUserToDeleteRows = false;
            this.TransactionsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TransactionsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TransactionsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TransactionsDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.TransactionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionDateView,
            this.TransactionAmountView,
            this.TransactionCategoryView,
            this.TransactionDescriptionView});
            this.TransactionsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TransactionsDataGridView.Location = new System.Drawing.Point(0, 120);
            this.TransactionsDataGridView.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.TransactionsDataGridView.Name = "TransactionsDataGridView";
            this.TransactionsDataGridView.ReadOnly = true;
            this.TransactionsDataGridView.RowHeadersVisible = false;
            this.TransactionsDataGridView.RowTemplate.Height = 25;
            this.TransactionsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TransactionsDataGridView.ShowCellToolTips = false;
            this.TransactionsDataGridView.ShowEditingIcon = false;
            this.TransactionsDataGridView.Size = new System.Drawing.Size(792, 297);
            this.TransactionsDataGridView.TabIndex = 0;
            // 
            // TransactionDateView
            // 
            this.TransactionDateView.FillWeight = 15F;
            this.TransactionDateView.HeaderText = "Date";
            this.TransactionDateView.Name = "TransactionDateView";
            this.TransactionDateView.ReadOnly = true;
            this.TransactionDateView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TransactionAmountView
            // 
            this.TransactionAmountView.FillWeight = 15F;
            this.TransactionAmountView.HeaderText = "Amount";
            this.TransactionAmountView.Name = "TransactionAmountView";
            this.TransactionAmountView.ReadOnly = true;
            this.TransactionAmountView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TransactionCategoryView
            // 
            this.TransactionCategoryView.FillWeight = 25F;
            this.TransactionCategoryView.HeaderText = "Category";
            this.TransactionCategoryView.Name = "TransactionCategoryView";
            this.TransactionCategoryView.ReadOnly = true;
            this.TransactionCategoryView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TransactionCategoryView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TransactionDescriptionView
            // 
            this.TransactionDescriptionView.FillWeight = 45F;
            this.TransactionDescriptionView.HeaderText = "Description";
            this.TransactionDescriptionView.Name = "TransactionDescriptionView";
            this.TransactionDescriptionView.ReadOnly = true;
            this.TransactionDescriptionView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UILayout
            // 
            this.UILayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UILayout.ColumnCount = 1;
            this.UILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UILayout.Controls.Add(this.TransactionsDataGridView, 0, 1);
            this.UILayout.Controls.Add(this.TopUIPanelLayout, 0, 0);
            this.UILayout.Location = new System.Drawing.Point(0, 0);
            this.UILayout.Margin = new System.Windows.Forms.Padding(0);
            this.UILayout.Name = "UILayout";
            this.UILayout.RowCount = 2;
            this.UILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.UILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UILayout.Size = new System.Drawing.Size(792, 420);
            this.UILayout.TabIndex = 1;
            // 
            // AccountExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UILayout);
            this.DoubleBuffered = true;
            this.Name = "AccountExpenses";
            this.Size = new System.Drawing.Size(792, 420);
            this.TopUIPanelLayout.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ControlsUITableLayout.ResumeLayout(false);
            this.BallanceUIContainer.ResumeLayout(false);
            this.BallanceUILayoutPanel.ResumeLayout(false);
            this.BallanceUILayoutPanel.PerformLayout();
            this.ControlsPanelContainer.ResumeLayout(false);
            this.ControlsUILayoutPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.MiscellaneousButtonsLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsDataGridView)).EndInit();
            this.UILayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox ControlsPanelContainer;
        private TableLayoutPanel ControlsUILayoutPanel;
        private Button ClearFilters;
        private Button FilterByCategoryButton;
        private Button FilterByAmountButton;
        private Button FilterByDateButton;
        private GroupBox BallanceUIContainer;
        private TableLayoutPanel BallanceUILayoutPanel;
        private Label label1;
        private Label label3;
        private TableLayoutPanel TopUIPanelLayout;
        private GroupBox groupBox1;
        private TableLayoutPanel ControlsUITableLayout;
        private Button CloneTransactionButton;
        private Button DeleteTransactionButton;
        private Button EditTransactionButton;
        private Button NewTransactionButton;
        private ExpenseManager.UI.Components.TransactionsDataGridView TransactionsDataGridView;
        private TableLayoutPanel UILayout;
        private GroupBox groupBox2;
        private Button OpenCategoriesPanel;
        private TableLayoutPanel MiscellaneousButtonsLayout;
        private Button CloseDatabaseButton;
        private DataGridViewTextBoxColumn TransactionDateView;
        private DataGridViewTextBoxColumn TransactionAmountView;
        private DataGridViewTextBoxColumn TransactionCategoryView;
        private DataGridViewTextBoxColumn TransactionDescriptionView;
        private Label TotalBallanceCurrencyDisplay;
        private Label FilteredBallanceCurrencyDisplay;
        private Label TotalBallanceDisplay;
        private Label FilteredBallanceDisplay;
    }
}
