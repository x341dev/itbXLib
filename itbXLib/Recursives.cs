namespace itbXLib;

public static class Recursives
{
    /// <summary>
    /// Prints a countdown from n to 1 to the console recursively.
    /// </summary>
    /// <param name="n">The starting number for the countdown.</param>
    /// <returns>Returns 0 when the countdown is complete.</returns>
    public static int Countdown(int n)
    {
        if (n == 0) return 0;
        Console.WriteLine(n); 
        return Countdown(n - 1);
    }
    
    /// <summary>
    /// Calculates the total number of digits in an integer recursively.
    /// </summary>
    /// <param name="n">The integer to count the digits of.</param>
    /// <returns>The total count of digits in the number.</returns>
    public static int CountDigits(int n)
    {
        if (n < 10) return 1;

        return 1 + CountDigits(n / 10);
    }
    
    /// <summary>
    /// Calculates the sum of all individual digits in an integer recursively.
    /// </summary>
    /// <param name="n">The integer whose digits will be summed.</param>
    /// <returns>The sum of the digits.</returns>
    public static int AddDigits(int n)
    {
        if (n < 10) return n;
        
        return (n % 10) + AddDigits(n / 10);
    }

    /// <summary>
    /// Invert the digits of an integer
    /// </summary>
    /// <param name="n">Number to invert</param>
    /// <returns>The number with the digits inverted</returns>
    public static int Swap(int n)
    {
        return SwapAux(n, 0);
    }

    /// <summary>
    /// Auxiliar recursive function to construct the inverted number
    /// </summary>
    /// <param name="n">The number to process</param>
    /// <param name="result">The accumulator with the number inverted at the moment</param>
    /// <returns>Tge final number inverted</returns>
    private static int SwapAux(int n, int result)
    {
        if (n == 0) return result;

        int newResult = (result * 10) + (n % 10);

        return SwapAux(n / 10, newResult);
    }

    /// <summary>
    /// Prints all entries of an array in order
    /// </summary>
    /// <param name="arrayInt">The array to print</param>
    /// <param name="index">The position to check</param>
    public static void PrintForwardArray(int[] arrayInt, int index)
    {
        if (index == arrayInt.Length - 1) Console.WriteLine(arrayInt[index]);
        else
        {
            Console.Write(arrayInt[index] + " ");
            PrintForwardArray(arrayInt, index + 1);
        }
    }
    
    /// <summary>
    /// Prints all entries of an array in reverse order
    /// </summary>
    /// <param name="arrayInt">The array to print</param>
    /// <param name="index">The position to check</param>
    public static void PrintBackwardArray(int[] arrayInt, int index)
    {
        if (index == 0) Console.WriteLine(arrayInt[index]);
        else
        {
            Console.Write(arrayInt[index] + " ");
            PrintBackwardArray(arrayInt, index - 1);
        }
    }

    /// <summary>
    /// Finds the maximum value in an integer array recursively.
    /// </summary>
    /// <param name="arrayInt">The array of integers to search.</param>
    /// <param name="index">The current index being evaluated (start with 0).</param>
    /// <returns>The maximum value found in the array.</returns>
    public static int FindMax(int[] arrayInt, int index)
    {
        if (index == arrayInt.Length - 1) return arrayInt[index];

        int max = FindMax(arrayInt, index + 1);

        return Math.Max(arrayInt[index], max);
    }
    
    /// <summary>
    /// Finds if the word is a palindrome (reads the same left to right and right to left).
    /// </summary>
    /// <param name="word">The word to compare.</param>
    /// <returns>True if the word is a palindrome; otherwise, false.</returns>
    public static bool IsPalindrome(string word)
    {
        if (word.Length <= 1) return true;
         
        if (word[0] != word[^1]) return false;

        return IsPalindrome(word.Substring(1, word.Length - 2));
    }

    /// <summary>
    /// Calculates the Greatest Common Divisor (GCD) of two integers using the Euclidean algorithm.
    /// </summary>
    /// <param name="a">The first integer.</param>
    /// <param name="b">The second integer.</param>
    /// <returns>The greatest common divisor of the two provided numbers.</returns>
    public static int MCD(int a, int b)
    {
        if (b == 0) return a;
        return MCD(b, a % b);
    }

    /// <summary>
    /// Converts a decimal integer to its binary string representation recursively.
    /// </summary>
    /// <param name="n">The decimal integer to convert.</param>
    /// <returns>A string representing the binary value of the number (e.g., 5 returns "101").</returns>
    public static string DecimalToBinary(int n)
    {
        if (n == 0) return "0";
        if (n == 1) return "1";
        
        return DecimalToBinary(n / 2) + (n % 2);
    }
    
}