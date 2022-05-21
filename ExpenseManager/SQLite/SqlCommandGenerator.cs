namespace ExpenseManager.SQLite;

public static class SqlCommandGenerator
{
    private static StringBuilder sb = new StringBuilder();
    public static string CreateTable(string name, IReadOnlyList<ISqlColumnDescriptor> columns) {
        sb.Clear();
        sb.Append("CREATE TABLE ");
        sb.Append(name);
        sb.Append('(');
        for (int i = 0; i < columns.Count; ++i) {
            sb.Append(columns[i].ToSqlColumnDefinition());
            if (i < columns.Count - 1) {
                sb.Append(',');
                sb.Append(' ');
            }
        }
        sb.Append(')');
        sb.Append(';');
        return sb.ToString();
    }

    public static string CreateSelectCommand(SqlTable table, IReadOnlyList<string> columns) {
        var descriptors = table.ColumnTypes;
        sb.Clear();
        AppendBasicSelectCommand(sb, table, columns);
        sb.Append(";");
        return sb.ToString();
    }

    public static string CreateSelectCommandWithPredicate(SqlTable table, IReadOnlyList<string> columns, string predicate) {
        var descriptors = table.ColumnTypes;
        sb.Clear();
        AppendBasicSelectCommand(sb, table, columns);
        sb.Append(" WHERE ");
        sb.Append(predicate);
        sb.Append(';');
        return sb.ToString();
    }

    private static void AppendBasicSelectCommand(StringBuilder sb, SqlTable table, IReadOnlyList<string> columns) {
        var descriptors = table.ColumnTypes;
        sb.Append("SELECT ");
        for (int i = 0; i < columns.Count; ++i) {
            var descriptor = descriptors.GetDescriptorByName(columns[i]);
            sb.Append(descriptor.Name);
            if (i < columns.Count - 1) {
                sb.Append(',');
                sb.Append(' ');
            }
        }
        sb.Append(" FROM ");
        sb.Append(table.TableName);
    }

    public static string CreateInsertCommand(SqlTable table, SqlParam[] parameters) {
        var descriptors = table.ColumnTypes;
        sb.Clear();
        sb.Append("INSERT INTO ");
        sb.Append(table.TableName);
        sb.Append(' ');
        sb.Append('(');
        for (int i = 0; i < parameters.Length; ++i) {
            var param = parameters[i];
            var descriptor = descriptors.GetDescriptorByName(param.Name);
            sb.Append(param.Name);
            if (i < parameters.Length - 1) {
                sb.Append(',');
                sb.Append(' ');
            }
        }
        sb.Append(") VALUES (");
        for (int i = 0; i < parameters.Length; ++i) {
            var param = parameters[i];
            var descriptor = descriptors.GetDescriptorByName(param.Name);
            sb.Append(descriptor.Converter.ToSql(param.Value));
            if (i < parameters.Length - 1) {
                sb.Append(',');
                sb.Append(' ');
            }
        }
        sb.Append(')');
        sb.Append(';');
        return sb.ToString();
    }

    public static string CreateInsertCommand<T>(SqlTable table, IObjectSqlDeconstructor<T> deconstructor, T target) {
        var descriptors = table.TableDescriptor.GetDescriptorsByNames(deconstructor.ColumnNames);
        sb.Clear();
        CreateInsertHeader(table, deconstructor, sb);
        sb.Append(") VALUES (");
        for (int i = 0; i < deconstructor.FieldCount; ++i) {
            var value = deconstructor.GetFieldValueAt(target, i);
            sb.Append(descriptors[i].Converter.ToSql(value));
            if (i < deconstructor.FieldCount - 1) {
                sb.Append(',');
                sb.Append(' ');
            }
        }
        sb.Append(')');
        sb.Append(';');
        return sb.ToString();
    }

    public static string CreateInsertCommand<T>(SqlTable table, IObjectSqlDeconstructor<T> deconstructor, IReadOnlyList<T> values) {
        var descriptors = table.TableDescriptor.GetDescriptorsByNames(deconstructor.ColumnNames);
        sb.Clear();
        CreateInsertHeader(table, deconstructor, sb);
        sb.Append(") VALUES ");
        for (var y = 0; y < values.Count; ++y) {
            sb.Append('(');
            var target = values[y];
            for (int i = 0; i < deconstructor.FieldCount; ++i) {
                var value = deconstructor.GetFieldValueAt(target, i);
                sb.Append(descriptors[i].Converter.ToSql(value));
                if (i < deconstructor.FieldCount - 1) {
                    sb.Append(',');
                    sb.Append(' ');
                }
            }
            sb.Append(')');
            if (y < values.Count - 1)
                sb.Append(',');
        }
        sb.Append(';');
        var result = sb.ToString();
        sb.Clear();
        sb.Capacity = 16;
        return result;
    }

    private static void CreateInsertHeader<T>(SqlTable table, IObjectSqlDeconstructor<T> deconstructor, StringBuilder sb) {
        sb.Append("INSERT INTO ");
        sb.Append(table.TableName);
        sb.Append(' ');
        sb.Append('(');
        for (int i = 0; i < deconstructor.ColumnNames.Count; ++i) {
            var columnName = deconstructor.ColumnNames[i];
            sb.Append(columnName);
            if (i < deconstructor.ColumnNames.Count - 1) {
                sb.Append(',');
                sb.Append(' ');
            }
        }
    }

    public static string CreateUpdateCommand<T>(SqlTable table, IObjectSqlDeconstructor<T> deconstructor, T target) {
        var descriptors = table.TableDescriptor.GetDescriptorsByNames(deconstructor.ColumnNames);
        sb.Clear();
        sb.Append("UPDATE ");
        sb.Append(table.TableName);
        sb.Append(" SET ");
        var quality_separator = " = ";
        for (int i = 0; i < deconstructor.ColumnNames.Count; ++i) {
            sb.Append(deconstructor.ColumnNames[i]);
            sb.Append(quality_separator);
            var value = deconstructor.GetFieldValueAt(target, i);
            sb.Append(descriptors[i].Converter.ToSql(value));
            if (i < deconstructor.ColumnNames.Count - 1)
                sb.Append(',');
        }
        sb.Append(" WHERE ");
        sb.Append(table.TableDescriptor.PrimaryKey.Name);
        sb.Append(quality_separator);
        sb.Append(deconstructor.GetObjectDatabaseId(target));
        sb.Append(';');
        return sb.ToString();
    }

    public static string CreateDeleteCommandById<T>(SqlTable table, IObjectSqlDeconstructor<T> deconstructor, T target) {
        sb.Clear();
        CreateDeleteHeader(table, sb);
        sb.Append(table.TableDescriptor.PrimaryKey.Name);
        sb.Append(" = ");
        sb.Append(deconstructor.GetObjectDatabaseId(target));
        sb.Append(';');
        return sb.ToString();
    }
    
    public static string CreateDeleteCommandByIdMultiple<T>(SqlTable table, IObjectSqlDeconstructor<T> deconstructor, IReadOnlyList<T> targets) {
        sb.Clear();
        CreateDeleteHeader(table, sb);
        sb.Append(table.TableDescriptor.PrimaryKey.Name);
        sb.Append(" IN (");
        for (int i = 0; i < targets.Count; i++) {
            sb.Append(deconstructor.GetObjectDatabaseId(targets[i]));
            if (i < targets.Count - 1)
                sb.Append(',');
        }
        sb.Append(");");
        return sb.ToString();
    }

    private static void CreateDeleteHeader(SqlTable table, StringBuilder sb) {
        sb.Clear();
        sb.Append("DELETE FROM ");
        sb.Append(table.TableName);
        sb.Append(" WHERE ");
    }
}
