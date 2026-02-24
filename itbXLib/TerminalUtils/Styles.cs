namespace itbXLib.TerminalUtils;

/// <summary>
/// Provides utilities for applying terminal text styles using ANSI escape sequences,
/// and helper methods for emoji support in the terminal.
/// <para>
/// All styling methods return plain, unstyled text when
/// <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.
/// </para>
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
    /// Returns plain text when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>A styled string, or the original text if styling is disabled.</returns>
    public static string Bold(string text) =>
        TerminalCapabilities.StylingEnabled ? $"{AnsiBold}{text}{AnsiReset}" : text;

    /// <summary>
    /// Wraps the given text with ANSI escape codes to render it as <i>italic</i> (cursive) in the terminal.
    /// Returns plain text when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>A styled string, or the original text if styling is disabled.</returns>
    public static string Italic(string text) =>
        TerminalCapabilities.StylingEnabled ? $"{AnsiItalic}{text}{AnsiReset}" : text;

    /// <summary>
    /// Wraps the given text with ANSI escape codes to render it as <u>underlined</u> in the terminal.
    /// Returns plain text when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>A styled string, or the original text if styling is disabled.</returns>
    public static string Underline(string text) =>
        TerminalCapabilities.StylingEnabled ? $"{AnsiUnderline}{text}{AnsiReset}" : text;

    /// <summary>
    /// Combines bold, italic and underline styles on the given text.
    /// Returns plain text when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.
    /// </summary>
    /// <param name="text">The text to style.</param>
    /// <returns>A styled string, or the original text if styling is disabled.</returns>
    public static string BoldItalicUnderline(string text) =>
        TerminalCapabilities.StylingEnabled
            ? $"{AnsiBold}{AnsiItalic}{AnsiUnderline}{text}{AnsiReset}"
            : text;

    // --- Raw ANSI sequences ---

    /// <summary>
    /// Gets the raw ANSI escape sequence that enables bold text, or <see cref="string.Empty"/> if styling is disabled.
    /// </summary>
    public static string BoldCode => TerminalCapabilities.StylingEnabled ? AnsiBold : string.Empty;

    /// <summary>
    /// Gets the raw ANSI escape sequence that enables italic (cursive) text, or <see cref="string.Empty"/> if styling is disabled.
    /// </summary>
    public static string ItalicCode => TerminalCapabilities.StylingEnabled ? AnsiItalic : string.Empty;

    /// <summary>
    /// Gets the raw ANSI escape sequence that enables underlined text, or <see cref="string.Empty"/> if styling is disabled.
    /// </summary>
    public static string UnderlineCode => TerminalCapabilities.StylingEnabled ? AnsiUnderline : string.Empty;

    /// <summary>
    /// Gets the raw ANSI escape sequence that resets all active styles, or <see cref="string.Empty"/> if styling is disabled.
    /// </summary>
    public static string ResetCode => TerminalCapabilities.StylingEnabled ? AnsiReset : string.Empty;

    // --- Emoji support ---

    /// <summary>
    /// Ensures the console output encoding is set to UTF-8 so that emoji and other Unicode characters
    /// are displayed correctly in the terminal.
    /// Call this method once at application startup before writing any emoji output.
    /// <para>Has no effect when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.</para>
    /// </summary>
    public static void EnableEmojiSupport()
    {
        if (!TerminalCapabilities.StylingEnabled) return;
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
    /// Combines an emoji with a text label into a single formatted string.
    /// </summary>
    /// <param name="emoji">The emoji character or string.</param>
    /// <param name="label">The text label to display next to the emoji.</param>
    /// <returns>A formatted string combining the emoji and the label.</returns>
    public static string WithEmoji(string emoji, string label) => $"{emoji} {label}";
}
