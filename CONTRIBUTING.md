# Contributing to ThemeUITool

Thank you for your interest in contributing to ThemeUITool! This document provides guidelines for contributing to the project.

## Getting Started

1. Fork the repository
2. Clone your fork: `git clone https://github.com/YOUR-USERNAME/ThemeUITool.git`
3. Create a new branch: `git checkout -b feature/your-feature-name`
4. Make your changes
5. Test your changes in Unity Editor
6. Commit your changes: `git commit -m "Description of changes"`
7. Push to your fork: `git push origin feature/your-feature-name`
8. Submit a Pull Request

## Development Guidelines

### Code Style

- Follow C# naming conventions (PascalCase for public members, camelCase with m_ prefix for private fields)
- Use meaningful variable and method names
- Add XML documentation comments for all public APIs
- Keep methods focused and single-purpose
- Use the provided `.editorconfig` for consistent formatting

### Unity Conventions

- Use Unity's serialization attributes appropriately (`[SerializeField]`, `[HideInInspector]`, etc.)
- Follow Unity's component-based architecture
- Use TextMesh Pro for all text components
- Ensure compatibility with Unity 2021.3 or later

### Testing

- Test your changes in the Unity Editor before submitting
- Create various theme configurations to ensure your changes work in different scenarios
- Verify that existing themes still work correctly after your changes

### Commit Messages

- Use clear, descriptive commit messages
- Start with a verb in present tense (e.g., "Add", "Fix", "Update", "Remove")
- Reference issue numbers when applicable (e.g., "Fix #123: Button theme not applying")

## What to Contribute

### Bug Reports

When reporting bugs, please include:
- Unity version
- Steps to reproduce the issue
- Expected behavior
- Actual behavior
- Screenshots or error logs if applicable

### Feature Requests

When suggesting features, please:
- Describe the feature and its use case
- Explain why it would be valuable
- Consider if it aligns with the tool's editor-only scope

### Code Contributions

Good areas for contribution:
- Bug fixes
- Performance improvements
- Additional theme properties
- Better error handling and validation
- Documentation improvements
- New UI component support (following the existing pattern)

## Code Review Process

1. All Pull Requests will be reviewed by maintainers
2. Feedback will be provided through PR comments
3. Address any requested changes
4. Once approved, your PR will be merged

## Questions?

If you have questions, feel free to:
- Open an issue for discussion
- Tag maintainers in your PR for guidance

Thank you for contributing to ThemeUITool!
