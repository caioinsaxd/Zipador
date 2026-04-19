# Zipador

A simple CLI tool to compress and extract ZIP files.

## Features

- **Compress** folders into ZIP files
- **Extract** ZIP files to folders  
- **List** contents of ZIP archives

## Prerequisites

**.NET 10.0 Runtime** - Most Windows 10/11 systems already have it.  
Download from: https://dotnet.microsoft.com/download

## Quick Start (For Users)

### 1. Build

```bash
git clone https://github.com/caioinsaxd/Zipador.git
cd Zipador
dotnet publish -c Release -o ./publish
```

### 2. Add to PATH

```cmd
# Option A: Add manually
# Copy the publish folder path, then:
# System Properties → Environment Variables → PATH → Edit → Add folder path

# Option B: Using CMD (run as Administrator)
setx PATH "%PATH%;C:\path\to\Zipador\publish"
```

### 3. Verify

```cmd
zipador --help
```

## Usage

### Compress

```cmd
zipador compress "C:\path\to\folder" -o "C:\path\to\output.zip"
```

### Extract

```cmd
zipador extract "C:\path\to\file.zip" -o "C:\path\to\output"
```

### List Contents

```cmd
zipador list "C:\path\to\file.zip"
```

## Important: Use Quotes for Paths with Spaces

**Always use `" "` around paths that contain spaces:**

```cmd
# Good - with quotes
zipador compress "My Documents" -o "archive.zip"

# Bad - without quotes (will fail)
zipador compress My Documents -o archive.zip
```

## Shortcuts

| Command | Shortcut |
|--------|---------|
| `zipador --help` | `zipador -h` |
| `zipador --list` | `zipador -l` |

## Examples

```cmd
# Compress a folder
zipador compress "C:\Users\John\Documents" -o "C:\backup.zip"

# Extract to desktop
zipador extract "C:\backup.zip" -o "C:\Users\John\Desktop\extracted"

# List contents
zipador list "C:\backup.zip"

# Show help
zipador -h
```

## Troubleshooting

### "zipador is not recognized"

- Close and reopen your terminal
- Verify PATH: `echo %PATH%`
- Or use full path: `"C:\path\to\Zipador\publish\Zipador.exe" compress folder -o output.zip`

### "Error: Archive not found"

- Check the file path is correct
- Use quotes around paths with spaces
