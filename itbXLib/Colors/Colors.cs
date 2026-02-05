namespace itbXLib.Colors;

/// <summary>
/// Utilities for converting colors to terminal escape sequences.
/// </summary>
public class Colors
{
    /// <summary>
    /// Converts RGB components to an ANSI escape sequence for 24-bit (TrueColor) foreground color.
    /// </summary>
    /// <param name="r">Red component (0-255).</param>
    /// <param name="g">Green component (0-255).</param>
    /// <param name="b">Blue component (0-255).</param>
    /// <returns>An ANSI escape sequence string that sets the console foreground to the specified RGB color.</returns>
    public static string RgbToAnsi(int r, int g, int b)
    {
        return $"\u001b[38;2;{r};{g};{b}m";
    }
}