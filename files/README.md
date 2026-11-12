# Files C# Aspose.ZIP – Working with Archives and Compression

A set of practical C# examples that demonstrate how to use **Aspose.ZIP for .NET**, a UI‑agnostic backend API that runs everywhere – ASP.NET Core, console apps, Azure Functions, Docker containers, etc. The snippets cover creating 7z archives from in‑memory data, applying BZip2 and LZMA compression to ZIP entries, handling multiple files in a single archive, and even chaining compression with immediate extraction.

## What You Can Do
- **Create a 7z archive from in‑memory data** and save it locally using `SevenZipArchive`.
- **Compress a single file to BZip2** while opening the output stream with `FileMode.Create`.
- **Build a ZIP archive that uses BZip2 compression for multiple files** in one pass.
- **Generate a ZIP file with LZMA compression** using `FileMode.Create` for the output stream.
- **Combine compression of several files and instantly decompress the resulting ZIP** in a single workflow.

## Quick Start
The most common scenario is creating a ZIP archive that contains several files. Below is a minimal, ready‑to‑run example:

```csharp
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main()
    {
        // Input files
        string[] files = { "data/file1.txt", "data/file2.txt" };
        // Output ZIP path
        string zipPath = "output/compressed.zip";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

        // Create the ZIP archive
        using (var archive = new ZipArchive())
        {
            foreach (var file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                // Add each file as a new entry
                archive.AddEntry(Path.GetFileName(file), File.OpenRead(file));
            }

            // Save the archive to disk
            using (var outStream = File.Create(zipPath))
                archive.Save(outStream);
        }

        Console.WriteLine($"ZIP archive created at: {zipPath}");
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
| [Release Notes](https://releases.aspose.com/zip/net/) | What's new in each release |
| [Online Apps](https://products.aspose.app/zip/family/) | Try ZIP operations in the browser |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-in-memory-file-data-to-a-new-7z-archive-using-sevenziparchive-and-save-the-7z-file-locally.cs](./add-in-memory-file-data-to-a-new-7z-archive-using-sevenziparchive-and-save-the-7z-file-locally.cs) |
| [add-in-memory-file-data-to-a-tar-container-and-save-a-tar-gz-file-using-savegzipped.cs](./add-in-memory-file-data-to-a-tar-container-and-save-a-tar-gz-file-using-savegzipped.cs) |
| [apply-bzip2-compression-to-a-file-entry-while-using-filemode-create-for-the-output-stream.cs](./apply-bzip2-compression-to-a-file-entry-while-using-filemode-create-for-the-output-stream.cs) |
| [apply-bzip2-compression-to-an-xml-file-entry-while-creating-a-zip-archive-and-store-the-archive.cs](./apply-bzip2-compression-to-an-xml-file-entry-while-creating-a-zip-archive-and-store-the-archive.cs) |
| [apply-bzip2-compression-to-multiple-entries-within-a-zip-archive-created-using-a-file-stream.cs](./apply-bzip2-compression-to-multiple-entries-within-a-zip-archive-created-using-a-file-stream.cs) |
| [apply-lzma-compression-to-a-csv-file-entry-when-creating-a-zip-archive-and-save-it.cs](./apply-lzma-compression-to-a-csv-file-entry-when-creating-a-zip-archive-and-save-it.cs) |
| [apply-lzma-compression-to-a-file-entry-while-using-filemode-create-for-the-output-stream.cs](./apply-lzma-compression-to-a-file-entry-while-using-filemode-create-for-the-output-stream.cs) |
| [apply-lzma-compression-to-multiple-entries-within-a-zip-archive-created-from-fileinfo-objects.cs](./apply-lzma-compression-to-multiple-entries-within-a-zip-archive-created-from-fileinfo-objects.cs) |
| [combine-compression-of-a-set-of-files-and-immediate-decompression-of-the-resulting-zip-archive-in-one-workflow.cs](./combine-compression-of-a-set-of-files-and-immediate-decompression-of-the-resulting-zip-archive-in-one-workflow.cs) |
| [compress-a-single-text-file-into-a-zip-archive-using-a-file-stream-and-save-the-archive.cs](./compress-a-single-text-file-into-a-zip-archive-using-a-file-stream-and-save-the-archive.cs) |
| [compress-files-specified-by-fileinfo-objects-into-a-zip-archive-and-write-the-archive-to-disk.cs](./compress-files-specified-by-fileinfo-objects-into-a-zip-archive-and-write-the-archive-to-disk.cs) |
| [compress-files-using-fileinfo-objects-and-set-an-archive-comment-during-creation.cs](./compress-files-using-fileinfo-objects-and-set-an-archive-comment-during-creation.cs) |
| [compress-files-using-filemode-open-for-reading-source-files-and-create-a-zip-archive.cs](./compress-files-using-filemode-open-for-reading-source-files-and-create-a-zip-archive.cs) |
| [compress-multiple-files-into-a-zip-archive-using-parallel-processing-and-then-list-the-archive-entries.cs](./compress-multiple-files-into-a-zip-archive-using-parallel-processing-and-then-list-the-archive-entries.cs) |
| [compress-multiple-image-files-into-a-zip-archive-using-a-file-stream-and-store-the-resulting-archive.cs](./compress-multiple-image-files-into-a-zip-archive-using-a-file-stream-and-store-the-resulting-archive.cs) |
| [create-an-archive-instance-add-local-files-open-the-zip-output-with-filemode-openorcreate-truncate-stale-output.cs](./create-an-archive-instance-add-local-files-open-the-zip-output-with-filemode-openorcreate-truncate-stale-output.cs) |
| [create-an-archive-instance-add-one-local-file-open-an-output-filestream-with-filemode-create-and-save-the-zip-to.cs](./create-an-archive-instance-add-one-local-file-open-an-output-filestream-with-filemode-create-and-save-the-zip-to.cs) |
| [decompress-a-zip-archive-and-extract-a-specific-file-to-a-designated-output-path.cs](./decompress-a-zip-archive-and-extract-a-specific-file-to-a-designated-output-path.cs) |
| [decompress-a-zip-archive-and-extract-all-its-contents-to-a-target-folder-on-disk.cs](./decompress-a-zip-archive-and-extract-all-its-contents-to-a-target-folder-on-disk.cs) |
| [decompress-a-zip-archive-that-contains-entries-compressed-with-lzma-and-bzip2-methods.cs](./decompress-a-zip-archive-that-contains-entries-compressed-with-lzma-and-bzip2-methods.cs) |
| [decompress-an-existing-tar-gz-into-a-tar-stream-add-a-generated-csv-file-entry-and-save-the-updated-tar-gz-using.cs](./decompress-an-existing-tar-gz-into-a-tar-stream-add-a-generated-csv-file-entry-and-save-the-updated-tar-gz-using.cs) |
| [list-all-entry-names-in-a-zip-archive-and-save-the-list-to-a-csv-file.cs](./list-all-entry-names-in-a-zip-archive-and-save-the-list-to-a-csv-file.cs) |
| [load-a-local-7z-archive-add-a-generated-text-file-stream-using-createentry-and-save-the-updated-7z-archive.cs](./load-a-local-7z-archive-add-a-generated-text-file-stream-using-createentry-and-save-the-updated-7z-archive.cs) |
| [load-a-local-zip-created-with-parallel-compression-read-its-archive-comment-and-save-the-comment-in-a-local-text.cs](./load-a-local-zip-created-with-parallel-compression-read-its-archive-comment-and-save-the-comment-in-a-local-text.cs) |
| [load-an-existing-zip-add-additional-local-file-entries-and-save-the-complete-updated-zip-to-a-new-file-instead-of.cs](./load-an-existing-zip-add-additional-local-file-entries-and-save-the-complete-updated-zip-to-a-new-file-instead-of.cs) |
| [load-an-existing-zip-add-local-image-files-with-bzip2compressionsettings-and-save-the-complete-updated-zip-to-a.cs](./load-an-existing-zip-add-local-image-files-with-bzip2compressionsettings-and-save-the-complete-updated-zip-to-a.cs) |
| [retrieve-the-archive-comment-from-an-existing-zip-archive-and-write-it-to-a-text-file.cs](./retrieve-the-archive-comment-from-an-existing-zip-archive-and-write-it-to-a-text-file.cs) |
| [set-an-archive-comment-after-adding-files-to-the-zip-archive-using-a-file-stream.cs](./set-an-archive-comment-after-adding-files-to-the-zip-archive-using-a-file-stream.cs) |
| [set-an-archive-comment-on-a-newly-created-zip-archive-and-save-the-updated-archive.cs](./set-an-archive-comment-on-a-newly-created-zip-archive-and-save-the-updated-archive.cs) |
| [store-a-pdf-file-in-a-zip-archive-without-compression-and-save-the-uncompressed-archive-file.cs](./store-a-pdf-file-in-a-zip-archive-without-compression-and-save-the-uncompressed-archive-file.cs) |
[**View all 33 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/files)
