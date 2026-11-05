# Compression in C# with Aspose.ZIP  

A collection of ready‑to‑run C# snippets that demonstrate how to use **Aspose.ZIP for .NET** – a UI‑agnostic backend API that works in ASP.NET Core, console apps, Azure Functions, Docker containers, and any .NET 9+ environment. The examples cover adding entries to existing ZIP archives from streams, configuring automatic disposal of entry sources, building CAB archives from XML files, and compressing XML data into LZIP archives with custom dictionary size and threading options.

## What You Can Do  

- **Add files to an existing ZIP archive from streams** – open source files with `File.OpenRead` and create entries via `CreateEntry` (see *add-entries-to-a-zip-archive-by-opening-source-files-with-openread-and-creating-entries-via-createentry.cs*).  
- **Add a `FileStream` to a ZIP archive with auto‑close of the entry source** – set `CloseEntrySource = true` in `ZipSaveOptions` (see *add-entry-to-zip-from-a-local-filestream-set-closeentrysource-true-in-the-format-specific-save-options-save-auto.cs*).  
- **Create a CAB archive from multiple XML files using stream providers** – supply `StreamProvider` callbacks that automatically dispose the streams after saving (see *build-cab-archive-with-entries-from-two-local-xml-files-using-stream-providers-and-automatic-disposal-save-xml-cab.cs*).  
- **Compress an XML file into an LZIP archive with custom dictionary size and compression threads** – configure `LzipCompressionOptions` before saving (see *configure-lzip-archive-with-custom-dictionary-size-and-compressionthreads-three-compress-dataset-xml-to-dataset-lz.cs*).  
- **(Upcoming) Create a 7z archive from a large video file using SEVENZIP LZMA2 compression** – demonstrates handling of large data streams (referenced in the truncated *create-a-7z-archive-from-a-single-local-large-video-configure-sevenziplzma2compressionse* file).

## Quick Start  

The most common scenario is adding several files to an existing ZIP archive directly from streams:

```csharp
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main()
    {
        // Paths (adjust to your environment)
        string sourceZip = "data/source.zip";
        string[] filesToAdd = { "data/file1.txt", "data/file2.txt" };
        string resultZip = "output/result.zip";

        // Open the source archive for update
        using (var archive = ZipArchive.Open(sourceZip, ZipArchiveMode.Update))
        {
            foreach (var filePath in filesToAdd)
            {
                using var stream = File.OpenRead(filePath);
                // Create a new entry with the same name as the source file
                var entry = archive.CreateEntry(Path.GetFileName(filePath));
                // Copy the file stream into the entry
                stream.CopyTo(entry.Open());
            }

            // Save changes to a new archive
            archive.Save(resultZip);
        }

        Console.WriteLine($"Files added and saved to {resultZip}");
    }
}
```

## Requirements  

- **.NET 9+**  
- **Aspose.Zip** NuGet package  

```bash
dotnet add package Aspose.Zip
```

## Resources  

| Resource | Link |
|----------|------|
| Documentation | https://docs.aspose.com/zip/net/ |
| NuGet | https://www.nuget.org/packages/Aspose.Zip |
| Release Notes | https://releases.aspose.com/zip/net/ |
| Online Apps | https://products.aspose.app/zip/family/ |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-entries-to-a-zip-archive-by-opening-source-files-with-openread-and-creating-entries-via-createentry.cs](./add-entries-to-a-zip-archive-by-opening-source-files-with-openread-and-creating-entries-via-createentry.cs) |
| [add-entry-to-7z-archive-using-createentry-stream-provider-from-a-local-filestream-then-save-final-7z.cs](./add-entry-to-7z-archive-using-createentry-stream-provider-from-a-local-filestream-then-save-final-7z.cs) |
| [add-entry-to-7z-archive-using-createentry-with-a-local-filestream-then-save-streamed-7z.cs](./add-entry-to-7z-archive-using-createentry-with-a-local-filestream-then-save-streamed-7z.cs) |
| [add-entry-to-7z-using-createentry-with-a-local-filestream-set-closeentrysource-true-in-the-format-specific-save-53594.cs](./add-entry-to-7z-using-createentry-with-a-local-filestream-set-closeentrysource-true-in-the-format-specific-save-53594.cs) |
| [add-entry-to-7z-using-createentry-with-a-local-filestream-set-closeentrysource-true-in-the-format-specific-save.cs](./add-entry-to-7z-using-createentry-with-a-local-filestream-set-closeentrysource-true-in-the-format-specific-save.cs) |
| [add-entry-to-cab-using-createentry-with-a-local-filestream-enable-closeentrysource-true-in-the-format-specific.cs](./add-entry-to-cab-using-createentry-with-a-local-filestream-enable-closeentrysource-true-in-the-format-specific.cs) |
| [add-entry-to-zip-archive-using-createentry-with-stream-provider-that-reads-a-local-filestream-then-save-archive.cs](./add-entry-to-zip-archive-using-createentry-with-stream-provider-that-reads-a-local-filestream-then-save-archive.cs) |
| [add-entry-to-zip-from-a-local-filestream-defer-opening-stream-until-compression-begins-save-deferred-open-zip.cs](./add-entry-to-zip-from-a-local-filestream-defer-opening-stream-until-compression-begins-save-deferred-open-zip.cs) |
| [add-entry-to-zip-from-a-local-filestream-enable-automatic-disposal-with-closeentrysource-true-in-the-format.cs](./add-entry-to-zip-from-a-local-filestream-enable-automatic-disposal-with-closeentrysource-true-in-the-format.cs) |
| [add-entry-to-zip-from-a-local-filestream-set-closeentrysource-true-in-the-format-specific-save-options-save-auto.cs](./add-entry-to-zip-from-a-local-filestream-set-closeentrysource-true-in-the-format-specific-save-options-save-auto.cs) |
| [add-entry-to-zip-using-createentry-with-a-local-filestream-enable-automatic-disposal-save-auto-dispose-entries-zip.cs](./add-entry-to-zip-using-createentry-with-a-local-filestream-enable-automatic-disposal-save-auto-dispose-entries-zip.cs) |
| [add-entry-to-zip-using-createentry-with-stream-provider-set-closeentrysource-true-save-auto-close-zip.cs](./add-entry-to-zip-using-createentry-with-stream-provider-set-closeentrysource-true-save-auto-close-zip.cs) |
| [assign-paralleloptions-parallelcompressinmemory-as-parallelcompressionmode-always-create-entries-with-createentry.cs](./assign-paralleloptions-parallelcompressinmemory-as-parallelcompressionmode-always-create-entries-with-createentry.cs) |
| [build-cab-archive-from-five-local-pdf-files-using-stream-providers-and-closeentrysource-true-in-the-format.cs](./build-cab-archive-from-five-local-pdf-files-using-stream-providers-and-closeentrysource-true-in-the-format.cs) |
| [build-cab-archive-from-local-csv-files-using-stream-providers-and-closeentrysource-true-in-the-format-specific.cs](./build-cab-archive-from-local-csv-files-using-stream-providers-and-closeentrysource-true-in-the-format-specific.cs) |
| [build-cab-archive-using-stream-providers-for-four-local-json-files-set-closeentrysource-true-in-the-format.cs](./build-cab-archive-using-stream-providers-for-four-local-json-files-set-closeentrysource-true-in-the-format.cs) |
| [build-cab-archive-using-stream-providers-for-three-local-files-set-closeentrysource-true-in-the-format-specific.cs](./build-cab-archive-using-stream-providers-for-three-local-files-set-closeentrysource-true-in-the-format-specific.cs) |
| [build-cab-archive-using-stream-providers-for-three-local-xml-files-set-closeentrysource-true-in-the-format.cs](./build-cab-archive-using-stream-providers-for-three-local-xml-files-set-closeentrysource-true-in-the-format.cs) |
| [build-cab-archive-with-entries-from-two-local-xml-files-using-stream-providers-and-automatic-disposal-save-xml-cab.cs](./build-cab-archive-with-entries-from-two-local-xml-files-using-stream-providers-and-automatic-disposal-save-xml-cab.cs) |
| [compose-a-7z-archive-from-five-local-files-by-supplying-stream-providers-for-each-entry-then-save-archive-7z.cs](./compose-a-7z-archive-from-five-local-files-by-supplying-stream-providers-for-each-entry-then-save-archive-7z.cs) |
| [compose-a-7z-archive-with-compression-algorithms-by-assigning-lzma-to-text-files-and-bzip2-to-binary-files-and.cs](./compose-a-7z-archive-with-compression-algorithms-by-assigning-lzma-to-text-files-and-bzip2-to-binary-files-and.cs) |
| [compose-zip-archive-from-a-list-of-local-file-paths-using-createentry-for-each-save-urls-archive-zip.cs](./compose-zip-archive-from-a-list-of-local-file-paths-using-createentry-for-each-save-urls-archive-zip.cs) |
| [configure-bzip2saveoptions-compressionthreads-eight-compress-large-dataset-json-to-large-dataset-bz2.cs](./configure-bzip2saveoptions-compressionthreads-eight-compress-large-dataset-json-to-large-dataset-bz2.cs) |
| [configure-bzip2saveoptions-compressionthreads-four-compress-image-set-tif-to-image-set-bz2.cs](./configure-bzip2saveoptions-compressionthreads-four-compress-image-set-tif-to-image-set-bz2.cs) |
| [configure-bzip2saveoptions-compressionthreads-seven-compress-large-image-tif-to-large-image-bz2.cs](./configure-bzip2saveoptions-compressionthreads-seven-compress-large-image-tif-to-large-image-bz2.cs) |
| [configure-bzip2saveoptions-compressionthreads-three-compress-large-dataset-csv-to-large-dataset-bz2.cs](./configure-bzip2saveoptions-compressionthreads-three-compress-large-dataset-csv-to-large-dataset-bz2.cs) |
| [configure-lzip-archive-with-custom-dictionary-size-and-compressionthreads-six-compress-image-png-to-image-lz.cs](./configure-lzip-archive-with-custom-dictionary-size-and-compressionthreads-six-compress-image-png-to-image-lz.cs) |
| [configure-lzip-archive-with-custom-dictionary-size-and-compressionthreads-three-compress-dataset-xml-to-dataset-lz.cs](./configure-lzip-archive-with-custom-dictionary-size-and-compressionthreads-three-compress-dataset-xml-to-dataset-lz.cs) |
| [configure-lzip-archive-with-custom-dictionary-size-compressionthreads-nine-compress-archive-tar-gz-to-archive-lz.cs](./configure-lzip-archive-with-custom-dictionary-size-compressionthreads-nine-compress-archive-tar-gz-to-archive-lz.cs) |
| [configure-lzip-archive-with-custom-dictionary-size-compressionthreads-six-compress-dataset-sql-to-dataset-lz.cs](./configure-lzip-archive-with-custom-dictionary-size-compressionthreads-six-compress-dataset-sql-to-dataset-lz.cs) |
[**View all 112 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/compression)