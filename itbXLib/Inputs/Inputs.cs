using itbXLib.Colors;

namespace itbXLib.Inputs;

/// <summary>
/// Provides helper methods for asking the user for integer inputs on the console.
/// Methods will repeatedly prompt until a valid value is entered.
/// </summary>
public static class IntInput
{
    private const string MsgNotANumber = "Input is not a number";
    private const string MsgNegativeNumber = "Number inputted is negative";
    private const string MsgTooBig = "Number is too big";
    
    /// <summary>
    /// Prompts the user with <paramref name="msg"/> and reads a line from the console until a valid integer is entered.
    /// </summary>
    /// <param name="msg">The prompt message shown to the user.</param>
    /// <returns>The parsed integer value.</returns>
    public static int AskForNumber(string msg)
    {
        while (true)
        {
            Console.Write(msg);
            string nstr = Console.ReadLine() ?? "";

            try
            {
                int n = int.Parse(nstr);
                return n;
            }
            catch (FormatException)
            {
                Console.WriteLine($"{Colors.Colors.RgbToAnsi("FF8B00")}{MsgNotANumber}{Colors.Colors.AnsiReset}");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{Colors.Colors.RgbToAnsi("FF8B00")}{MsgTooBig}{Colors.Colors.AnsiReset}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{Colors.Colors.RgbToAnsi("FF8B00")}Unexpected error" + e.Message + $"{Colors.Colors.AnsiReset}");
            }
        }
    }
    
    /// <summary>
    /// Prompts the user until they enter a non-negative integer. Negative values will re-prompt.
    /// </summary>
    /// <param name="msg">The prompt message shown to the user.</param>
    /// <returns>A non-negative integer entered by the user.</returns>
    public static int AskForPositiveNumber(string msg)
    {
        while (true)
        {
            int n = AskForNumber(msg);
            if (n < 0)
            {
                Console.WriteLine($"{Colors.Colors.RgbToAnsi("FF8B00")}{MsgNegativeNumber}{Colors.Colors.AnsiReset}");
                continue;
            }
            return n;
        }
    }
}