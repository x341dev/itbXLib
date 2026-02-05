namespace itbXLib.Colors;

public class Colors
{
    public static string RgbToAnsi(int r, int g, int b)
    {
        return $"\u001b[38;2;{r};{g};{b}m";
    }
}