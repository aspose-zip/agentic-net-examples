---
name: volumes
description: C# examples for Volumes using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Volumes

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Volumes** category.
This folder contains standalone C# examples for Volumes operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (79/72 files)
- `using System.IO;` (79/72 files)
- `using Aspose.Zip;` (59/72 files) ← category-specific
- `using Aspose.Zip.Saving;` (43/72 files) ← category-specific
- `using Aspose.Zip.SevenZip;` (24/72 files) ← category-specific
- `using System.Linq;` (21/72 files)
- `using System.Text;` (2/72 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [create-a-7z-archive-from-local-files-and-save-60-mib-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs](./create-a-7z-archive-from-local-files-and-save-60-mib-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs) | `SplitSevenZipArchiveSaveOptions` | Create a 7z archive from local files and save 60 MiB volumes using SplitSevenZip... |
| [create-a-7z-archive-from-local-files-and-save-80-mib-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs](./create-a-7z-archive-from-local-files-and-save-80-mib-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs) | `SplitSevenZipArchiveSaveOptions` | Create a 7z archive from local files and save 80 MiB volumes using SplitSevenZip... |
| [create-fileinfo-sources-for-local-files-add-them-to-archive-and-save-64-mib-zip-segments-using.cs](./create-fileinfo-sources-for-local-files-add-them-to-archive-and-save-64-mib-zip-segments-using.cs) | `SplitArchiveSaveOptions` | Create FileInfo sources for local files, add them to Archive, and save 64 MiB ZI... |
| [create-fileinfo-sources-for-local-files-add-them-to-sevenziparchive-and-save-64-mib-7z-volumes-using-savesplit.cs](./create-fileinfo-sources-for-local-files-add-them-to-sevenziparchive-and-save-64-mib-7z-volumes-using-savesplit.cs) | `SplitSevenZipArchiveSaveOptions` | Create FileInfo sources for local files, add them to SevenZipArchive, and save 6... |
| [add-local-files-to-archive-and-save-multi-volume-zip-parts-using-savesplit-with-a-caller-specified-segment-size.cs](./add-local-files-to-archive-and-save-multi-volume-zip-parts-using-savesplit-with-a-caller-specified-segment-size.cs) | `SplitArchiveSaveOptions` | Add local files to Archive and save multi-volume ZIP parts using SaveSplit with ... |
| [add-local-files-to-sevenziparchive-and-save-multi-volume-7z-parts-using-savesplit-with-a-caller-specified-volume.cs](./add-local-files-to-sevenziparchive-and-save-multi-volume-7z-parts-using-savesplit-with-a-caller-specified-volume.cs) | `SplitSevenZipArchiveSaveOptions` | Add local files to SevenZipArchive and save multi-volume 7z parts using SaveSpli... |
| [invoke-the-savesplit-method-to-generate-a-multi-volume-zip-archive-from-prepared-fileinfo-objects.cs](./invoke-the-savesplit-method-to-generate-a-multi-volume-zip-archive-from-prepared-fileinfo-objects.cs) | `SplitArchiveSaveOptions` | Invoke the SaveSplit method to generate a multi-volume ZIP archive from prepared... |
| [invoke-the-savesplit-method-to-generate-a-multi-volume-7z-archive-from-prepared-fileinfo-objects.cs](./invoke-the-savesplit-method-to-generate-a-multi-volume-7z-archive-from-prepared-fileinfo-objects.cs) | `SplitSevenZipArchiveSaveOptions` | Invoke the SaveSplit method to generate a multi-volume 7Z archive from prepared ... |
| [create-a-multi-volume-zip-archive-with-50-mb-volume-size-using-savesplit.cs](./create-a-multi-volume-zip-archive-with-50-mb-volume-size-using-savesplit.cs) | `SplitArchiveSaveOptions` | Create a multi-volume ZIP archive with 50 MB volume size using SaveSplit. |
| [create-a-multi-volume-zip-archive-from-multiple-files-with-80-mb-volume-size-using-savesplit.cs](./create-a-multi-volume-zip-archive-from-multiple-files-with-80-mb-volume-size-using-savesplit.cs) | `SplitArchiveSaveOptions` | Create a multi-volume ZIP archive from multiple files with 80 MB volume size usi... |
| [create-a-multi-volume-zip-archive-with-85-mb-volume-size-and-high-compression-using-savesplit.cs](./create-a-multi-volume-zip-archive-with-85-mb-volume-size-and-high-compression-using-savesplit.cs) | `SplitArchiveSaveOptions` | Create a multi-volume ZIP archive with 85 MB volume size and high compression us... |
| [split-an-existing-large-7z-archive-into-30-mb-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs](./split-an-existing-large-7z-archive-into-30-mb-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs) | `SplitSevenZipArchiveSaveOptions` | Split an existing large 7Z archive into 30 MB volumes using SplitSevenZipArchive... |
| [split-a-large-zip-archive-into-40-mb-sequential-volume-files-by-configuring-split-options.cs](./split-a-large-zip-archive-into-40-mb-sequential-volume-files-by-configuring-split-options.cs) | `SplitArchiveSaveOptions` | Split a large ZIP archive into 40 MB sequential volume files by configuring spli... |
| [load-standard-zip-segments-archive-z01-through-archive-z04-and-final-archive-zip-with-archive-then-extract-their.cs](./load-standard-zip-segments-archive-z01-through-archive-z04-and-final-archive-zip-with-archive-then-extract-their.cs) |  | Load standard ZIP segments archive.z01 through archive.z04 and final archive.zip... |
| [extract-a-multi-volume-7z-archive-with-parts-7z-001-7z-006-preserving-folder-hierarchy.cs](./extract-a-multi-volume-7z-archive-with-parts-7z-001-7z-006-preserving-folder-hierarchy.cs) |  | Extract a multi-volume 7Z archive with parts .7z.001–.7z.006 preserving folder h... |
| [extract-contents-from-a-password-protected-multi-volume-zip-archive-using-provided-password.cs](./extract-contents-from-a-password-protected-multi-volume-zip-archive-using-provided-password.cs) | `ArchiveLoadOptions` | Extract contents from a password-protected multi-volume ZIP archive using provid... |
| [extract-contents-from-a-multi-volume-archive-after-confirming-all-parts-are-present-saving-to-output-folder.cs](./extract-contents-from-a-multi-volume-archive-after-confirming-all-parts-are-present-saving-to-output-folder.cs) |  | Extract contents from a multi-volume archive after confirming all parts are pres... |
| [create-a-multi-volume-zip-from-local-files-with-configured-compression-save-all-segments-and-extract-the-complete.cs](./create-a-multi-volume-zip-from-local-files-with-configured-compression-save-all-segments-and-extract-the-complete.cs) | `SplitArchiveSaveOptions` | Create a multi-volume ZIP from local files with configured compression, save all... |
| [provide-all-volume-files-to-the-extraction-routine-to-reassemble-a-multi-volume-zip-archive.cs](./provide-all-volume-files-to-the-extraction-routine-to-reassemble-a-multi-volume-zip-archive.cs) |  | Provide all volume files to the extraction routine to reassemble a multi-volume ... |
| [provide-all-volume-files-to-the-extraction-routine-to-reassemble-a-multi-volume-7z-archive.cs](./provide-all-volume-files-to-the-extraction-routine-to-reassemble-a-multi-volume-7z-archive.cs) |  | Provide all volume files to the extraction routine to reassemble a multi-volume ... |
| [load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-with-exactly-three.cs](./load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-with-exactly-three.cs) |  | Load all parts of a local multi-volume 7z with the SevenZipArchive volume-path c... |
| [load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-with-exactly-three.cs](./load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-with-exactly-three.cs) |  | Load all parts of a local multi-volume 7z with the SevenZipArchive volume-path c... |
| [load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-with-the-full-ordered.cs](./load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-with-the-full-ordered.cs) |  | Load all parts of a local multi-volume 7z with the SevenZipArchive volume-path c... |
| [load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-using-fully-qualified.cs](./load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-using-fully-qualified.cs) |  | Load all parts of a local multi-volume 7z with the SevenZipArchive volume-path c... |
| [load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-with-all-volume-paths.cs](./load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-with-all-volume-paths.cs) |  | Load all parts of a local multi-volume 7z with the SevenZipArchive volume-path c... |
| [extract-a-multi-volume-7z-archive-to-a-directory-whose-path-contains-spaces-ensuring-correct-handling.cs](./extract-a-multi-volume-7z-archive-to-a-directory-whose-path-contains-spaces-ensuring-correct-handling.cs) |  | Extract a multi‑volume 7z archive to a directory whose path contains spaces, ens... |
| [extract-a-multi-volume-7z-archive-to-a-folder-named-after-the-archive-without-file-extension.cs](./extract-a-multi-volume-7z-archive-to-a-folder-named-after-the-archive-without-file-extension.cs) |  | Extract a multi‑volume 7z archive to a folder named after the archive without fi... |
| [extract-a-multi-volume-7z-archive-to-a-folder-named-extractionresult-7z-with-date-suffix.cs](./extract-a-multi-volume-7z-archive-to-a-folder-named-extractionresult-7z-with-date-suffix.cs) |  | Extract a multi‑volume 7z archive to a folder named ExtractionResult_7z with dat... |
| [extract-a-multi-volume-7z-archive-to-a-folder-named-output-7z-volumeseta-for-organized-storage.cs](./extract-a-multi-volume-7z-archive-to-a-folder-named-output-7z-volumeseta-for-organized-storage.cs) |  | Extract a multi‑volume 7z archive to a folder named Output_7z_VolumeSetA for org... |
| [load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-and-a-caller-supplied.cs](./load-all-parts-of-a-local-multi-volume-7z-with-the-sevenziparchive-volume-path-constructor-and-a-caller-supplied.cs) |  | Load all parts of a local multi-volume 7z with the SevenZipArchive volume-path c... |
| *...and 49 more files* | | [View all](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/volumes) |

## Category Statistics
- Total examples: 72
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveLoadOptions`
- `SplitArchiveSaveOptions`
- `SplitSevenZipArchiveSaveOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-11-04 | Run: `20261104_175126` | Examples: 72
<!-- AUTOGENERATED:END -->