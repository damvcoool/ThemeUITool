# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Fixed
- Fixed incorrect access modifier usage (`protected private` changed to `private protected`)
- Fixed typo in `DropdownThemeSO.dropdownArrow` property name
- Added null reference safety checks in `TThemeSelector` base class to prevent NullReferenceExceptions
- Removed commented-out debug code

### Changed
- Refactored `ThemeUITool.cs` to reduce code duplication by extracting `LoadAllThemeAssets()` helper method
- Improved parameter naming in `GetSpecificTheme` method (Theme → themeName)

### Added
- Comprehensive README documentation with installation instructions, usage examples, and best practices
- XML documentation comments for helper methods
- CHANGELOG file for tracking version history

## [1.0.0] - Initial Release

### Added
- Initial release of ThemeUITool
- Support for theming multiple Unity UI components:
  - Button
  - Slider
  - Scrollbar
  - Toggle
  - Input Field
  - Dropdown
  - Scroll View (ScrollRect)
- ScriptableObject-based theme system
- Theme selector components for automatic theme application
- Editor menu items for creating pre-themed UI components
- Default theme support with automatic detection
