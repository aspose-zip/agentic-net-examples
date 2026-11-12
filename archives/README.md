# Archives in C# with Aspose.ZIP  

A set of ready‑to‑run C# snippets that demonstrate how to work with various archive formats using **Aspose.ZIP for .NET** – a UI‑agnostic backend API that runs everywhere (ASP.NET Core, console apps, Azure Functions, Docker, etc.).  
The examples show how to add a Bzip2‑compressed entry to an XAR archive, compress an executable to LZ, create individual BZ2 files from many text documents, build a self‑extracting EXE from a folder of WIM images, and generate an Apple‑specific archive with custom compression settings.

## What You Can Do  

- **Add a Bzip2‑compressed file to a XAR archive** using a `FileStream` source and save the resulting archive.  
- **Compress a binary executable (`.exe`) to LZ format** with `LzipArchive` and write the compressed data to a file stream.  
- **Compress each local text document into its own BZ2 stream**, producing a separate `.bz2` file per source document.  
- **Create a self‑extracting (SFX) executable** from a folder that contains extracted WIM images.  
- **Create an Apple archive (AppleDouble) with a single entry**, using `AppleCompressionSettings.Store` and disabling the CRC‑32 checksum.

## Quick Start  

```csharp
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Xar;

class QuickStart
{
    static void Main()
    {
        // Input file to be added and the XAR archive to create
        string inputFile = "input.txt";
        string xarPath   = "output.xar";

        // Create a new XAR archive and add the file as a Bzip2‑compressed entry
        using (var archive = new XarArchive())
        {
            using (var source = File.OpenRead(inputFile))
            {
                var entry = archive.CreateEntry("input.txt", CompressionMethod.Bzip2);
                source.CopyTo(entry.Open());
            }

            // Save the archive to disk
            using (var outStream = File.Create(xarPath))
                archive.Save(outStream);
        }

        Console.WriteLine($"Created XAR archive: {xarPath}");
    }
}
```

Run the snippet in any .NET 9+ project after installing the Aspose.ZIP package.

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
| [add-a-bzip2-compressed-entry-to-a-xar-archive-using-a-filestream-source-and-save-the-resulting-archive.cs](./add-a-bzip2-compressed-entry-to-a-xar-archive-using-a-filestream-source-and-save-the-resulting-archive.cs) |
| [add-a-configuration-file-as-an-uncompressed-entry-to-a-xar-archive-using-fileinfo-and-output-the-archive.cs](./add-a-configuration-file-as-an-uncompressed-entry-to-a-xar-archive-using-fileinfo-and-output-the-archive.cs) |
| [add-a-directory-recursively-to-a-zip-archive-while-preserving-ntfs-attributes-and-applying-custom-compression.cs](./add-a-directory-recursively-to-a-zip-archive-while-preserving-ntfs-attributes-and-applying-custom-compression.cs) |
| [add-a-pdf-document-as-an-uncompressed-entry-to-a-xar-archive-using-fileinfo-and-write-the-archive.cs](./add-a-pdf-document-as-an-uncompressed-entry-to-a-xar-archive-using-fileinfo-and-write-the-archive.cs) |
| [add-a-single-file-to-an-existing-zip-archive-using-the-archive-class-and-save-the-updated-archive.cs](./add-a-single-file-to-an-existing-zip-archive-using-the-archive-class-and-save-the-updated-archive.cs) |
| [add-a-single-file-to-the-zip-archive-using-archiveentrysettings-and-save-to-disk.cs](./add-a-single-file-to-the-zip-archive-using-archiveentrysettings-and-save-to-disk.cs) |
| [add-a-zlib-compressed-entry-to-a-xar-archive-from-a-memorystream-source-and-output-the-archive-to-disk.cs](./add-a-zlib-compressed-entry-to-a-xar-archive-from-a-memorystream-source-and-output-the-archive-to-disk.cs) |
| [add-an-entry-to-a-cab-archive-from-a-memory-stream-and-specify-default-compression-settings-before-saving.cs](./add-an-entry-to-a-cab-archive-from-a-memory-stream-and-specify-default-compression-settings-before-saving.cs) |
| [add-an-existing-local-barcode-image-stream-to-a-zip-without-intermediate-files-and-save-the-zip-locally.cs](./add-an-existing-local-barcode-image-stream-to-a-zip-without-intermediate-files-and-save-the-zip-locally.cs) |
| [add-entries-to-a-cab-archive-using-file-metadata-for-entry-names-and-timestamps-then-save.cs](./add-entries-to-a-cab-archive-using-file-metadata-for-entry-names-and-timestamps-then-save.cs) |
| [add-entries-to-a-cabarchive-from-file-streams-and-configure-cabsaveoptions-to-close-each-source-stream-after.cs](./add-entries-to-a-cabarchive-from-file-streams-and-configure-cabsaveoptions-to-close-each-source-stream-after.cs) |
| [add-entries-to-a-cabarchive-using-cabentrysettings-with-cabmszipcompressionsettings-for-mszip-compression-and-save.cs](./add-entries-to-a-cabarchive-using-cabentrysettings-with-cabmszipcompressionsettings-for-mszip-compression-and-save.cs) |
| [add-entries-to-a-cabarchive-using-cabentrysettings-with-cabstorecompressionsettings-to-store-them-uncompressed.cs](./add-entries-to-a-cabarchive-using-cabentrysettings-with-cabstorecompressionsettings-to-store-them-uncompressed.cs) |
| [add-extracted-files-from-a-nested-archive-back-into-the-main-zip-archive-under-a-folder-named-extracted.cs](./add-extracted-files-from-a-nested-archive-back-into-the-main-zip-archive-under-a-folder-named-extracted.cs) |
| [add-extracted-files-from-a-nested-archive-into-the-main-zip-archive-under-a-new-folder-and-save.cs](./add-extracted-files-from-a-nested-archive-into-the-main-zip-archive-under-a-new-folder-and-save.cs) |
| [add-multiple-documents-to-an-existing-7z-archive-using-sevenziparchive-and-save-the-updated-archive.cs](./add-multiple-documents-to-an-existing-7z-archive-using-sevenziparchive-and-save-the-updated-archive.cs) |
| [add-multiple-files-from-a-directory-recursively-to-the-zip-archive-preserving-ntfs-attributes.cs](./add-multiple-files-from-a-directory-recursively-to-the-zip-archive-preserving-ntfs-attributes.cs) |
| [add-multiple-files-to-an-existing-zip-archive-with-archive-class-and-write-the-modified-archive-to-disk.cs](./add-multiple-files-to-an-existing-zip-archive-with-archive-class-and-write-the-modified-archive-to-disk.cs) |
| [add-three-entries-to-a-xar-archive-using-memorystream-sources-each-with-a-compression-type-and-save-archive.cs](./add-three-entries-to-a-xar-archive-using-memorystream-sources-each-with-a-compression-type-and-save-archive.cs) |
| [add-two-files-to-a-cab-archive-using-cabstorecompressionsettings-to-store-entries-without-compression-and-save-it.cs](./add-two-files-to-a-cab-archive-using-cabstorecompressionsettings-to-store-entries-without-compression-and-save-it.cs) |
| [add-two-files-to-a-cab-archive-with-cabmszipcompressionsettings-for-mszip-compression-and-save-the-archive.cs](./add-two-files-to-a-cab-archive-with-cabmszipcompressionsettings-for-mszip-compression-and-save-the-archive.cs) |
| [add-two-local-files-to-a-cabarchive-by-specifying-their-file-paths-and-save-the-resulting-cab-file.cs](./add-two-local-files-to-a-cabarchive-by-specifying-their-file-paths-and-save-the-resulting-cab-file.cs) |
| [append-csv-files-from-a-data-folder-to-an-existing-7z-archive-and-save-the-updated-archive.cs](./append-csv-files-from-a-data-folder-to-an-existing-7z-archive-and-save-the-updated-archive.cs) |
| [append-entries-from-a-directory-to-an-existing-7z-archive-preserve-timestamps-using-fileinfo-and-save-the-archive.cs](./append-entries-from-a-directory-to-an-existing-7z-archive-preserve-timestamps-using-fileinfo-and-save-the-archive.cs) |
| [append-entries-from-a-stream-provider-to-an-existing-7z-archive-encrypt-new-entries-with-aes-and-save.cs](./append-entries-from-a-stream-provider-to-an-existing-7z-archive-encrypt-new-entries-with-aes-and-save.cs) |
| [apply-custom-compression-options-to-a-zip-archive-containing-large-video-files-before-saving-to-disk.cs](./apply-custom-compression-options-to-a-zip-archive-containing-large-video-files-before-saving-to-disk.cs) |
| [apply-savelzipped-on-the-cpio-archive-to-create-a-cpio-lz-file.cs](./apply-savelzipped-on-the-cpio-archive-to-create-a-cpio-lz-file.cs) |
| [apply-savezcompressed-on-the-cpio-archive-to-generate-a-cpio-z-file.cs](./apply-savezcompressed-on-the-cpio-archive-to-generate-a-cpio-z-file.cs) |
| [batch-load-local-zip-files-use-a-separate-image-byte-buffer-for-each-archive-and-save-each-archive-s-extracted.cs](./batch-load-local-zip-files-use-a-separate-image-byte-buffer-for-each-archive-and-save-each-archive-s-extracted.cs) |
| [batch-load-zip-files-from-a-local-directory-extract-their-image-entries-and-save-each-archive-s-images-in-a.cs](./batch-load-zip-files-from-a-local-directory-extract-their-image-entries-and-save-each-archive-s-images-in-a.cs) |
[**View all 575 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/archives)
