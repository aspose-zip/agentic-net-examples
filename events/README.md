# Events in C# with Aspose.ZIP for .NET  

This collection shows how to hook into **Aspose.ZIP** events to control long‑running archive operations.  
Examples demonstrate cancelling a CAB extraction after a timeout, aborting a ZIP extraction once a size limit is reached, and tracking compression progress for ZIP, 7z and BZIP2 archives – all without any UI dependencies, so the code runs in ASP.NET Core, console apps, Azure Functions, or Docker containers.

## What You Can Do  

- **Cancel CAB extraction after a timeout** and retrieve a list of entries that were successfully extracted.  
- **Monitor ZIP entry compression progress** by handling the `CompressionProgressed` event and persisting the percentage to a JSON file.  
- **Abort ZIP extraction** when the processed data exceeds a configurable limit (e.g., 50 MB) using a `CancellationToken`.  
- **Create a 7z archive** from a set of local files while computing an archive‑wide compression percentage by summing individual entry progress values.  
- **Generate a BZIP2 backup archive** and attach a `CompressionProgressed` handler that writes the overall compression ratio to a log or file.  

## Quick Start  

Below is a minimal snippet that creates a ZIP file, attaches a `CompressionProgressed` handler to each entry, and writes the overall compression percentage to a JSON file.

```csharp
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string zipPath   = "data.zip";
        string jsonPath  = "zip_progress.json";

        using var archive = new ZipArchive();
        var entry = archive.CreateEntry(Path.GetFileName(inputFile));

        // Attach progress event
        entry.CompressionProgressed += (s, e) =>
        {
            var progress = new { Entry = e.EntryName, Percent = e.ProgressPercentage };
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(progress));
        };

        // Write file data into the entry
        using (var entryStream = entry.Open())
        using (var fileStream = File.OpenRead(inputFile))
            fileStream.CopyTo(entryStream);

        // Save the archive
        archive.Save(zipPath);
        Console.WriteLine($"Created {zipPath} with progress saved to {jsonPath}");
    }
}
```

## Requirements  

- .NET 9+  
- Aspose.Zip NuGet package  

```bash
dotnet add package Aspose.Zip
```

## Resources  

| Link | Description |
|------|-------------|
| [Documentation](https://docs.aspose.com/zip/net/) | Full API reference and guides |
| [NuGet](https://www.nuget.org/packages/Aspose.Zip) | Package download and version history |
| [Release Notes](https://releases.aspose.com/zip/net/) | Changelog for each version |
| [Online Apps](https://products.aspose.app/zip/family/) | Try ZIP operations in the browser |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [apply-cancellationtokensource-cancelafter-to-cab-extraction-then-produce-a-list-of-successfully-extracted-entries.cs](./apply-cancellationtokensource-cancelafter-to-cab-extraction-then-produce-a-list-of-successfully-extracted-entries.cs) |
| [apply-cancellationtokensource-cancelafter-to-zip-extraction-then-generate-a-text-report-of-files-extracted-before.cs](./apply-cancellationtokensource-cancelafter-to-zip-extraction-then-generate-a-text-report-of-files-extracted-before.cs) |
| [attach-compressionprogressed-event-to-sevenziparchiveentry-while-compressing-project-7z-and-record-overall.cs](./attach-compressionprogressed-event-to-sevenziparchiveentry-while-compressing-project-7z-and-record-overall.cs) |
| [attach-compressionprogressed-handler-to-archiveentry-while-creating-backup-zip-and-write-overall-compression.cs](./attach-compressionprogressed-handler-to-archiveentry-while-creating-backup-zip-and-write-overall-compression.cs) |
| [attach-compressionprogressed-handler-to-archiveentry-while-creating-data-zip-and-write-overall-compression.cs](./attach-compressionprogressed-handler-to-archiveentry-while-creating-data-zip-and-write-overall-compression.cs) |
| [attach-extractionprogressed-event-to-archiveentry-while-extracting-files-zip-and-write-overall-extraction.cs](./attach-extractionprogressed-event-to-archiveentry-while-extracting-files-zip-and-write-overall-extraction.cs) |
| [calculate-overall-compression-percentage-for-backup-zip-by-aggregating-archiveentry-compressionprogressed.cs](./calculate-overall-compression-percentage-for-backup-zip-by-aggregating-archiveentry-compressionprogressed.cs) |
| [cancel-extraction-of-bigdata-zip-after-200-megabytes-processed-using-a-cancellationtoken.cs](./cancel-extraction-of-bigdata-zip-after-200-megabytes-processed-using-a-cancellationtoken.cs) |
| [cancel-extraction-of-large-archive-zip-after-50-megabytes-processed-by-providing-a-cancellationtoken-to-the.cs](./cancel-extraction-of-large-archive-zip-after-50-megabytes-processed-by-providing-a-cancellationtoken-to-the.cs) |
| [compress-files-into-media-7z-while-aggregating-sevenziparchiveentry-compressionprogressed-bytes-to-calculate.cs](./compress-files-into-media-7z-while-aggregating-sevenziparchiveentry-compressionprogressed-bytes-to-calculate.cs) |
| [compress-reports-folder-into-reports-xar-using-xarfileentry-compressionprogressed-generate-progress-report-in-xar.cs](./compress-reports-folder-into-reports-xar-using-xarfileentry-compressionprogressed-generate-progress-report-in-xar.cs) |
| [create-a-zip-archive-cancel-after-processing-entry-number-eight-and-keep-the-partially-created-archive-on-disk.cs](./create-a-zip-archive-cancel-after-processing-entry-number-eight-and-keep-the-partially-created-archive-on-disk.cs) |
| [create-an-archive-from-local-files-compute-archive-wide-percentage-for-collection-7z-by-summing.cs](./create-an-archive-from-local-files-compute-archive-wide-percentage-for-collection-7z-by-summing.cs) |
| [create-an-archive-from-local-files-generate-real-time-progress-report-for-sample-zip-by-handling-archiveentry.cs](./create-an-archive-from-local-files-generate-real-time-progress-report-for-sample-zip-by-handling-archiveentry.cs) |
| [create-archive-zip-from-local-files-with-a-filestream-output-subscribe-to-archiveentry-compressionprogressed-and.cs](./create-archive-zip-from-local-files-with-a-filestream-output-subscribe-to-archiveentry-compressionprogressed-and.cs) |
| [create-bzip2archive-for-archive-bz2-and-attach-compressionprogressed-handler-that-records-overall-compression.cs](./create-bzip2archive-for-archive-bz2-and-attach-compressionprogressed-handler-that-records-overall-compression.cs) |
| [create-bzip2archive-for-backup-bz2-and-attach-compressionprogressed-handler-that-writes-overall-compression.cs](./create-bzip2archive-for-backup-bz2-and-attach-compressionprogressed-handler-that-writes-overall-compression.cs) |
| [create-zip-from-a-local-folder-set-cancelentryeventargs-cancel-through-archivesaveoptions-eventsbag.cs](./create-zip-from-a-local-folder-set-cancelentryeventargs-cancel-through-archivesaveoptions-eventsbag.cs) |
| [create-zip-from-local-files-set-cancelentryeventargs-cancel-through-eventsbag-entrycompressed-when-the-named.cs](./create-zip-from-local-files-set-cancelentryeventargs-cancel-through-eventsbag-entrycompressed-when-the-named.cs) |
| [extract-a-bzip2-archive-to-a-location-providing-a-token-that-cancels-after-seven-seconds.cs](./extract-a-bzip2-archive-to-a-location-providing-a-token-that-cancels-after-seven-seconds.cs) |
| [extract-a-bzip2-archive-to-a-specific-output-file-path-while-providing-a-cancellationtoken-for-abort-capability.cs](./extract-a-bzip2-archive-to-a-specific-output-file-path-while-providing-a-cancellationtoken-for-abort-capability.cs) |
| [extract-a-forward-only-zip-from-a-local-pipe-stream-with-a-cancellationtoken-cancel-after-two-completed-entries.cs](./extract-a-forward-only-zip-from-a-local-pipe-stream-with-a-cancellationtoken-cancel-after-two-completed-entries.cs) |
| [extract-a-forward-only-zip-with-a-cancellationtoken-cancel-after-three-completed-entries-and-save-the-completed.cs](./extract-a-forward-only-zip-with-a-cancellationtoken-cancel-after-three-completed-entries-and-save-the-completed.cs) |
| [extract-a-gzip-archive-to-a-temporary-folder-using-a-cancellationtoken-that-aborts-after-five-seconds.cs](./extract-a-gzip-archive-to-a-temporary-folder-using-a-cancellationtoken-that-aborts-after-five-seconds.cs) |
| [extract-a-rar-archive-to-a-directory-with-a-token-that-cancels-after-four-seconds-of-extraction.cs](./extract-a-rar-archive-to-a-directory-with-a-token-that-cancels-after-four-seconds-of-extraction.cs) |
| [extract-a-specific-cab-entry-to-a-memorystream-with-a-token-and-write-the-partial-data-to-disk.cs](./extract-a-specific-cab-entry-to-a-memorystream-with-a-token-and-write-the-partial-data-to-disk.cs) |
| [extract-a-zip-entry-to-a-memorystream-with-a-cancellationtoken-then-save-the-partial-stream-to-a-file.cs](./extract-a-zip-entry-to-a-memorystream-with-a-cancellationtoken-then-save-the-partial-stream-to-a-file.cs) |
| [extract-archive-zip-while-aggregating-archiveentry-extractionprogressed-bytes-to-compute-overall-extraction.cs](./extract-archive-zip-while-aggregating-archiveentry-extractionprogressed-bytes-to-compute-overall-extraction.cs) |
| [extract-data-zip-while-aggregating-archiveentry-extractionprogressed-bytes-across-entries-to-compute-overall.cs](./extract-data-zip-while-aggregating-archiveentry-extractionprogressed-bytes-across-entries-to-compute-overall.cs) |
| [extract-documents-zip-with-filestream-subscribe-to-archiveentry-extractionprogressed-and-output-overall.cs](./extract-documents-zip-with-filestream-subscribe-to-archiveentry-extractionprogressed-and-output-overall.cs) |
[**View all 51 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/events)
