namespace itbXLib.TerminalUtils;

/// <summary>
/// Provides utilities for applying terminal text styles using ANSI escape sequences,
/// and helper methods for emoji support in the terminal.
/// </summary>
public static class Styles
{
    private const string AnsiReset = "\u001b[0m";
    private const string AnsiBold = "\u001b[1m";
    private const string AnsiItalic = "\u001b[3m";
    private const string AnsiUnderline = "\u001b[4m";

    // --- Style wrappers ---

    /// <summary>
    /// Wraps the given text with ANSI escape codes to render it as <b>bold</b> in the terminal.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>A string with bold ANSI codes applied, followed by a reset sequence.</returns>
    public static string Bold(string text) => $"{AnsiBold}{text}{AnsiReset}";

    /// <summary>
    /// Wraps the given text with ANSI escape codes to render it as <i>italic</i> (cursive) in the terminal.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>A string with italic ANSI codes applied, followed by a reset sequence.</returns>
    public static string Italic(string text) => $"{AnsiItalic}{text}{AnsiReset}";

    /// <summary>
    /// Wraps the given text with ANSI escape codes to render it as <u>underlined</u> in the terminal.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>A string with underline ANSI codes applied, followed by a reset sequence.</returns>
    public static string Underline(string text) => $"{AnsiUnderline}{text}{AnsiReset}";

    /// <summary>
    /// Combines bold, italic and underline styles on the given text.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>A string with bold, italic and underline ANSI codes applied, followed by a reset sequence.</returns>
    public static string BoldItalicUnderline(string text) =>
        $"{AnsiBold}{AnsiItalic}{AnsiUnderline}{text}{AnsiReset}";

    // --- Raw ANSI sequences ---

    /// <summary>
    /// Gets the raw ANSI escape sequence that enables bold text.
    /// </summary>
    public static string BoldCode => AnsiBold;

    /// <summary>
    /// Gets the raw ANSI escape sequence that enables italic (cursive) text.
    /// </summary>
    public static string ItalicCode => AnsiItalic;

    /// <summary>
    /// Gets the raw ANSI escape sequence that enables underlined text.
    /// </summary>
    public static string UnderlineCode => AnsiUnderline;

    /// <summary>
    /// Gets the raw ANSI escape sequence that resets all active styles.
    /// </summary>
    public static string ResetCode => AnsiReset;

    // --- Emoji support ---

    /// <summary>
    /// Ensures the console output encoding is set to UTF-8 so that emoji and other
    /// Unicode characters are displayed correctly in the terminal.
    /// Call this method once at application startup before writing any emoji output.
    /// </summary>
    public static void EnableEmojiSupport()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    }

    /// <summary>
    /// Converts a Unicode code point (e.g. <c>0x1F600</c>) to its corresponding emoji string.
    /// </summary>
    /// <param name="codePoint">The Unicode code point of the emoji.</param>
    /// <returns>A string containing the emoji character.</returns>
    /// <example>
    /// <code>
    /// string emoji = Styles.FromCodePoint(0x1F600); // 😀
    /// </code>
    /// </example>
    public static string FromCodePoint(int codePoint) =>
        char.ConvertFromUtf32(codePoint);

    /// <summary>
    /// Wraps an emoji (or any text) alongside a label with proper UTF-8 encoding awareness.
    /// Useful for composing emoji + text lines cleanly.
    /// </summary>
    /// <param name="emoji">The emoji character or string.</param>
    /// <param name="label">The text label to display next to the emoji.</param>
    /// <returns>A formatted string combining the emoji and the label.</returns>
    public static string WithEmoji(string emoji, string label) => $"{emoji} {label}";
}

