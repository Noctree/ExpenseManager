namespace ExpenseManager.UI.Components;

partial class ImportAccountDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.UILayout = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TransactionsFileNameField = new System.Windows.Forms.TextBox();
            this.CategoriesFileNameField = new System.Windows.Forms.TextBox();
            this.AccountNameField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectTransactionsButton = new System.Windows.Forms.Button();
            this.SelectCategoriesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CancellationButton = new System.Windows.Forms.Button();
            this.ConfirmationButton = new System.Windows.Forms.Button();
            this.OpenTransactionsFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.OpenCategoriesFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.UILayout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UILayout
            // 
            this.UILayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UILayout.ColumnCount = 3;
            this.UILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.UILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.UILayout.Controls.Add(this.label1, 0, 0);
            this.UILayout.Controls.Add(this.label2, 0, 1);
            this.UILayout.Controls.Add(this.TransactionsFileNameField, 1, 0);
            this.UILayout.Controls.Add(this.CategoriesFileNameField, 1, 1);
            this.UILayout.Controls.Add(this.AccountNameField, 1, 2);
            this.UILayout.Controls.Add(this.label3, 0, 2);
            this.UILayout.Controls.Add(this.SelectTransactionsButton, 2, 0);
            this.UILayout.Controls.Add(this.SelectCategoriesButton, 2, 1);
            this.UILayout.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.UILayout.Location = new System.Drawing.Point(12, 12);
            this.UILayout.Name = "UILayout";
            this.UILayout.RowCount = 4;
            this.UILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.UILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.UILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.UILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UILayout.Size = new System.Drawing.Size(441, 133);
            this.UILayout.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exported Transactions:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exported Categories:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TransactionsFileNameField
            // 
            this.TransactionsFileNameField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionsFileNameField.Location = new System.Drawing.Point(153, 3);
            this.TransactionsFileNameField.Name = "TransactionsFileNameField";
            this.TransactionsFileNameField.Size = new System.Drawing.Size(240, 23);
            this.TransactionsFileNameField.TabIndex = 2;
            // 
            // CategoriesFileNameField
            // 
            this.CategoriesFileNameField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoriesFileNameField.Location = new System.Drawing.Point(153, 33);
            this.CategoriesFileNameField.Name = "CategoriesFileNameField";
            this.CategoriesFileNameField.Size = new System.Drawing.Size(240, 23);
            this.CategoriesFileNameField.TabIndex = 3;
            // 
            // AccountNameField
            // 
            this.AccountNameField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountNameField.Location = new System.Drawing.Point(153, 63);
            this.AccountNameField.Name = "AccountNameField";
            this.AccountNameField.Size = new System.Drawing.Size(240, 23);
            this.AccountNameField.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Account Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectTransactionsButton
            // 
            this.SelectTransactionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectTransactionsButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectTransactionsButton.Location = new System.Drawing.Point(399, 3);
            this.SelectTransactionsButton.Name = "SelectTransactionsButton";
            this.SelectTransactionsButton.Size = new System.Drawing.Size(39, 24);
            this.SelectTransactionsButton.TabIndex = 6;
            this.SelectTransactionsButton.Text = "📁";
            this.SelectTransactionsButton.UseVisualStyleBackColor = true;
            this.SelectTransactionsButton.Click += new System.EventHandler(this.SelectTransactionsButton_Click);
            // 
            // SelectCategoriesButton
            // 
            this.SelectCategoriesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectCategoriesButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectCategoriesButton.Location = new System.Drawing.Point(399, 33);
            this.SelectCategoriesButton.Name = "SelectCategoriesButton";
            this.SelectCategoriesButton.Size = new System.Drawing.Size(39, 24);
            this.SelectCategoriesButton.TabIndex = 7;
            this.SelectCategoriesButton.Text = "📁";
            this.SelectCategoriesButton.UseVisualStyleBackColor = true;
            this.SelectCategoriesButton.Click += new System.EventHandler(this.SelectCategoriesButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.UILayout.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CancellationButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ConfirmationButton, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(435, 37);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // CancellationButton
            // 
            this.CancellationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancellationButton.Location = new System.Drawing.Point(110, 3);
            this.CancellationButton.Name = "CancellationButton";
            this.CancellationButton.Size = new System.Drawing.Size(94, 31);
            this.CancellationButton.TabIndex = 0;
            this.CancellationButton.Text = "Cancel";
            this.CancellationButton.UseVisualStyleBackColor = true;
            this.CancellationButton.Click += new System.EventHandler(this.CancellationButton_Click);
            // 
            // ConfirmationButton
            // 
            this.ConfirmationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmationButton.Location = new System.Drawing.Point(230, 3);
            this.ConfirmationButton.Name = "ConfirmationButton";
            this.ConfirmationButton.Size = new System.Drawing.Size(94, 31);
            this.ConfirmationButton.TabIndex = 1;
            this.ConfirmationButton.Text = "Confirm";
            this.ConfirmationButton.UseVisualStyleBackColor = true;
            this.ConfirmationButton.Click += new System.EventHandler(this.ConfirmationButton_Click);
            // 
            // OpenTransactionsFileDialog
            // 
            this.OpenTransactionsFileDialog.DefaultExt = "csv";
            this.OpenTransactionsFileDialog.Filter = "CSV Files (*.csv)|.csv";
            this.OpenTransactionsFileDialog.Title = "Select transactions file";
            // 
            // OpenCategoriesFileDialog
            // 
            this.OpenCategoriesFileDialog.DefaultExt = "csv";
            this.OpenCategoriesFileDialog.Filter = "CSV Files (*.csv)|.csv";
            this.OpenCategoriesFileDialog.Title = "Select categories file";
            // 
            // ImportAccountDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 157);
            this.Controls.Add(this.UILayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ImportAccountDialog";
            this.Text = "Import Account";
            this.UILayout.ResumeLayout(false);
            this.UILayout.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private TableLayoutPanel UILayout;
    private Label label1;
    private Label label2;
    private TextBox TransactionsFileNameField;
    private TextBox CategoriesFileNameField;
    private TextBox AccountNameField;
    private Label label3;
    private Button SelectTransactionsButton;
    private Button SelectCategoriesButton;
    private TableLayoutPanel tableLayoutPanel2;
    private Button CancellationButton;
    private Button ConfirmationButton;
    private OpenFileDialog OpenTransactionsFileDialog;
    private OpenFileDialog OpenCategoriesFileDialog;
}