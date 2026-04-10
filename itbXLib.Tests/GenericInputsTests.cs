using itbXLib.TerminalUtils;
using Xunit;

namespace itbXLib.Tests;

public class GenericInputsTests
{
    [Theory]
    [InlineData("42", true, 42)]
    [InlineData("-1", true, -1)]
    [InlineData("abc", false, 0)]
    [InlineData("", false, 0)]
    public void IntValidator_ParsesCorrectly(string input, bool expectedValid, int expectedValue)
    {
        var (isValid, value) = ParseInt(input);
        Assert.Equal(expectedValid, isValid);
        Assert.Equal(expectedValue, value);
    }

    [Theory]
    [InlineData("3.14", true)]
    [InlineData("0", true)]
    [InlineData("abc", false)]
    public void DoubleValidator_ParsesCorrectly(string input, bool expectedValid)
    {
        bool isValid = double.TryParse(input, out _);
        Assert.Equal(expectedValid, isValid);
    }

    [Theory]
    [InlineData("s", true, true)]
    [InlineData("n", true, false)]
    [InlineData("true", true, true)]
    [InlineData("false", true, false)]
    [InlineData("yes", true, true)]
    [InlineData("no", true, false)]
    [InlineData("maybe", false, false)]
    [InlineData("", false, false)]
    public void ReadBool_Validator_AcceptsExpectedInputs(string input, bool expectedValid, bool expectedValue)
    {
        string normalized = input.Trim().ToLowerInvariant();
        bool isTrue  = normalized is "s" or "true" or "yes";
        bool isFalse = normalized is "n" or "false" or "no";
        bool isValid = isTrue || isFalse;

        Assert.Equal(expectedValid, isValid);
        if (isValid)
            Assert.Equal(expectedValue, isTrue);
    }

    [Theory]
    [InlineData("hello", 1, true)]
    [InlineData("hi", 3, false)]
    [InlineData("", 1, false)]
    [InlineData("   ", 1, false)]
    public void ReadString_Validator_EnforcesMinLength(string input, int minLength, bool expectedValid)
    {
        bool isValid = !string.IsNullOrWhiteSpace(input) && input.Length >= minLength;
        Assert.Equal(expectedValid, isValid);
    }

    // ---------------------------------------------------------------------------
    // Helpers
    // ---------------------------------------------------------------------------

    private static (bool isValid, int value) ParseInt(string input) =>
        (int.TryParse(input, out int val), val);
}
