using ExpenseManager.SQLite;

namespace ExpenseManager.DataObjects.Conversion;
public class CategoryReconstructor : IObjectReconstructor<Category>
{
    private static readonly List<Type> ParamTypes = new() { typeof(string), typeof(Color), typeof(string), typeof(long) };
    public bool AllowsNull => false;

    public IReadOnlyList<Type> ParameterTypes => ParamTypes.AsReadOnly();

    public Category ReconstructObject(params object?[] parameters) {
        if (!IObjectReconstructor<Category>.VerifyParameterTypes(parameters, ParameterTypes, AllowsNull, out int faultyIndex)) {
            throw new ArgumentException($"Object at index {faultyIndex} ({parameters[faultyIndex].GetType().Name}) did not match the required type {ParameterTypes[faultyIndex].Name}");
        }
        return new Category((string)parameters[0]!, (Color?)parameters[1], (string?)parameters[2], (long?)parameters[3]);
    }
}
