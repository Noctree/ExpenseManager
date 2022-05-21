using ExpenseManager.SQLite;

namespace ExpenseManager.DataObjects.Conversion;
public class SqlCategoryReconstructor : IObjectSqlReconstructor<Category>
{
    private static readonly List<Type> ParamTypes = new() { typeof(string), typeof(Color), typeof(string), typeof(long) };
    public bool AllowsNull => false;

    public IReadOnlyList<Type> FieldTypes => ParamTypes.AsReadOnly();

    public Category ReconstructObject(params object?[] parameters) {
        if (!IObjectSqlReconstructor<Category>.VerifyParameterTypes(parameters, FieldTypes, AllowsNull, out int faultyIndex)) {
            IObjectSqlReconstructor<Category>.ThrowParameterTypeNotMatchingFieldTypeCount(parameters, FieldTypes, faultyIndex);
        }
        return new Category((string)parameters[0]!, (Color?)parameters[1], (string?)parameters[2], (long?)parameters[3]);
    }
}
