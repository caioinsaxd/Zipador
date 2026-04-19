# Zipador

A simple CLI tool to compress and extract ZIP files.

## Features

- **Compress** folders into ZIP files
- **Extract** ZIP files to folders  
- **List** contents of ZIP archives
- Self-contained EXE - no .NET installation required!
- Interactive mode - just double-click to use!

## Installation

1. Download `Zipador.exe` from [Releases](https://github.com/caioinsaxd/Zipador/releases)
2. Copy to anywhere (e.g., `C:\Program Files\Zipador`)
3. Double-click to run!

## How to Use

### Method 1: Double-Click (Recommended)

Just **double-click** `Zipador.exe` - it opens an interactive window:

```
======================================
       Zipador - ZIP Compression Tool
======================================

Type 'help' for commands, 'exit' to quit.

Zipador> 
```

Then type commands like:
- `compress MyFolder -o archive.zip`
- `extract archive.zip -o extracted`
- `list archive.zip`
- `help`
- `exit`

### Method 2: Command Line

Run from CMD/Terminal:

```cmd
Zipador.exe compress "C:\path\to\folder" -o "C:\path\to\output.zip"
Zipador.exe extract "C:\path\to\file.zip" -o "C:\path\to\output"
Zipador.exe list "C:\path\to\file.zip"
```

## Commands

| Command | Description |
|---------|-------------|
| `compress <folder> -o <output.zip>` | Compress folder to ZIP |
| `extract <archive> -o <folder>` | Extract ZIP to folder |
| `list <archive>` | List ZIP contents |
| `help` | Show available commands |
| `exit` | Quit the program |

## Examples

```
Zipador> compress "My Documents" -o backup.zip
Zipador> extract "backup.zip" -o "extracted folder"
Zipador> list "backup.zip"
Zipador> help
Zipador> exit
```

## Important: Use Quotes for Paths with Spaces

**Always use `" "` around paths that contain spaces:**

```cmd
# Good - with quotes
Zipador.exe compress "My Documents" -o "archive.zip"

# Bad - without quotes (will fail)
Zipador.exe compress My Documents -o archive.zip
```
```

## Troubleshooting

### "Error: Archive not found"

- Check the file path is correct
- Use quotes around paths with spaces

### Access Denied

- Run terminal as Administrator if writing to protected folders
