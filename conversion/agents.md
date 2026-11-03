---
name: conversion
description: C# examples for Conversion using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Conversion

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Conversion** category.
This folder contains standalone C# examples for Conversion operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (91/91 files)
- `using System.IO;` (91/91 files)
- `using Aspose.Zip;` (70/91 files) ← category-specific
- `using Aspose.Zip.SevenZip;` (35/91 files) ← category-specific
- `using Aspose.Zip.Rar;` (28/91 files) ← category-specific
- `using Aspose.Zip.Tar;` (25/91 files) ← category-specific
- `using System.Collections.Generic;` (23/91 files)
- `using Aspose.Zip.Saving;` (11/91 files) ← category-specific
- `using Aspose.Zip.Gzip;` (8/91 files) ← category-specific
- `using Aspose.Zip.Bzip2;` (4/91 files) ← category-specific
- `using Aspose.Zip.Xz;` (4/91 files) ← category-specific
- `using System.Text;` (3/91 files)
- `using System.Linq;` (1/91 files)
- `using Aspose.Zip.Cpio;` (1/91 files) ← category-specific

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [convert-a-rar-archive-to-zip-format-using-on-the-fly-compression-and-save-the-file.cs](./convert-a-rar-archive-to-zip-format-using-on-the-fly-compression-and-save-the-file.cs) |  | Convert a RAR archive to ZIP format using on‑the‑fly compression and save the fi... |
| [convert-a-rar-archive-to-zip-format-without-on-the-fly-compression-and-write-the-output.cs](./convert-a-rar-archive-to-zip-format-without-on-the-fly-compression-and-write-the-output.cs) |  | Convert a RAR archive to ZIP format without on‑the‑fly compression and write the... |
| [convert-a-rar-archive-containing-nested-directories-to-zip-while-preserving-trailing-slash-entries.cs](./convert-a-rar-archive-containing-nested-directories-to-zip-while-preserving-trailing-slash-entries.cs) |  | Convert a RAR archive containing nested directories to ZIP while preserving trai... |
| [convert-a-zip-archive-to-7z-format-using-compress-on-the-fly-and-store-the-result.cs](./convert-a-zip-archive-to-7z-format-using-compress-on-the-fly-and-store-the-result.cs) |  | Convert a ZIP archive to 7Z format using compress‑on‑the‑fly and store the resul... |
| [convert-a-zip-archive-to-7z-format-without-compress-on-the-fly-and-save-the-file.cs](./convert-a-zip-archive-to-7z-format-without-compress-on-the-fly-and-save-the-file.cs) |  | Convert a ZIP archive to 7Z format without compress‑on‑the‑fly and save the file... |
| [convert-a-zip-archive-to-7z-format-preserving-directory-entries-with-trailing-slash.cs](./convert-a-zip-archive-to-7z-format-preserving-directory-entries-with-trailing-slash.cs) |  | Convert a ZIP archive to 7Z format preserving directory entries with trailing sl... |
| [convert-a-zip-archive-to-tar-gz-format-using-compress-on-the-fly-and-write-the-compressed-file.cs](./convert-a-zip-archive-to-tar-gz-format-using-compress-on-the-fly-and-write-the-compressed-file.cs) |  | Convert a ZIP archive to TAR.GZ format using compress‑on‑the‑fly and write the c... |
| [convert-a-zip-archive-to-tar-gz-format-without-compress-on-the-fly-and-save-the-output.cs](./convert-a-zip-archive-to-tar-gz-format-without-compress-on-the-fly-and-save-the-output.cs) |  | Convert a ZIP archive to TAR.GZ format without compress‑on‑the‑fly and save the ... |
| [convert-a-zip-archive-to-tar-gz-format-preserving-directory-entries-with-trailing-slash.cs](./convert-a-zip-archive-to-tar-gz-format-preserving-directory-entries-with-trailing-slash.cs) |  | Convert a ZIP archive to TAR.GZ format preserving directory entries with trailin... |
| [extract-entries-from-a-rar-archive-into-memory-streams-and-add-them-to-a-new-zip-preserving-hierarchy.cs](./extract-entries-from-a-rar-archive-into-memory-streams-and-add-them-to-a-new-zip-preserving-hierarchy.cs) |  | Extract entries from a RAR archive into memory streams and add them to a new ZIP... |
| [extract-entries-from-a-rar-archive-into-memory-and-add-them-to-a-7z-archive-with-compress-on-the-fly.cs](./extract-entries-from-a-rar-archive-into-memory-and-add-them-to-a-7z-archive-with-compress-on-the-fly.cs) |  | Extract entries from a RAR archive into memory and add them to a 7Z archive with... |
| [extract-entries-from-a-rar-archive-into-memory-and-add-them-to-a-tar-gz-archive-using-compress-on-the-fly.cs](./extract-entries-from-a-rar-archive-into-memory-and-add-them-to-a-tar-gz-archive-using-compress-on-the-fly.cs) |  | Extract entries from a RAR archive into memory and add them to a TAR.GZ archive ... |
| [perform-bulk-conversion-of-multiple-rar-archives-to-zip-format-with-compress-on-the-fly-enabled.cs](./perform-bulk-conversion-of-multiple-rar-archives-to-zip-format-with-compress-on-the-fly-enabled.cs) |  | Perform bulk conversion of multiple RAR archives to ZIP format with compress‑on‑... |
| [perform-bulk-conversion-of-multiple-rar-archives-to-zip-format-without-compress-on-the-fly.cs](./perform-bulk-conversion-of-multiple-rar-archives-to-zip-format-without-compress-on-the-fly.cs) | `ArchiveSaveOptions` | Perform bulk conversion of multiple RAR archives to ZIP format without compress‑... |
| [perform-bulk-conversion-of-multiple-rar-archives-to-zip-preserving-directory-entries-with-trailing-slash.cs](./perform-bulk-conversion-of-multiple-rar-archives-to-zip-preserving-directory-entries-with-trailing-slash.cs) |  | Perform bulk conversion of multiple RAR archives to ZIP preserving directory ent... |
| [perform-bulk-conversion-of-multiple-zip-archives-to-7z-format-with-compress-on-the-fly.cs](./perform-bulk-conversion-of-multiple-zip-archives-to-7z-format-with-compress-on-the-fly.cs) |  | Perform bulk conversion of multiple ZIP archives to 7Z format with compress‑on‑t... |
| [perform-bulk-conversion-of-multiple-zip-archives-to-7z-format-without-compress-on-the-fly.cs](./perform-bulk-conversion-of-multiple-zip-archives-to-7z-format-without-compress-on-the-fly.cs) |  | Perform bulk conversion of multiple ZIP archives to 7Z format without compress‑o... |
| [perform-bulk-conversion-of-multiple-zip-archives-to-tar-gz-format-with-compress-on-the-fly.cs](./perform-bulk-conversion-of-multiple-zip-archives-to-tar-gz-format-with-compress-on-the-fly.cs) |  | Perform bulk conversion of multiple ZIP archives to TAR.GZ format with compress‑... |
| [perform-bulk-conversion-of-multiple-zip-archives-to-tar-gz-format-without-compress-on-the-fly.cs](./perform-bulk-conversion-of-multiple-zip-archives-to-tar-gz-format-without-compress-on-the-fly.cs) |  | Perform bulk conversion of multiple ZIP archives to TAR.GZ format without compre... |
| [perform-bulk-conversion-of-multiple-zip-archives-to-tar-gz-preserving-directory-entries-with-trailing-slash.cs](./perform-bulk-conversion-of-multiple-zip-archives-to-tar-gz-preserving-directory-entries-with-trailing-slash.cs) |  | Perform bulk conversion of multiple ZIP archives to TAR.GZ preserving directory ... |
| [batch-convert-local-rar-archives-to-7z-passing-extracted-entry-streams-to-compression-on-the-fly-and-save-each-7z.cs](./batch-convert-local-rar-archives-to-7z-passing-extracted-entry-streams-to-compression-on-the-fly-and-save-each-7z.cs) |  | Batch convert local RAR archives to 7z, passing extracted entry streams to compr... |
| [batch-convert-local-rar-archives-to-7z-using-buffered-entry-data-rather-than-on-the-fly-compression-and-save-each.cs](./batch-convert-local-rar-archives-to-7z-using-buffered-entry-data-rather-than-on-the-fly-compression-and-save-each.cs) |  | Batch convert local RAR archives to 7z using buffered entry data rather than on-... |
| [batch-convert-local-rar-archives-to-tar-gz-using-extracted-entry-streams-and-save-each-compressed-tar-file.cs](./batch-convert-local-rar-archives-to-tar-gz-using-extracted-entry-streams-and-save-each-compressed-tar-file.cs) |  | Batch convert local RAR archives to TAR.GZ using extracted entry streams, and sa... |
| [batch-convert-local-rar-archives-to-tar-gz-using-buffered-entry-data-and-save-each-compressed-tar-file.cs](./batch-convert-local-rar-archives-to-tar-gz-using-buffered-entry-data-and-save-each-compressed-tar-file.cs) |  | Batch convert local RAR archives to TAR.GZ using buffered entry data, and save e... |
| [convert-a-large-rar-archive-to-zip-format-after-verifying-sufficient-virtual-memory-and-save-the-file.cs](./convert-a-large-rar-archive-to-zip-format-after-verifying-sufficient-virtual-memory-and-save-the-file.cs) |  | Convert a large RAR archive to ZIP format after verifying sufficient virtual mem... |
| [convert-a-large-zip-archive-to-7z-format-after-checking-virtual-memory-availability-and-write-the-output.cs](./convert-a-large-zip-archive-to-7z-format-after-checking-virtual-memory-availability-and-write-the-output.cs) |  | Convert a large ZIP archive to 7Z format after checking virtual memory availabil... |
| [convert-a-large-zip-archive-to-tar-gz-format-after-confirming-virtual-memory-is-sufficient-and-store-the-result.cs](./convert-a-large-zip-archive-to-tar-gz-format-after-confirming-virtual-memory-is-sufficient-and-store-the-result.cs) |  | Convert a large ZIP archive to TAR.GZ format after confirming virtual memory is ... |
| [convert-a-rar-archive-containing-only-directories-to-zip-format-preserving-empty-folder-entries-with-trailing.cs](./convert-a-rar-archive-containing-only-directories-to-zip-format-preserving-empty-folder-entries-with-trailing.cs) |  | Convert a RAR archive containing only directories to ZIP format preserving empty... |
| [convert-a-zip-archive-with-empty-folders-to-tar-gz-format-preserving-empty-directories-and-trailing-slash.cs](./convert-a-zip-archive-with-empty-folders-to-tar-gz-format-preserving-empty-directories-and-trailing-slash.cs) |  | Convert a ZIP archive with empty folders to TAR.GZ format preserving empty direc... |
| [convert-a-rar-archive-directly-to-7z-using-extracted-entry-streams-and-on-the-fly-compression-and-save-the-7z-file.cs](./convert-a-rar-archive-directly-to-7z-using-extracted-entry-streams-and-on-the-fly-compression-and-save-the-7z-file.cs) |  | Convert a RAR archive directly to 7z using extracted entry streams and on-the-fl... |
| *...and 61 more files* | | [View all](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/conversion) |

## Category Statistics
- Total examples: 91
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveLoadOptions`
- `ArchiveSaveOptions`
- `RarArchiveLoadOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-11-03 | Run: `20261103_124142` | Examples: 91
<!-- AUTOGENERATED:END -->