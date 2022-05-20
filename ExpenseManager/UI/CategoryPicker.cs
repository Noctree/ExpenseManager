using System;
using System.Collections.Generic;
using ExpenseManager.DataObjects;

namespace ExpenseManager.UI;
public partial class CategoryPicker : Form
{
    private List<Category> categories;
    public int SelectedCategoryIndex { get; set; } = 0;
    public Category SelectedCategory => categories[SelectedCategoryIndex];
    public CategoryPicker() {
        InitializeComponent();
    }

    public DialogResult ShowDialog(List<Category> categories) {
        this.categories = categories;
        CategoryComboBox.Items.Clear();
        CategoryComboBox.Items.AddRange(categories.ConvertAll(c => c.Name).ToArray());
        CategoryComboBox.SelectedIndex = SelectedCategoryIndex < categories.Count? SelectedCategoryIndex : categories.Count - 1;
        return base.ShowDialog();
    }

    private void ConfirmButton_Click(object sender, EventArgs e) {
        SelectedCategoryIndex = CategoryComboBox.SelectedIndex;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e) {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
