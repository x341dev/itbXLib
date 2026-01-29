using System.Globalization;

namespace itbXLib;

/// <summary>
/// Provides static utility methods to enhance console application output.
/// Includes functionality for writing text in standard console colors, specific RGB values (via ANSI codes), 
/// and formatting centered headers.
/// </summary>
public static class ConsoleHelper
{
    private const string AnsiReset = "\u001b[0m";

    /// <summary>
    /// Writes the specified string value to the standard output stream using the specified standard ConsoleColor.
    /// This method does not append a newline character to the end of the string.
    /// </summary>
    /// <remarks>
    /// The console foreground color is automatically reset to its default value after the message is written.
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="color">The <see cref="ConsoleColor"/> to use for the text.</param>
    public static void ColorWrite(string msg, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(msg);
        Console.ResetColor();
    }
    
    /// <summary>
    /// Writes the specified string value to the standard output stream using a specific Hex color code.
    /// This method uses ANSI escape sequences to support TrueColor (24-bit) and does not append a newline.
    /// </summary>
    /// <remarks>
    /// <para>This method requires a terminal that supports ANSI escape codes and TrueColor.</para>
    /// <para>The color is automatically reset to default after the message is written.</para>
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="hexColor">The hex color code (e.g., "#FF5733" or "FF5733").</param>
    public static void ColorWrite(string msg, string hexColor)
    {
        string ansiColor = GetAnsiFromHex(hexColor);
        Console.Write($"{ansiColor}{msg}{AnsiReset}");
    }
    
    /// <summary>
    /// Writes the specified string value, followed by the current line terminator, 
    /// to the standard output stream using the specified standard ConsoleColor.
    /// </summary>
    /// <remarks>
    /// The console foreground color is automatically reset to its default value after the message is written.
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="color">The <see cref="ConsoleColor"/> to use for the text.</param>
    public static void ColorWriteLine(string msg, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(msg);
        Console.ResetColor();
    }
    
    /// <summary>
    /// Writes the specified string value, followed by the current line terminator, 
    /// to the standard output stream using a specific Hex color code.
    /// </summary>
    /// <remarks>
    /// <para>This method requires a terminal that supports ANSI escape codes and TrueColor.</para>
    /// <para>The color is automatically reset to default after the message is written.</para>
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="hexColor">The hex color code (e.g., "#FF5733" or "FF5733").</param>
    public static void ColorWriteLine(string msg, string hexColor)
    {
        string ansiColor = GetAnsiFromHex(hexColor);
        Console.WriteLine($"{ansiColor}{msg}{AnsiReset}");
    }

    /// <summary>
    /// Prints a stylized header to the console consisting of the message surrounded by separator lines.
    /// The entire block is horizontally centered based on the current window width.
    /// </summary>
    /// <remarks>
    /// The separator lines are equal signs ('=') matching the length of the text plus margins.
    /// If the window width is too small, the left padding is set to 0 to prevent exceptions.
    /// </remarks>
    /// <param name="msg">The title text to display inside the separator block.</param>
    public static void HeaderSeparator(string msg)
    {
        int margin = 2;
        int totalWidth = msg.Length + (margin * 2);
        string separator = new string('=', totalWidth);
        
        // Calculate padding to center the block in the window
        int paddingLeft = (Console.WindowWidth - totalWidth) / 2;
        
        // Safety check to ensure padding is never negative
        if (paddingLeft < 0) paddingLeft = 0;
        
        string paddingStr = new string(' ', paddingLeft);

        Console.WriteLine(paddingStr + separator);
        Console.WriteLine(paddingStr + new string(' ', margin) + msg + new string(' ', margin));
        Console.WriteLine(paddingStr + separator);
    }

    private static string GetAnsiFromHex(string hexColor)
    {
        if (string.IsNullOrEmpty(hexColor)) return "";

        hexColor = hexColor.TrimStart('#');

        if (hexColor.Length != 6) return "";

        byte r = byte.Parse(hexColor.Substring(0, 2), NumberStyles.HexNumber);
        byte g = byte.Parse(hexColor.Substring(2, 2), NumberStyles.HexNumber);
        byte b = byte.Parse(hexColor.Substring(4, 2), NumberStyles.HexNumber);
        
        return $"\u001b[38;2;{r};{g};{b}m";
    }
}