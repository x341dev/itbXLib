# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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


