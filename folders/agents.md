---
name: folders
description: C# examples for Folders using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Folders

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Folders** category.
This folder contains standalone C# examples for Folders operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (27/27 files)
- `using System.IO;` (27/27 files)
- `using Aspose.Zip;` (27/27 files) ← category-specific
- `using Aspose.Zip.Saving;` (5/27 files) ← category-specific
- `using System.Text;` (4/27 files)
- `using System.Collections.Generic;` (1/27 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [define-the-source-directory-to-be-compressed-then-compress-its-contents-into-a-zip-file-using-c.cs](./define-the-source-directory-to-be-compressed-then-compress-its-contents-into-a-zip-file-using-c.cs) |  | Define the source directory to be compressed, then compress its contents into a ... |
| [create-archive-add-a-local-source-folder-open-an-output-filestream-with-filemode-create-and-save-the-zip-to-that.cs](./create-archive-add-a-local-source-folder-open-an-output-filestream-with-filemode-create-and-save-the-zip-to-that.cs) |  | Create Archive, add a local source folder, open an output FileStream with FileMo... |
| [define-the-source-directory-open-a-filestream-with-specific-filemode-settings-instantiate-archive-and-compress.cs](./define-the-source-directory-open-a-filestream-with-specific-filemode-settings-instantiate-archive-and-compress.cs) |  | Define the source directory, open a FileStream with specific FileMode settings, ... |
| [create-archive-add-a-local-source-directory-with-createentries-and-save-the-zip-through-an-output-filestream.cs](./create-archive-add-a-local-source-directory-with-createentries-and-save-the-zip-through-an-output-filestream.cs) |  | Create Archive, add a local source directory with CreateEntries, and save the ZI... |
| [create-a-zip-from-a-local-folder-and-save-it-with-filemode-create-replacing-any-existing-output-file.cs](./create-a-zip-from-a-local-folder-and-save-it-with-filemode-create-replacing-any-existing-output-file.cs) |  | Create a ZIP from a local folder and save it with FileMode.Create, replacing any... |
| [create-a-zip-from-a-local-folder-and-save-it-with-filemode-createnew-reporting-an-existing-output-file-without.cs](./create-a-zip-from-a-local-folder-and-save-it-with-filemode-createnew-reporting-an-existing-output-file-without.cs) |  | Create a ZIP from a local folder and save it with FileMode.CreateNew, reporting ... |
| [open-a-zip-output-filestream-with-filemode-create-add-a-source-folder-with-createentries-and-save-the-zip-before.cs](./open-a-zip-output-filestream-with-filemode-create-add-a-source-folder-with-createentries-and-save-the-zip-before.cs) |  | Open a ZIP output FileStream with FileMode.Create, add a source folder with Crea... |
| [create-zip-entries-for-all-files-and-subfolders-with-createentries-and-save-the-zip-locally.cs](./create-zip-entries-for-all-files-and-subfolders-with-createentries-and-save-the-zip-locally.cs) |  | Create ZIP entries for all files and subfolders with CreateEntries and save the ... |
| [add-selected-local-directories-to-a-zip-using-createentries-with-distinct-entry-prefixes-and-save-the-zip-file.cs](./add-selected-local-directories-to-a-zip-using-createentries-with-distinct-entry-prefixes-and-save-the-zip-file.cs) |  | Add selected local directories to a ZIP using CreateEntries with distinct entry ... |
| [create-entries-from-files-and-subfolders-then-compress-the-archive-using-the-archive-class.cs](./create-entries-from-files-and-subfolders-then-compress-the-archive-using-the-archive-class.cs) |  | Create entries from files and subfolders, then compress the archive using the Ar... |
| [create-archive-entries-from-files-and-subfolders-and-save-the-resulting-zip-archive-to-disk.cs](./create-archive-entries-from-files-and-subfolders-and-save-the-resulting-zip-archive-to-disk.cs) |  | Create archive entries from files and subfolders and save the resulting ZIP arch... |
| [add-files-from-multiple-local-subfolders-to-a-zip-using-relative-entry-paths-and-save-the-zip-locally.cs](./add-files-from-multiple-local-subfolders-to-a-zip-using-relative-entry-paths-and-save-the-zip-locally.cs) | `ArchiveSaveOptions` | Add files from multiple local subfolders to a ZIP using relative entry paths and... |
| [define-a-source-directory-create-fileinfo-objects-for-each-file-and-compress-them-into-a-zip-using-createentries.cs](./define-a-source-directory-create-fileinfo-objects-for-each-file-and-compress-them-into-a-zip-using-createentries.cs) | `ArchiveSaveOptions` | Define a source directory, create FileInfo objects for each file, and compress t... |
| [compress-selected-files-by-creating-fileinfo-objects-for-each-file-and-adding-them-to-a-zip-archive.cs](./compress-selected-files-by-creating-fileinfo-objects-for-each-file-and-adding-them-to-a-zip-archive.cs) | `ArchiveSaveOptions` | Compress selected files by creating FileInfo objects for each file and adding th... |
| [use-fileinfo-objects-to-include-hidden-files-in-the-zip-archive-while-compressing-a-directory.cs](./use-fileinfo-objects-to-include-hidden-files-in-the-zip-archive-while-compressing-a-directory.cs) |  | Use FileInfo objects to include hidden files in the ZIP archive while compressin... |
| [compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-streams-after-compression-completes.cs](./compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-streams-after-compression-completes.cs) | `ArchiveSaveOptions` | Compress files by providing FileInfo objects and a FileStream, then close the st... |
| [compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-archive-after-writing.cs](./compress-files-by-providing-fileinfo-objects-and-a-filestream-then-close-the-archive-after-writing.cs) | `ArchiveSaveOptions` | Compress files by providing FileInfo objects and a FileStream, then close the ar... |
| [compress-an-entire-directory-into-a-zip-archive-and-save-it-to-a-specified-file-path.cs](./compress-an-entire-directory-into-a-zip-archive-and-save-it-to-a-specified-file-path.cs) |  | Compress an entire directory into a ZIP archive and save it to a specified file ... |
| [compress-only-the-contents-of-a-directory-excluding-the-root-folder-and-store-as-a-zip-file.cs](./compress-only-the-contents-of-a-directory-excluding-the-root-folder-and-store-as-a-zip-file.cs) |  | Compress only the contents of a directory, excluding the root folder, and store ... |
| [compress-only-the-directory-contents-excluding-the-root-folder-and-save-the-archive-using-a-custom-file-name.cs](./compress-only-the-directory-contents-excluding-the-root-folder-and-save-the-archive-using-a-custom-file-name.cs) |  | Compress only the directory contents, excluding the root folder, and save the ar... |
| [compress-a-directory-then-close-the-archive-and-file-streams-to-release-resources.cs](./compress-a-directory-then-close-the-archive-and-file-streams-to-release-resources.cs) |  | Compress a directory, then close the archive and file streams to release resourc... |
| [compress-an-entire-directory-then-close-the-archive-and-file-streams-to-finalize-the-zip-file.cs](./compress-an-entire-directory-then-close-the-archive-and-file-streams-to-finalize-the-zip-file.cs) |  | Compress an entire directory, then close the archive and file streams to finaliz... |
| [compress-a-directory-then-extract-the-archive-to-a-different-location-to-demonstrate-successful-decompression.cs](./compress-a-directory-then-extract-the-archive-to-a-different-location-to-demonstrate-successful-decompression.cs) |  | Compress a directory, then extract the archive to a different location to demons... |
| [extract-a-compressed-directory-archive-to-a-target-location-while-preserving-the-original-folder-hierarchy.cs](./extract-a-compressed-directory-archive-to-a-target-location-while-preserving-the-original-folder-hierarchy.cs) |  | Extract a compressed directory archive to a target location while preserving the... |
| [extract-a-compressed-directory-archive-to-a-target-location-using-the-archive-class.cs](./extract-a-compressed-directory-archive-to-a-target-location-using-the-archive-class.cs) |  | Extract a compressed directory archive to a target location using the Archive cl... |
| [extract-a-compressed-directory-archive-to-a-new-folder-and-then-close-the-archive-to-release-resources.cs](./extract-a-compressed-directory-archive-to-a-new-folder-and-then-close-the-archive-to-release-resources.cs) |  | Extract a compressed directory archive to a new folder and then close the archiv... |
| [open-an-output-filestream-with-filemode-create-add-a-local-folder-to-archive-save-the-zip-and-then-close-the.cs](./open-an-output-filestream-with-filemode-create-add-a-local-folder-to-archive-save-the-zip-and-then-close-the.cs) |  | Open an output FileStream with FileMode.Create, add a local folder to Archive, s... |

## Category Statistics
- Total examples: 27
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveSaveOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-11-06 | Run: `20261104_103032` | Examples: 27
<!-- AUTOGENERATED:END -->