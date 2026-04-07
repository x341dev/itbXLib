# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0](https://github.com/x341dev/itbXLib/compare/itbXLib-v1.3.1...itbXLib-v2.0.0) (2026-04-07)


### ⚠ BREAKING CHANGES

* namespaces itbXLib.Colors, itbXLib.ConsoleUtils and itbXLib.Inputs have been removed. All types (Colors, ConsoleHelper, IntInput, Styles) now live under itbXLib.TerminalUtils. Any consumer code must update its using directives accordingly.
* remove ConsoleHelper
* **console:** The method signatures for ColorWrite and ColorWriteLine have changed from (string, byte, byte, byte) to (string, string).
* remove testing (for now)

### Features

* add Ansi reset color to Colors ([ed7fab4](https://github.com/x341dev/itbXLib/commit/ed7fab414f5e0c6d9db6d21dfe6de4ac45c2d4c8))
* add Colors class with RgbToAnsi method for color conversion ([ed4deaf](https://github.com/x341dev/itbXLib/commit/ed4deaf325ffdc14020df97a75468b6f6c1141e8))
* add GitHub Actions workflow for automated release and publishing to NuGet ([2f0d7c6](https://github.com/x341dev/itbXLib/commit/2f0d7c6db774af42a1a6ea8999e06352a5986e71))
* add input validation methods for int, double, string, and bool ([391299a](https://github.com/x341dev/itbXLib/commit/391299a548796e12b18b96eca9c02cfc780c0a3c))
* add RgbToAnsi method for hex color conversion ([b429def](https://github.com/x341dev/itbXLib/commit/b429def544e0af788f68f084482ac84211bfe575))
* add Styles class for terminal text styling and emoji support ([4b556a2](https://github.com/x341dev/itbXLib/commit/4b556a23c5467f75cf9415af622bd70fc7c7c643))
* added helper library for future projects ([d5d9ed1](https://github.com/x341dev/itbXLib/commit/d5d9ed1ccca29abb8051eb30a0011de7780367cf))
* added RGB console support and improoved HeaderSeparator ([e016d26](https://github.com/x341dev/itbXLib/commit/e016d2671242af8326e85cadde4967042f918836))
* **console:** add optional formatting arguments to ColorWrite methods ([32d2291](https://github.com/x341dev/itbXLib/commit/32d22912e98428e530e3540dc1010fc508f140cf))
* **inputs:** add generic input reading method with validation ([fa0da39](https://github.com/x341dev/itbXLib/commit/fa0da39f1682fc293dd50cfc0d6ff9a5ff6c3216))


### Bug Fixes

* added static to the classes declaration ([74ede75](https://github.com/x341dev/itbXLib/commit/74ede7530fc665d24cc44800b2004fcd0aa24c5d))
* **console:** update ConsoleHelper to use formatted messages ([3da4cab](https://github.com/x341dev/itbXLib/commit/3da4cab45cd65e3bde453a68c96965c518346db3))
* **inputs:** using WriteLine on input instead of Write ([37371e3](https://github.com/x341dev/itbXLib/commit/37371e3d6975af2b2454df0d907c10899cf45674))
* update NuGet push command to use environment variable for API key ([1a6e4d7](https://github.com/x341dev/itbXLib/commit/1a6e4d776750c172076794831425583e6e73269f))
* use of now removed ConsoleHelper ([f8193c7](https://github.com/x341dev/itbXLib/commit/f8193c7a0edc91ac10458f21a024afb98f22287d))
* using WriteLine instead of Write ([93a8d60](https://github.com/x341dev/itbXLib/commit/93a8d60413741f9552ca5179351ceef059687a27))


### Code Refactoring

* **console:** replace RGB params with Hex string support ([138e292](https://github.com/x341dev/itbXLib/commit/138e292fb99581b507dccf6d976683cec350b585))
* consolidate all utilities into itbXLib.TerminalUtils and add TerminalCapabilities ([2392ca2](https://github.com/x341dev/itbXLib/commit/2392ca252558b62b353a58b79c02ead192936521))

## [v1.3.1] - 2026-04-06

### BUG FIXES

- Update ConsoleHelper to use formatted messages (3da4cab)

## [v1.3.0] - 2026-04-06

### FEATURES

- Add optional formatting arguments to ColorWrite methods (32d2291)

## [v1.2.0] - 2026-03-23

### BUG FIXES

- Using WriteLine on input instead of Write (37371e3)


### FEATURES

- Add generic input reading method with validation (fa0da39)

## [v1.1.0] - 2026-03-02

### FEATURES

- Add input validation methods for int, double, string, and bool (391299a) — deprecate old methods

## [v1.0.0] - 2026-02-24

### FEATURES

- Add Styles class for terminal text styling and emoji support (4b556a2)


### REFACTOR

- **BREAKING**: Consolidate all utilities into itbXLib.TerminalUtils and add TerminalCapabilities (2392ca2)

## [v0.2.1] - 2026-02-09

### BUG FIXES

- Use of now removed ConsoleHelper (f8193c7)


### FEATURES

- **BREAKING**: Add Ansi reset color to Colors (ed7fab4)

## [v0.2.0] - 2026-02-05

### BUG FIXES

- Using WriteLine instead of Write (93a8d60)


### FEATURES

- Add Colors class with RgbToAnsi method for color conversion (ed4deaf)

- Add RgbToAnsi method for hex color conversion (b429def)

## [v0.1.2] - 2026-01-29

### REFACTOR

- **BREAKING**: Replace RGB params with Hex string support (138e292) — Updated ColorWrite and ColorWriteLine to accept a hex color code string (e.g. "#FF0000") instead of individual byte parameters for RGB.
