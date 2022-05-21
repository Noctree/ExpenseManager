namespace ExpenseManager.SQLite;
public interface IObjectSqlReconstructor<T>
{
    /// <summary>
    /// Whenever the 
    /// <see cref="ReconstructObject(object?[])"/> method accepts null as value
    /// </summary>
    public bool AllowsNull { get; }

    /// <summary>
    /// How many parameters are needed to reconstruct the object
    /// </summary>
    public int FieldCount => FieldTypes.Count;

    /// <summary>
    /// What type each parameter should be of, returned in order in which parameters should be passed into 
    /// <see cref="ReconstructObject(object?[])"/>
    /// </summary>
    public IReadOnlyList<Type> FieldTypes { get; }

    public T ReconstructObject(params object?[] parameters);

    /// <summary>
    /// Utility method to verify if types of parameters match those returned by 
    /// <see cref="FieldTypes"/>
    /// </summary>
    /// <param name="parameters">Parameters received in <see cref="ReconstructObject(object?[])"/></param>
    /// <param name="faultyParameterIndex">Index of the parameter which did not match <see cref="FieldTypes"/>, or was null when <see cref="AllowsNull"/>was set to false, is set to -1 if the function returns true</param>
    /// <returns>True if all parameter types are valid</returns>
    protected static bool VerifyParameterTypes(object?[] parameters, IReadOnlyList<Type> paramTypes, bool allowsNull, out int faultyParameterIndex) {
        faultyParameterIndex = -1;
        for (int i = 0; i < parameters.Length; i++) {
            if (parameters[i] is null) {
                if (allowsNull)
                    continue;
                faultyParameterIndex = i;
                return false;
            }
            if (!parameters[i]!.GetType().IsAssignableTo(paramTypes[i])) {
                faultyParameterIndex = i;
                return false;
            }
        }
        return true;
    }

    protected static void ThrowParameterTypeNotMatchingFieldTypeCount(object?[] parameters, IReadOnlyList<Type> paramTypes, int faultyParameterIndex) {
        if (parameters[faultyParameterIndex] is null)
            throw new ArgumentNullException($"Parameter at index {faultyParameterIndex} was null when {nameof(AllowsNull)} was set to false");
        else
            throw new ArgumentException($"Object at index {faultyParameterIndex} ({parameters[faultyParameterIndex]!.GetType().Name}) did not match the required type {paramTypes[faultyParameterIndex].Name}");
    }
}
