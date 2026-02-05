using itbXLib.ConsoleUtils;

namespace itbXLib.Inputs;

public static class Inputs
{
    private const string MsgNotANumber = "Input is not a number";
    private const string MsgNegativeNumber = "Number inputted is negative";
    private const string MsgTooBig = "Number is too big";
    
    public static int AskForNumber(string msg)
    {
        int n;

        while (true)
        {
            Console.WriteLine(msg);
            string nstr = Console.ReadLine() ?? "";

            try
            {
                n = int.Parse(nstr);
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
}