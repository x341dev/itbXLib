# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Add comprehensive XML documentation comments to all public types and methods:
  - `Colors` class and `RgbToAnsi` methods
  - `IntInput` class and `AskForNumber`, `AskForPositiveNumber` methods
  - `ConsoleHelper` class and all color/console output methods

### Documentation
- Create `CHANGELOG.md` for release tracking

## [v0.1.2] - 2026-01-29

### Added
- Add XML documentation to all functions and classes (5cc0717)

### Changed
- Rename `Inputs` class to `IntInput` and add `AskForPositiveNumber` method (ad35f7b)
- Rename files and update namespaces for better organization (f52001d)

### Fixed
- Fix `using WriteLine` instead of `Write` for proper console output (93a8d60)
- Remove unnecessary `Recursives` file (3bb8037)

### Security
- Fix typo in CI configuration (99ccc74)
- Fix security hotspot in code (f00e285)

### Chores
- Remove unused function with bad practices (613c42a)
- Remove leftover test files (bca89b3)

## [v0.1.1] - 2026-01-29

### Breaking Changes
- **BREAKING**: `refactor(console)!` - Replace RGB byte parameters with Hex string support (138e292)
  - Method signatures for `ColorWrite` and `ColorWriteLine` changed from `(string, byte, byte, byte)` to `(string, string)`
  - Now accept hex color code strings (e.g., "#FF0000") instead of individual RGB byte parameters

### Chores
- Remove leftover test files (bca89b3)
- Create CI/CD workflow for autopublish to NuGet (955ab5a)

### Fixed
- Update NuGet push command to use environment variable for API key (1a6e4d7)

## [v0.1.0] - 2026-01-29

### Breaking Changes
- **BREAKING**: `feat!` - Add GitHub Actions workflow for automated release and publishing to NuGet (2f0d7c6)
  - Remove testing (for now) to streamline CI/CD pipeline

### Added
- Add GitHub Actions workflow for automated release and publishing to NuGet (2f0d7c6)
- Add RGB console support and improve `HeaderSeparator` method (e016d26)
- Add test suites for Recursive functions (2c4fe52)
- Add automatic testing on push via CI (a2b806f)
- Add `.gitignore` file (4d0d904)
- Add basic `README.md` (b1bdc5e)

### Fixed
- Add `static` to class declarations (74ede75)

### Documentation
- Update test badge on README (3b3b657)

### Chores
- Prepare library for NuGet upload (75515b1)
- Initial commit: Add helper library for future projects (d5d9ed1)
  - Added `ConsoleHelper`, `Inputs`, and `Recursives` modules
