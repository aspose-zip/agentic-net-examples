---
name: files
description: C# examples for Files using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Files

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Files** category.
This folder contains standalone C# examples for Files operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (33/33 files)
- `using System.IO;` (33/33 files)
- `using Aspose.Zip;` (30/33 files) ← category-specific
- `using Aspose.Zip.Saving;` (18/33 files) ← category-specific
- `using System.Text;` (16/33 files)
- `using Aspose.Zip.SevenZip;` (2/33 files) ← category-specific
- `using Aspose.Zip.Tar;` (2/33 files) ← category-specific
- `using Aspose.Zip.LZMA;` (1/33 files) ← category-specific
- `using Aspose.Zip.Bzip2;` (1/33 files) ← category-specific
- `using System.Linq;` (1/33 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [add-in-memory-file-data-to-a-new-7z-archive-using-sevenziparchive-and-save-the-7z-file-locally.cs](./add-in-memory-file-data-to-a-new-7z-archive-using-sevenziparchive-and-save-the-7z-file-locally.cs) |  | Add in-memory file data to a new 7z archive using SevenZipArchive and save the 7... |
| [add-in-memory-file-data-to-a-tar-container-and-save-a-tar-gz-file-using-savegzipped.cs](./add-in-memory-file-data-to-a-tar-container-and-save-a-tar-gz-file-using-savegzipped.cs) |  | Add in-memory file data to a TAR container and save a TAR.GZ file using SaveGzip... |
| [load-a-local-7z-archive-add-a-generated-text-file-stream-using-createentry-and-save-the-updated-7z-archive.cs](./load-a-local-7z-archive-add-a-generated-text-file-stream-using-createentry-and-save-the-updated-7z-archive.cs) |  | Load a local 7z archive, add a generated text-file stream using CreateEntry, and... |
| [decompress-an-existing-tar-gz-into-a-tar-stream-add-a-generated-csv-file-entry-and-save-the-updated-tar-gz-using.cs](./decompress-an-existing-tar-gz-into-a-tar-stream-add-a-generated-csv-file-entry-and-save-the-updated-tar-gz-using.cs) |  | Decompress an existing TAR.GZ into a TAR stream, add a generated CSV-file entry,... |
| [compress-a-single-text-file-into-a-zip-archive-using-a-file-stream-and-save-the-archive.cs](./compress-a-single-text-file-into-a-zip-archive-using-a-file-stream-and-save-the-archive.cs) |  | Compress a single text file into a ZIP archive using a file stream and save the ... |
| [compress-multiple-image-files-into-a-zip-archive-using-a-file-stream-and-store-the-resulting-archive.cs](./compress-multiple-image-files-into-a-zip-archive-using-a-file-stream-and-store-the-resulting-archive.cs) | `ArchiveSaveOptions` | Compress multiple image files into a ZIP archive using a file stream and store t... |
| [compress-files-specified-by-fileinfo-objects-into-a-zip-archive-and-write-the-archive-to-disk.cs](./compress-files-specified-by-fileinfo-objects-into-a-zip-archive-and-write-the-archive-to-disk.cs) | `ArchiveSaveOptions` | Compress files specified by FileInfo objects into a ZIP archive and write the ar... |
| [compress-files-using-filemode-open-for-reading-source-files-and-create-a-zip-archive.cs](./compress-files-using-filemode-open-for-reading-source-files-and-create-a-zip-archive.cs) | `ArchiveSaveOptions` | Compress files using FileMode.Open for reading source files and create a ZIP arc... |
| [create-an-archive-instance-add-one-local-file-open-an-output-filestream-with-filemode-create-and-save-the-zip-to.cs](./create-an-archive-instance-add-one-local-file-open-an-output-filestream-with-filemode-create-and-save-the-zip-to.cs) |  | Create an Archive instance, add one local file, open an output FileStream with F... |
| [create-an-archive-instance-add-local-files-open-the-zip-output-with-filemode-openorcreate-truncate-stale-output.cs](./create-an-archive-instance-add-local-files-open-the-zip-output-with-filemode-openorcreate-truncate-stale-output.cs) | `ArchiveSaveOptions` | Create an Archive instance, add local files, open the ZIP output with FileMode.O... |
| [compress-multiple-files-into-a-zip-archive-using-parallel-processing-and-then-list-the-archive-entries.cs](./compress-multiple-files-into-a-zip-archive-using-parallel-processing-and-then-list-the-archive-entries.cs) | `ArchiveSaveOptions` | Compress multiple files into a ZIP archive using parallel processing and then li... |
| [combine-compression-of-a-set-of-files-and-immediate-decompression-of-the-resulting-zip-archive-in-one-workflow.cs](./combine-compression-of-a-set-of-files-and-immediate-decompression-of-the-resulting-zip-archive-in-one-workflow.cs) | `ArchiveSaveOptions` | Combine compression of a set of files and immediate decompression of the resulti... |
| [store-a-pdf-file-in-a-zip-archive-without-compression-and-save-the-uncompressed-archive-file.cs](./store-a-pdf-file-in-a-zip-archive-without-compression-and-save-the-uncompressed-archive-file.cs) | `ArchiveSaveOptions` | Store a PDF file in a ZIP archive without compression and save the uncompressed ... |
| [store-a-set-of-files-in-a-zip-archive-without-compression-and-later-extract-them-to-a-folder.cs](./store-a-set-of-files-in-a-zip-archive-without-compression-and-later-extract-them-to-a-folder.cs) | `ArchiveSaveOptions` | Store a set of files in a ZIP archive without compression and later extract them... |
| [store-files-without-compression-and-then-update-the-archive-by-adding-compressed-entries-using-parallel-processing.cs](./store-files-without-compression-and-then-update-the-archive-by-adding-compressed-entries-using-parallel-processing.cs) | `ArchiveSaveOptions` | Store files without compression and then update the archive by adding compressed... |
| [apply-lzma-compression-to-a-csv-file-entry-when-creating-a-zip-archive-and-save-it.cs](./apply-lzma-compression-to-a-csv-file-entry-when-creating-a-zip-archive-and-save-it.cs) |  | Apply LZMA compression to a CSV file entry when creating a ZIP archive and save ... |
| [apply-bzip2-compression-to-an-xml-file-entry-while-creating-a-zip-archive-and-store-the-archive.cs](./apply-bzip2-compression-to-an-xml-file-entry-while-creating-a-zip-archive-and-store-the-archive.cs) |  | Apply BZip2 compression to an XML file entry while creating a ZIP archive and st... |
| [apply-lzma-compression-to-multiple-entries-within-a-zip-archive-created-from-fileinfo-objects.cs](./apply-lzma-compression-to-multiple-entries-within-a-zip-archive-created-from-fileinfo-objects.cs) |  | Apply LZMA compression to multiple entries within a ZIP archive created from Fil... |
| [apply-bzip2-compression-to-multiple-entries-within-a-zip-archive-created-using-a-file-stream.cs](./apply-bzip2-compression-to-multiple-entries-within-a-zip-archive-created-using-a-file-stream.cs) |  | Apply BZip2 compression to multiple entries within a ZIP archive created using a... |
| [apply-lzma-compression-to-a-file-entry-while-using-filemode-create-for-the-output-stream.cs](./apply-lzma-compression-to-a-file-entry-while-using-filemode-create-for-the-output-stream.cs) |  | Apply LZMA compression to a file entry while using FileMode.Create for the outpu... |
| [apply-bzip2-compression-to-a-file-entry-while-using-filemode-create-for-the-output-stream.cs](./apply-bzip2-compression-to-a-file-entry-while-using-filemode-create-for-the-output-stream.cs) |  | Apply BZip2 compression to a file entry while using FileMode.Create for the outp... |
| [load-an-existing-zip-add-additional-local-file-entries-and-save-the-complete-updated-zip-to-a-new-file-instead-of.cs](./load-an-existing-zip-add-additional-local-file-entries-and-save-the-complete-updated-zip-to-a-new-file-instead-of.cs) |  | Load an existing ZIP, add additional local file entries, and save the complete u... |
| [load-an-existing-zip-add-local-image-files-with-bzip2compressionsettings-and-save-the-complete-updated-zip-to-a.cs](./load-an-existing-zip-add-local-image-files-with-bzip2compressionsettings-and-save-the-complete-updated-zip-to-a.cs) |  | Load an existing ZIP, add local image files with Bzip2CompressionSettings, and s... |
| [set-an-archive-comment-on-a-newly-created-zip-archive-and-save-the-updated-archive.cs](./set-an-archive-comment-on-a-newly-created-zip-archive-and-save-the-updated-archive.cs) |  | Set an archive comment on a newly created ZIP archive and save the updated archi... |
| [set-an-archive-comment-after-adding-files-to-the-zip-archive-using-a-file-stream.cs](./set-an-archive-comment-after-adding-files-to-the-zip-archive-using-a-file-stream.cs) |  | Set an archive comment after adding files to the ZIP archive using a file stream... |
| [compress-files-using-fileinfo-objects-and-set-an-archive-comment-during-creation.cs](./compress-files-using-fileinfo-objects-and-set-an-archive-comment-during-creation.cs) | `ArchiveSaveOptions` | Compress files using FileInfo objects and set an archive comment during creation... |
| [retrieve-the-archive-comment-from-an-existing-zip-archive-and-write-it-to-a-text-file.cs](./retrieve-the-archive-comment-from-an-existing-zip-archive-and-write-it-to-a-text-file.cs) |  | Retrieve the archive comment from an existing ZIP archive and write it to a text... |
| [load-a-local-zip-created-with-parallel-compression-read-its-archive-comment-and-save-the-comment-in-a-local-text.cs](./load-a-local-zip-created-with-parallel-compression-read-its-archive-comment-and-save-the-comment-in-a-local-text.cs) |  | Load a local ZIP created with parallel compression, read its archive comment, an... |
| [decompress-a-zip-archive-and-extract-all-its-contents-to-a-target-folder-on-disk.cs](./decompress-a-zip-archive-and-extract-all-its-contents-to-a-target-folder-on-disk.cs) |  | Decompress a ZIP archive and extract all its contents to a target folder on disk... |
| [decompress-a-zip-archive-and-extract-a-specific-file-to-a-designated-output-path.cs](./decompress-a-zip-archive-and-extract-a-specific-file-to-a-designated-output-path.cs) |  | Decompress a ZIP archive and extract a specific file to a designated output path... |
| *...and 3 more files* | | [View all](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/files) |

## Category Statistics
- Total examples: 33
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveSaveOptions`

## Failed Tasks

All tasks passed ✅


## Use Cases
- When you need to generate a **7z archive** directly from in‑memory byte arrays, the “add‑in‑memory‑file‑data‑to‑a‑new‑7z‑archive‑using‑sevenziparchive‑and‑save‑the‑7z‑file‑locally.cs” example shows how to create the archive with `SevenZipArchive` and write it to disk – a common requirement for temporary data packaging in C# applications.  
- If your workflow involves compressing a single file with **BZip2** while ensuring the output stream is created with `FileMode.Create`, the “apply‑bzip2‑compression‑to‑a‑file‑entry‑while‑using‑filemode‑create‑for‑the‑output‑stream.cs” snippet demonstrates the exact API calls and directory handling you need.  
- For projects that must compress **multiple files** into a ZIP archive using **BZip2** compression, the “apply‑bzip2‑compression‑to‑multiple‑entries‑within‑a‑zip‑archive‑created‑using‑a‑file‑stream.cs” file provides a ready‑to‑use pattern that validates inputs, creates the output folder, and configures `ArchiveEntrySettings`.  
- When you want to produce a **LZMA‑compressed ZIP** while explicitly opening the destination file with `FileMode.Create`, the “apply‑lzma‑compression‑to‑a‑file‑entry‑while‑using‑filemode‑create‑for‑the‑output‑stream.cs” example walks through checking source existence, preparing the directory, and applying `LzmaCompressionSettings`.  
- To automate a workflow that **compresses a set of files and immediately extracts them** for verification, the “combine‑compression‑of‑a‑set‑of‑files‑and‑immediate‑decompression‑of‑the‑resulting‑zip‑archive‑in‑one‑workflow.cs” script shows how to use `Archive` for both creation and extraction in a single C# program, ideal for testing backup pipelines.

## Related Categories
The **Files** category naturally complements the **Archives** and **Compression** sections of the repository, where you’ll find examples focused on creating and manipulating archive containers themselves. If you need to work with **stream‑based** operations or explore advanced **encryption** features, the **Streams** and **Security** categories provide deeper dives that build on the file‑level techniques shown here. Together, these groups give a complete picture of handling data from raw files through compressed archives to secure storage in Aspose.ZIP for .NET.


## Operations Covered
- Create a 7z archive from in‑memory data  
- Add a file entry to a 7z archive  
- Apply Bzip2 compression to a single file entry  
- Apply Bzip2 compression to multiple entries in a ZIP archive  
- Apply LZMA compression to a file entry in a ZIP archive  
- Create a ZIP archive from several files  
- Extract a newly created ZIP archive immediately after compression  
- Ensure the output directory exists before saving the archive  
- Verify that source files exist before processing  
- Use **FileMode.Create** for output streams  
- Use **FileMode.Open** for reading source files  

## Supported Formats
- **7z** – used for the SevenZip archive created from memory  
- **Bzip2** (.bz2) – used for compressing individual or multiple entries  
- **ZIP** – primary container format for most examples  
- **LZMA** – applied as a compression method inside a ZIP archive  

*(No image formats such as PNG, JPEG, etc., appear in the provided code.)*  

## API Classes Used
- `SevenZipArchive` — creates and manipulates 7z archives (adds entries, saves to disk).  
- `Archive` — represents a ZIP archive; allows adding entries and writing the archive.  
- `ArchiveEntrySettings` — configures per‑entry options like compression method and level.  
- `LzmaCompressionSettings` — specifies LZMA compression parameters for an archive entry.  
- `Bzip2CompressionSettings` — specifies Bzip2 compression parameters for an archive entry.  
- `FileStream` — opens files with specific `FileMode` values for reading or writing archive data.  
- `File` — static helper used to check file existence and create directories.

<!-- AUTOGENERATED:START -->
Updated: 2026-11-06 | Run: `20261103_214608` | Examples: 33
<!-- AUTOGENERATED:END -->