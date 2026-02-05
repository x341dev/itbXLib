using itbXLib.ConsoleUtils;

namespace itbXLib.Inputs;

public static class IntInput
{
    private const string MsgNotANumber = "Input is not a number";
    private const string MsgNegativeNumber = "Number inputted is negative";
    private const string MsgTooBig = "Number is too big";
    
    public static int AskForNumber(string msg)
    {
        while (true)
        {
            Console.WriteLine(msg);
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