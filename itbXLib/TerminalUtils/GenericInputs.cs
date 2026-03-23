namespace itbXLib.TerminalUtils;

public static class GenericInputs<T>
{
    public static T Read(string message, string errorMessage, Func<string, (bool isValid, T value)> validator, ConsoleColor? color = null)
    {
        ConsoleHelper.ColorWrite(message, color ?? ConsoleColor.Gray);
        string input = Console.ReadLine() ?? string.Empty;
        var (isValid, value) = validator(input);
        while (!isValid)
        {
            ConsoleHelper.ColorWriteLine(errorMessage, ConsoleColor.DarkRed);
            ConsoleHelper.ColorWrite(message, color ?? ConsoleColor.Gray);
            input = Console.ReadLine() ?? string.Empty;
            (isValid, value) = validator(input);
        }
        return value;
    }
}