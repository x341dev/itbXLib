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
    
    /// <summary>
    /// Converts a hex color string (e.g., "#RRGGBB") to an ANSI escape sequence for 24-bit (TrueColor) foreground color.
    /// </summary>
    /// <param name="hex">Hex color code</param>
    /// <returns>An ANSI escape sequence string that sets the console foreground to the specified HEX color.</returns>
    /// <exception cref="ArgumentException">Thrown if the hex string is not in the correct format.</exception>
    public static string RgbToAnsi(string hex)
    {
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }
        
        if (hex.Length != 6)
        {
            throw new ArgumentException("Hex color must be 6 characters long.");
        }

        int r = Convert.ToInt32(hex.Substring(0, 2), 16);
        int g = Convert.ToInt32(hex.Substring(2, 2), 16);
        int b = Convert.ToInt32(hex.Substring(4, 2), 16);

        return RgbToAnsi(r, g, b);
    }
}