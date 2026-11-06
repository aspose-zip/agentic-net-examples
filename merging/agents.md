---
name: merging
description: C# examples for Merging using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Merging

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Merging** category.
This folder contains standalone C# examples for Merging operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (50/49 files)
- `using System.IO;` (50/49 files)
- `using Aspose.Zip;` (47/49 files) ← category-specific
- `using System.Collections.Generic;` (23/49 files)
- `using Aspose.Zip.Tar;` (12/49 files) ← category-specific
- `using Aspose.Zip.Saving;` (6/49 files) ← category-specific
- `using Aspose.Zip.SevenZip;` (5/49 files) ← category-specific
- `using System.Linq;` (5/49 files)
- `using Aspose.Zip.Gzip;` (3/49 files) ← category-specific
- `using Aspose.Zip.Cpio;` (2/49 files) ← category-specific
- `using System.Text;` (1/49 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [extract-multiple-local-zip-archives-into-memory-combine-their-entries-with-caller-specified-name-collision.cs](./extract-multiple-local-zip-archives-into-memory-combine-their-entries-with-caller-specified-name-collision.cs) |  | Extract multiple local ZIP archives into memory, combine their entries with call... |
| [extract-multiple-local-zip-archives-into-memory-combine-their-entries-with-caller-specified-name-collision.cs](./extract-multiple-local-zip-archives-into-memory-combine-their-entries-with-caller-specified-name-collision.cs) |  | Extract multiple local ZIP archives into memory, combine their entries with call... |
| [load-two-zip-archives-into-memory-merge-preserving-folder-hierarchy-and-save-as-a-new-zip-file.cs](./load-two-zip-archives-into-memory-merge-preserving-folder-hierarchy-and-save-as-a-new-zip-file.cs) |  | Load two ZIP archives into memory, merge preserving folder hierarchy, and save a... |
| [load-a-zip-archive-and-a-7zip-archive-merge-all-entries-and-create-a-new-zip-archive.cs](./load-a-zip-archive-and-a-7zip-archive-merge-all-entries-and-create-a-new-zip-archive.cs) |  | Load a ZIP archive and a 7ZIP archive, merge all entries, and create a new ZIP a... |
| [load-a-zip-archive-and-a-cpio-archive-merge-without-compression-and-output-a-combined-zip-archive.cs](./load-a-zip-archive-and-a-cpio-archive-merge-without-compression-and-output-a-combined-zip-archive.cs) | `ArchiveSaveOptions` | Load a ZIP archive and a CPIO archive, merge without compression, and output a c... |
| [load-three-tar-gz-archives-merge-them-in-memory-and-save-the-result-as-a-new-tar-gz-archive.cs](./load-three-tar-gz-archives-merge-them-in-memory-and-save-the-result-as-a-new-tar-gz-archive.cs) |  | Load three TAR.GZ archives, merge them in memory, and save the result as a new T... |
| [select-specific-files-from-three-different-archives-merge-them-in-memory-and-generate-a-new-zip-archive.cs](./select-specific-files-from-three-different-archives-merge-them-in-memory-and-generate-a-new-zip-archive.cs) |  | Select specific files from three different archives, merge them in memory, and g... |
| [select-entire-folders-from-two-source-archives-merge-while-preserving-hierarchy-and-save-as-a-new-tar-gz-archive.cs](./select-entire-folders-from-two-source-archives-merge-while-preserving-hierarchy-and-save-as-a-new-tar-gz-archive.cs) |  | Select entire folders from two source archives, merge while preserving hierarchy... |
| [merge-two-zip-archives-without-applying-compression-keeping-original-entry-sizes-and-output-a-merged-zip-archive.cs](./merge-two-zip-archives-without-applying-compression-keeping-original-entry-sizes-and-output-a-merged-zip-archive.cs) | `ArchiveSaveOptions` | Merge two ZIP archives without applying compression, keeping original entry size... |
| [merge-two-zip-archives-with-compression-enabled-creating-a-compressed-zip-archive-containing-all-merged-entries.cs](./merge-two-zip-archives-with-compression-enabled-creating-a-compressed-zip-archive-containing-all-merged-entries.cs) |  | Merge two ZIP archives with compression enabled, creating a compressed ZIP archi... |
| [compose-a-tar-archive-from-tar-gz-sources-using-tararchive-then-compress-with-savegzipped-to-produce-a-gz-file.cs](./compose-a-tar-archive-from-tar-gz-sources-using-tararchive-then-compress-with-savegzipped-to-produce-a-gz-file.cs) |  | Compose a Tar archive from TAR.GZ sources using TarArchive, then compress with S... |
| [load-a-large-collection-of-local-zip-archives-process-their-entry-data-within-a-caller-specified-memory-budget.cs](./load-a-large-collection-of-local-zip-archives-process-their-entry-data-within-a-caller-specified-memory-budget.cs) |  | Load a large collection of local ZIP archives, process their entry data within a... |
| [perform-in-memory-merging-of-multiple-archives-while-preserving-folder-hierarchy-then-output-the-result-as-a-zip.cs](./perform-in-memory-merging-of-multiple-archives-while-preserving-folder-hierarchy-then-output-the-result-as-a-zip.cs) |  | Perform in‑memory merging of multiple archives while preserving folder hierarchy... |
| [select-specific-files-and-folders-from-source-archives-merge-them-in-memory-and-create-a-combined-zip-archive.cs](./select-specific-files-and-folders-from-source-archives-merge-them-in-memory-and-create-a-combined-zip-archive.cs) |  | Select specific files and folders from source archives, merge them in memory, an... |
| [programmatically-merge-multiple-archives-without-invoking-external-tools-producing-a-merged-zip-file.cs](./programmatically-merge-multiple-archives-without-invoking-external-tools-producing-a-merged-zip-file.cs) |  | Programmatically merge multiple archives without invoking external tools, produc... |
| [merge-archives-and-apply-savegzipped-method-to-compress-the-combined-tar-archive-resulting-in-a-gz-file.cs](./merge-archives-and-apply-savegzipped-method-to-compress-the-combined-tar-archive-resulting-in-a-gz-file.cs) |  | Merge archives and apply SaveGzipped method to compress the combined Tar archive... |
| [combine-several-archives-in-memory-and-generate-a-new-zip-archive-that-contains-all-merged-entries.cs](./combine-several-archives-in-memory-and-generate-a-new-zip-archive-that-contains-all-merged-entries.cs) |  | Combine several archives in memory and generate a new ZIP archive that contains ... |
| [merge-multiple-source-archives-and-produce-a-new-tar-gz-archive-that-includes-the-combined-content.cs](./merge-multiple-source-archives-and-produce-a-new-tar-gz-archive-that-includes-the-combined-content.cs) |  | Merge multiple source archives and produce a new TAR.GZ archive that includes th... |
| [select-txt-files-from-a-zip-and-a-7zip-archive-merge-them-and-save-as-a-zip-archive.cs](./select-txt-files-from-a-zip-and-a-7zip-archive-merge-them-and-save-as-a-zip-archive.cs) | `ArchiveSaveOptions` | Select .txt files from a ZIP and a 7ZIP archive, merge them, and save as a ZIP a... |
| [select-jpg-images-from-multiple-tar-gz-archives-merge-them-while-preserving-folder-hierarchy-and-output-a-tar-gz.cs](./select-jpg-images-from-multiple-tar-gz-archives-merge-them-while-preserving-folder-hierarchy-and-output-a-tar-gz.cs) |  | Select .jpg images from multiple TAR.GZ archives, merge them while preserving fo... |
| [merge-a-zip-archive-with-a-cpio-archive-include-all-entries-and-produce-a-compressed-tar-gz-archive.cs](./merge-a-zip-archive-with-a-cpio-archive-include-all-entries-and-produce-a-compressed-tar-gz-archive.cs) |  | Merge a ZIP archive with a CPIO archive, include all entries, and produce a comp... |
| [merge-three-archives-of-different-formats-zip-7zip-cpio-in-memory-and-save-as-a-zip-archive.cs](./merge-three-archives-of-different-formats-zip-7zip-cpio-in-memory-and-save-as-a-zip-archive.cs) |  | Merge three archives of different formats (ZIP, 7ZIP, CPIO) in memory and save a... |
| [merge-folders-from-a-zip-archive-and-a-tar-gz-archive-preserving-hierarchy-and-output-a-new-tar-gz-archive.cs](./merge-folders-from-a-zip-archive-and-a-tar-gz-archive-preserving-hierarchy-and-output-a-new-tar-gz-archive.cs) |  | Merge folders from a ZIP archive and a TAR.GZ archive, preserving hierarchy, and... |
| [merge-multiple-zip-archives-ensure-sufficient-virtual-memory-and-produce-a-merged-zip-archive-without.cs](./merge-multiple-zip-archives-ensure-sufficient-virtual-memory-and-produce-a-merged-zip-archive-without.cs) |  | Merge multiple ZIP archives, ensure sufficient virtual memory, and produce a mer... |
| [load-several-archives-merge-them-with-compression-enabled-and-save-the-result-as-a-compressed-zip-archive.cs](./load-several-archives-merge-them-with-compression-enabled-and-save-the-result-as-a-compressed-zip-archive.cs) | `ArchiveSaveOptions` | Load several archives, merge them with compression enabled, and save the result ... |
| [select-csv-files-from-a-tar-gz-archive-merge-with-a-zip-archive-and-generate-a-combined-zip-archive.cs](./select-csv-files-from-a-tar-gz-archive-merge-with-a-zip-archive-and-generate-a-combined-zip-archive.cs) | `ArchiveSaveOptions` | Select .csv files from a TAR.GZ archive, merge with a ZIP archive, and generate ... |
| [merge-two-archives-then-use-savegzipped-to-produce-a-gz-file-containing-the-compressed-tar-archive.cs](./merge-two-archives-then-use-savegzipped-to-produce-a-gz-file-containing-the-compressed-tar-archive.cs) |  | Merge two archives, then use SaveGzipped to produce a GZ file containing the com... |
| [combine-entries-from-a-zip-and-a-7zip-archive-preserve-folder-hierarchy-and-output-a-new-tar-gz-archive.cs](./combine-entries-from-a-zip-and-a-7zip-archive-preserve-folder-hierarchy-and-output-a-new-tar-gz-archive.cs) |  | Combine entries from a ZIP and a 7ZIP archive, preserve folder hierarchy, and ou... |
| [select-json-files-from-multiple-archives-merge-them-while-preserving-folder-hierarchy-and-output-a-new-zip-archive.cs](./select-json-files-from-multiple-archives-merge-them-while-preserving-folder-hierarchy-and-output-a-new-zip-archive.cs) |  | Select .json files from multiple archives, merge them while preserving folder hi... |
| [merge-large-local-zip-archives-using-in-memory-entry-data-within-a-caller-specified-memory-budget-resolve-entry.cs](./merge-large-local-zip-archives-using-in-memory-entry-data-within-a-caller-specified-memory-budget-resolve-entry.cs) |  | Merge large local ZIP archives using in-memory entry data within a caller-specif... |
| *...and 20 more files* | | [View all](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/merging) |

## Category Statistics
- Total examples: 50
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveSaveOptions`

## Failed Tasks

All tasks passed ✅


## Use Cases  
- **Preserving entry order while consolidating archives** – When a compliance audit requires the original sequence of files inside multiple ZIP packages, the `add-entries-to-the-destination-archive-in-the-same-order-they-appear-in-each-source-archive.cs` example demonstrates how to merge ZIPs while keeping their entry order intact, a common need in document management systems.  
- **In‑memory aggregation of several ZIPs** – The `combine-several-archives-in-memory-and-generate-a-new-zip-archive-that-contains-all-merged-entries.cs` snippet shows how to load multiple archives into memory, merge their contents, and write a single output ZIP, useful for web services that need to bundle user‑uploaded files without touching the file system.  
- **Merging archives of different sizes and compression settings** – `create-a-merged-zip-file-that-includes-entries-from-source-archives-with-varying-file-sizes.cs` illustrates merging large and small entries from separate ZIPs, handling differing compression levels automatically, which is ideal for backup utilities that combine incremental and full snapshots.  
- **Handling name collisions across source archives** – The `extract-multiple-local-zip-archives-into-memory-combine-their-entries-with-caller-specified-name-collision-52734.cs` example provides a strategy for detecting and renaming duplicate entry names when merging, a frequent requirement in data‑migration scripts that consolidate legacy packages.  
- **Sequentially merging an arbitrary number of ZIP files without recompression** – Using `load-a-zip-archive-and-a-cpio-archive-merge-without-compression-and-output-a-combined-zip-archive.cs`, developers can merge many archives while preserving the original compression state, perfect for creating distribution bundles where re‑compressing would waste CPU cycles.  

These merging C# examples give concrete, ready‑to‑run patterns for real‑world archive consolidation tasks.

## Related Categories  
If you need to extract or inspect the contents before merging, the **Extraction** category offers examples that show how to read entries, filter by type, and stream data directly from ZIP or TAR archives. For scenarios where you must modify individual files—such as updating metadata, encrypting entries, or changing compression levels—the **Modification** category provides code that works hand‑in‑hand with the merging snippets. Finally, when the target format is a TAR.GZ or a custom archive layout, the **Compression & Archiving** category demonstrates how to create and save those formats, complementing the merging workflows presented here.

<!-- AUTOGENERATED:START -->
Updated: 2026-11-06 | Run: `20261104_124259` | Examples: 50
<!-- AUTOGENERATED:END -->