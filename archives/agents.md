---
name: archives
description: C# examples for Archives using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Archives

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Archives** category.
This folder contains standalone C# examples for Archives operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (575/572 files)
- `using System.IO;` (575/572 files)
- `using Aspose.Zip;` (242/572 files) ← category-specific
- `using Aspose.Zip.Saving;` (84/572 files) ← category-specific
- `using Aspose.Zip.Tar;` (73/572 files) ← category-specific
- `using Aspose.Zip.Wim;` (64/572 files) ← category-specific
- `using System.Text;` (53/572 files)
- `using Aspose.Zip.Cab;` (40/572 files) ← category-specific
- `using Aspose.Zip.Xz;` (39/572 files) ← category-specific
- `using Aspose.Zip.Xar;` (36/572 files) ← category-specific
- `using System.Linq;` (35/572 files)
- `using Aspose.Zip.SevenZip;` (32/572 files) ← category-specific
- `using Aspose.Zip.Bzip2;` (29/572 files) ← category-specific
- `using System.Collections.Generic;` (28/572 files)
- `using Aspose.Zip.Cpio;` (27/572 files) ← category-specific
- `using Aspose.Zip.Gzip;` (22/572 files) ← category-specific
- `using Aspose.Zip.Arj;` (20/572 files) ← category-specific
- `using Aspose.Zip.Lzip;` (18/572 files) ← category-specific
- `using Aspose.Zip.Lz4;` (17/572 files) ← category-specific
- `using Aspose.Zip.Rar;` (9/572 files) ← category-specific
- `using Aspose.Zip.Zstandard;` (9/572 files) ← category-specific
- `using Aspose.Zip.LZMA;` (5/572 files) ← category-specific
- `using System.Security.Cryptography;` (5/572 files)
- `using Aspose.Zip.Z;` (4/572 files) ← category-specific
- `using System.Threading;` (3/572 files)
- `using Aspose.Zip.ArchiveInfo;` (2/572 files) ← category-specific
- `using System.IO.Pipes;` (1/572 files)
- `using Aspose.Zip.Xz.Settings;` (1/572 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [create-a-new-archive-instance-add-local-files-with-createentry-and-save-a-zip-file-to-the-chosen-output-path.cs](./create-a-new-archive-instance-add-local-files-with-createentry-and-save-a-zip-file-to-the-chosen-output-path.cs) |  | Create a new Archive instance, add local files with CreateEntry, and save a ZIP ... |
| [add-a-single-file-to-the-zip-archive-using-archiveentrysettings-and-save-to-disk.cs](./add-a-single-file-to-the-zip-archive-using-archiveentrysettings-and-save-to-disk.cs) |  | Add a single file to the ZIP archive using ArchiveEntrySettings and save to disk... |
| [add-multiple-files-from-a-directory-recursively-to-the-zip-archive-preserving-ntfs-attributes.cs](./add-multiple-files-from-a-directory-recursively-to-the-zip-archive-preserving-ntfs-attributes.cs) |  | Add multiple files from a directory recursively to the ZIP archive preserving NT... |
| [enable-ntfs-attribute-preservation-when-adding-files-to-the-zip-archive-and-save-it.cs](./enable-ntfs-attribute-preservation-when-adding-files-to-the-zip-archive-and-save-it.cs) | `ArchiveSaveOptions` | Enable NTFS attribute preservation when adding files to the ZIP archive and save... |
| [add-a-directory-recursively-to-a-zip-archive-while-preserving-ntfs-attributes-and-applying-custom-compression.cs](./add-a-directory-recursively-to-a-zip-archive-while-preserving-ntfs-attributes-and-applying-custom-compression.cs) |  | Add a directory recursively to a ZIP archive while preserving NTFS attributes an... |
| [configure-custom-compression-settings-for-the-zip-archive-before-saving-it-to-a-memory-stream.cs](./configure-custom-compression-settings-for-the-zip-archive-before-saving-it-to-a-memory-stream.cs) |  | Configure custom compression settings for the ZIP archive before saving it to a ... |
| [apply-custom-compression-options-to-a-zip-archive-containing-large-video-files-before-saving-to-disk.cs](./apply-custom-compression-options-to-a-zip-archive-containing-large-video-files-before-saving-to-disk.cs) |  | Apply custom compression options to a ZIP archive containing large video files b... |
| [create-a-zip-archive-apply-custom-compression-settings-add-multiple-files-and-store-the-archive-in-memory.cs](./create-a-zip-archive-apply-custom-compression-settings-add-multiple-files-and-store-the-archive-in-memory.cs) |  | Create a ZIP archive, apply custom compression settings, add multiple files, and... |
| [save-the-created-zip-archive-to-a-physical-file-on-disk-using-archive.cs](./save-the-created-zip-archive-to-a-physical-file-on-disk-using-archive.cs) |  | Save the created ZIP archive to a physical file on disk using Archive. |
| [save-the-zip-archive-to-a-memory-stream-after-adding-entries-with-archiveentrysettings.cs](./save-the-zip-archive-to-a-memory-stream-after-adding-entries-with-archiveentrysettings.cs) |  | Save the ZIP archive to a memory stream after adding entries with ArchiveEntrySe... |
| [load-an-existing-zip-archive-from-a-memory-stream-add-a-new-entry-and-save-back.cs](./load-an-existing-zip-archive-from-a-memory-stream-add-a-new-entry-and-save-back.cs) |  | Load an existing ZIP archive from a memory stream, add a new entry, and save bac... |
| [load-a-zip-archive-from-a-file-extract-its-entries-to-a-temporary-directory-and-re-archive-them.cs](./load-a-zip-archive-from-a-file-extract-its-entries-to-a-temporary-directory-and-re-archive-them.cs) |  | Load a ZIP archive from a file, extract its entries to a temporary directory, an... |
| [load-an-existing-zip-by-file-path-with-archive-call-extracttodirectory-and-save-all-entries-in-a-local-directory.cs](./load-an-existing-zip-by-file-path-with-archive-call-extracttodirectory-and-save-all-entries-in-a-local-directory.cs) |  | Load an existing ZIP by file path with Archive, call ExtractToDirectory, and sav... |
| [extract-all-entries-from-a-zip-archive-using-a-memory-stream-and-write-them-to-an-output-folder.cs](./extract-all-entries-from-a-zip-archive-using-a-memory-stream-and-write-them-to-an-output-folder.cs) |  | Extract all entries from a ZIP archive using a memory stream and write them to a... |
| [load-an-existing-zip-from-an-input-stream-with-archive-call-extracttodirectory-and-save-all-entries-locally.cs](./load-an-existing-zip-from-an-input-stream-with-archive-call-extracttodirectory-and-save-all-entries-locally.cs) |  | Load an existing ZIP from an input stream with Archive, call ExtractToDirectory,... |
| [extract-a-password-protected-zip-archive-by-supplying-archiveloadoptions-with-the-correct-password.cs](./extract-a-password-protected-zip-archive-by-supplying-archiveloadoptions-with-the-correct-password.cs) | `ArchiveLoadOptions` | Extract a password‑protected ZIP archive by supplying ArchiveLoadOptions with th... |
| [extract-all-entries-from-a-password-protected-zip-archive-using-archiveloadoptions-and-save-to-a-target-directory.cs](./extract-all-entries-from-a-password-protected-zip-archive-using-archiveloadoptions-and-save-to-a-target-directory.cs) | `ArchiveLoadOptions` | Extract all entries from a password‑protected ZIP archive using ArchiveLoadOptio... |
| [load-a-zip-archive-delete-a-selected-entry-recreate-that-named-entry-with-replacement-contents-and-save-the.cs](./load-a-zip-archive-delete-a-selected-entry-recreate-that-named-entry-with-replacement-contents-and-save-the.cs) |  | Load a ZIP archive, delete a selected entry, recreate that named entry with repl... |
| [load-a-zip-archive-delete-selected-entries-and-recreate-each-with-replacement-contents-then-save-the-updated-zip.cs](./load-a-zip-archive-delete-selected-entries-and-recreate-each-with-replacement-contents-then-save-the-updated-zip.cs) |  | Load a ZIP archive, delete selected entries and recreate each with replacement c... |
| [remove-an-entry-from-the-zip-archive-using-the-remove-entry-workflow-and-save-changes.cs](./remove-an-entry-from-the-zip-archive-using-the-remove-entry-workflow-and-save-changes.cs) |  | Remove an entry from the ZIP archive using the remove entry workflow and save ch... |
| [remove-several-entries-from-a-zip-archive-based-on-a-predefined-list-and-save-the-modified-archive.cs](./remove-several-entries-from-a-zip-archive-based-on-a-predefined-list-and-save-the-modified-archive.cs) |  | Remove several entries from a ZIP archive based on a predefined list and save th... |
| [remove-an-entry-from-a-zip-archive-opened-from-a-file-path-and-save-the-cleaned-archive.cs](./remove-an-entry-from-a-zip-archive-opened-from-a-file-path-and-save-the-cleaned-archive.cs) |  | Remove an entry from a ZIP archive opened from a file path and save the cleaned ... |
| [extract-an-encrypted-zip-archive-using-archiveloadoptions-then-add-a-new-file-and-save-the-updated-archive.cs](./extract-an-encrypted-zip-archive-using-archiveloadoptions-then-add-a-new-file-and-save-the-updated-archive.cs) | `ArchiveLoadOptions` | Extract an encrypted ZIP archive using ArchiveLoadOptions, then add a new file a... |
| [extract-an-encrypted-zip-archive-using-archiveloadoptions-then-re-compress-its-contents-with-custom-compression.cs](./extract-an-encrypted-zip-archive-using-archiveloadoptions-then-re-compress-its-contents-with-custom-compression.cs) | `ArchiveLoadOptions` | Extract an encrypted ZIP archive using ArchiveLoadOptions, then re‑compress its ... |
| [load-a-local-rar-archive-using-rararchive-and-extract-all-entries-to-a-local-folder.cs](./load-a-local-rar-archive-using-rararchive-and-extract-all-entries-to-a-local-folder.cs) |  | Load a local RAR archive using RarArchive and extract all entries to a local fol... |
| [load-a-local-7z-archive-using-sevenziparchive-and-extract-all-entries-to-a-local-directory.cs](./load-a-local-7z-archive-using-sevenziparchive-and-extract-all-entries-to-a-local-directory.cs) |  | Load a local 7z archive using SevenZipArchive and extract all entries to a local... |
| [create-a-zip-archive-add-a-directory-recursively-enable-ntfs-attribute-preservation-and-save-to-a-specified.cs](./create-a-zip-archive-add-a-directory-recursively-enable-ntfs-attribute-preservation-and-save-to-a-specified.cs) |  | Create a ZIP archive, add a directory recursively, enable NTFS attribute preserv... |
| [create-a-zip-archive-add-files-from-two-different-directories-and-save-to-a-designated-output-folder.cs](./create-a-zip-archive-add-files-from-two-different-directories-and-save-to-a-designated-output-folder.cs) | `ArchiveSaveOptions` | Create a ZIP archive, add files from two different directories, and save to a de... |
| [create-a-zip-archive-add-file-contents-from-an-in-memory-byte-array-through-a-stream-and-save-the-zip-file.cs](./create-a-zip-archive-add-file-contents-from-an-in-memory-byte-array-through-a-stream-and-save-the-zip-file.cs) |  | Create a ZIP archive, add file contents from an in-memory byte array through a s... |
| [extract-a-password-protected-zip-archive-using-archiveloadoptions-then-re-compress-its-contents-with-custom.cs](./extract-a-password-protected-zip-archive-using-archiveloadoptions-then-re-compress-its-contents-with-custom.cs) | `ArchiveLoadOptions` | Extract a password‑protected ZIP archive using ArchiveLoadOptions, then re‑compr... |
| *...and 545 more files* | | [View all](https://github.com/aspose-zip/agentic-net-examples/tree/26.10.0/archives) |

## Category Statistics
- Total examples: 572
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveLoadOptions`
- `ArchiveSaveOptions`
- `ArjLoadOptions`
- `Bzip2SaveOptions`
- `RarArchiveLoadOptions`
- `SelfExtractorOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-10-30 | Run: `20261030_170832` | Examples: 572
<!-- AUTOGENERATED:END -->