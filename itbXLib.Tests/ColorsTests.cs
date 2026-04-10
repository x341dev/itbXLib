using itbXLib.TerminalUtils;
using Xunit;

namespace itbXLib.Tests;

public class ColorsTests
{
    public ColorsTests()
    {
        TerminalCapabilities.ForceSet(true);
    }

    [Fact]
    public void RgbToAnsi_ReturnsCorrectEscapeSequence()
    {
        string result = Colors.RgbToAnsi(255, 128, 0);
        Assert.Equal("\u001b[38;2;255;128;0m", result);
    }

    [Fact]
    public void RgbToAnsi_Hex_WithHash_ReturnsCorrectSequence()
    {
        string result = Colors.RgbToAnsi("#FF8000");
        Assert.Equal("\u001b[38;2;255;128;0m", result);
    }

    [Fact]
    public void RgbToAnsi_Hex_WithoutHash_ReturnsCorrectSequence()
    {
        string result = Colors.RgbToAnsi("FF8000");
        Assert.Equal("\u001b[38;2;255;128;0m", result);
    }

    [Fact]
    public void RgbToAnsi_Hex_InvalidLength_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => Colors.RgbToAnsi("FFF"));
    }

    [Fact]
    public void RgbToAnsiBg_ReturnsCorrectEscapeSequence()
    {
        string result = Colors.RgbToAnsiBg(0, 0, 255);
        Assert.Equal("\u001b[48;2;0;0;255m", result);
    }

    [Fact]
    public void RgbToAnsiBg_Hex_ReturnsCorrectSequence()
    {
        string result = Colors.RgbToAnsiBg("#0000FF");
        Assert.Equal("\u001b[48;2;0;0;255m", result);
    }

    [Fact]
    public void Reset_ReturnsResetSequence()
    {
        Assert.Equal("\u001b[0m", Colors.Reset);
    }

    [Fact]
    public void RgbToAnsi_WhenStylingDisabled_ReturnsEmpty()
    {
        TerminalCapabilities.ForceSet(false);
        try
        {
            Assert.Equal(string.Empty, Colors.RgbToAnsi(255, 0, 0));
            Assert.Equal(string.Empty, Colors.RgbToAnsi("#FF0000"));
            Assert.Equal(string.Empty, Colors.RgbToAnsiBg(255, 0, 0));
            Assert.Equal(string.Empty, Colors.RgbToAnsiBg("#FF0000"));
            Assert.Equal(string.Empty, Colors.Reset);
        }
        finally
        {
            TerminalCapabilities.ForceSet(true);
        }
    }
}
