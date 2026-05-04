---
title: Install Azure Cosmos DB Shell
description: Step-by-step guide to install Azure Cosmos DB Shell using VS Code Marketplace, NuGet package, or self-contained binaries.
author: sajeetharan
ms.author: sasinnat
ms.reviewer: mjbrown
ms.service: cosmos-db
ms.topic: how-to
ms.date: 05/04/2024
---

# Install Azure Cosmos DB Shell

Azure Cosmos DB Shell is available through three distribution methods. Choose the one that best fits your workflow.

## Option 1: VS Code Extension (Recommended)

The VS Code extension provides seamless integration with the code editor.

### Method 1a: Install from VS Code Marketplace

1. **Open VS Code**
   - Launch Visual Studio Code on your machine

2. **Open Extensions Marketplace**
   - Click the Extensions icon (Ctrl+Shift+X / Cmd+Shift+X)
   - Or go to View > Extensions

3. **Search for Cosmos DB**
   - Type "Cosmos DB" in the search box
   - Look for "Azure Cosmos DB Shell" by Microsoft

4. **Install the Extension**
   - Click the Install button
   - Wait for installation to complete

5. **Verify Installation**
   - The extension should appear in your installed extensions list
   - You can now access Cosmos DB Shell from the command palette

### Method 1b: Install from VSIX File

1. **Download Extension**
   - Download `vscode-cosmosdb-0.33.3.vsix` (or latest version) from the releases

2. **Install Extension**
   - Open VS Code
   - Go to Extensions (Ctrl+Shift+X / Cmd+Shift+X)
   - Click the "..." menu and select "Install from VSIX"
   - Select the downloaded file

3. **Complete Installation**
   - Wait for the installation to finish
   - Reload VS Code if prompted

### VS Code Extension Requirements

- **VS Code Version**: 1.85 or later
- **Supported Platforms**: Windows, macOS, Linux
- **Disk Space**: ~50 MB

For detailed VS Code integration features, see [VS Code Extension Setup](cosmosdb-shell-vscode.md).

## Option 2: NuGet Package (.NET Global Tool)

Install as a .NET global tool for command-line access.

### Prerequisites

- **.NET SDK**: Version 10.0 or later
- **Platform Support**: Windows, macOS (Intel and Apple Silicon), Linux (x64 and ARM)

### Installation Steps

1. **Open Terminal or Command Prompt**
   - Windows: Open Command Prompt or PowerShell
   - macOS/Linux: Open Terminal

2. **Install Global Tool**
   ```bash
   dotnet tool install --global CosmosDBShell --prerelease
   ```

3. **Verify Installation**
   ```bash
   cosmosdb-shell --version
   ```

### Update to Latest Version

```bash
dotnet tool update --global CosmosDBShell --prerelease
```

### Uninstall

```bash
dotnet tool uninstall --global CosmosDBShell
```

### Package Details

- **Package Name**: CosmosDBShell
- **Version**: 1.0.213-preview
- **NuGet URL**: [CosmosDBShell on NuGet.org](https://www.nuget.org/packages/CosmosDBShell/1.0.213-preview)
- **License**: MIT

## Option 3: Self-Contained Binary (No .NET Required)

Download and extract a self-contained binary for your platform.

### Prerequisites

- No runtime requirements (includes .NET runtime)
- Sufficient disk space (~200 MB)

### Installation Steps

1. **Download**
   - Choose your platform:
     - **Windows (x64)**: `cosmosdb-shell-win-x64.zip`
     - **Windows (ARM)**: `cosmosdb-shell-win-arm64.zip`
     - **macOS (Intel)**: `cosmosdb-shell-macos-x64.tar.gz`
     - **macOS (Apple Silicon)**: `cosmosdb-shell-macos-arm64.tar.gz`
     - **Linux (x64)**: `cosmosdb-shell-linux-x64.tar.gz`
     - **Linux (ARM64)**: `cosmosdb-shell-linux-arm64.tar.gz`

2. **Extract Archive**
   
   **Windows:**
   ```powershell
   Expand-Archive -Path cosmosdb-shell-win-x64.zip -DestinationPath "C:\Program Files\CosmosDBShell"
   ```
   
   **macOS/Linux:**
   ```bash
   mkdir -p ~/cosmosdb-shell
   tar -xzf cosmosdb-shell-macos-x64.tar.gz -C ~/cosmosdb-shell
   ```

3. **Add to PATH (Optional)**
   
   **Windows:**
   - Add `C:\Program Files\CosmosDBShell` to your system PATH
   - Or use the full path: `C:\Program Files\CosmosDBShell\cosmosdb-shell.exe`
   
   **macOS/Linux:**
   ```bash
   export PATH="$HOME/cosmosdb-shell:$PATH"
   # Add to ~/.bashrc or ~/.zshrc for persistence
   ```

4. **Run**
   ```bash
   cosmosdb-shell
   ```

## Verification

### Test Your Installation

1. **For NuGet Installation:**
   ```bash
   cosmosdb-shell --version
   ```

2. **For Binary Installation:**
   ```bash
   ./cosmosdb-shell --version
   ```

3. **For VS Code Extension:**
   - Open the command palette (Ctrl+Shift+P / Cmd+Shift+P)
   - Type "Cosmos DB Shell"
   - You should see Cosmos DB Shell commands

## Troubleshooting

### "Command Not Found" (NuGet Installation)

- Ensure .NET SDK 10.0+ is installed: `dotnet --version`
- Restart your terminal after installation
- Check that `$HOME/.dotnet/tools` is in your PATH

### "File Not Found" (Binary Installation)

- Verify the archive extracted successfully
- Check file permissions: `chmod +x cosmosdb-shell` (macOS/Linux)
- Use the full path to the executable

### VS Code Extension Not Appearing

- Ensure VS Code version is 1.85 or later
- Restart VS Code
- Check the Extensions marketplace for "Azure Cosmos DB Shell"

## Next Steps

- [Quick Start Guide](cosmosdb-shell-quickstart.md) - Get started with basic commands
- [Command Reference](cosmosdb-shell-commands.md) - Learn all available commands
- [Security Best Practices](cosmosdb-shell-security.md) - Secure your setup

## Support

If you encounter issues:
- [View Troubleshooting Guide](cosmosdb-shell-troubleshooting.md)
- [Check Security Considerations](cosmosdb-shell-security.md)

## See Also

- [Azure Cosmos DB Shell Overview](cosmosdb-shell.md)
- [Azure Cosmos DB Documentation](overview.md)
