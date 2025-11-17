# ThemeUITool

A Unity Editor tool that makes it easier to add "Profiles" (themes) to Unity UI Controls, allowing you to apply consistent theming across your project's user interface.

## Features

- **Theme System**: Apply consistent styling to Unity UI components with reusable theme assets
- **Multiple UI Components Supported**:
  - Buttons
  - Sliders
  - Scrollbars
  - Toggles
  - Input Fields
  - Dropdowns
  - Scroll Views (ScrollRect)
- **Editor-Only**: Runs entirely in the Unity Editor for zero runtime overhead
- **ScriptableObject-Based**: Themes are stored as ScriptableObject assets for easy management and reusability
- **Automatic Application**: Themes automatically apply when changed in the editor
- **Component Creation**: Built-in menu items for creating pre-themed UI components

## Requirements

- Unity 2021.3 or later (tested with Unity 2022.x)
- TextMesh Pro package (included in Unity)
- Universal Render Pipeline 14.0.8 (optional, for rendering)

## Installation

### Option 1: Unity Package Manager (Git URL)

1. Open Unity Package Manager (Window > Package Manager)
2. Click the "+" button and select "Add package from git URL"
3. Enter: `https://github.com/damvcoool/ThemeUITool.git`

### Option 2: Manual Installation

1. Download or clone this repository
2. Copy the `Assets/ThemeUITool` folder into your Unity project's `Assets` folder

## Usage

### Creating a Theme

1. Right-click in the Project window
2. Select **Create > Themed UI** and choose the type of theme you want to create:
   - Button Theme
   - Dropdown Theme
   - Input Field Theme
   - Scrollbar Theme
   - Scroll View Theme
   - Slider Theme
   - Toggle Theme

3. Configure the theme properties in the Inspector:
   - Size dimensions
   - Colors (normal, highlighted, pressed, disabled)
   - Sprites
   - Font and font size
   - Shadow effects

### Applying a Theme to a UI Component

#### Method 1: Add Theme Selector Component

1. Select an existing UI component in your scene
2. In the Inspector, click **Add Component**
3. Search for the appropriate **Theme Selector** (e.g., "Button Theme Selector")
4. Assign your theme asset to the Theme field
5. The theme will automatically apply

#### Method 2: Create Pre-Themed Components

1. Right-click in the Hierarchy window
2. Select **GameObject > UI > Themed UI** and choose a component type
3. A new UI component with theme selector will be created

### Creating Default Themes

The tool looks for themes with specific naming conventions for defaults:
- `DefaultButtonTheme` for buttons
- `DefaultSliderTheme` for sliders
- `DefaultScrollbarTheme` for scrollbars
- etc.

Components without an assigned theme will automatically use the default theme if it exists.

## Theme Types

### Button Theme
Controls button appearance including:
- Width and height
- Button sprite and color block
- Text size, font, and color
- Optional shadow effect

### Slider Theme
Configures slider appearance:
- Dimensions
- Background, fill, and handle sprites
- Color schemes for all slider parts

### Scrollbar Theme
Customizes scrollbar styling:
- Direction (horizontal/vertical)
- Background and handle appearance
- Size and colors

### Toggle Theme
Defines toggle appearance:
- Checkmark sprite and size
- Background colors
- Label text properties

### Input Field Theme
Sets input field styling:
- Border sprite and colors
- Text and placeholder styles
- Multiline support

### Dropdown Theme
Controls dropdown appearance:
- Main dropdown styling
- Arrow icon
- Template (list) appearance
- Item toggle styling

### Scroll View Theme
Manages scroll view appearance:
- Viewport and content area
- Scrollbar themes for both axes
- Background and mask settings

## Architecture

### Core Classes

- **`TThemeSO`**: Base class for all theme ScriptableObjects
- **`TThemeSelector<T>`**: Base component class that applies themes to UI elements
- **`ThemeUITool`**: Static utility class with helper methods for theme management

### Component Structure

Each UI component has:
1. A `*ThemeSO` ScriptableObject defining the theme data
2. A `*ThemeSelector` MonoBehaviour component that applies the theme

## Examples

### Creating a Themed Button

```csharp
// In Editor code
GameObject button = ThemeUIToolCreator.CreateButton();
// Button is automatically themed with the default ButtonTheme
```

### Switching Themes at Editor Time

```csharp
ButtonThemeSelector selector = button.GetComponent<ButtonThemeSelector>();
selector.Theme = myCustomButtonTheme;
selector.ApplyTheme();
```

### Finding All Button Themes

```csharp
ButtonThemeSO[] allButtonThemes = ThemeUITool.GetAllThemes<ButtonThemeSO>();
```

## Best Practices

1. **Create Default Themes**: Set up default themes for each component type to ensure consistency
2. **Organize Themes**: Keep theme assets in a dedicated folder (e.g., `Assets/Themes/`)
3. **Theme Variations**: Create theme variations for different UI contexts (e.g., "Primary Button", "Secondary Button")
4. **Naming Conventions**: Use clear, descriptive names for themes
5. **Test in Editor**: Always test theme changes in the Editor's Play mode

## Limitations

- **Editor Only**: This tool only works in the Unity Editor (not at runtime)
- **TextMesh Pro Required**: Uses TextMesh Pro for text components
- **Manual Updates**: Themes must be manually applied when changed (automatic in Editor)

## Contributing

Contributions are welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Support

For issues, questions, or suggestions, please [open an issue](https://github.com/damvcoool/ThemeUITool/issues) on GitHub.

## Credits

Developed by [damvcoool](https://github.com/damvcoool)
