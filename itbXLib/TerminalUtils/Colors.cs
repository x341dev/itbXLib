namespace itbXLib.TerminalUtils;

/// <summary>
/// Utilities for converting colors to ANSI terminal escape sequences.
/// <para>
/// All methods return an empty string when <see cref="TerminalCapabilities.StylingEnabled"/>
/// is <c>false</c>, ensuring no stray escape codes appear in unsupported terminals.
/// </para>
/// </summary>
public static class Colors
{
    private const string AnsiReset = "\u001b[0m";

    /// <summary>
    /// Gets the ANSI reset sequence, or an empty string when styling is disabled.
    /// </summary>
    public static string Reset => TerminalCapabilities.StylingEnabled ? AnsiReset : string.Empty;

    /// <summary>
    /// Converts RGB components to an ANSI escape sequence for 24-bit (TrueColor) foreground color.
    /// Returns an empty string when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.
    /// </summary>
    /// <param name="r">Red component (0–255).</param>
    /// <param name="g">Green component (0–255).</param>
    /// <param name="b">Blue component (0–255).</param>
    /// <returns>An ANSI escape sequence string, or <see cref="string.Empty"/> if styling is disabled.</returns>
    public static string RgbToAnsi(int r, int g, int b)
    {
        if (!TerminalCapabilities.StylingEnabled) return string.Empty;
        return $"\u001b[38;2;{r};{g};{b}m";
    }

    /// <summary>
    /// Converts a hex color string (e.g., <c>"#RRGGBB"</c> or <c>"RRGGBB"</c>) to an ANSI escape sequence
    /// for 24-bit (TrueColor) foreground color.
    /// Returns an empty string when <see cref="TerminalCapabilities.StylingEnabled"/> is <c>false</c>.
    /// </summary>
    /// <param name="hex">Hex color code.</param>
    /// <returns>An ANSI escape sequence string, or <see cref="string.Empty"/> if styling is disabled.</returns>
    /// <exception cref="ArgumentException">Thrown if the hex string is not in the correct format.</exception>
    public static string RgbToAnsi(string hex)
    {
        if (!TerminalCapabilities.StylingEnabled) return string.Empty;

        if (hex.StartsWith('#'))
            hex = hex.Substring(1);

        if (hex.Length != 6)
            throw new ArgumentException("Hex color must be 6 characters long.", nameof(hex));

        int r = Convert.ToInt32(hex.Substring(0, 2), 16);
        int g = Convert.ToInt32(hex.Substring(2, 2), 16);
        int b = Convert.ToInt32(hex.Substring(4, 2), 16);

        return RgbToAnsi(r, g, b);
    }
}

