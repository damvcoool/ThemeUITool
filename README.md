# ThemeUITool

A Unity Editor tool that makes it easy to add **theme profiles** to Unity UI controls, letting you apply consistent styling across your project's entire user interface from a single ScriptableObject asset.

---

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Quick Start](#quick-start)
- [Creating a Theme](#creating-a-theme)
- [Applying a Theme](#applying-a-theme)
- [Creating Pre-Themed GameObjects](#creating-pre-themed-gameobjects)
- [Default Themes](#default-themes)
- [Theme Reference](#theme-reference)
  - [Button Theme](#button-theme)
  - [Slider Theme](#slider-theme)
  - [Scrollbar Theme](#scrollbar-theme)
  - [Toggle Theme](#toggle-theme)
  - [Input Field Theme](#input-field-theme)
  - [Dropdown Theme](#dropdown-theme)
  - [Scroll View Theme](#scroll-view-theme)
- [Architecture](#architecture)
- [API Reference](#api-reference)
- [Best Practices](#best-practices)
- [Limitations](#limitations)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **ScriptableObject-Based Themes** — Store theme data as reusable project assets; share them across scenes and prefabs
- **Reactive Updates** — All `ThemeSelector` components in the scene automatically refresh whenever you edit a theme asset in the Inspector
- **7 Supported UI Components** — Button, Slider, Scrollbar, Toggle, Input Field, Dropdown, Scroll View
- **One-Click Component Creation** — Create fully pre-themed UI elements straight from the Hierarchy's right-click menu
- **Editor-Only, Zero Runtime Overhead** — The entire tool is compiled and executed inside the Unity Editor only (`#if UNITY_EDITOR`)
- **Custom Property Drawers** — Clean Inspector UI with type-safe theme dropdowns, collapsible shadow settings, and labelled Vector4 padding fields

---

## Requirements

| Dependency | Version |
|---|---|
| **Unity** | 6000.0 (Unity 6) or later |
| **TextMesh Pro** | 3.0.6+ (bundled with Unity 6) |
| **Unity UI (UGUI)** | 1.0.0+ (bundled with Unity 6) |

> **Note:** Unity 6 ships TextMesh Pro and UGUI as built-in packages, so no manual installation is needed beyond Unity itself.

---

## Installation

### Option 1: Unity Package Manager — Git URL *(recommended)*

1. Open **Window > Package Manager**
2. Click the **+** button → **Add package from git URL…**
3. Enter:
   ```
   https://github.com/damvcoool/ThemeUITool.git
   ```
4. Click **Add** — Unity will import the package automatically

### Option 2: Manual

1. Download or clone this repository
2. Copy the `Assets/ThemeUITool` folder into your project's `Assets` directory
3. Unity will compile the assembly automatically

---

## Quick Start

1. In the **Hierarchy**, right-click → **GameObject > Themed UI > Button**
2. A new `Themed Button` GameObject is created inside a Canvas (auto-created if none exists), with a `ButtonThemeSelector` already wired up to the built-in **DefaultButtonTheme**
3. Select the button in the Hierarchy, then click the theme dropdown in the Inspector to switch to any other `ButtonThemeSO` in your project
4. Edit the theme asset in the Project window — all buttons using that theme update instantly

---

## Creating a Theme

1. In the **Project window**, right-click anywhere
2. Go to **Create > Themed UI** and pick the type:

   | Menu item | Asset type |
   |---|---|
   | Button Theme | `ButtonThemeSO` |
   | Dropdown Theme | `DropdownThemeSO` |
   | Input Field Theme | `InputFieldThemeSO` |
   | Scrollbar Theme | `ScrollbarThemeSO` |
   | ScrollRect Theme | `ScrollRectThemeSO` |
   | Slider Theme | `SliderThemeSO` |
   | Toggle Theme | `ToggleThemeSO` |

3. Give the asset a descriptive name (e.g. `PrimaryButtonTheme`, `DarkInputFieldTheme`)
4. Select the new asset and configure it in the Inspector

> **Tip:** Keep all your theme assets in a dedicated folder such as `Assets/UI/Themes/` to keep the Project window tidy.

---

## Applying a Theme

### Method A — Use the Theme Selector component on an existing GameObject

1. Select the UI GameObject in the Hierarchy
2. In the Inspector, click **Add Component** and search for the matching selector:
   - `Button Theme Selector`
   - `Slider Theme Selector`
   - `Scrollbar Theme Selector`
   - `Toggle Theme Selector`
   - `Input Field Theme Selector`
   - `Dropdown Theme Selector`
   - `Scroll Rect Theme Selector`
3. The **Theme** field on the selector shows a dropdown of every compatible `*ThemeSO` asset in your project — pick one
4. The theme applies immediately and updates live whenever you edit the asset

The selector also exposes the **target component** reference fields. These are auto-wired when the component is created via the menu, but you can reassign them manually if needed.

### Method B — Script (Editor scripts / custom tooling)

```csharp
using ThemedUITool;
using UnityEngine;

// --- Retrieve themes ---

// Get every ButtonThemeSO in the project
ButtonThemeSO[] allButtonThemes = ThemeUITool.GetAllThemes<ButtonThemeSO>();

// Get the default theme (asset named "DefaultButtonTheme")
ButtonThemeSO defaultTheme = ThemeUITool.GetDefaultTheme<ButtonThemeSO>();

// Get a theme by its exact asset name
ButtonThemeSO darkTheme = ThemeUITool.GetSpecificTheme<ButtonThemeSO>("DarkButtonTheme");

// --- Apply a theme ---

ButtonThemeSelector selector = myButton.GetComponent<ButtonThemeSelector>();
selector.Theme = darkTheme;
selector.ApplyTheme();
```

---

## Creating Pre-Themed GameObjects

The fastest way to add a themed UI element is via the **Hierarchy context menu**.

Right-click inside the **Hierarchy** window → **Themed UI →** and choose:

| Menu item | GameObject created |
|---|---|
| **Button** | `Themed Button` with Image, Button, ButtonThemeSelector, and a child TMP label |
| **Dropdown** | `Themed Dropdown` with TMP_Dropdown, arrow Image, and a fully-built template ScrollView + Toggle item |
| **Input Field** | `Themed Input Field` with TMP_InputField, TextArea (RectMask2D), Placeholder, and Text children |
| **Scrollbar** | `Themed Scrollbar` with Scrollbar, Sliding Area, and Handle children |
| **Scroll View** | `Themed Scroll View` with ScrollRect, Viewport, Content, and both a horizontal and vertical scrollbar |
| **Slider** | `Themed Slider` with Slider, Background, Fill Area, and Handle Slide Area children |
| **Toggle** | `Themed Toggle` with Toggle, Background, Checkmark, and Label children |

If no Canvas exists in the scene, one is created automatically with **Screen Space – Overlay** render mode and **Constant Physical Size** scaling.

---

## Default Themes

Each `ThemeSelector` component automatically falls back to a **default theme** when none is explicitly assigned. The lookup is by name: the tool searches for an asset named **`Default{TypeName}`**, where `TypeName` is the class name with the trailing `SO` removed.

| Component | Expected default asset name |
|---|---|
| `ButtonThemeSelector` | `DefaultButtonTheme` |
| `SliderThemeSelector` | `DefaultSliderTheme` |
| `ScrollbarThemeSelector` | `DefaultScrollbarTheme` |
| `ToggleThemeSelector` | `DefaultToggleTheme` |
| `InputFieldThemeSelector` | `DefaultInputFieldTheme` |
| `DropdownThemeSelector` | `DefaultDropdownTheme` |
| `ScrollRectThemeSelector` | `DefaultScrollRectTheme` |

Pre-built default assets ship with the package in:
```
Assets/ThemeUITool/Core/Defaults/
```

You can override them for your project by creating assets with the same names anywhere in `Assets/`.

---

## Theme Reference

### Button Theme

**Asset:** `ButtonThemeSO` · **Menu:** *Create > Themed UI > Button Theme*

| Property | Type | Description |
|---|---|---|
| `width` / `height` | `float` | RectTransform size delta |
| `buttonImage` | `Sprite` | Background sprite (Sliced) |
| `colorBlock` | `ColorBlock` | Normal / Highlighted / Pressed / Disabled tint colors |
| `textSize` | `float` | Label font size |
| `fontAsset` | `TMP_FontAsset` | Label font (falls back to TMP default) |
| `fontColor` | `Color` | Label colour |
| `addShadow` | `AddShadow` | Enable shadow, shadow offset and shadow colour |

**Component:** `ButtonThemeSelector`

| Property | Type | Description |
|---|---|---|
| `Theme` | `ButtonThemeSO` | The active theme |
| `TargetButton` | `Button` | The Unity Button component to theme |
| `Text` | `TMP_Text` | The label text component |

---

### Slider Theme

**Asset:** `SliderThemeSO` · **Menu:** *Create > Themed UI > Slider Theme*

| Property | Type | Description |
|---|---|---|
| `width` / `height` | `float` | RectTransform size delta |
| `handleSprite` | `Sprite` | Knob sprite |
| `handleWith` | `float` | Width of the handle Image *(note: this property retains its original spelling in the source)* |
| `colorBlock` | `ColorBlock` | Interactive state colors (applied to the Slider) |
| `fillSprite` | `Sprite` | Fill area sprite |
| `fillColor` | `Color` | Fill area tint |
| `backgroundSprite` | `Sprite` | Track background sprite |
| `backgroundColor` | `Color` | Track background tint |

**Component:** `SliderThemeSelector`

| Property | Type | Description |
|---|---|---|
| `Theme` | `SliderThemeSO` | The active theme |
| `TargetSlider` | `Slider` | The Unity Slider component |
| `Background` | `Image` | The background track Image |

---

### Scrollbar Theme

**Asset:** `ScrollbarThemeSO` · **Menu:** *Create > Themed UI > Scrollbar Theme*

| Property | Type | Description |
|---|---|---|
| `width` / `height` | `float` | RectTransform size delta |
| `handleSprite` | `Sprite` | Handle sprite |
| `colorBlock` | `ColorBlock` | Interactive state colors |
| `direction` | `Scrollbar.Direction` | `LeftToRight`, `RightToLeft`, `BottomToTop`, `TopToBottom` |
| `handleSize` | `float` (0–1) | Normalized size of the handle relative to the track |
| `backgroundSprite` | `Sprite` | Track sprite |
| `backgroundColor` | `Color` | Track tint |

**Component:** `ScrollbarThemeSelector`

| Property | Type | Description |
|---|---|---|
| `Theme` | `ScrollbarThemeSO` | The active theme |
| `TargetScrollbar` | `Scrollbar` | The Unity Scrollbar component |
| `Background` | `Image` | The background track Image |

---

### Toggle Theme

**Asset:** `ToggleThemeSO` · **Menu:** *Create > Themed UI > Toggle Theme*

| Property | Type | Description |
|---|---|---|
| `width` / `height` | `float` | RectTransform size delta |
| `backgroundSprite` | `Sprite` | Checkbox background sprite |
| `colorBlock` | `ColorBlock` | Interactive state colors |
| `checkmarkImage` | `Sprite` | Checkmark sprite |
| `checkmarkColor` | `Color` | Checkmark tint |
| `displayText` | `bool` | Show or hide the label |
| `textSize` | `float` | Label font size |
| `fontAsset` | `TMP_FontAsset` | Label font |
| `fontColor` | `Color` | Label colour |

**Component:** `ToggleThemeSelector`

| Property | Type | Description |
|---|---|---|
| `Theme` | `ToggleThemeSO` | The active theme |
| `TargetToggle` | `Toggle` | The Unity Toggle component |
| `Label` | `TMP_Text` | The label text component |

---

### Input Field Theme

**Asset:** `InputFieldThemeSO` · **Menu:** *Create > Themed UI > Input Field Theme*

| Property | Type | Description |
|---|---|---|
| `width` / `height` | `float` | RectTransform size delta |
| `fieldBackground` | `Sprite` | Border/background sprite |
| `colorBlock` | `ColorBlock` | Interactive state colors |
| `textAreaPadding` | `Vector4` | Padding applied to the RectMask2D viewport *(Left, Right, Top, Bottom)* |
| `multiline` | `UseMultiline` | Enable multiline mode and assign a `ScrollbarThemeSO` profile for the vertical scrollbar |
| `textSize` | `float` | Input text font size |
| `fontAsset` | `TMP_FontAsset` | Input text font |
| `fontColor` | `Color` | Input text colour |
| `placeholderSize` | `float` | Placeholder text font size |
| `placeholderAsset` | `TMP_FontAsset` | Placeholder font |
| `placeholderColor` | `Color` | Placeholder colour (typically semi-transparent) |
| `addShadow` | `AddShadow` | Optional shadow effect |

When **Multiline** is enabled and the `TMP_InputField` has no vertical scrollbar, one is created automatically and themed using the specified `ScrollbarThemeSO` profile.

**Component:** `InputFieldThemeSelector`

| Property | Type | Description |
|---|---|---|
| `Theme` | `InputFieldThemeSO` | The active theme |
| `TargetInputField` | `TMP_InputField` | The TextMeshPro InputField component |

---

### Dropdown Theme

**Asset:** `DropdownThemeSO` · **Menu:** *Create > Themed UI > Dropdown Theme*

| Property | Type | Description |
|---|---|---|
| `width` / `height` | `float` | RectTransform size delta |
| `dropdownImage` | `Sprite` | Main background sprite |
| `colorBlock` | `ColorBlock` | Interactive state colors |
| `captionFontSize` | `float` | Caption text font size |
| `dropdownArrow` | `Sprite` | Arrow icon sprite |
| `dropdownArrowColor` | `Color` | Arrow tint |
| `captionFontAsset` | `TMP_FontAsset` | Caption font |
| `captionFontColor` | `Color` | Caption colour |
| `template` | `ScrollRectThemeSO` | Theme for the drop-down list panel (ScrollRect) |
| `templateItem` | `ToggleThemeSO` | Theme for each item row (Toggle) |

**Component:** `DropdownThemeSelector`

| Property | Type | Description |
|---|---|---|
| `Theme` | `DropdownThemeSO` | The active theme |
| `TargetDropdown` | `TMP_Dropdown` | The TextMeshPro Dropdown component |
| `Arrow` | `Image` | The arrow Image child |
| `Item` | `ToggleThemeSelector` | The template item's ToggleThemeSelector |

---

### Scroll View Theme

**Asset:** `ScrollRectThemeSO` · **Menu:** *Create > Themed UI > ScrollRect Theme*

| Property | Type | Description |
|---|---|---|
| `width` / `height` | `float` | RectTransform size delta |
| `background` | `Sprite` | Background sprite |
| `backgroundColor` | `Color` | Background tint |
| `enableHorizontal` | `bool` | Allow horizontal scrolling |
| `enableVertical` | `bool` | Allow vertical scrolling |
| `viewportMask` | `Sprite` | Viewport mask sprite |
| `viewportMaskColor` | `Color` | Viewport mask tint |
| `contentMovement` | `ScrollRect.MovementType` | `Unrestricted`, `Elastic`, or `Clamped` |
| `useInertia` | `bool` | Enable scroll inertia (momentum after release) |
| `horizontalProfile` | `ScrollbarThemeSO` | Theme for the horizontal scrollbar |
| `horizontalVisibility` | `ScrollRect.ScrollbarVisibility` | Auto-hide behaviour for the horizontal scrollbar |
| `horizontalSpacing` | `float` | Gap between content and horizontal scrollbar |
| `verticalProfile` | `ScrollbarThemeSO` | Theme for the vertical scrollbar |
| `verticalVisibility` | `ScrollRect.ScrollbarVisibility` | Auto-hide behaviour for the vertical scrollbar |
| `verticalSpacing` | `float` | Gap between content and vertical scrollbar |

**Component:** `ScrollRectThemeSelector`

| Property | Type | Description |
|---|---|---|
| `Theme` | `ScrollRectThemeSO` | The active theme |
| `TargetScrollRect` | `ScrollRect` | The Unity ScrollRect component |
| `Background` | `Image` | The background Image component |

---

## Architecture

```
TThemeSO  (abstract ScriptableObject)
├── ButtonThemeSO
├── SliderThemeSO
├── ScrollbarThemeSO
├── ToggleThemeSO
├── InputFieldThemeSO
├── DropdownThemeSO
└── ScrollRectThemeSO

TThemeSelector<T>  (abstract MonoBehaviour, [ExecuteAlways])
├── ButtonThemeSelector
├── SliderThemeSelector
├── ScrollbarThemeSelector
├── ToggleThemeSelector
├── InputFieldThemeSelector
├── DropdownThemeSelector
└── ScrollRectThemeSelector

ThemeUITool  (static Editor utility)
ThemeUIToolCreator  (internal factory — used by Editor menu items)
```

### How reactivity works

1. You edit a `*ThemeSO` asset in the Inspector
2. Unity calls `OnValidate()` on the asset, which sets `_themeChanged = true`
3. The custom `TThemeSOEditor` detects `_themeChanged` on the next `OnInspectorGUI` call and invokes `TThemeSO.ThemeChanged()`
4. Every `TThemeSelector` that has subscribed to that asset's `OnThemeChanged` event calls `ApplyTheme()` in response
5. `ApplyTheme()` calls the concrete `Apply()` implementation, which writes all theme properties to the live Unity UI components

### Editor-only compilation

All runtime MonoBehaviours and ScriptableObjects are wrapped in `#if UNITY_EDITOR`. The assembly definition (`ThemedUITool.asmdef`) targets the **Editor** platform only, so no ThemeUITool code is included in player builds.

---

## API Reference

### `ThemeUITool` (static)

```csharp
// Retrieve themes
TThemeSO[]  ThemeUITool.GetAllThemes(Type type)
T[]         ThemeUITool.GetAllThemes<T>()               where T : TThemeSO
TThemeSO    ThemeUITool.GetDefaultTheme(Type type)
T           ThemeUITool.GetDefaultTheme<T>()             where T : TThemeSO
T           ThemeUITool.GetSpecificTheme<T>(string name) where T : TThemeSO

// Apply properties to components
void ThemeUITool.SetRectTransformProperties(
    GameObject target, Vector4 anchorMinMax, Vector2 size, Vector3 position,
    GameObject parent = null)

void ThemeUITool.SetImageTheme(
    Image target, Sprite sprite, Color color,
    float? width = null, float? height = null)

void ThemeUITool.SetTextTheme(
    TMP_Text target, float fontSize, TMP_FontAsset font, Color color)

void ThemeUITool.SetShadow(
    GameObject target, bool addShadow, Vector2 offset, Color color)
```

### `TThemeSelector<T>` (base component)

```csharp
T    Theme      { get; set; }   // The assigned theme asset
bool Validate   { get; set; }   // Set to true by OnValidate; triggers ApplyTheme() in the Editor

void ApplyTheme()               // Re-applies the current theme to all child UI components
```

### Code Examples

#### Switch a button to a different theme

```csharp
// In an Editor script (e.g. a custom EditorWindow)
ButtonThemeSelector selector = myButton.GetComponent<ButtonThemeSelector>();
selector.Theme = ThemeUITool.GetSpecificTheme<ButtonThemeSO>("DarkButtonTheme");
selector.ApplyTheme();
```

#### Apply the same theme to every Button in the scene

```csharp
ButtonThemeSO theme = ThemeUITool.GetSpecificTheme<ButtonThemeSO>("HighContrastButtonTheme");

foreach (ButtonThemeSelector selector in Object.FindObjectsByType<ButtonThemeSelector>(FindObjectsSortMode.None))
{
    selector.Theme = theme;
    selector.ApplyTheme();
}
```

#### List all available themes of a type

```csharp
ButtonThemeSO[] themes = ThemeUITool.GetAllThemes<ButtonThemeSO>();
foreach (var theme in themes)
    Debug.Log(theme.name);
```

#### Create a pre-themed Button from an Editor script

```csharp
// ThemeUIToolCreator is internal — use it only from Editor code inside the ThemedUITool assembly
// or create via the Hierarchy menu instead.
[MenuItem("MyTools/Create Themed Button")]
private static void CreateThemedButton(MenuCommand menuCommand)
{
    GameObject go = ThemeUIToolCreator.CreateButton();
    // Place it in the scene
    GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
    Undo.RegisterCreatedObjectUndo(go, "Create Themed Button");
    Selection.activeObject = go;
}
```

#### Enable multiline on an Input Field theme

```csharp
InputFieldThemeSO theme = ThemeUITool.GetSpecificTheme<InputFieldThemeSO>("ChatInputTheme");
theme.multiline.multiline = true;
theme.multiline.profile = ThemeUITool.GetSpecificTheme<ScrollbarThemeSO>("DefaultVerticalScrollbarTheme");
// Selector will pick up the change via OnValidate → ThemeChanged → ApplyTheme
```

---

## Best Practices

| Practice | Why |
|---|---|
| **Name defaults correctly** | The fallback lookup is name-based. A `ButtonThemeSO` named `DefaultButtonTheme` is auto-assigned to any `ButtonThemeSelector` with no theme set at `Awake` |
| **Organise by folder** | Keep all theme assets under `Assets/UI/Themes/` (or similar) for easy browsing with the in-Inspector dropdown |
| **One theme per visual variant** | Create `PrimaryButtonTheme`, `SecondaryButtonTheme`, `DangerButtonTheme` rather than duplicating the selector component — just swap the theme reference |
| **Shared sub-themes for Dropdown / ScrollRect** | Dropdown and ScrollRect themes reference `ScrollbarThemeSO` / `ToggleThemeSO` assets; reuse your default scrollbar theme across all scroll views for consistency |
| **Don't edit assets at runtime** | The tool is Editor-only — theme edits and `ApplyTheme()` calls should only happen from `[MenuItem]`, custom `EditorWindow` scripts, or `[ExecuteAlways]` components |

---

## Limitations

- **Editor-only** — ThemeUITool does not run in player builds. UI appearance at runtime is whatever the Editor applied last; there is no runtime theme-switching API
- **TextMesh Pro required** — All text components use `TMP_Text` / `TMP_InputField` / `TMP_Dropdown`
- **Unity 6+ only** — The assembly uses `FindFirstObjectByType<T>()`, which requires Unity 2023.1 / Unity 6

---

## Contributing

Contributions are welcome! Please read [CONTRIBUTING.md](CONTRIBUTING.md) for coding guidelines, commit message conventions, and the pull request process.

---

## License

MIT — see the [LICENSE](LICENSE) file for details.

---

## Support

Found a bug or have a feature request? Please [open an issue](https://github.com/damvcoool/ThemeUITool/issues) on GitHub.

---

## Credits

Developed by [damvcoool](https://github.com/damvcoool)
