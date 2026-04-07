namespace itbXLib.TerminalUtils;

public static class GenericInputs<T>
{
    /// <summary>
    /// Repeatedly prompts the user for input until a valid value is provided.
    /// The input is validated using the supplied delegate function.
    /// </summary>
    /// <param name="message">The prompt message to display to the user.</param>
    /// <param name="errorMessage">The error message to display when validation fails.</param>
    /// <param name="validator">A delegate that parses the input and returns a tuple of (isValid, parsedValue).</param>
    /// <param name="color">The <see cref="ConsoleColor"/> for the prompt message. Defaults to gray.</param>
    /// <returns>A validated value of type <typeparamref name="T"/>.</returns>
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