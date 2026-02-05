using itbXLib.ConsoleUtils;

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
                ConsoleHelper.ColorWriteLine(MsgNotANumber, ConsoleColor.DarkRed);
            }
            catch (OverflowException)
            {
                ConsoleHelper.ColorWriteLine(MsgTooBig, ConsoleColor.DarkRed);
            }
            catch (Exception e)
            {
                ConsoleHelper.ColorWriteLine("Unexpected error" + e.Message, ConsoleColor.DarkRed);
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
                ConsoleHelper.ColorWriteLine(MsgNegativeNumber, ConsoleColor.DarkRed);
                continue;
            }
            return n;
        }
    }
}