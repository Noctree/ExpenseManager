namespace ExpenseManager.UI
{
    partial class OpenDatabaseDialog
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
        private void InitializeComponent()
        {
            this.AccountsListView = new System.Windows.Forms.ListBox();
            this.OpenUserButton = new System.Windows.Forms.Button();
            this.CreateNewButton = new System.Windows.Forms.Button();
            this.CancelOpenButton = new System.Windows.Forms.Button();
            this.UILayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DeleteUserButton = new System.Windows.Forms.Button();
            this.UILayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccountsListView
            // 
            this.AccountsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountsListView.FormattingEnabled = true;
            this.AccountsListView.ItemHeight = 15;
            this.AccountsListView.Location = new System.Drawing.Point(0, 0);
            this.AccountsListView.Margin = new System.Windows.Forms.Padding(0);
            this.AccountsListView.Name = "AccountsListView";
            this.AccountsListView.Size = new System.Drawing.Size(131, 214);
            this.AccountsListView.TabIndex = 0;
            this.AccountsListView.DoubleClick += new System.EventHandler(this.OnAccountListViewDoubleClick);
            // 
            // OpenUserButton
            // 
            this.OpenUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenUserButton.Location = new System.Drawing.Point(13, 113);
            this.OpenUserButton.Name = "OpenUserButton";
            this.OpenUserButton.Size = new System.Drawing.Size(99, 24);
            this.OpenUserButton.TabIndex = 1;
            this.OpenUserButton.Text = "Open";
            this.OpenUserButton.UseVisualStyleBackColor = true;
            this.OpenUserButton.Click += new System.EventHandler(this.OnConfirm);
            // 
            // CreateNewButton
            // 
            this.CreateNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateNewButton.Location = new System.Drawing.Point(13, 3);
            this.CreateNewButton.Name = "CreateNewButton";
            this.CreateNewButton.Size = new System.Drawing.Size(99, 24);
            this.CreateNewButton.TabIndex = 2;
            this.CreateNewButton.Text = "Create New";
            this.CreateNewButton.UseVisualStyleBackColor = true;
            this.CreateNewButton.Click += new System.EventHandler(this.OnCreateNewAccount);
            // 
            // CancelOpenButton
            // 
            this.CancelOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelOpenButton.Location = new System.Drawing.Point(13, 143);
            this.CancelOpenButton.Name = "CancelOpenButton";
            this.CancelOpenButton.Size = new System.Drawing.Size(99, 24);
            this.CancelOpenButton.TabIndex = 3;
            this.CancelOpenButton.Text = "Cancel";
            this.CancelOpenButton.UseVisualStyleBackColor = true;
            this.CancelOpenButton.Click += new System.EventHandler(this.OnCancel);
            // 
            // UILayout
            // 
            this.UILayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UILayout.ColumnCount = 2;
            this.UILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UILayout.Controls.Add(this.AccountsListView, 0, 0);
            this.UILayout.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.UILayout.Location = new System.Drawing.Point(12, 12);
            this.UILayout.Name = "UILayout";
            this.UILayout.RowCount = 1;
            this.UILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UILayout.Size = new System.Drawing.Size(262, 224);
            this.UILayout.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.CreateNewButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.OpenUserButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.CancelOpenButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.DeleteUserButton, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(134, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(125, 218);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // DeleteUserButton
            // 
            this.DeleteUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteUserButton.Location = new System.Drawing.Point(13, 33);
            this.DeleteUserButton.Name = "DeleteUserButton";
            this.DeleteUserButton.Size = new System.Drawing.Size(99, 24);
            this.DeleteUserButton.TabIndex = 4;
            this.DeleteUserButton.Text = "Delete Account";
            this.DeleteUserButton.UseVisualStyleBackColor = true;
            this.DeleteUserButton.Click += new System.EventHandler(this.DeleteUserButton_Click);
            // 
            // OpenDatabaseDialog
            // 
            this.AcceptButton = this.OpenUserButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 248);
            this.Controls.Add(this.UILayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenDatabaseDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Account";
            this.TopMost = true;
            this.UILayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox AccountsListView;
        private Button OpenUserButton;
        private Button CreateNewButton;
        private Button CancelOpenButton;
        private TableLayoutPanel UILayout;
        private TableLayoutPanel tableLayoutPanel1;
        private Button DeleteUserButton;
    }
}