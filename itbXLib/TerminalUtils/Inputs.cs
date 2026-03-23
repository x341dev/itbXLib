namespace itbXLib.TerminalUtils;

/// <summary>
/// Provides helper methods for prompting the user for integer inputs on the console.
/// Methods will repeatedly prompt until a valid value is entered.
/// </summary>
public static class IntInputs
{
    public static int ReadInt(string message, string errorMessage)
    {
        int result;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out result) || result < 0)
        {
            Console.WriteLine(errorMessage);
        }
        return result;
    }

    //Generic method to read and validate a positive double from console
    public static double ReadDouble(string message, string errorMessage)
    {
        double result;
        Console.Write(message);
        while(!double.TryParse(Console.ReadLine(), out result) || result <= 0)
        {
            Console.WriteLine(errorMessage);
        }
        return result;
    }

    // Generic method to read and validate a non-empty string with minimum length from console
    public static string ReadString(string message, string errorMessage, int minLength)
    {
        Console.Write(message);
        string input = Console.ReadLine() ?? string.Empty;
        while (string.IsNullOrWhiteSpace(input) || input.Length < minLength)
        {
            Console.WriteLine(errorMessage);
            input = Console.ReadLine() ?? string.Empty;
        }
        return input;
    }

    //Generic method to read and validate a boolean from console
    public static bool ReadBool(string message, string errorMessage)
    {
        bool result;
        Console.Write(message);
        while (!bool.TryParse(Console.ReadLine()?.ToLower().Trim(), out result)) {
            Console.WriteLine(errorMessage);
        }
        return result;
    }
    /* DEPRECATED METHODS BELOW */
    
    private const string MsgNotANumber = "Input is not a number";
    private const string MsgNegativeNumber = "Number inputted is negative";
    private const string MsgTooBig = "Number is too big";
 
    [Obsolete("Use ReadInt instead")]
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
                ConsoleHelper.ColorWriteLine("Unexpected error: " + e.Message, ConsoleColor.DarkRed);
            }
        }
    }

    [Obsolete("Use ReadInt instead")]
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

