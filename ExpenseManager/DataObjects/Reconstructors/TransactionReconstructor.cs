using ExpenseManager.SQLite;

namespace ExpenseManager.DataObjects.Conversion;
public class TransactionReconstructor : IObjectReconstructor<Transaction>
{
    private static readonly List<Type> ParamTypes = new() { typeof(DateOnly), typeof(decimal), typeof(object), typeof(string), typeof(long) };
    public bool AllowsNull => true;

    public IReadOnlyList<Type> ParameterTypes => ParamTypes.AsReadOnly();

    public Transaction ReconstructObject(params object?[] parameters) {
        if (!IObjectReconstructor<Transaction>.VerifyParameterTypes(parameters, ParameterTypes, AllowsNull, out int faultyIndex)) {
            throw new ArgumentException($"Object at index {faultyIndex} ({parameters[faultyIndex]}) did not match the required type {ParameterTypes[faultyIndex].Name}");
        }
        return new Transaction((DateOnly)parameters[0]!, (decimal)parameters[1]!, null, (string?)parameters[3], (long?)parameters[4]);
    }
}
