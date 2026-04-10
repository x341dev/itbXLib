using itbXLib.TerminalUtils;
using Xunit;

namespace itbXLib.Tests;

public class TerminalCapabilitiesTests
{
    [Fact]
    public void ForceSet_True_EnablesStyling()
    {
        TerminalCapabilities.ForceSet(true);
        Assert.True(TerminalCapabilities.StylingEnabled);
    }

    [Fact]
    public void ForceSet_False_DisablesStyling()
    {
        TerminalCapabilities.ForceSet(false);
        try
        {
            Assert.False(TerminalCapabilities.StylingEnabled);
        }
        finally
        {
            TerminalCapabilities.ForceSet(true);
        }
    }

    [Fact]
    public void NoColor_EnvVar_DisablesStyling()
    {
        Environment.SetEnvironmentVariable("NO_COLOR", "1");
        try
        {
            TerminalCapabilities.Detect();
            Assert.False(TerminalCapabilities.StylingEnabled);
        }
        finally
        {
            Environment.SetEnvironmentVariable("NO_COLOR", null);
            TerminalCapabilities.ForceSet(true);
        }
    }
}
