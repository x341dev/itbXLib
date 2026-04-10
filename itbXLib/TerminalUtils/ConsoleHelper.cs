using System.Globalization;

namespace itbXLib.TerminalUtils;

/// <summary>
/// Provides static utility methods to enhance console application output.
/// Includes functionality for writing text in standard console colors, specific RGB values (via ANSI codes),
/// and formatting centered headers.
/// <para>
/// All ANSI-based overloads degrade gracefully to plain output when
/// <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.
/// </para>
/// </summary>
public static class ConsoleHelper
{
    /// <summary>
    /// Writes the specified string value to the standard output stream using the specified standard
    /// <see cref="ConsoleColor"/>. Does not append a newline character.
    /// </summary>
    /// <remarks>
    /// The console foreground color is automatically reset to its default value after the message is written.
    /// When <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>, the color parameter is ignored
    /// and the text is written without any styling.
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="color">The <see cref="ConsoleColor"/> to use for the text.</param>
    /// <param name="args">Optional formatting arguments for the message.</param>
    public static void ColorWrite(string msg, ConsoleColor color, params object[] args)
    {
        string formattedMessage = (args is { Length: > 0 }) ? string.Format(msg, args) : msg;

        if (!TerminalCapabilities.StylingEnabled)
        {
            Console.Write(formattedMessage);
            return;
        }
        Console.ForegroundColor = color;
        Console.Write(formattedMessage);
        Console.ResetColor();
    }

    /// <summary>
    /// Writes the specified string value to the standard output stream using a specific RGB color.
    /// This method uses ANSI escape sequences to support TrueColor (24-bit) and does not append a newline.
    /// </summary>
    /// <remarks>
    /// <para>Requires a terminal that supports ANSI escape codes and TrueColor.</para>
    /// <para>The color is automatically reset to default after the message is written.</para>
    /// <para>Falls back to plain output when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.</para>
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="r">Red component (0–255).</param>
    /// <param name="g">Green component (0–255).</param>
    /// <param name="b">Blue component (0–255).</param>
    /// <param name="args">Optional formatting arguments for the message.</param>
    public static void ColorWrite(string msg, int r, int g, int b, params object[] args)
    {
        string formattedMessage = (args is { Length: > 0 }) ? string.Format(msg, args) : msg;

        if (!TerminalCapabilities.StylingEnabled)
        {
            Console.Write(formattedMessage);
            return;
        }
        Console.Write($"{Colors.RgbToAnsi(r, g, b)}{formattedMessage}{Colors.Reset}");
    }

    /// <summary>
    /// Writes the specified string value to the standard output stream using a specific hex color code.
    /// This method uses ANSI escape sequences to support TrueColor (24-bit) and does not append a newline.
    /// </summary>
    /// <remarks>
    /// <para>Requires a terminal that supports ANSI escape codes and TrueColor.</para>
    /// <para>The color is automatically reset to default after the message is written.</para>
    /// <para>Falls back to plain output when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.</para>
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="hexColor">The foreground hex color code (e.g., <c>"#FF5733"</c> or <c>"FF5733"</c>).</param>
    /// <param name="bgHexColor">Optional background hex color code. Pass <c>null</c> to leave the background unchanged.</param>
    /// <param name="args">Optional formatting arguments for the message.</param>
    public static void ColorWrite(string msg, string hexColor, string? bgHexColor = null, params object[] args)
    {
        string formattedMessage = (args is { Length: > 0 }) ? string.Format(msg, args) : msg;

        if (!TerminalCapabilities.StylingEnabled)
        {
            Console.Write(formattedMessage);
            return;
        }
        string ansiColor = GetAnsiFromHex(hexColor);
        string ansiBg = bgHexColor is not null ? Colors.RgbToAnsiBg(bgHexColor) : string.Empty;
        Console.Write($"{ansiBg}{ansiColor}{formattedMessage}{Colors.Reset}");
    }

    /// <summary>
    /// Writes the specified string value, followed by the current line terminator,
    /// to the standard output stream using the specified standard <see cref="ConsoleColor"/>.
    /// </summary>
    /// <remarks>
    /// The console foreground color is automatically reset to its default value after the message is written.
    /// When <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>, the color parameter is ignored.
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="color">The <see cref="ConsoleColor"/> to use for the text.</param>
    /// <param name="args">Optional formatting arguments for the message.</param>
    public static void ColorWriteLine(string msg, ConsoleColor color, params object[] args)
    {
        string formattedMessage = (args is { Length: > 0 }) ? string.Format(msg, args) : msg;

        if (!TerminalCapabilities.StylingEnabled)
        {
            Console.WriteLine(formattedMessage);
            return;
        }
        Console.ForegroundColor = color;
        Console.WriteLine(formattedMessage);
        Console.ResetColor();
    }

    /// <summary>
    /// Writes the specified string value, followed by the current line terminator,
    /// to the standard output stream using a specific hex color code.
    /// </summary>
    /// <remarks>
    /// <para>Requires a terminal that supports ANSI escape codes and TrueColor.</para>
    /// <para>Falls back to plain output when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.</para>
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="hexColor">The foreground hex color code (e.g., <c>"#FF5733"</c> or <c>"FF5733"</c>).</param>
    /// <param name="bgHexColor">Optional background hex color code. Pass <c>null</c> to leave the background unchanged.</param>
    /// <param name="args">Optional formatting arguments for the message.</param>
    public static void ColorWriteLine(string msg, string hexColor, string? bgHexColor = null, params object[] args)
    {
        string formattedMessage = (args is { Length: > 0 }) ? string.Format(msg, args) : msg;

        if (!TerminalCapabilities.StylingEnabled)
        {
            Console.WriteLine(formattedMessage);
            return;
        }
        string ansiColor = GetAnsiFromHex(hexColor);
        string ansiBg = bgHexColor is not null ? Colors.RgbToAnsiBg(bgHexColor) : string.Empty;
        Console.WriteLine($"{ansiBg}{ansiColor}{formattedMessage}{Colors.Reset}");
    }

    /// <summary>
    /// Writes the specified string value, followed by the current line terminator,
    /// to the standard output stream using a specific RGB color.
    /// </summary>
    /// <remarks>
    /// <para>Requires a terminal that supports ANSI escape codes and TrueColor.</para>
    /// <para>Falls back to plain output when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.</para>
    /// </remarks>
    /// <param name="msg">The message to write to the console.</param>
    /// <param name="r">Red component (0–255).</param>
    /// <param name="g">Green component (0–255).</param>
    /// <param name="b">Blue component (0–255).</param>
    /// <param name="args">Optional formatting arguments for the message.</param>
    public static void ColorWriteLine(string msg, int r, int g, int b, params object[] args)
    {
        string formattedMessage = (args is { Length: > 0 }) ? string.Format(msg, args) : msg;

        if (!TerminalCapabilities.StylingEnabled)
        {
            Console.WriteLine(formattedMessage);
            return;
        }
        Console.WriteLine($"{Colors.RgbToAnsi(r, g, b)}{formattedMessage}{Colors.Reset}");
    }

    /// <summary>
    /// Prints a stylized header to the console consisting of the message surrounded by separator lines.
    /// The entire block is horizontally centered based on the current window width.
    /// </summary>
    /// <remarks>
    /// The separator lines are equal signs (<c>=</c>) matching the length of the text plus margins.
    /// If the window width is too small, the left padding is set to 0 to prevent exceptions.
    /// </remarks>
    /// <param name="msg">The title text to display inside the separator block.</param>
    public static void HeaderSeparator(string msg)
    {
        int margin = 2;
        int totalWidth = msg.Length + (margin * 2);
        string separator = new string('=', totalWidth);

        int paddingLeft = (Console.WindowWidth - totalWidth) / 2;
        if (paddingLeft < 0) paddingLeft = 0;

        string paddingStr = new string(' ', paddingLeft);

        Console.WriteLine(paddingStr + separator);
        Console.WriteLine(paddingStr + new string(' ', margin) + msg + new string(' ', margin));
        Console.WriteLine(paddingStr + separator);
    }

    // ------------------------------------------------------------------
    // Private helpers
    // ------------------------------------------------------------------

    private static string GetAnsiFromHex(string hexColor)
    {
        if (string.IsNullOrEmpty(hexColor)) return string.Empty;

        hexColor = hexColor.TrimStart('#');

        if (hexColor.Length != 6) return string.Empty;

        byte r = byte.Parse(hexColor.Substring(0, 2), NumberStyles.HexNumber);
        byte g = byte.Parse(hexColor.Substring(2, 2), NumberStyles.HexNumber);
        byte b = byte.Parse(hexColor.Substring(4, 2), NumberStyles.HexNumber);

        return $"\u001b[38;2;{r};{g};{b}m";
    }
}

