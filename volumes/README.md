# Create Multi‑Volume ZIP Archives in C# with Aspose.ZIP  

This collection shows how to work with **volumes** using **Aspose.ZIP for .NET** – a UI‑agnostic backend API that runs everywhere (ASP.NET Core, console apps, Azure Functions, Docker, etc.). The examples demonstrate creating split ZIP archives for audio, image thumbnails, and video clips with custom part sizes, as well as validating and extracting multi‑volume archives.

## What You Can Do  

- **Split audio files into 110 KiB ZIP volumes** – add `sample1.mp3`, `sample2.wav`, … and save with a base name like `samples` using `SplitArchiveSaveOptions`.  
- **Create a 200 KiB‑per‑volume ZIP for multiple audio tracks** – pack `song1.mp3`, `song2.wav`, `song3.flac` into split parts with a custom base name (`audio`).  
- **Generate 64 KB ZIP segments for image thumbnails** – archive all files from a thumbnails folder (`C:\Images\Thumbnails`) into split parts named `thumbs`.  
- **Combine large video clips into 2 MiB ZIP volumes** – add several video files and split the archive into 2 MiB chunks.  
- **Validate and extract a multi‑volume ZIP** – enumerate `.z01`, `.z02`, … segments, ensure each part is readable, then load the final `archive.zip` and extract its contents.

## Quick Start  

```csharp
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main()
    {
        // Input files (audio example)
        string[] files = {
            Path.Combine("input", "sample1.mp3"),
            Path.Combine("input", "sample2.wav")
        };

        // Create a split ZIP with 110 KiB volumes
        using var archive = new Archive();
        foreach (var f in files)
            archive.AddEntry(Path.GetFileName(f), File.OpenRead(f));

        var splitOptions = new SplitArchiveSaveOptions
        {
            VolumeSize = 110 * 1024,          // 110 KiB per part
            BaseName   = "samples"            // base name for parts: samples.z01, samples.z02, …
        };

        archive.SaveSplit("output\\samples.zip", splitOptions);
        Console.WriteLine("Split archive created successfully.");
    }
}
```

## Requirements  

- **.NET 9+**  
- **Aspose.Zip** NuGet package  

```bash
dotnet add package Aspose.Zip
```

## Resources  

| Link | Description |
|------|-------------|
| [Documentation](https://docs.aspose.com/zip/net/) | Full API reference and guides |
| [NuGet](https://www.nuget.org/packages/Aspose.Zip) | Package download |
| [Release Notes](https://releases.aspose.com/zip/net/) | Version history and new features |
| [Online Apps](https://products.aspose.app/zip/family/) | Try ZIP operations in the browser |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [add-audio-sample-files-to-archive-set-110-kib-splitarchivesaveoptions-call-savesplit-with-base-name-samples-and.cs](./add-audio-sample-files-to-archive-set-110-kib-splitarchivesaveoptions-call-savesplit-with-base-name-samples-and.cs) |
| [add-csv-and-xml-files-add-to-archive-set-90-kib-splitarchivesaveoptions-call-savesplit-with-base-name-datafiles.cs](./add-csv-and-xml-files-add-to-archive-set-90-kib-splitarchivesaveoptions-call-savesplit-with-base-name-datafiles.cs) |
| [add-five-pdf-documents-to-archive-configure-256-kib-splitarchivesaveoptions-call-savesplit-with-base-name-docs.cs](./add-five-pdf-documents-to-archive-configure-256-kib-splitarchivesaveoptions-call-savesplit-with-base-name-docs.cs) |
| [add-json-configuration-files-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs](./add-json-configuration-files-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs) |
| [add-local-files-to-archive-and-save-multi-volume-zip-parts-using-savesplit-with-a-caller-specified-segment-size.cs](./add-local-files-to-archive-and-save-multi-volume-zip-parts-using-savesplit-with-a-caller-specified-segment-size.cs) |
| [add-local-files-to-sevenziparchive-and-save-multi-volume-7z-parts-using-savesplit-with-a-caller-specified-volume.cs](./add-local-files-to-sevenziparchive-and-save-multi-volume-7z-parts-using-savesplit-with-a-caller-specified-volume.cs) |
| [add-multiple-audio-files-to-archive-configure-200-kib-splitarchivesaveoptions-call-savesplit-with-base-name-audio.cs](./add-multiple-audio-files-to-archive-configure-200-kib-splitarchivesaveoptions-call-savesplit-with-base-name-audio.cs) |
| [add-pdf-and-docx-files-to-archive-configure-180-kib-splitarchivesaveoptions-call-savesplit-with-base-name-reports.cs](./add-pdf-and-docx-files-to-archive-configure-180-kib-splitarchivesaveoptions-call-savesplit-with-base-name-reports.cs) |
| [add-script-files-js-py-to-archive-configure-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name-scripts.cs](./add-script-files-js-py-to-archive-configure-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name-scripts.cs) |
| [add-svg-graphics-to-archive-configure-70-kib-splitarchivesaveoptions-call-savesplit-with-base-name-svg-and-save.cs](./add-svg-graphics-to-archive-configure-70-kib-splitarchivesaveoptions-call-savesplit-with-base-name-svg-and-save.cs) |
| [add-xml-files-to-archive-configure-80-kib-splitarchivesaveoptions-call-savesplit-with-base-name-xml-and-save-all.cs](./add-xml-files-to-archive-configure-80-kib-splitarchivesaveoptions-call-savesplit-with-base-name-xml-and-save-all.cs) |
| [archive-html-webpages-add-to-archive-set-120-kib-splitarchivesaveoptions-call-savesplit-with-base-name-site-and.cs](./archive-html-webpages-add-to-archive-set-120-kib-splitarchivesaveoptions-call-savesplit-with-base-name-site-and.cs) |
| [archive-image-thumbnails-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name-thumbs.cs](./archive-image-thumbnails-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name-thumbs.cs) |
| [archive-ini-configuration-files-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs](./archive-ini-configuration-files-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs) |
| [archive-markdown-documents-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name-md-and.cs](./archive-markdown-documents-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name-md-and.cs) |
| [archive-png-image-files-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name-pngset.cs](./archive-png-image-files-add-to-archive-set-64-kib-splitarchivesaveoptions-call-savesplit-with-base-name-pngset.cs) |
| [archive-ttf-font-files-add-to-archive-configure-95-kib-splitarchivesaveoptions-call-savesplit-with-base-name-ttf.cs](./archive-ttf-font-files-add-to-archive-configure-95-kib-splitarchivesaveoptions-call-savesplit-with-base-name-ttf.cs) |
| [check-that-all-local-7z-volume-files-are-readable-load-them-in-order-with-sevenziparchive-and-extract-their.cs](./check-that-all-local-7z-volume-files-are-readable-load-them-in-order-with-sevenziparchive-and-extract-their.cs) |
| [check-that-all-local-zip-segments-are-readable-load-the-final-zip-and-preceding-z01-z02-parts-with-archive-and.cs](./check-that-all-local-zip-segments-are-readable-load-the-final-zip-and-preceding-z01-z02-parts-with-archive-and.cs) |
| [combine-backup-files-add-to-archive-set-250-kib-splitarchivesaveoptions-call-savesplit-with-base-name-backup-and.cs](./combine-backup-files-add-to-archive-set-250-kib-splitarchivesaveoptions-call-savesplit-with-base-name-backup-and.cs) |
| [combine-csv-and-json-files-add-to-archive-configure-85-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs](./combine-csv-and-json-files-add-to-archive-configure-85-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs) |
| [combine-encrypted-pdf-files-add-to-archive-set-150-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs](./combine-encrypted-pdf-files-add-to-archive-set-150-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs) |
| [combine-epub-ebook-files-add-to-archive-configure-150-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs](./combine-epub-ebook-files-add-to-archive-configure-150-kib-splitarchivesaveoptions-call-savesplit-with-base-name.cs) |
| [combine-several-csv-files-add-to-archive-set-100-kib-splitarchivesaveoptions-call-savesplit-with-base-name-data.cs](./combine-several-csv-files-add-to-archive-set-100-kib-splitarchivesaveoptions-call-savesplit-with-base-name-data.cs) |
| [combine-video-clip-files-add-to-archive-set-2-mib-splitarchivesaveoptions-call-savesplit-with-base-name-clip-and.cs](./combine-video-clip-files-add-to-archive-set-2-mib-splitarchivesaveoptions-call-savesplit-with-base-name-clip-and.cs) |
| [combine-video-files-add-to-archive-set-1-mib-splitarchivesaveoptions-call-savesplit-with-base-name-video-and-save.cs](./combine-video-files-add-to-archive-set-1-mib-splitarchivesaveoptions-call-savesplit-with-base-name-video-and-save.cs) |
| [create-a-7z-archive-from-local-files-and-save-60-mib-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs](./create-a-7z-archive-from-local-files-and-save-60-mib-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs) |
| [create-a-7z-archive-from-local-files-and-save-80-mib-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs](./create-a-7z-archive-from-local-files-and-save-80-mib-volumes-using-splitsevenziparchivesaveoptions-and-savesplit.cs) |
| [create-a-multi-volume-zip-archive-from-multiple-files-with-80-mb-volume-size-using-savesplit.cs](./create-a-multi-volume-zip-archive-from-multiple-files-with-80-mb-volume-size-using-savesplit.cs) |
| [create-a-multi-volume-zip-archive-with-50-mb-volume-size-using-savesplit.cs](./create-a-multi-volume-zip-archive-with-50-mb-volume-size-using-savesplit.cs) |
[**View all 79 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/volumes)
