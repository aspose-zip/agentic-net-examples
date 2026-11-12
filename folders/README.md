# Folders in C# with Aspose.ZIP – Create and Compress ZIP Archives

Aspose.ZIP for .NET is a UI‑agnostic backend API that works everywhere you can run .NET 9+ code – ASP.NET Core, console apps, Azure Functions, Docker containers, etc. The examples in this folder show how to work with **folders**: adding files from multiple sub‑folders with relative entry paths, compressing an entire directory, compressing only the contents of a folder (excluding the root), and using `FileInfo`/`FileStream` objects to build a ZIP archive.

## What You Can Do
- **Add files from several local sub‑folders to a ZIP while preserving relative paths** – see `add-files-from-multiple-local-subfolders-to-a-zip-using-relative-entry-paths-and-save-the-zip-locally.cs`.
- **Compress a single local folder into a ZIP file** – see `compress-a-directory-then-close-the-archive-and-file-streams-to-release-resources.cs`.
- **Compress an entire directory (including its root) into a ZIP file** – see `compress-an-entire-directory-into-a-zip-archive-and-save-it-to-a-specified-file-path.cs`.
- **Compress multiple files by passing `FileInfo` objects and a `FileStream`** – see `compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-archive-after-writing.cs`.
- **Compress only the contents of a folder (omit the root folder) into a ZIP file** – see `compress-only-the-contents-of-a-directory-excluding-the-root-folder-and-store-as-a-zip-file.cs`.

## Quick Start
The most common scenario is compressing a whole folder into a ZIP archive:

```csharp
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main()
    {
        // Folder to compress
        string inputFolder = @"C:\Data\MyFolder";

        // Destination ZIP file
        string outputZip = @"C:\Data\MyArchive.zip";

        if (!Directory.Exists(inputFolder))
        {
            Console.Error.WriteLine($"Directory not found: {inputFolder}");
            return;
        }

        // Create the archive and add the folder
        using (var archive = new ZipArchive())
        {
            archive.AddFolder(inputFolder);
            archive.Save(outputZip);
        }

        Console.WriteLine($"Folder '{inputFolder}' compressed to '{outputZip}'.");
    }
}
```

## Requirements
- .NET 9 or later
- Aspose.Zip NuGet package  

```bash
dotnet add package Aspose.Zip
```

## Resources
| Link | Description |
|------|-------------|
| [Documentation](https://docs.aspose.com/zip/net/) | Full API reference and guides |
| [NuGet](https://www.nuget.org/packages/Aspose.Zip) | Package download and version history |
| [Release Notes](https://releases.aspose.com/zip/net/) | What's new in each version |
| [Online Apps](https://products.aspose.app/zip/family/) | Try ZIP operations in the browser |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-files-from-multiple-local-subfolders-to-a-zip-using-relative-entry-paths-and-save-the-zip-locally.cs](./add-files-from-multiple-local-subfolders-to-a-zip-using-relative-entry-paths-and-save-the-zip-locally.cs) |
| [add-selected-local-directories-to-a-zip-using-createentries-with-distinct-entry-prefixes-and-save-the-zip-file.cs](./add-selected-local-directories-to-a-zip-using-createentries-with-distinct-entry-prefixes-and-save-the-zip-file.cs) |
| [compress-a-directory-then-close-the-archive-and-file-streams-to-release-resources.cs](./compress-a-directory-then-close-the-archive-and-file-streams-to-release-resources.cs) |
| [compress-a-directory-then-extract-the-archive-to-a-different-location-to-demonstrate-successful-decompression.cs](./compress-a-directory-then-extract-the-archive-to-a-different-location-to-demonstrate-successful-decompression.cs) |
| [compress-an-entire-directory-into-a-zip-archive-and-save-it-to-a-specified-file-path.cs](./compress-an-entire-directory-into-a-zip-archive-and-save-it-to-a-specified-file-path.cs) |
| [compress-an-entire-directory-then-close-the-archive-and-file-streams-to-finalize-the-zip-file.cs](./compress-an-entire-directory-then-close-the-archive-and-file-streams-to-finalize-the-zip-file.cs) |
| [compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-archive-after-writing.cs](./compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-archive-after-writing.cs) |
| [compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-streams-after-compression-completes.cs](./compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-streams-after-compression-completes.cs) |
| [compress-only-the-contents-of-a-directory-excluding-the-root-folder-and-store-as-a-zip-file.cs](./compress-only-the-contents-of-a-directory-excluding-the-root-folder-and-store-as-a-zip-file.cs) |
| [compress-only-the-directory-contents-excluding-the-root-folder-and-save-the-archive-using-a-custom-file-name.cs](./compress-only-the-directory-contents-excluding-the-root-folder-and-save-the-archive-using-a-custom-file-name.cs) |
| [compress-selected-files-by-creating-fileinfo-objects-for-each-file-and-adding-them-to-a-zip-archive.cs](./compress-selected-files-by-creating-fileinfo-objects-for-each-file-and-adding-them-to-a-zip-archive.cs) |
| [create-a-zip-from-a-local-folder-and-save-it-with-filemode-create-replacing-any-existing-output-file.cs](./create-a-zip-from-a-local-folder-and-save-it-with-filemode-create-replacing-any-existing-output-file.cs) |
| [create-a-zip-from-a-local-folder-and-save-it-with-filemode-createnew-reporting-an-existing-output-file-without.cs](./create-a-zip-from-a-local-folder-and-save-it-with-filemode-createnew-reporting-an-existing-output-file-without.cs) |
| [create-archive-add-a-local-source-directory-with-createentries-and-save-the-zip-through-an-output-filestream.cs](./create-archive-add-a-local-source-directory-with-createentries-and-save-the-zip-through-an-output-filestream.cs) |
| [create-archive-add-a-local-source-folder-open-an-output-filestream-with-filemode-create-and-save-the-zip-to-that.cs](./create-archive-add-a-local-source-folder-open-an-output-filestream-with-filemode-create-and-save-the-zip-to-that.cs) |
| [create-archive-entries-from-files-and-subfolders-and-save-the-resulting-zip-archive-to-disk.cs](./create-archive-entries-from-files-and-subfolders-and-save-the-resulting-zip-archive-to-disk.cs) |
| [create-entries-from-files-and-subfolders-then-compress-the-archive-using-the-archive-class.cs](./create-entries-from-files-and-subfolders-then-compress-the-archive-using-the-archive-class.cs) |
| [create-zip-entries-for-all-files-and-subfolders-with-createentries-and-save-the-zip-locally.cs](./create-zip-entries-for-all-files-and-subfolders-with-createentries-and-save-the-zip-locally.cs) |
| [define-a-source-directory-create-fileinfo-objects-for-each-file-and-compress-them-into-a-zip-using-createentries.cs](./define-a-source-directory-create-fileinfo-objects-for-each-file-and-compress-them-into-a-zip-using-createentries.cs) |
| [define-the-source-directory-open-a-filestream-with-specific-filemode-settings-instantiate-archive-and-compress.cs](./define-the-source-directory-open-a-filestream-with-specific-filemode-settings-instantiate-archive-and-compress.cs) |
| [define-the-source-directory-to-be-compressed-then-compress-its-contents-into-a-zip-file-using-c.cs](./define-the-source-directory-to-be-compressed-then-compress-its-contents-into-a-zip-file-using-c.cs) |
| [extract-a-compressed-directory-archive-to-a-new-folder-and-then-close-the-archive-to-release-resources.cs](./extract-a-compressed-directory-archive-to-a-new-folder-and-then-close-the-archive-to-release-resources.cs) |
| [extract-a-compressed-directory-archive-to-a-target-location-using-the-archive-class.cs](./extract-a-compressed-directory-archive-to-a-target-location-using-the-archive-class.cs) |
| [extract-a-compressed-directory-archive-to-a-target-location-while-preserving-the-original-folder-hierarchy.cs](./extract-a-compressed-directory-archive-to-a-target-location-while-preserving-the-original-folder-hierarchy.cs) |
| [open-a-zip-output-filestream-with-filemode-create-add-a-source-folder-with-createentries-and-save-the-zip-before.cs](./open-a-zip-output-filestream-with-filemode-create-add-a-source-folder-with-createentries-and-save-the-zip-before.cs) |
| [open-an-output-filestream-with-filemode-create-add-a-local-folder-to-archive-save-the-zip-and-then-close-the.cs](./open-an-output-filestream-with-filemode-create-add-a-local-folder-to-archive-save-the-zip-and-then-close-the.cs) |
| [use-fileinfo-objects-to-include-hidden-files-in-the-zip-archive-while-compressing-a-directory.cs](./use-fileinfo-objects-to-include-hidden-files-in-the-zip-archive-while-compressing-a-directory.cs) |
[**View all 27 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/folders)
