---
name: aspose-zip-examples
description: AI-friendly C# code examples for Aspose.ZIP for .NET
language: csharp
framework: net9.0
package: Aspose.Zip
---

# Aspose.ZIP for .NET Examples

AI-friendly index of compiler-validated C# examples for Aspose.ZIP for .NET.

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET.
When working in this repository:
- Each `.cs` file is a **standalone Console Application** - do not create multi-file projects
- All examples must **compile and run** without errors using `dotnet build` and `dotnet run`
- Follow the conventions, boundaries, and anti-patterns documented below exactly
- Use the **Command Reference** section for build/run commands

## Repository Overview

This repository contains **916** working code examples demonstrating Aspose.ZIP for .NET capabilities.

**Statistics** (as of 2026-11-05):
- Total Examples: 1124
- Categories: 11
- Overall Pass Rate: 100.0%

## Category Details

### archives
- Examples: 575
- Guide: [agents.md](./archives/agents.md)

### compression
- Examples: 112
- Guide: [agents.md](./compression/agents.md)

### conversion
- Examples: 91
- Guide: [agents.md](./conversion/agents.md)

### decryption
- Examples: 45
- Guide: [agents.md](./decryption/agents.md)

### encryption
- Examples: 42
- Guide: [agents.md](./encryption/agents.md)

### events
- Examples: 51
- Guide: [agents.md](./events/agents.md)

## Boundaries

### Always

These rules are mandatory for every example.

#### Use explicit types - never use `var`
```csharp
// CORRECT
using (FileStream zipFile = File.Open("archive.zip", FileMode.Create))
{
    using (Archive archive = new Archive())
    {
        archive.CreateEntry("input.txt", "input.txt");
        archive.Save(zipFile);
    }
}

// WRONG
// var archive = new Archive();
```

#### Use `using` blocks for IDisposable objects
```csharp
// CORRECT
using (Archive archive = new Archive("archive.zip"))
{
    archive.ExtractToDirectory("output");
}

// WRONG - memory leak, file lock not released
// Archive archive = new Archive("archive.zip");
// archive.ExtractToDirectory("output");
```

#### Use Aspose.Zip archive types explicitly
```csharp
// CORRECT
using (Archive archive = new Archive("archive.zip"))
{ }

// WRONG - missing Aspose.Zip namespace/import
// using (Zip zip = new Zip("archive.zip")) { }
```

#### Save archives after adding entries
```csharp
using (Archive archive = new Archive())
{
    archive.CreateEntry("input.txt", "input.txt");
    archive.Save("archive.zip");
}
```

### Ask First

Check with a human before doing any of these:
- **Creating multi-file projects** - each example must be a single `.cs` file
- **Using deprecated APIs** - check the Aspose.ZIP changelog for the current API surface
- **Adding NuGet packages** beyond `Aspose.Zip` - the `.csproj` template only includes Aspose.Zip
- **Modifying shared infrastructure** - `.csproj` templates, `agents.md` files, CI configs

### Never

- Never use `var` for variable declarations
- Never invent archive types or members - use the documented Aspose.Zip API surface
- Never forget to dispose archives and streams - always use `using` blocks
- Never modify `agents.md` files - they are auto-generated
- Never modify the `.csproj` template - it is generated

## Common Mistakes (Anti-Patterns)

### Invented Archive Type
```csharp
// WRONG - no generic Zip type in Aspose.Zip
Zip zip = new Zip("archive.zip");
```
```csharp
// CORRECT
using Aspose.Zip;
Archive archive = new Archive("archive.zip");
```

### Missing using block
```csharp
// WRONG - file handle not released
Archive archive = new Archive("archive.zip");
archive.ExtractToDirectory("output");
```
```csharp
// CORRECT
using (Archive archive = new Archive("archive.zip"))
{
    archive.ExtractToDirectory("output");
}
```

### Using var
```csharp
// WRONG
var archive = new Archive("archive.zip");
var outputDirectory = "output";
```
```csharp
// CORRECT
Archive archive = new Archive("archive.zip");
string outputDirectory = "output";
```

## Repository Structure

```
agents.md
README.md
+-- archives/
+-- compression/
+-- conversion/
+-- decryption/
+-- encryption/
+-- events/
```

## Category Index

| Category | Examples | Pass Rate | Details |
|----------|----------|-----------|---------|
| [Archives](./archives/) | 575 | 100.0% | [agents.md](./archives/agents.md) |
| [Compression](./compression/) | 112 | 100.0% | [agents.md](./compression/agents.md) |
| [Conversion](./conversion/) | 91 | 100.0% | [agents.md](./conversion/agents.md) |
| [Decryption](./decryption/) | 45 | 100.0% | [agents.md](./decryption/agents.md) |
| [Encryption](./encryption/) | 42 | 100.0% | [agents.md](./encryption/agents.md) |
| [Events](./events/) | 51 | 100.0% | [agents.md](./events/agents.md) |

## Command Reference

### Build and Run
```bash
# Create a new project (if needed)
dotnet new console -n ExampleProject --framework net9.0

# Add Aspose.Zip NuGet package
dotnet add package Aspose.Zip

# Build
dotnet build --configuration Release --verbosity minimal

# Run
dotnet run
```

### Project File (.csproj)
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Aspose.Zip" Version="*" />
  </ItemGroup>
</Project>
```

## Testing Guide

Every example must pass these verification steps.

### Build Verification
```bash
dotnet build --configuration Release --verbosity minimal
```
- **Success**: Exit code 0, no `CS` error codes in output
- **Failure**: Any `error CS####` line indicates a build failure

### Common Error Codes
| Code | Meaning | Fix |
|------|---------|-----|
| `CS0104` | Ambiguous type reference | Fully qualify the intended type |
| `CS1061` | Member does not exist on type | Check Aspose.ZIP API docs |
| `CS0246` | Type or namespace not found | Add missing `using` directive |
| `CS0029` | Cannot convert type | Cast explicitly or use correct type |

## How to Use These Examples

### Prerequisites
- .NET SDK (8.0 or higher)
- Aspose.ZIP for .NET (via NuGet)

### Running an Example
1. Navigate to any category folder
2. Each .cs file is a standalone Console Application
3. Compile and run:
   ```bash
   dotnet run <example-file.cs>
   ```



## Related Resources

Aspose.ZIP for .NET is a UI-agnostic backend API for archive processing that integrates into any .NET application — ASP.NET Core, console apps, Azure Functions, Docker containers — without requiring a display or UI framework.

| Resource | URL |
|----------|-----|
| 📖 Documentation | https://docs.aspose.com/zip/net/ |
| 📦 NuGet | https://www.nuget.org/packages/Aspose.Zip |
| 🚀 Release Notes | https://releases.aspose.com/zip/net/ |
| 🌐 Online Apps | https://products.aspose.app/zip/family/ |

## Agent Capabilities

- **MCP‑compatible archive processing agent**  
  - *Input*: Archive metadata, file paths, or raw byte streams (ZIP, TAR, GZIP, etc.) in a format compatible with the MCP (Message Communication Protocol).  
  - *Output*: Validation reports, extraction logs, compression/decompression status, and optionally transformed archive files.

- **REST API for C# code generation**  
  - *Input*: JSON payload describing the desired operation (e.g., “compress folder X”, “encrypt archive Y with password Z”), target .NET version, and optional code style preferences.  
  - *Output*: A `200 OK` response containing a downloadable `.cs` file (or a zip of multiple files) with ready‑to‑run Aspose.ZIP example code, plus a JSON summary of generated classes and methods.

- **Agentic example generator for Aspose.ZIP**  
  - *Input*: High‑level scenario description (e.g., “convert a password‑protected ZIP to a plain ZIP and log events”), optional constraints (runtime, async/sync, error handling).  
  - *Output*: Fully‑commented C# snippet or project skeleton that demonstrates the scenario using Aspose.ZIP APIs, plus a markdown README explaining usage.

- **AI agent for .NET archive processing examples**  
  - *Input*: Natural‑language query or structured request asking for a specific archive operation (compression, encryption, decryption, conversion, event handling).  
  - *Output*: Tailored C# example code, step‑by‑step explanation, and a list of required NuGet packages.

- **OpenAPI‑compatible ZIP code generator**  
  - *Input*: OpenAPI (Swagger) specification fragment that defines an endpoint for ZIP manipulation (e.g., `/zip/compress`, `/zip/decrypt`).  
  - *Output*: Auto‑generated C# controller code, request/response DTOs, and client‑side usage examples that conform to the provided OpenAPI contract.

- **Event‑driven archive workflow builder**  
  - *Input*: Sequence of event definitions (e.g., `OnStart`, `OnProgress`, `OnComplete`, `OnError`) and associated actions in JSON or YAML.  
  - *Output*: C# code wiring Aspose.ZIP event handlers to the defined actions, ready for integration into larger .NET applications.

- **Conversion & encryption/decryption service orchestrator**  
  - *Input*: Source archive location, target format, encryption password (optional), and conversion flags.  
  - *Output*: Executable C# routine that performs the full conversion pipeline, returns status codes, and logs detailed operation metrics.

- **Documentation & metadata extractor**  
  - *Input*: Existing Aspose.ZIP C# project or code file.  
  - *Output*: Structured metadata (methods used, parameters, supported features) and auto‑generated markdown documentation for quick reference.

## Quick Reference
| Task | Category | Key Classes |
|---|---|---|
| Create a new ZIP archive | archives | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveOptions` |
| Add files/folders to an existing archive | compression | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveEntry`, `Aspose.Zip.CompressionLevel`, `Aspose.Zip.CompressionMethod` |
| Extract all entries to a folder | archives | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveExtractor` |
| Extract selected entries (by name or pattern) | archives | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveEntry`, `Aspose.Zip.ArchiveExtractor` |
| List contents of a ZIP file | archives | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveEntry` |
| Remove one or more entries from an archive | archives | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveEntry` |
| Update an existing entry (replace data) | archives | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveEntry` |
| Encrypt an archive with a password | encryption | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveEncryptionOptions` |
| Decrypt an encrypted archive | decryption | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveDecryptionOptions` |
| Set or modify archive comment | archives | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveComment` |
| Convert an archive to a memory stream (or from stream) | conversion | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveStream` |
| Subscribe to archive events (e.g., progress, entry added) | events | `Aspose.Zip.ArchiveEvent`, `Aspose.Zip.ArchiveEventArgs` |
| Split a large archive into multiple parts | compression | `Aspose.Zip.Archive`, `Aspose.Zip.ArchiveOptions` |
| Change compression level/method for specific entries | compression | `Aspose.Zip.ArchiveEntry`, `Aspose.Zip.CompressionLevel`, `Aspose.Zip.CompressionMethod` |
<!-- AUTOGENERATED:START -->
Updated: 2026-11-05 | Run: `20261105_115120` | Examples: 916 | Categories: 6
<!-- AUTOGENERATED:END -->

---
## Related Agentic .NET Example Repositories

| Repository | Product |
|------------|---------|
| [aspose-pdf/agentic-net-examples](https://github.com/aspose-pdf/agentic-net-examples) | Aspose.PDF for .NET |
| [aspose-words/agentic-net-examples](https://github.com/aspose-words/agentic-net-examples) | Aspose.Words for .NET |
| [aspose-cells/agentic-net-examples](https://github.com/aspose-cells/agentic-net-examples) | Aspose.Cells for .NET |
| [aspose-slides/agentic-net-examples](https://github.com/aspose-slides/agentic-net-examples) | Aspose.Slides for .NET |
| [aspose-email/agentic-net-examples](https://github.com/aspose-email/agentic-net-examples) | Aspose.Email for .NET |
| [aspose-barcode/agentic-net-examples](https://github.com/aspose-barcode/agentic-net-examples) | Aspose.BarCode for .NET |

*Maintained by an [agentic example generation workflow](https://metrics.aspose.com/agents/product-families/zip/) | For AI-friendly guidance, see [AGENTS.md](https://github.com/aspose-zip/agentic-net-examples/blob/main/agents.md) | Last updated: 2026-11-05*