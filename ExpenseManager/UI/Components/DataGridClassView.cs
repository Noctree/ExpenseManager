namespace ExpenseManager.UI.Components;

/// <summary>
/// DataGridView ideal for displaying data of a single class of type <see cref="T"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataGridClassView<T> : DataGridView where T : notnull
{
    public delegate object ObjectValueSelector(T value);
    public delegate int ColumnSortComparer(T a, T b);

    private readonly Dictionary<int, ColumnSortComparer> ColumnSortComparers = new();
    private readonly Dictionary<int, ObjectValueSelector> ColumnValueSelectors = new();
    protected List<T> dataGridValues = new();

    public event EventHandler? OnRowsFiltered;
    public event EventHandler? OnRowFilterCleared;

    public IReadOnlyList<T> Values => dataGridValues.AsReadOnly();

    private object[] CreateObjectBuffer() => new object[Columns.Count];

    public void AddRows(IEnumerable<T> values) {
        object[] objectsBuffer = CreateObjectBuffer();

        SuspendLayout();
        foreach (T obj in values)
            AddRow_Internal(obj, objectsBuffer);
        ResumeLayout(true);
    }

    protected void AddRow_Internal(T value, object[] buffer) {
        for (int i = 0; i < buffer.Length; i++) {
            buffer[i] = ColumnValueSelectors.TryGetValue(i, out var selector) ? selector(value) : value;
        }
        Rows.Add(buffer);
        dataGridValues.Add(value);
    }

    public void AddRow(T value) => AddRow_Internal(value, CreateObjectBuffer());

    public void RemoveRow(T value) {
        int index = dataGridValues.IndexOf(value);
        if (index == -1)
            return;
        RemoveAt(index);
    }

    public void RemoveAt(int index) {
        dataGridValues.RemoveAt(index);
        Rows.RemoveAt(index);
    }

    public void RemoveRows(IList<T> values) {
        var toBeRemoved = new List<int>();
        var valuesToBeRemoved = new HashSet<T>(values);
        for (int i = 0; i < dataGridValues.Count; i++) {
            if (valuesToBeRemoved.Contains(dataGridValues[i]))
                toBeRemoved.Add(i);
        }

        SuspendLayout();
        foreach (var index in (toBeRemoved as IEnumerable<int>).Reverse())
            RemoveAt(index);
        ResumeLayout(true);
    }

    public IEnumerable<T> GetVisibleValues() {
        for (int i = 0; i < dataGridValues.Count; ++i) {
            if (Rows[i].Visible)
                yield return dataGridValues[i];
        }
    }

    public void FilterRows(Predicate<T> predicate) {
        for (int i = 0; i < dataGridValues.Count; ++i) {
            Rows[i].Visible = predicate(dataGridValues[i]);
        }
        OnRowsFiltered?.Invoke(this, EventArgs.Empty);
    }

    public void ClearFilter() {
        for (int i = 0; i < Rows.Count; ++i) {
            Rows[i].Visible = true;
        }
        OnRowFilterCleared?.Invoke(this, EventArgs.Empty);
    }

    public void ClearRows() {
        dataGridValues.Clear();
        Rows.Clear();
    }

    protected void RegisterColumnSortComparer(int columnIndex, ColumnSortComparer comparer) {
        if (!ColumnSortComparers.TryAdd(columnIndex, comparer))
            throw new ArgumentException($"A different sort comparer for column {columnIndex} has already beed registered", nameof(comparer));
    }

    protected void UnregisterColumnSortComparer(int columnIndex) => ColumnSortComparers.Remove(columnIndex);
    protected bool HasColumnSortComparerForColumn(int columnIndex) => ColumnSortComparers.ContainsKey(columnIndex);
    protected void UnregisterAllColumnSortComparers() => ColumnSortComparers.Clear();

    protected void RegisterColumnValueSelector(int columnIndex, ObjectValueSelector selector) {
        if (ColumnValueSelectors.ContainsKey(columnIndex))
            ColumnValueSelectors[columnIndex] = selector;
        else
            ColumnValueSelectors.Add(columnIndex, selector);
    }

    protected void UnregisterColumnValueSelector(int columnIndex) => ColumnValueSelectors.Remove(columnIndex);
    protected void UnregisterAllColumnValueSelectors() => ColumnValueSelectors.Clear();

    protected override void OnSortCompare(DataGridViewSortCompareEventArgs e) {
        if (ColumnSortComparers.TryGetValue(e.Column.Index, out var comparer)) {
            e.SortResult = comparer((T)e.CellValue1, (T)e.CellValue2);
            e.Handled = true;
        }
        else {
            base.OnSortCompare(e);
        }
    }

    protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e) {
        if (HasColumnSortComparerForColumn(e.ColumnIndex)) {
            for (int i = 0; i < Columns.Count; ++i) {
                if (i != e.ColumnIndex)
                    Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            var direction = Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection;
            direction = (SortOrder)(((int)direction + 1) % 3);
            if (direction != SortOrder.None)
                Sort(Columns[e.ColumnIndex], direction == SortOrder.Ascending ? System.ComponentModel.ListSortDirection.Ascending : System.ComponentModel.ListSortDirection.Descending);
            Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direction;
        }
        base.OnColumnHeaderMouseClick(e);
    }

    protected override void Dispose(bool disposing) {
        if (disposing) {
            dataGridValues.Clear();
            ColumnValueSelectors.Clear();
            UnregisterAllColumnSortComparers();
            OnRowsFiltered = null;
            OnRowFilterCleared = null;
        }
        base.Dispose(disposing);
    }
}
