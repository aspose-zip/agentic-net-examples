# Extract, Analyze, and Archive Images with Aspose.ZIP for .NET in C#

A set of ready‑to‑run C# examples that show how to work with image files inside ZIP archives using **Aspose.ZIP for .NET**.  
The code demonstrates how to batch‑extract images from DOCX documents, calculate their total size, compress them back into ZIP files, convert them to Base64 strings, and generate simple summary reports. Aspose.ZIP is a UI‑agnostic backend API that runs everywhere – ASP.NET Core, console apps, Azure Functions, Docker containers, and more – without any UI dependencies.

## What You Can Do
- **Batch extract images from multiple DOCX files** and create a separate ZIP archive for each document.  
- **Calculate the combined byte length** of all extracted images and write the value to a text file.  
- **Compress a folder of extracted images** into a new ZIP archive named `ExtractedImages.zip`.  
- **Convert each image’s byte array to a Base64 string** and store all strings in a single text file.  
- **Count the total number of extracted images** and write a summary (count) to a text file.

## Quick Start
The most common scenario is extracting images from a batch of DOCX files and archiving each set into its own ZIP file:

```csharp
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main()
    {
        string inputFolder  = @"C:\InputDocs";   // folder with DOCX files
        string outputFolder = @"C:\OutputZips";  // where ZIPs will be saved

        if (!Directory.Exists(inputFolder))
        {
            Console.Error.WriteLine($"Input folder not found: {inputFolder}");
            return;
        }

        foreach (var docxPath in Directory.GetFiles(inputFolder, "*.docx"))
        {
            // 1. Extract images from the DOCX (treated as a ZIP archive)
            using (var zip = new ZipFile(docxPath))
            {
                var images = zip.Entries
                                .Where(e => e.Name.EndsWith(".png") ||
                                            e.Name.EndsWith(".jpg") ||
                                            e.Name.EndsWith(".jpeg"));
                string zipName = Path.GetFileNameWithoutExtension(docxPath) + ".zip";
                string zipPath = Path.Combine(outputFolder, zipName);

                // 2. Create a new ZIP containing only the images
                using (var outZip = new ZipFile())
                {
                    foreach (var img in images)
                        outZip.AddEntry(img.Name, img.Open());

                    outZip.Save(zipPath);
                }
            }

            Console.WriteLine($"Created: {Path.GetFileName(zipPath)}");
        }
    }
}
```

Run the snippet in a console app, ASP.NET Core service, Azure Function, or Docker container – no UI required.

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
| [Release Notes](https://releases.aspose.com/zip/net/) | What's new in each version |
| [Online Apps](https://products.aspose.app/zip/family/) | Try ZIP operations in the browser |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [batch-extract-images-from-docx-files-in-a-folder-and-archive-each-set-into-a-zip-file.cs](./batch-extract-images-from-docx-files-in-a-folder-and-archive-each-set-into-a-zip-file.cs) |
| [calculate-the-combined-byte-length-of-all-extracted-images-and-save-the-value-to-a-text-file.cs](./calculate-the-combined-byte-length-of-all-extracted-images-and-save-the-value-to-a-text-file.cs) |
| [compress-all-extracted-image-files-into-a-new-zip-archive-named-extractedimages-zip.cs](./compress-all-extracted-image-files-into-a-new-zip-archive-named-extractedimages-zip.cs) |
| [convert-each-image-byte-array-to-a-base64-string-and-write-the-strings-to-a-text-file.cs](./convert-each-image-byte-array-to-a-base64-string-and-write-the-strings-to-a-text-file.cs) |
| [count-the-total-number-of-extracted-images-and-write-the-count-to-a-summary-text-file.cs](./count-the-total-number-of-extracted-images-and-write-the-count-to-a-summary-text-file.cs) |
| [create-a-utility-that-copies-all-extracted-image-files-into-a-user-specified-output-directory.cs](./create-a-utility-that-copies-all-extracted-image-files-into-a-user-specified-output-directory.cs) |
| [create-a-utility-that-saves-a-dictionary-of-image-entry-names-and-base64-strings-to-a-json-file.cs](./create-a-utility-that-saves-a-dictionary-of-image-entry-names-and-base64-strings-to-a-json-file.cs) |
| [develop-a-method-that-generates-a-markdown-document-listing-each-extracted-image-with-its-base64-data-block.cs](./develop-a-method-that-generates-a-markdown-document-listing-each-extracted-image-with-its-base64-data-block.cs) |
| [develop-a-routine-that-reads-the-base64-text-file-and-reconstructs-original-images-in-an-output-folder.cs](./develop-a-routine-that-reads-the-base64-text-file-and-reconstructs-original-images-in-an-output-folder.cs) |
| [generate-a-summary-report-file-listing-the-number-of-images-extracted-and-total-bytes-processed.cs](./generate-a-summary-report-file-listing-the-number-of-images-extracted-and-total-bytes-processed.cs) |
| [implement-a-function-that-writes-total-image-count-and-combined-size-to-a-json-summary-file.cs](./implement-a-function-that-writes-total-image-count-and-combined-size-to-a-json-summary-file.cs) |
| [load-a-local-docx-as-a-zip-package-with-archive-enumerate-its-entries-and-save-the-entry-names-in-a-text-report.cs](./load-a-local-docx-as-a-zip-package-with-archive-enumerate-its-entries-and-save-the-entry-names-in-a-text-report.cs) |
| [load-a-local-docx-zip-package-extract-word-media-image-entries-to-byte-arrays-and-persist-each-array-with-its.cs](./load-a-local-docx-zip-package-extract-word-media-image-entries-to-byte-arrays-and-persist-each-array-with-its.cs) |
| [load-a-local-docx-zip-package-with-archive-identify-word-media-entries-and-save-their-full-names-in-a-text-report.cs](./load-a-local-docx-zip-package-with-archive-identify-word-media-entries-and-save-their-full-names-in-a-text-report.cs) |
| [process-a-list-of-docx-paths-extract-images-from-each-and-save-them-to-separate-folders.cs](./process-a-list-of-docx-paths-extract-images-from-each-and-save-them-to-separate-folders.cs) |
| [save-each-extracted-image-byte-array-to-an-output-folder-using-its-original-entry-name.cs](./save-each-extracted-image-byte-array-to-an-output-folder-using-its-original-entry-name.cs) |
| [write-a-routine-that-renames-extracted-image-files-to-include-their-original-entry-index-prefix.cs](./write-a-routine-that-renames-extracted-image-files-to-include-their-original-entry-index-prefix.cs) |
| [write-a-routine-that-saves-each-base64-string-as-a-separate-txt-file-named-after-its-image-entry.cs](./write-a-routine-that-saves-each-base64-string-as-a-separate-txt-file-named-after-its-image-entry.cs) |
| [write-a-utility-that-generates-an-html-file-displaying-all-extracted-images-using-data-uri-sources.cs](./write-a-utility-that-generates-an-html-file-displaying-all-extracted-images-using-data-uri-sources.cs) |
[**View all 19 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/images)
