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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CreateNewButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AccountsListView
            // 
            this.AccountsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AccountsListView.FormattingEnabled = true;
            this.AccountsListView.ItemHeight = 15;
            this.AccountsListView.Location = new System.Drawing.Point(12, 12);
            this.AccountsListView.Name = "AccountsListView";
            this.AccountsListView.Size = new System.Drawing.Size(172, 214);
            this.AccountsListView.TabIndex = 0;
            this.AccountsListView.DoubleClick += new System.EventHandler(this.OnAccountListViewDoubleClick);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(190, 63);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(84, 23);
            this.ConfirmButton.TabIndex = 1;
            this.ConfirmButton.Text = "Open";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.OnConfirm);
            // 
            // CreateNewButton
            // 
            this.CreateNewButton.Location = new System.Drawing.Point(190, 12);
            this.CreateNewButton.Name = "CreateNewButton";
            this.CreateNewButton.Size = new System.Drawing.Size(84, 23);
            this.CreateNewButton.TabIndex = 2;
            this.CreateNewButton.Text = "Create New";
            this.CreateNewButton.UseVisualStyleBackColor = true;
            this.CreateNewButton.Click += new System.EventHandler(this.OnCreateNewAccount);
            // 
            // AbortButton
            // 
            this.AbortButton.Location = new System.Drawing.Point(190, 92);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(84, 23);
            this.AbortButton.TabIndex = 3;
            this.AbortButton.Text = "Cancel";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.OnCancel);
            // 
            // OpenDatabaseDialog
            // 
            this.AcceptButton = this.ConfirmButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 248);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.CreateNewButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.AccountsListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenDatabaseDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Account";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox AccountsListView;
        private Button ConfirmButton;
        private Button CreateNewButton;
        private Button AbortButton;
    }
}