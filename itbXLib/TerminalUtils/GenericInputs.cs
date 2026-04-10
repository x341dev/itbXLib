namespace itbXLib.TerminalUtils;

/// <summary>
/// Provides a generic validated console input loop.
/// </summary>
/// <typeparam name="T">The type of value to read and return.</typeparam>
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

/// <summary>
/// Provides static convenience methods for common validated console input types,
/// built on top of <see cref="GenericInputs{T}"/>.
/// </summary>
public static class GenericInputs
{
    /// <summary>
    /// Reads a validated integer from the console.
    /// </summary>
    /// <param name="message">The prompt message to display.</param>
    /// <param name="errorMessage">The error message displayed on invalid input.</param>
    /// <param name="color">Optional prompt color. Defaults to gray.</param>
    /// <returns>A valid <see cref="int"/> entered by the user.</returns>
    public static int ReadInt(string message, string errorMessage, ConsoleColor? color = null) =>
        GenericInputs<int>.Read(message, errorMessage,
            input => (int.TryParse(input, out int val), val), color);

    /// <summary>
    /// Reads a validated double from the console.
    /// </summary>
    /// <param name="message">The prompt message to display.</param>
    /// <param name="errorMessage">The error message displayed on invalid input.</param>
    /// <param name="color">Optional prompt color. Defaults to gray.</param>
    /// <returns>A valid <see cref="double"/> entered by the user.</returns>
    public static double ReadDouble(string message, string errorMessage, ConsoleColor? color = null) =>
        GenericInputs<double>.Read(message, errorMessage,
            input => (double.TryParse(input, out double val), val), color);

    /// <summary>
    /// Reads a validated non-empty string from the console.
    /// </summary>
    /// <param name="message">The prompt message to display.</param>
    /// <param name="errorMessage">The error message displayed on invalid input.</param>
    /// <param name="minLength">Minimum accepted string length. Defaults to 1.</param>
    /// <param name="color">Optional prompt color. Defaults to gray.</param>
    /// <returns>A non-empty <see cref="string"/> of at least <paramref name="minLength"/> characters.</returns>
    public static string ReadString(string message, string errorMessage, int minLength = 1, ConsoleColor? color = null) =>
        GenericInputs<string>.Read(message, errorMessage,
            input => (!string.IsNullOrWhiteSpace(input) && input.Length >= minLength, input ?? string.Empty), color);

    /// <summary>
    /// Reads a validated boolean from the console.
    /// Accepts <c>s</c>/<c>n</c>, <c>true</c>/<c>false</c>, and <c>yes</c>/<c>no</c> (case-insensitive).
    /// </summary>
    /// <param name="message">The prompt message to display.</param>
    /// <param name="errorMessage">The error message displayed on invalid input.</param>
    /// <param name="color">Optional prompt color. Defaults to gray.</param>
    /// <returns><c>true</c> for affirmative input, <c>false</c> for negative input.</returns>
    public static bool ReadBool(string message, string errorMessage, ConsoleColor? color = null) =>
        GenericInputs<bool>.Read(message, errorMessage, input =>
        {
            string normalized = input.Trim().ToLowerInvariant();
            bool isTrue  = normalized is "s" or "true" or "yes";
            bool isFalse = normalized is "n" or "false" or "no";
            return (isTrue || isFalse, isTrue);
        }, color);
}