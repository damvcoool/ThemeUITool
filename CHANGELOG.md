# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.1.0] - 2026-03-25

### Fixed
- Fixed bitwise `&` operator used instead of logical `&&` in `SliderThemeSelector`, `ScrollbarThemeSelector`, and `ToggleThemeSelector` — previously, both operands were always evaluated regardless of the first condition
- Fixed `NullReferenceException` in `DropdownThemeSelector.Apply()` — execution previously continued past the warning log into unchecked field access; all operations are now guarded by a proper null check
- Fixed `GetDefaultTheme()` string manipulation in `ThemeUITool.cs` — replaced the fragile `Substring(0, name.Length - 2)` call with an explicit `EndsWith("SO")` check, making the convention clear and safe for type names that do not end in `"SO"`
- Fixed typo `"DefaultTemplateScrolRect"` → `"DefaultTemplateScrollRect"` in `TThemeSO.cs`; renamed the corresponding asset file

### Added
- `ScrollRectThemeSelector` now applies the `useInertia` field from `ScrollRectThemeSO` — the property was defined in the theme asset but was never written to `ScrollRect.inertia`

### Changed
- Replaced `async void Apply()` + `Task.Delay(50)` in `InputFieldThemeSelector` with `EditorApplication.delayCall` — the correct Unity Editor pattern for deferred work; `async void` silently swallowed exceptions
- Renamed `ToggleThemeSelector.targetToggle` → `TargetToggle` to match the PascalCase convention used by every other selector; updated the reference in `ThemeUIToolCreator`
- Removed no-op `if (m_Theme == null) m_Theme = Theme;` self-assignments from all `Apply()` methods
- Removed `tvOS` from `ThemedUITool.asmdef` `includePlatforms` — the assembly is Editor-only; the tvOS entry was erroneous
- Updated `package.json` minimum Unity version from `"2021.3"` to `"6000.0"` to accurately reflect the use of `FindFirstObjectByType` (introduced in Unity 2023.1 / Unity 6)
- Removed stale commented-out code from `SliderThemeSelector` and `TThemeSelectorEditor`
- Rewrote README with full property tables, corrected menu paths, architecture diagram, and comprehensive API examples

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
