# itbXLib

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4.svg)](https://dotnet.microsoft.com/)
[![NuGet](https://img.shields.io/badge/nuget-itbXLib-blue.svg)](https://www.nuget.org/)

A helper library for educational activities at the **Institut Tecnològic de Barcelona** (ITB). This library provides utilities for console applications, including color management and validated user input helpers.

## Features

- **🎨 Color Utilities**: Convert RGB and HEX colors to ANSI escape sequences for colorful console output
- **⌨️ Input Helpers**: Robust console input validation for integers with automatic error handling and retry logic
- **🛡️ Built-in Validation**: Automatic handling of format errors, overflows, and negative numbers
- **💪 Type-Safe**: Built with C# and .NET 8.0 with nullable reference types enabled

## Installation

### Using .NET CLI

```bash
dotnet add package itbXLib
```

### Using Package Manager Console

```powershell
Install-Package itbXLib
```

### Using PackageReference

Add this to your `.csproj` file:

```xml
<PackageReference Include="itbXLib" Version="*" />
```

## Usage

### Colors - RGB/Hex to ANSI

Convert colors to ANSI escape sequences for colorful terminal output:

```csharp
using itbXLib.Colors;

// Using RGB values (0-255)
string redColor = Colors.RgbToAnsi(255, 0, 0);
Console.WriteLine($"{redColor}This text is red!{Colors.AnsiReset}");

// Using HEX color codes
string blueColor = Colors.RgbToAnsi("#0000FF");
Console.WriteLine($"{blueColor}This text is blue!{Colors.AnsiReset}");

// Using HEX without the # prefix
string greenColor = Colors.RgbToAnsi("00FF00");
Console.WriteLine($"{greenColor}This text is green!{Colors.AnsiReset}");

// Always reset colors after use
Console.Write(Colors.AnsiReset);
```

### Input Helpers - Validated Integer Input

Get validated integer input from users with automatic error handling:

```csharp
using itbXLib.Inputs;

// Ask for any integer (can be negative)
int age = IntInput.AskForNumber("Enter your age: ");

// Ask for a non-negative integer only
int score = IntInput.AskForPositiveNumber("Enter your score: ");

// The methods will automatically:
// - Retry on invalid input (non-numeric values)
// - Handle overflow errors (numbers too large for int)
// - Display colored error messages using the Colors utility
// - Keep prompting until valid input is received
```

## API Reference

### `itbXLib.Colors.Colors`

#### Constants

- `AnsiReset`: Resets all console colors and formatting

#### Methods

- `RgbToAnsi(int r, int g, int b)`: Converts RGB values (0-255) to ANSI escape sequence
- `RgbToAnsi(string hex)`: Converts HEX color code (with or without #) to ANSI escape sequence

### `itbXLib.Inputs.IntInput`

#### Methods

- `AskForNumber(string msg)`: Prompts user and returns any valid integer
- `AskForPositiveNumber(string msg)`: Prompts user and returns a non-negative integer (>= 0)

Both methods will loop until valid input is received, displaying colored error messages for:
- Non-numeric input
- Overflow errors (number too large)
- Negative numbers (only for `AskForPositiveNumber`)

## Requirements

- **.NET 8.0** or higher
- Compatible with Windows, macOS, and Linux
- Terminal/console that supports ANSI escape sequences for color features

## Building from Source

```bash
# Clone the repository
git clone https://github.com/x341dev/itbXLib.git
cd itbXLib

# Build the project
dotnet build

# Run tests (if available)
dotnet test
```

## Contributing

Contributions are welcome! Please follow these guidelines:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

Please ensure your code:
- Follows existing code style and conventions
- Includes appropriate XML documentation comments
- Builds without warnings
- Maintains backward compatibility

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Copyright (c) 2026 x341dev

## Maintainer

**x341dev** - [GitHub Profile](https://github.com/x341dev)

**Organization**: ITecBCN (Institut Tecnològic de Barcelona)

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for a list of changes and version history.

---

Made with ❤️ for educational purposes at Institut Tecnològic de Barcelona