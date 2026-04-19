# Zipador

A simple CLI tool to compress and extract ZIP files.

## Features

- **Compress** folders into ZIP files
- **Extract** ZIP files to folders  
- **List** contents of ZIP archives
- Self-contained EXE - no .NET installation required!

## Installation

### Option A: Download Ready-to-Use EXE (Recommended)

1. Go to [Releases](https://github.com/caioinsaxd/Zipador/releases)
2. Download `Zipador.exe` from the latest release
3. Copy to anywhere (e.g., `C:\Program Files\Zipador`)
4. Run!

```cmd
C:\Program Files\Zipador\Zipador.exe --help
```

### Option B: Build from Source

```bash
git clone https://github.com/caioinsaxd/Zipador.git
cd Zipador
dotnet publish -c Release -r win-x64 -o ./publish
```

## Usage

### Compress

```cmd
Zipador.exe compress "C:\path\to\folder" -o "C:\path\to\output.zip"
```

### Extract

```cmd
Zipador.exe extract "C:\path\to\file.zip" -o "C:\path\to\output"
```

### List Contents

```cmd
Zipador.exe list "C:\path\to\file.zip"
```

## Important: Use Quotes for Paths with Spaces

**Always use `" "` around paths that contain spaces:**

```cmd
# Good - with quotes
Zipador.exe compress "My Documents" -o "archive.zip"

# Bad - without quotes (will fail)
Zipador.exe compress My Documents -o archive.zip
```

## Shortcuts

| Command | Shortcut |
|--------|---------|
| `Zipador.exe --help` | `Zipador.exe -h` |
| `Zipador.exe --list` | `Zipador.exe -l` |

## Examples

```cmd
# Compress a folder
Zipador.exe compress "C:\Users\John\Documents" -o "C:\backup.zip"

# Extract to desktop
Zipador.exe extract "C:\backup.zip" -o "C:\Users\John\Desktop\extracted"

# List contents
Zipador.exe list "C:\backup.zip"

# Show help
Zipador.exe -h
```

## Troubleshooting

### "Error: Archive not found"

- Check the file path is correct
- Use quotes around paths with spaces

### Access Denied

- Run terminal as Administrator if writing to protected folders

## License

MIT