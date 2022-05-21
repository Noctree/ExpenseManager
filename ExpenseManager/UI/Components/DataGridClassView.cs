namespace ExpenseManager.UI.Components;

/// <summary>
/// DataGridView ideal for displaying data of a single class of type <see cref="T"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataGridClassView<T> : DataGridView where T : notnull
{
    public delegate object ObjectValueSelector(T value);
    public delegate int ColumnSortComparer(T a, T b, DataGridViewColumn column);

    private Dictionary<int, ColumnSortComparer> ColumnSortComparers = new Dictionary<int, ColumnSortComparer>();
    protected List<T> dataGridValues = new List<T>();

    public event EventHandler? OnRowsFiltered;
    public event EventHandler? OnRowFilterCleared;

    public IDictionary<int, ObjectValueSelector> ColumnValueSelectors { get; } = new Dictionary<int, ObjectValueSelector>();
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
            if (ColumnValueSelectors.TryGetValue(i, out var selector))
                buffer[i] = selector(value);
            else
                buffer[i] = value;
        }
        Rows.Add(buffer);
        dataGridValues.Add(value);
    }

    public void AddRow(T value) {
        AddRow_Internal(value, CreateObjectBuffer());
    }

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
        for (int i = 0; i < dataGridValues.Count; i++)
            if (valuesToBeRemoved.Contains(dataGridValues[i]))
                toBeRemoved.Add(i);
        SuspendLayout();
        foreach (var index in toBeRemoved)
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

    protected void RegisterColumnSortComparer(int columnIndex, ColumnSortComparer comparer) {
        if (!ColumnSortComparers.TryAdd(columnIndex, comparer))
            throw new ArgumentException($"A different sort comparer for column {columnIndex} has already beed registered", nameof(comparer));
    }

    protected void UnregisterColumnSortComparer(int columnIndex) => ColumnSortComparers.Remove(columnIndex);
    protected bool HasColumnSortComparerForColumn(int columnIndex) => ColumnSortComparers.ContainsKey(columnIndex);
    protected void UnregisterAllColumnSortComparers() => ColumnSortComparers.Clear();

    protected override void OnSortCompare(DataGridViewSortCompareEventArgs e) {
        if (ColumnSortComparers.TryGetValue(e.Column.Index, out var comparer)) {
            e.SortResult = comparer((T)e.CellValue1, (T)e.CellValue2, e.Column);
            e.Handled = true;
        } else
            base.OnSortCompare(e);
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
