# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.4.1](https://github.com/x341dev/itbXLib/compare/itbXLib-v1.4.0...itbXLib-v1.4.1) (2026-04-10)


### Bug Fixes

* **tests:** disable test parallelization to prevent static state races ([8f6aa15](https://github.com/x341dev/itbXLib/commit/8f6aa15ca5482d151088b17f874d69ae76ed846a))

## [1.4.0](https://github.com/x341dev/itbXLib/compare/itbXLib-v1.3.6...itbXLib-v1.4.0) (2026-04-10)


### Features

* **colors:** add background color support ([3556b86](https://github.com/x341dev/itbXLib/commit/3556b86dced2c01770340dedc64c15ba1fa595f7)), closes [#12](https://github.com/x341dev/itbXLib/issues/12)
* **inputs:** add convenience methods to GenericInputs ([bc1d29d](https://github.com/x341dev/itbXLib/commit/bc1d29de9621a7904fd15a3783f44efdf2d67937)), closes [#13](https://github.com/x341dev/itbXLib/issues/13)
* **inputs:** add RGB overloads to ConsoleHelper ([938c58c](https://github.com/x341dev/itbXLib/commit/938c58caba077bdc3a137b0c9bfeb45cd5d68577)), closes [#8](https://github.com/x341dev/itbXLib/issues/8)

## [1.3.6](https://github.com/x341dev/itbXLib/compare/itbXLib-v1.3.5...itbXLib-v1.3.6) (2026-04-07)


### Bug Fixes

* add ID to NuGet login step for better tracking ([a0d5b4b](https://github.com/x341dev/itbXLib/commit/a0d5b4bf7bc4f7df0f884382901d905c4d2bd1fb))

## [1.3.5](https://github.com/x341dev/itbXLib/compare/itbXLib-v1.3.4...itbXLib-v1.3.5) (2026-04-07)


### Bug Fixes

* update NuGet push command to use API key from login step ([30c4b51](https://github.com/x341dev/itbXLib/commit/30c4b51978687b183d344e4ecd6d3d8b1d1fdc8a))

## [1.3.4](https://github.com/x341dev/itbXLib/compare/itbXLib-v1.3.3...itbXLib-v1.3.4) (2026-04-07)


### Bug Fixes

* correct PackageReadmeFile element in project file ([89ec36e](https://github.com/x341dev/itbXLib/commit/89ec36efd55b96842a5f3ab468d6af2fae3d4067))
* correct PackageReadmeFile element in project file ([f3d7285](https://github.com/x341dev/itbXLib/commit/f3d7285a3f24f20dc4759223de25f1448c75e5a7))

## [1.3.3](https://github.com/x341dev/itbXLib/compare/itbXLib-v1.3.2...itbXLib-v1.3.3) (2026-04-07)


### Bug Fixes

* correct PackageReadmeFile element in project file ([89ec36e](https://github.com/x341dev/itbXLib/commit/89ec36efd55b96842a5f3ab468d6af2fae3d4067))

## [1.3.2](https://github.com/x341dev/itbXLib/compare/itbXLib-v1.3.1...itbXLib-v1.3.2) (2026-04-07)


### Bug Fixes

* correct PackageReadmeFile element in project file ([f3d7285](https://github.com/x341dev/itbXLib/commit/f3d7285a3f24f20dc4759223de25f1448c75e5a7))

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
