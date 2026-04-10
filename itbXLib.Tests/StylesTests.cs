using itbXLib.TerminalUtils;
using Xunit;

namespace itbXLib.Tests;

public class StylesTests
{
    public StylesTests()
    {
        TerminalCapabilities.ForceSet(true);
    }

    [Fact]
    public void Bold_ReturnsBoldWrappedText()
    {
        string result = Styles.Bold("hello");
        Assert.Equal("\u001b[1mhello\u001b[0m", result);
    }

    [Fact]
    public void Italic_ReturnsItalicWrappedText()
    {
        string result = Styles.Italic("hello");
        Assert.Equal("\u001b[3mhello\u001b[0m", result);
    }

    [Fact]
    public void Underline_ReturnsUnderlineWrappedText()
    {
        string result = Styles.Underline("hello");
        Assert.Equal("\u001b[4mhello\u001b[0m", result);
    }

    [Fact]
    public void BoldItalicUnderline_ReturnsCombinedStyles()
    {
        string result = Styles.BoldItalicUnderline("hello");
        Assert.Equal("\u001b[1m\u001b[3m\u001b[4mhello\u001b[0m", result);
    }

    [Fact]
    public void Bold_WhenStylingDisabled_ReturnsPlainText()
    {
        TerminalCapabilities.ForceSet(false);
        try
        {
            Assert.Equal("hello", Styles.Bold("hello"));
            Assert.Equal("hello", Styles.Italic("hello"));
            Assert.Equal("hello", Styles.Underline("hello"));
            Assert.Equal("hello", Styles.BoldItalicUnderline("hello"));
        }
        finally
        {
            TerminalCapabilities.ForceSet(true);
        }
    }

    [Fact]
    public void StyleCodes_WhenStylingDisabled_ReturnEmpty()
    {
        TerminalCapabilities.ForceSet(false);
        try
        {
            Assert.Equal(string.Empty, Styles.BoldCode);
            Assert.Equal(string.Empty, Styles.ItalicCode);
            Assert.Equal(string.Empty, Styles.UnderlineCode);
            Assert.Equal(string.Empty, Styles.ResetCode);
        }
        finally
        {
            TerminalCapabilities.ForceSet(true);
        }
    }

    [Fact]
    public void FromCodePoint_ReturnsEmojiString()
    {
        string emoji = Styles.FromCodePoint(0x1F600);
        Assert.Equal("😀", emoji);
    }

    [Fact]
    public void WithEmoji_CombinesEmojiAndLabel()
    {
        string result = Styles.WithEmoji("😀", "hello");
        Assert.Equal("😀 hello", result);
    }
}
