namespace itbXLib.TerminalUtils;

/// <summary>
/// Detects terminal capabilities at runtime and controls whether ANSI styling features
/// (colors, bold, italic, underline, emoji) are available.
/// <para>
/// On first access, the terminal environment is inspected. If it does not support ANSI
/// escape sequences, a one-time warning is printed to <see cref="Console.Error"/> and
/// <see cref="StylingEnabled"/> is set to <c>false</c>, causing all styling methods
/// across <see cref="itbXLib.TerminalUtils.ConsoleHelper"/>, <see cref="itbXLib.TerminalUtils.Colors"/> and <see cref="itbXLib.TerminalUtils.Styles"/>
/// to fall back to plain, unstyled output.
/// </para>
/// </summary>
public static class TerminalCapabilities
{
    private static bool? _stylingEnabled;
    private static bool _warningSent;

    /// <summary>
    /// Gets a value indicating whether ANSI terminal styling is supported and enabled.
    /// <para>
    /// The first time this property is read the terminal environment is automatically
    /// probed via <see cref="Detect"/>. Subsequent reads return the cached result.
    /// </para>
    /// </summary>
    public static bool StylingEnabled
    {
        get
        {
            if (_stylingEnabled is null) Detect();
            return _stylingEnabled!.Value;
        }
    }

    /// <summary>
    /// Probes the current terminal environment and updates <see cref="StylingEnabled"/>.
    /// <para>
    /// Detection logic (in order):
    /// <list type="number">
    ///   <item>If stdout is not connected to a terminal (i.e. it is redirected), styling is disabled.</item>
    ///   <item>On Windows, the <c>TERM</c> / <c>WT_SESSION</c> / <c>ConEmuANSI</c> environment variables
    ///         and the Windows version are checked.</item>
    ///   <item>On Unix-like systems the <c>TERM</c> environment variable is inspected; a value of
    ///         <c>dumb</c> disables styling.</item>
    ///   <item>If the <c>NO_COLOR</c> environment variable is set (regardless of value), styling is disabled
    ///         per the <see href="https://no-color.org"/> convention.</item>
    /// </list>
    /// </para>
    /// <para>
    /// If styling is determined to be unsupported, a one-time warning is written to
    /// <see cref="Console.Error"/> before disabling all features.
    /// </para>
    /// </summary>
    public static void Detect()
    {
        bool supported = InternalDetect();

        if (!supported && !_warningSent)
        {
            _warningSent = true;
            Console.Error.WriteLine(
                "[itbXLib] WARNING: This terminal does not support ANSI escape sequences. " +
                "All text styling (colors, bold, italic, underline) has been disabled.");
        }

        _stylingEnabled = supported;
    }

    /// <summary>
    /// Overrides the auto-detected value and forces styling on or off.
    /// Useful for testing or when the caller knows better than the heuristic.
    /// </summary>
    /// <param name="enabled">
    /// <c>true</c> to force styling on; <c>false</c> to disable all ANSI output.
    /// </param>
    public static void ForceSet(bool enabled)
    {
        _stylingEnabled = enabled;
    }

    // ------------------------------------------------------------------
    // Private helpers
    // ------------------------------------------------------------------

    private static bool InternalDetect()
    {
        // Respect the NO_COLOR convention (https://no-color.org)
        if (Environment.GetEnvironmentVariable("NO_COLOR") is not null)
            return false;

        // When stdout is redirected the terminal can't render ANSI codes
        if (Console.IsOutputRedirected)
            return false;

        string? term = Environment.GetEnvironmentVariable("TERM");

        if (OperatingSystem.IsWindows())
        {
            // Windows Terminal sets WT_SESSION; ConEmu sets ConEmuANSI=ON
            bool hasWt = Environment.GetEnvironmentVariable("WT_SESSION") is not null;
            bool hasConEmu = string.Equals(
                Environment.GetEnvironmentVariable("ConEmuANSI"), "ON",
                StringComparison.OrdinalIgnoreCase);

            // Windows 10 build 10586+ has native VT support
            bool nativeVt = Environment.OSVersion.Version >= new Version(10, 0, 10586);

            // TERM being set usually means a Unix-like shell (WSL / Git-Bash / Cygwin)
            bool hasTerm = !string.IsNullOrEmpty(term) && term != "dumb";

            return hasWt || hasConEmu || nativeVt || hasTerm;
        }

        // Unix / macOS
        if (string.IsNullOrEmpty(term) || term == "dumb")
            return false;

        return true;
    }
}

