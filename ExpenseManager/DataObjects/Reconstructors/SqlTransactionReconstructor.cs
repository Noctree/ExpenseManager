using ExpenseManager.SQLite;

namespace ExpenseManager.DataObjects.Conversion;
public class SqlTransactionReconstructor : IObjectSqlReconstructor<Transaction>
{
    private static readonly List<Type> ParamTypes = new() { typeof(DateOnly), typeof(decimal), typeof(object), typeof(string), typeof(long) };
    public bool AllowsNull => true;

    public IReadOnlyList<Type> FieldTypes => ParamTypes.AsReadOnly();

    public Transaction ReconstructObject(params object?[] parameters) {
        if (!IObjectSqlReconstructor<Transaction>.VerifyParameterTypes(parameters, FieldTypes, AllowsNull, out int faultyIndex)) {
            IObjectSqlReconstructor<Transaction>.ThrowParameterTypeNotMatchingFieldTypeCount(parameters, FieldTypes, faultyIndex);
        }
        return new Transaction((DateOnly)parameters[0]!, (decimal)parameters[1]!, null, (string?)parameters[3], (long?)parameters[4]);
    }
}
