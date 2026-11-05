---
name: events
description: C# examples for Events using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Events

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Events** category.
This folder contains standalone C# examples for Events operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (51/51 files)
- `using System.IO;` (51/51 files)
- `using Aspose.Zip;` (31/51 files) ← category-specific
- `using System.Threading;` (25/51 files)
- `using Aspose.Zip.Saving;` (10/51 files) ← category-specific
- `using Aspose.Zip.Bzip2;` (8/51 files) ← category-specific
- `using System.Collections.Generic;` (7/51 files)
- `using Aspose.Zip.Cab;` (5/51 files) ← category-specific
- `using Aspose.Zip.Rar;` (4/51 files) ← category-specific
- `using Aspose.Zip.SevenZip;` (3/51 files) ← category-specific
- `using Aspose.Zip.Gzip;` (3/51 files) ← category-specific
- `using Aspose.Zip.ArchiveInfo;` (2/51 files) ← category-specific
- `using System.Linq;` (2/51 files)
- `using Aspose.Zip.Xar;` (1/51 files) ← category-specific
- `using System.Diagnostics;` (1/51 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-forward-only-zip-with-a-cancellationtoken-cancel-after-a-caller-specified-number-of-completed-entries-and.cs](./load-a-forward-only-zip-with-a-cancellationtoken-cancel-after-a-caller-specified-number-of-completed-entries-and.cs) | `ArchiveLoadOptions` | Load a forward-only ZIP with a CancellationToken, cancel after a caller-specifie... |
| [extract-a-forward-only-zip-from-a-local-pipe-stream-with-a-cancellationtoken-cancel-after-two-completed-entries.cs](./extract-a-forward-only-zip-from-a-local-pipe-stream-with-a-cancellationtoken-cancel-after-two-completed-entries.cs) | `ArchiveLoadOptions` | Extract a forward-only ZIP from a local pipe stream with a CancellationToken, ca... |
| [extract-a-forward-only-zip-with-a-cancellationtoken-cancel-after-three-completed-entries-and-save-the-completed.cs](./extract-a-forward-only-zip-with-a-cancellationtoken-cancel-after-three-completed-entries-and-save-the-completed.cs) | `ArchiveLoadOptions` | Extract a forward-only ZIP with a CancellationToken, cancel after three complete... |
| [load-apple-archive-with-a-cancellationtoken-in-applearchiveloadoptions-extract-to-a-local-directory-and-report.cs](./load-apple-archive-with-a-cancellationtoken-in-applearchiveloadoptions-extract-to-a-local-directory-and-report.cs) | `ArchiveLoadOptions` | Load Apple Archive with a CancellationToken in AppleArchiveLoadOptions, extract ... |
| [load-bzip2-with-bzip2loadoptions-extractionprogressed-extract-the-stream-to-a-local-file-and-save-a-progress.cs](./load-bzip2-with-bzip2loadoptions-extractionprogressed-extract-the-stream-to-a-local-file-and-save-a-progress.cs) | `Bzip2LoadOptions` | Load BZIP2 with Bzip2LoadOptions.ExtractionProgressed, extract the stream to a l... |
| [load-bzip2-with-a-cancellationtoken-in-bzip2loadoptions-extract-to-a-local-file-and-handle-cancellation-with-a.cs](./load-bzip2-with-a-cancellationtoken-in-bzip2loadoptions-extract-to-a-local-file-and-handle-cancellation-with-a.cs) | `Bzip2LoadOptions` | Load BZIP2 with a CancellationToken in Bzip2LoadOptions, extract to a local file... |
| [extract-a-bzip2-archive-to-a-specific-output-file-path-while-providing-a-cancellationtoken-for-abort-capability.cs](./extract-a-bzip2-archive-to-a-specific-output-file-path-while-providing-a-cancellationtoken-for-abort-capability.cs) | `Bzip2LoadOptions` | Extract a BZIP2 archive to a specific output file path while providing a Cancell... |
| [cancel-extraction-of-large-archive-zip-after-50-megabytes-processed-by-providing-a-cancellationtoken-to-the.cs](./cancel-extraction-of-large-archive-zip-after-50-megabytes-processed-by-providing-a-cancellationtoken-to-the.cs) | `ArchiveLoadOptions` | Cancel extraction of 'large_archive.zip' after 50 megabytes processed by providi... |
| [attach-compressionprogressed-event-to-sevenziparchiveentry-while-compressing-project-7z-and-record-overall.cs](./attach-compressionprogressed-event-to-sevenziparchiveentry-while-compressing-project-7z-and-record-overall.cs) |  | Attach CompressionProgressed event to SevenZipArchiveEntry while compressing 'pr... |
| [create-archive-zip-from-local-files-with-a-filestream-output-subscribe-to-archiveentry-compressionprogressed-and.cs](./create-archive-zip-from-local-files-with-a-filestream-output-subscribe-to-archiveentry-compressionprogressed-and.cs) |  | Create 'archive.zip' from local files with a FileStream output, subscribe to Arc... |
| [compress-reports-folder-into-reports-xar-using-xarfileentry-compressionprogressed-generate-progress-report-in-xar.cs](./compress-reports-folder-into-reports-xar-using-xarfileentry-compressionprogressed-generate-progress-report-in-xar.cs) |  | Compress 'reports' folder into 'reports.xar' using XarFileEntry.CompressionProgr... |
| [cancel-extraction-of-bigdata-zip-after-200-megabytes-processed-using-a-cancellationtoken.cs](./cancel-extraction-of-bigdata-zip-after-200-megabytes-processed-using-a-cancellationtoken.cs) | `ArchiveLoadOptions` | Cancel extraction of 'bigdata.zip' after 200 megabytes processed using a Cancell... |
| [compress-files-into-media-7z-while-aggregating-sevenziparchiveentry-compressionprogressed-bytes-to-calculate.cs](./compress-files-into-media-7z-while-aggregating-sevenziparchiveentry-compressionprogressed-bytes-to-calculate.cs) |  | Compress files into 'media.7z' while aggregating SevenZipArchiveEntry.Compressio... |
| [extract-documents-zip-with-filestream-subscribe-to-archiveentry-extractionprogressed-and-output-overall.cs](./extract-documents-zip-with-filestream-subscribe-to-archiveentry-extractionprogressed-and-output-overall.cs) |  | Extract 'documents.zip' with FileStream, subscribe to ArchiveEntry.ExtractionPro... |
| [attach-compressionprogressed-handler-to-archiveentry-while-creating-data-zip-and-write-overall-compression.cs](./attach-compressionprogressed-handler-to-archiveentry-while-creating-data-zip-and-write-overall-compression.cs) |  | Attach CompressionProgressed handler to ArchiveEntry while creating 'data.zip' a... |
| [create-an-archive-from-local-files-compute-archive-wide-percentage-for-collection-7z-by-summing.cs](./create-an-archive-from-local-files-compute-archive-wide-percentage-for-collection-7z-by-summing.cs) |  | Create an archive from local files; compute archive-wide percentage for 'collect... |
| [create-an-archive-from-local-files-generate-real-time-progress-report-for-sample-zip-by-handling-archiveentry.cs](./create-an-archive-from-local-files-generate-real-time-progress-report-for-sample-zip-by-handling-archiveentry.cs) |  | Create an archive from local files; generate real-time progress report for 'samp... |
| [extract-data-zip-while-aggregating-archiveentry-extractionprogressed-bytes-across-entries-to-compute-overall.cs](./extract-data-zip-while-aggregating-archiveentry-extractionprogressed-bytes-across-entries-to-compute-overall.cs) | `ArchiveLoadOptions` | Extract 'data.zip' while aggregating ArchiveEntry.ExtractionProgressed bytes acr... |
| [attach-extractionprogressed-event-to-archiveentry-while-extracting-files-zip-and-write-overall-extraction.cs](./attach-extractionprogressed-event-to-archiveentry-while-extracting-files-zip-and-write-overall-extraction.cs) | `ArchiveLoadOptions` | Attach ExtractionProgressed event to ArchiveEntry while extracting 'files.zip' a... |
| [create-bzip2archive-for-backup-bz2-and-attach-compressionprogressed-handler-that-writes-overall-compression.cs](./create-bzip2archive-for-backup-bz2-and-attach-compressionprogressed-handler-that-writes-overall-compression.cs) |  | Create Bzip2Archive for 'backup.bz2' and attach CompressionProgressed handler th... |
| [calculate-overall-compression-percentage-for-backup-zip-by-aggregating-archiveentry-compressionprogressed.cs](./calculate-overall-compression-percentage-for-backup-zip-by-aggregating-archiveentry-compressionprogressed.cs) |  | Calculate overall compression percentage for 'backup.zip' by aggregating Archive... |
| [extract-archive-zip-while-aggregating-archiveentry-extractionprogressed-bytes-to-compute-overall-extraction.cs](./extract-archive-zip-while-aggregating-archiveentry-extractionprogressed-bytes-to-compute-overall-extraction.cs) |  | Extract 'archive.zip' while aggregating ArchiveEntry.ExtractionProgressed bytes ... |
| [attach-compressionprogressed-handler-to-archiveentry-while-creating-backup-zip-and-write-overall-compression.cs](./attach-compressionprogressed-handler-to-archiveentry-while-creating-backup-zip-and-write-overall-compression.cs) |  | Attach CompressionProgressed handler to ArchiveEntry while creating 'backup.zip'... |
| [create-bzip2archive-for-archive-bz2-and-attach-compressionprogressed-handler-that-records-overall-compression.cs](./create-bzip2archive-for-archive-bz2-and-attach-compressionprogressed-handler-that-records-overall-compression.cs) |  | Create Bzip2Archive for 'archive.bz2' and attach CompressionProgressed handler t... |
| [create-zip-from-a-local-folder-set-cancelentryeventargs-cancel-through-archivesaveoptions-eventsbag.cs](./create-zip-from-a-local-folder-set-cancelentryeventargs-cancel-through-archivesaveoptions-eventsbag.cs) | `ArchiveSaveOptions` | Create ZIP from a local folder, set CancelEntryEventArgs.Cancel through ArchiveS... |
| [create-zip-from-local-files-set-cancelentryeventargs-cancel-through-eventsbag-entrycompressed-when-the-named.cs](./create-zip-from-local-files-set-cancelentryeventargs-cancel-through-eventsbag-entrycompressed-when-the-named.cs) | `ArchiveSaveOptions` | Create ZIP from local files, set CancelEntryEventArgs.Cancel through EventsBag.E... |
| [subscribe-to-entrycompressed-for-a-zip-archive-and-cancel-after-the-fifth-entry-is-processed.cs](./subscribe-to-entrycompressed-for-a-zip-archive-and-cancel-after-the-fifth-entry-is-processed.cs) | `ArchiveSaveOptions` | Subscribe to EntryCompressed for a ZIP archive and cancel after the fifth entry ... |
| [use-cancellationtokensource-cancelafter-to-set-a-three-second-timeout-for-extracting-a-zip-archive-to-a-directory.cs](./use-cancellationtokensource-cancelafter-to-set-a-three-second-timeout-for-extracting-a-zip-archive-to-a-directory.cs) | `ArchiveLoadOptions` | Use CancellationTokenSource.CancelAfter to set a three‑second timeout for extrac... |
| [use-cancellationtokensource-cancelafter-to-set-a-six-second-timeout-for-extracting-a-cab-archive-to-a-folder.cs](./use-cancellationtokensource-cancelafter-to-set-a-six-second-timeout-for-extracting-a-cab-archive-to-a-folder.cs) | `CabLoadOptions` | Use CancellationTokenSource.CancelAfter to set a six‑second timeout for extracti... |
| [extract-a-rar-archive-to-a-directory-with-a-token-that-cancels-after-four-seconds-of-extraction.cs](./extract-a-rar-archive-to-a-directory-with-a-token-that-cancels-after-four-seconds-of-extraction.cs) | `RarArchiveLoadOptions` | Extract a RAR archive to a directory with a token that cancels after four second... |
| *...and 21 more files* | | [View all](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/events) |

## Category Statistics
- Total examples: 51
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveLoadOptions`
- `ArchiveSaveOptions`
- `Bzip2LoadOptions`
- `CabLoadOptions`
- `GzipLoadOptions`
- `RarArchiveLoadOptions`

## Failed Tasks

All tasks passed ✅


## Use Cases
- **Timeout‑controlled CAB extraction** – By wiring a `CancellationTokenSource` to the CAB extraction process, you can automatically cancel the operation after a set period and still retrieve a list of files that were successfully extracted, a common requirement for long‑running batch jobs. *(events C# examples)*
- **Real‑time ZIP compression monitoring** – Attaching a `CompressionProgressed` handler to each `ArchiveEntry` while building a backup ZIP lets you capture the overall compression percentage and write it to a log file, useful for UI feedback or audit trails. *(events C# examples)*
- **Aggregated progress for 7‑zip archives** – Subscribing to the `CompressionProgressed` event on `SevenZipArchiveEntry` objects enables you to sum processed bytes across all entries and compute a single progress metric for large multi‑file 7z archives. *(events C# examples)*
- **Conditional cancellation during ZIP creation** – Using the `CancelEntryEventArgs` event, you can abort the compression of a ZIP entry when a specific condition is met (e.g., file size exceeds a threshold), allowing dynamic control over the archive composition. *(events C# examples)*
- **Bzip2 compression analytics** – By handling the `CompressionProgressed` event on a `Bzip2Archive`, you can record detailed compression statistics for each file, helping you fine‑tune performance for high‑volume data pipelines. *(events C# examples)*

## Related Categories
The **Events** examples often complement the **Compression** and **Extraction** categories, where the same APIs are used to perform the core archive operations but without event handling. If you need to secure archives, the **Encryption** category shows how to combine password protection with event‑driven progress tracking. Likewise, the **Streaming** category demonstrates processing large archives in a memory‑efficient way, which can be enhanced by attaching the same event handlers shown here to monitor streaming progress. Exploring these adjacent sections gives a fuller picture of how Aspose.ZIP for .NET can be orchestrated across different workflow stages.

<!-- AUTOGENERATED:START -->
Updated: 2026-11-05 | Run: `20261103_183832` | Examples: 51
<!-- AUTOGENERATED:END -->