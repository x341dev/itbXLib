# itbXLib

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4.svg)](https://dotnet.microsoft.com/)
[![NuGet](https://img.shields.io/badge/nuget-itbXLib-blue.svg)](https://www.nuget.org/packages/itbXLib)

A .NET helper library for console applications used in educational projects at ITecBCN.

## Features 🌟

- Terminal color helpers with RGB and HEX to ANSI conversion
- Text styles (bold, italic/cursive, underline, and combined styles)
- Emoji helpers for UTF-8 output and Unicode code point conversion
- Runtime terminal capability detection with safe fallback to plain output
- Generic validated input helper for reusable parsing and validation

## Installation 📥

### .NET CLI

```bash
dotnet add package itbXLib
```

### Package Manager Console

```powershell
Install-Package itbXLib
```

### PackageReference

```xml
<PackageReference Include="itbXLib" Version="*" />
```

## Usage 💠

All public utilities are under:

```csharp
using itbXLib.TerminalUtils;
```

### Colors

```csharp
string red = Colors.RgbToAnsi("#FF0000");
Console.WriteLine($"{red}Error message{Colors.Reset}");

string custom = Colors.RgbToAnsi(30, 144, 255);
Console.WriteLine($"{custom}Info message{Colors.Reset}");
```

### Styled text and emoji

```csharp
Styles.EnableEmojiSupport();

Console.WriteLine(Styles.Bold("Bold text"));
Console.WriteLine(Styles.Italic("Italic text"));
Console.WriteLine(Styles.Underline("Underlined text"));
Console.WriteLine(Styles.BoldItalicUnderline("Strong emphasis"));

string rocket = Styles.FromCodePoint(0x1F680);
Console.WriteLine(Styles.WithEmoji(rocket, "Launch ready"));
```

### ConsoleHelper output

```csharp
ConsoleHelper.ColorWriteLine("Success", ConsoleColor.Green);
ConsoleHelper.ColorWriteLine("HEX message", "#22C55E");
ConsoleHelper.HeaderSeparator("My App");
```

### Generic input validation

```csharp
int age = GenericInputs<int>.Read(
    "Enter age: ",
    "Please enter a valid non-negative integer.",
    input =>
    {
        bool ok = int.TryParse(input, out int value) && value >= 0;
        return (ok, value);
    },
    ConsoleColor.Cyan
);
```

## Terminal compatibility behavior

`TerminalCapabilities` is used internally by color/style helpers:

- It auto-detects ANSI/styling support the first time styling is used
- If unsupported, it prints a one-time warning to `Console.Error`
- Styling is disabled for that runtime and output falls back to plain text
- You can override detection manually with `TerminalCapabilities.ForceSet(bool)`

Example:

```csharp
TerminalCapabilities.Detect();
if (!TerminalCapabilities.StylingEnabled)
{
    Console.WriteLine("Running in plain output mode.");
}
```

## API reference (current)

- `itbXLib.TerminalUtils.Colors`
  - `RgbToAnsi(int r, int g, int b)`
  - `RgbToAnsi(string hex)`
  - `Reset`
- `itbXLib.TerminalUtils.Styles`
  - `Bold(string)`
  - `Italic(string)`
  - `Underline(string)`
  - `BoldItalicUnderline(string)`
  - `EnableEmojiSupport()`
  - `FromCodePoint(int)`
  - `WithEmoji(string emoji, string label)`
- `itbXLib.TerminalUtils.ConsoleHelper`
  - `ColorWrite(...)`, `ColorWriteLine(...)`, `HeaderSeparator(string)`
- `itbXLib.TerminalUtils.GenericInputs<T>`
  - `Read(string message, string errorMessage, Func<string, (bool isValid, T value)> validator, ConsoleColor? color = null)`
- `itbXLib.TerminalUtils.TerminalCapabilities`
  - `StylingEnabled`
  - `Detect()`
  - `ForceSet(bool)`

## Notes on deprecated APIs

Deprecated members are intentionally omitted from this README. For new code, use `GenericInputs<T>` for input workflows and the `itbXLib.TerminalUtils` namespace for all terminal helpers.

## Building from source

```bash
git clone https://github.com/x341dev/itbXLib.git
cd itbXLib
dotnet build
```

## Contributing

Contributions are widely appreciated!
If you want to help out, please follow these steps:

1. Fork the repository
2. Create a branch (`git checkout -b feature/my-change`)
3. Commit using conventional commits
4. Push and open a pull request

## Changelog

See `CHANGELOG.md` for release history.

---

Made with ❤️ from Barcelona. x341dev - [GitHub](https://github.com/x341dev)