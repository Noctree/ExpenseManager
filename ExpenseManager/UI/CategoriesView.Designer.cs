namespace ExpenseManager.UI
{
    partial class CategoriesView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CategoryDataGridView = new ExpenseManager.UI.Components.CategoryDataGridView();
            this.CategoryNameView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryColorView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryDescriptionView = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomUILayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddSelectedButton = new System.Windows.Forms.Button();
            this.EditSelectedButton = new System.Windows.Forms.Button();
            this.CloneSelectedButton = new System.Windows.Forms.Button();
            this.DeleteSelectedButton = new System.Windows.Forms.Button();
            this.CloseFormButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDataGridView)).BeginInit();
            this.BottomUILayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CategoryDataGridView
            // 
            this.CategoryDataGridView.AllowUserToAddRows = false;
            this.CategoryDataGridView.AllowUserToDeleteRows = false;
            this.CategoryDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CategoryDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.CategoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CategoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryNameView,
            this.CategoryColorView,
            this.CategoryDescriptionView});
            this.CategoryDataGridView.Location = new System.Drawing.Point(3, 3);
            this.CategoryDataGridView.Name = "CategoryDataGridView";
            this.CategoryDataGridView.ReadOnly = true;
            this.CategoryDataGridView.RowHeadersVisible = false;
            this.CategoryDataGridView.RowTemplate.Height = 25;
            this.CategoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CategoryDataGridView.Size = new System.Drawing.Size(620, 420);
            this.CategoryDataGridView.TabIndex = 0;
            // 
            // CategoryNameView
            // 
            this.CategoryNameView.FillWeight = 30F;
            this.CategoryNameView.HeaderText = "Name";
            this.CategoryNameView.Name = "CategoryNameView";
            this.CategoryNameView.ReadOnly = true;
            // 
            // CategoryColorView
            // 
            this.CategoryColorView.FillWeight = 20F;
            this.CategoryColorView.HeaderText = "color";
            this.CategoryColorView.Name = "CategoryColorView";
            this.CategoryColorView.ReadOnly = true;
            // 
            // CategoryDescriptionView
            // 
            this.CategoryDescriptionView.FillWeight = 50F;
            this.CategoryDescriptionView.HeaderText = "Description";
            this.CategoryDescriptionView.Name = "CategoryDescriptionView";
            this.CategoryDescriptionView.ReadOnly = true;
            // 
            // BottomUILayout
            // 
            this.BottomUILayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomUILayout.ColumnCount = 2;
            this.BottomUILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomUILayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.BottomUILayout.Controls.Add(this.CategoryDataGridView, 0, 0);
            this.BottomUILayout.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.BottomUILayout.Location = new System.Drawing.Point(12, 12);
            this.BottomUILayout.Name = "BottomUILayout";
            this.BottomUILayout.RowCount = 1;
            this.BottomUILayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomUILayout.Size = new System.Drawing.Size(776, 426);
            this.BottomUILayout.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.AddSelectedButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.EditSelectedButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CloneSelectedButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.DeleteSelectedButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.CloseFormButton, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(651, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(100, 426);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // AddSelectedButton
            // 
            this.AddSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddSelectedButton.Location = new System.Drawing.Point(3, 53);
            this.AddSelectedButton.Name = "AddSelectedButton";
            this.AddSelectedButton.Size = new System.Drawing.Size(94, 24);
            this.AddSelectedButton.TabIndex = 0;
            this.AddSelectedButton.Text = "Add";
            this.AddSelectedButton.UseVisualStyleBackColor = true;
            this.AddSelectedButton.Click += new System.EventHandler(this.AddSelectedButton_Click);
            // 
            // EditSelectedButton
            // 
            this.EditSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditSelectedButton.Location = new System.Drawing.Point(3, 83);
            this.EditSelectedButton.Name = "EditSelectedButton";
            this.EditSelectedButton.Size = new System.Drawing.Size(94, 24);
            this.EditSelectedButton.TabIndex = 1;
            this.EditSelectedButton.Text = "Edit";
            this.EditSelectedButton.UseVisualStyleBackColor = true;
            this.EditSelectedButton.Click += new System.EventHandler(this.EditSelectedButton_Click);
            // 
            // CloneSelectedButton
            // 
            this.CloneSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloneSelectedButton.Location = new System.Drawing.Point(3, 113);
            this.CloneSelectedButton.Name = "CloneSelectedButton";
            this.CloneSelectedButton.Size = new System.Drawing.Size(94, 24);
            this.CloneSelectedButton.TabIndex = 2;
            this.CloneSelectedButton.Text = "Clone";
            this.CloneSelectedButton.UseVisualStyleBackColor = true;
            this.CloneSelectedButton.Click += new System.EventHandler(this.CloneSelectedButton_Click);
            // 
            // DeleteSelectedButton
            // 
            this.DeleteSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteSelectedButton.Location = new System.Drawing.Point(3, 143);
            this.DeleteSelectedButton.Name = "DeleteSelectedButton";
            this.DeleteSelectedButton.Size = new System.Drawing.Size(94, 24);
            this.DeleteSelectedButton.TabIndex = 3;
            this.DeleteSelectedButton.Text = "Delete";
            this.DeleteSelectedButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedButton.Click += new System.EventHandler(this.DeleteSelectedButton_Click);
            // 
            // CloseFormButton
            // 
            this.CloseFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseFormButton.Location = new System.Drawing.Point(3, 233);
            this.CloseFormButton.Name = "CloseFormButton";
            this.CloseFormButton.Size = new System.Drawing.Size(94, 23);
            this.CloseFormButton.TabIndex = 4;
            this.CloseFormButton.Text = "Close";
            this.CloseFormButton.UseVisualStyleBackColor = true;
            this.CloseFormButton.Click += new System.EventHandler(this.CloseFormButton_Click);
            // 
            // CategoriesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BottomUILayout);
            this.Name = "CategoriesView";
            this.Text = "CategoriesView";
            ((System.ComponentModel.ISupportInitialize)(this.CategoryDataGridView)).EndInit();
            this.BottomUILayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ExpenseManager.UI.Components.CategoryDataGridView CategoryDataGridView;
        private TableLayoutPanel BottomUILayout;
        private TableLayoutPanel tableLayoutPanel1;
        private Button AddSelectedButton;
        private Button EditSelectedButton;
        private Button CloneSelectedButton;
        private Button DeleteSelectedButton;
        private Button CloseFormButton;
        private DataGridViewTextBoxColumn CategoryNameView;
        private DataGridViewTextBoxColumn CategoryColorView;
        private DataGridViewTextBoxColumn CategoryDescriptionView;
    }
}