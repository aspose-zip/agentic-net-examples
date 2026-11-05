# Convert Archives with Aspose.Zip for .NET (C#)

This collection shows how to **convert** between popular archive formats (RAR, ZIP, 7z, TAR.GZ) using the **Aspose.Zip for .NET** library. The code works in ASP.NET Core, console apps, Azure Functions, Docker containers, and any other UI‑agnostic .NET environment.

## What You Can Do
- **Batch‑convert local RAR archives to 7z** while streaming each extracted entry directly into the new 7z archive (no intermediate files).  
- **Convert a large RAR archive to ZIP** after verifying that enough virtual memory is available, then save the resulting ZIP file.  
- **Preserve trailing‑slash (empty folder) entries** when converting a RAR archive that contains nested directories to ZIP.  
- **Convert a ZIP archive to 7z** and keep empty folder entries intact.  
- **Convert a ZIP archive to a TAR.GZ (or other TAR‑based) format** by compressing on‑the‑fly and writing the final compressed file.

## Quick Start
The most common scenario—converting a ZIP file to a 7z archive while preserving empty folders—can be done in just a few lines:

```csharp
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class ConvertZipTo7z
{
    static void Main()
    {
        string zipPath   = @"C:\Archives\input.zip";
        string sevenZPath = @"C:\Archives\output.7z";

        if (!File.Exists(zipPath))
        {
            Console.Error.WriteLine($"File not found: {zipPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(sevenZPath)!);

        // Load the source ZIP archive
        using (var zip = new ZipArchive(File.OpenRead(zipPath)))
        // Create the target 7z archive, preserving empty folder entries
        using (var sevenZ = new SevenZipArchive(File.Create(sevenZPath), CompressionLevel.Normal, true))
        {
            // Copy all entries (files and empty folders) from ZIP to 7z
            foreach (var entry in zip.Entries)
                sevenZ.AddEntry(entry.FullName, entry.Open(), entry.IsDirectory);
        }

        Console.WriteLine($"Converted '{zipPath}' → '{sevenZPath}'");
    }
}
```

## Requirements
- **.NET 9+**
- **Aspose.Zip** NuGet package  

```bash
dotnet add package Aspose.Zip
```

## Resources

| Link | Description |
|------|-------------|
| [Documentation](https://docs.aspose.com/zip/net/) | Full API reference and usage guides |
| [NuGet](https://www.nuget.org/packages/Aspose.Zip) | Package download and version history |
| [Release Notes](https://releases.aspose.com/zip/net/) | What's new in each release |
| [Online Apps](https://products.aspose.app/zip/family/) | Try zip operations in the browser |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [batch-convert-local-rar-archives-to-7z-passing-extracted-entry-streams-to-compression-on-the-fly-and-save-each-7z.cs](./batch-convert-local-rar-archives-to-7z-passing-extracted-entry-streams-to-compression-on-the-fly-and-save-each-7z.cs) |
| [batch-convert-local-rar-archives-to-7z-using-buffered-entry-data-rather-than-on-the-fly-compression-and-save-each.cs](./batch-convert-local-rar-archives-to-7z-using-buffered-entry-data-rather-than-on-the-fly-compression-and-save-each.cs) |
| [batch-convert-local-rar-archives-to-tar-gz-using-buffered-entry-data-and-save-each-compressed-tar-file.cs](./batch-convert-local-rar-archives-to-tar-gz-using-buffered-entry-data-and-save-each-compressed-tar-file.cs) |
| [batch-convert-local-rar-archives-to-tar-gz-using-extracted-entry-streams-and-save-each-compressed-tar-file.cs](./batch-convert-local-rar-archives-to-tar-gz-using-extracted-entry-streams-and-save-each-compressed-tar-file.cs) |
| [compress-a-cpio-container-of-binary-files-with-bzip2-and-save-binaries-cpio-bz2.cs](./compress-a-cpio-container-of-binary-files-with-bzip2-and-save-binaries-cpio-bz2.cs) |
| [compress-an-existing-tar-file-containing-images-with-bzip2-and-save-images-tar-bz2.cs](./compress-an-existing-tar-file-containing-images-with-bzip2-and-save-images-tar-bz2.cs) |
| [compress-an-existing-tar-stream-with-gzip-and-save-archive-tar-gz.cs](./compress-an-existing-tar-stream-with-gzip-and-save-archive-tar-gz.cs) |
| [convert-a-large-rar-archive-to-zip-format-after-verifying-sufficient-virtual-memory-and-save-the-file.cs](./convert-a-large-rar-archive-to-zip-format-after-verifying-sufficient-virtual-memory-and-save-the-file.cs) |
| [convert-a-large-zip-archive-to-7z-format-after-checking-virtual-memory-availability-and-write-the-output.cs](./convert-a-large-zip-archive-to-7z-format-after-checking-virtual-memory-availability-and-write-the-output.cs) |
| [convert-a-large-zip-archive-to-7z-using-in-memory-entry-data-within-a-caller-specified-memory-budget-and-save-the.cs](./convert-a-large-zip-archive-to-7z-using-in-memory-entry-data-within-a-caller-specified-memory-budget-and-save-the.cs) |
| [convert-a-large-zip-archive-to-tar-gz-format-after-confirming-virtual-memory-is-sufficient-and-store-the-result.cs](./convert-a-large-zip-archive-to-tar-gz-format-after-confirming-virtual-memory-is-sufficient-and-store-the-result.cs) |
| [convert-a-local-zip-to-7z-using-archive-to-read-zip-entries-and-sevenziparchive-to-create-the-target-then-save.cs](./convert-a-local-zip-to-7z-using-archive-to-read-zip-entries-and-sevenziparchive-to-create-the-target-then-save.cs) |
| [convert-a-local-zip-to-tar-gz-using-archive-to-read-zip-entries-and-tararchive-savegzipped-for-the-target-then.cs](./convert-a-local-zip-to-tar-gz-using-archive-to-read-zip-entries-and-tararchive-savegzipped-for-the-target-then.cs) |
| [convert-a-multi-gigabyte-zip-archive-to-tar-gz-using-in-memory-entry-data-within-a-caller-specified-memory-budget.cs](./convert-a-multi-gigabyte-zip-archive-to-tar-gz-using-in-memory-entry-data-within-a-caller-specified-memory-budget.cs) |
| [convert-a-rar-archive-containing-nested-directories-to-zip-while-preserving-trailing-slash-entries.cs](./convert-a-rar-archive-containing-nested-directories-to-zip-while-preserving-trailing-slash-entries.cs) |
| [convert-a-rar-archive-containing-only-directories-to-zip-format-preserving-empty-folder-entries-with-trailing.cs](./convert-a-rar-archive-containing-only-directories-to-zip-format-preserving-empty-folder-entries-with-trailing.cs) |
| [convert-a-rar-archive-directly-to-7z-using-extracted-entry-streams-and-on-the-fly-compression-and-save-the-7z-file.cs](./convert-a-rar-archive-directly-to-7z-using-extracted-entry-streams-and-on-the-fly-compression-and-save-the-7z-file.cs) |
| [convert-a-rar-archive-to-zip-format-using-on-the-fly-compression-and-save-the-file.cs](./convert-a-rar-archive-to-zip-format-using-on-the-fly-compression-and-save-the-file.cs) |
| [convert-a-rar-archive-to-zip-format-without-on-the-fly-compression-and-write-the-output.cs](./convert-a-rar-archive-to-zip-format-without-on-the-fly-compression-and-write-the-output.cs) |
| [convert-a-zip-archive-containing-nested-folders-to-a-7z-archive-while-skipping-empty-directories.cs](./convert-a-zip-archive-containing-nested-folders-to-a-7z-archive-while-skipping-empty-directories.cs) |
| [convert-a-zip-archive-containing-nested-folders-to-a-tar-gz-archive-while-skipping-empty-directories.cs](./convert-a-zip-archive-containing-nested-folders-to-a-tar-gz-archive-while-skipping-empty-directories.cs) |
| [convert-a-zip-archive-to-7z-format-preserving-directory-entries-with-trailing-slash.cs](./convert-a-zip-archive-to-7z-format-preserving-directory-entries-with-trailing-slash.cs) |
| [convert-a-zip-archive-to-7z-format-using-compress-on-the-fly-and-store-the-result.cs](./convert-a-zip-archive-to-7z-format-using-compress-on-the-fly-and-store-the-result.cs) |
| [convert-a-zip-archive-to-7z-format-without-compress-on-the-fly-and-save-the-file.cs](./convert-a-zip-archive-to-7z-format-without-compress-on-the-fly-and-save-the-file.cs) |
| [convert-a-zip-archive-to-7z-using-in-memory-entry-data-and-relative-entry-paths-and-save-the-7z-file.cs](./convert-a-zip-archive-to-7z-using-in-memory-entry-data-and-relative-entry-paths-and-save-the-7z-file.cs) |
| [convert-a-zip-archive-to-a-7z-file-using-sevenziparchive-with-default-lzma2-compression.cs](./convert-a-zip-archive-to-a-7z-file-using-sevenziparchive-with-default-lzma2-compression.cs) |
| [convert-a-zip-archive-to-a-tar-gz-file-by-extracting-entries-and-applying-savegzipped-on-a-tar-archive.cs](./convert-a-zip-archive-to-a-tar-gz-file-by-extracting-entries-and-applying-savegzipped-on-a-tar-archive.cs) |
| [convert-a-zip-archive-to-tar-gz-format-preserving-directory-entries-with-trailing-slash.cs](./convert-a-zip-archive-to-tar-gz-format-preserving-directory-entries-with-trailing-slash.cs) |
| [convert-a-zip-archive-to-tar-gz-format-using-compress-on-the-fly-and-write-the-compressed-file.cs](./convert-a-zip-archive-to-tar-gz-format-using-compress-on-the-fly-and-write-the-compressed-file.cs) |
| [convert-a-zip-archive-to-tar-gz-format-without-compress-on-the-fly-and-save-the-output.cs](./convert-a-zip-archive-to-tar-gz-format-without-compress-on-the-fly-and-save-the-output.cs) |
[**View all 91 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/conversion)