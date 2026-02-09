# Changelog

All notable changes to this project are documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### ADDED

- **BREAKING**: Add Ansi reset color to Colors (ed7fab4)


### DOCUMENTATION

- Created LICENSE (75c2ca4)

- Update CHANGELOG.md [skip ci] (976b898)

## [v0.2.0] - 2026-02-05

### ADDED

- Add Colors class with RgbToAnsi method for color conversion (ed4deaf)

- Add RgbToAnsi method for hex color conversion (b429def)


### CI/CD

- Add GitHub Actions workflow for automatic CHANGELOG generation (11ccfa4)


### CHANGED

- Remove unnecesary Recursives file (3bb8037)

- Rename files and update namespaces for better organization (f52001d)

- Rename Inputs class to IntInput and add AskForPositiveNumber method (ad35f7b)


### DOCUMENTATION

- Add documentation to all functions (5cc0717)

- Create CHANGELOG.md (4b8e341)

- Update CHANGELOG.md [skip ci] (e18fc40)


### FIXED

- Using WriteLine instead of Write (93a8d60)

## [v0.1.2] - 2026-01-29

### CI/CD

- Create ci/cd workflow for autopublish to NuGet (955ab5a)

- Fix security hotspot (f00e285)

- Fix typo (whoops) (99ccc74)


### CHANGED

- **BREAKING**: Replace RGB params with Hex string support (138e292) — Updated ColorWrite and ColorWriteLine to accept a hex color code string (e.g. "#FF0000") instead of individual byte parameters for RGB.


### CHORES

- Remove letfover test files (bca89b3)

- Remove unused function with bad practices (613c42a)


