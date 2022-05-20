using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace ExpenseManager.SQLite;

public static class SQLiteExtensions
{
    private const int LoggingMessageLengthLimit = 10_000;
    /// <summary>
    /// Opens the connection and wraps it in TemporaryConnection object, is to be used with the 'using' syntax to enable automatic closing of the connection without disposing it
    /// </summary>
    /// <param name="connection"></param>
    /// <returns>TemporaryConnection wrapper</returns>
    public static TemporaryConnection OpenAsTemporaryConnection(this SQLiteConnection connection) {
        return new TemporaryConnection(connection);
    }

    /// <summary>
    /// Finds column descriptor by name
    /// </summary>
    /// <param name="descriptors"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException">Thrown when no column descriptor with the specified name is found</exception>
    public static ISqlColumnDescriptor GetDescriptorByName(this IReadOnlyList<ISqlColumnDescriptor> descriptors, string name) {
        for (int i = 0; i < descriptors.Count; i++) {
            if (string.Equals(descriptors[i].Name, name, StringComparison.Ordinal))
                return descriptors[i];
        }
        throw new KeyNotFoundException($"Table does not contain column " + name);
    }

    public static int ExecuteNonQueryWithLogging(this SQLiteCommand command, [CallerMemberName] string callerMethod = "unknown", [CallerFilePath] string fileName = "unknown") {
        if (command.CommandText.Length < LoggingMessageLengthLimit)
            Debug.WriteLine($"[{Path.GetFileNameWithoutExtension(fileName)}.{callerMethod}]: Execute query - {command.CommandText}");
        return command.ExecuteNonQuery();
    }

    public static SQLiteDataReader ExecuteReaderWithLogging(this SQLiteCommand command, [CallerMemberName] string callerMethod = "unknown", [CallerFilePath] string fileName = "unknown") {
        if (command.CommandText.Length < LoggingMessageLengthLimit)
            Debug.WriteLine($"[{Path.GetFileNameWithoutExtension(fileName)}.{callerMethod}]: Execute query - {command.CommandText}");
        return command.ExecuteReader();
    }
}
