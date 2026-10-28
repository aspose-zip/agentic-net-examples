---
name: images
description: C# examples for Images using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Images

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Images** category.
This folder contains standalone C# examples for Images operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (21/21 files)
- `using System.IO;` (21/21 files)
- `using Aspose.Zip;` (16/21 files) ← category-specific
- `using System.Collections.Generic;` (6/21 files)
- `using System.Text;` (6/21 files)
- `using System.Linq;` (2/21 files)
- `using Aspose.Zip.Saving;` (2/21 files) ← category-specific
- `using System.Text.Json;` (1/21 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [load-a-local-docx-as-a-zip-package-with-archive-enumerate-its-entries-and-save-the-entry-names-in-a-text-report.cs](./load-a-local-docx-as-a-zip-package-with-archive-enumerate-its-entries-and-save-the-entry-names-in-a-text-report.cs) |  | Load a local DOCX as a ZIP package with Archive, enumerate its entries, and save... |
| [load-a-local-docx-zip-package-with-archive-identify-word-media-entries-and-save-their-full-names-in-a-text-report.cs](./load-a-local-docx-zip-package-with-archive-identify-word-media-entries-and-save-their-full-names-in-a-text-report.cs) |  | Load a local DOCX ZIP package with Archive, identify word/media entries, and sav... |
| [load-a-local-docx-zip-package-extract-word-media-image-entries-to-byte-arrays-and-persist-each-array-with-its.cs](./load-a-local-docx-zip-package-extract-word-media-image-entries-to-byte-arrays-and-persist-each-array-with-its.cs) |  | Load a local DOCX ZIP package, extract word/media image entries to byte arrays, ... |
| [save-each-extracted-image-byte-array-to-an-output-folder-using-its-original-entry-name.cs](./save-each-extracted-image-byte-array-to-an-output-folder-using-its-original-entry-name.cs) |  | Save each extracted image byte array to an output folder using its original entr... |
| [convert-each-image-byte-array-to-a-base64-string-and-write-the-strings-to-a-text-file.cs](./convert-each-image-byte-array-to-a-base64-string-and-write-the-strings-to-a-text-file.cs) |  | Convert each image byte array to a Base64 string and write the strings to a text... |
| [write-a-routine-that-saves-each-base64-string-as-a-separate-txt-file-named-after-its-image-entry.cs](./write-a-routine-that-saves-each-base64-string-as-a-separate-txt-file-named-after-its-image-entry.cs) |  | Write a routine that saves each Base64 string as a separate .txt file named afte... |
| [count-the-total-number-of-extracted-images-and-write-the-count-to-a-summary-text-file.cs](./count-the-total-number-of-extracted-images-and-write-the-count-to-a-summary-text-file.cs) |  | Count the total number of extracted images and write the count to a summary text... |
| [calculate-the-combined-byte-length-of-all-extracted-images-and-save-the-value-to-a-text-file.cs](./calculate-the-combined-byte-length-of-all-extracted-images-and-save-the-value-to-a-text-file.cs) |  | Calculate the combined byte length of all extracted images and save the value to... |
| [develop-a-routine-that-calculates-average-byte-size-of-extracted-images-and-saves-to-a-text-file.cs](./develop-a-routine-that-calculates-average-byte-size-of-extracted-images-and-saves-to-a-text-file.cs) |  | Develop a routine that calculates average byte size of extracted images and save... |
| [generate-a-summary-report-file-listing-the-number-of-images-extracted-and-total-bytes-processed.cs](./generate-a-summary-report-file-listing-the-number-of-images-extracted-and-total-bytes-processed.cs) |  | Generate a summary report file listing the number of images extracted and total ... |
| [create-a-utility-that-saves-a-dictionary-of-image-entry-names-and-base64-strings-to-a-json-file.cs](./create-a-utility-that-saves-a-dictionary-of-image-entry-names-and-base64-strings-to-a-json-file.cs) | `JsonSerializerOptions` | Create a utility that saves a dictionary of image entry names and Base64 strings... |
| [create-a-script-that-generates-a-csv-file-containing-image-entry-names-and-their-byte-sizes.cs](./create-a-script-that-generates-a-csv-file-containing-image-entry-names-and-their-byte-sizes.cs) |  | Create a script that generates a CSV file containing image entry names and their... |
| [write-a-utility-that-generates-an-html-file-displaying-all-extracted-images-using-data-uri-sources.cs](./write-a-utility-that-generates-an-html-file-displaying-all-extracted-images-using-data-uri-sources.cs) |  | Write a utility that generates an HTML file displaying all extracted images usin... |
| [develop-a-method-that-generates-a-markdown-document-listing-each-extracted-image-with-its-base64-data-block.cs](./develop-a-method-that-generates-a-markdown-document-listing-each-extracted-image-with-its-base64-data-block.cs) |  | Develop a method that generates a Markdown document listing each extracted image... |
| [compress-all-extracted-image-files-into-a-new-zip-archive-named-extractedimages-zip.cs](./compress-all-extracted-image-files-into-a-new-zip-archive-named-extractedimages-zip.cs) | `ArchiveSaveOptions` | Compress all extracted image files into a new ZIP archive named "ExtractedImages... |
| [create-a-utility-that-copies-all-extracted-image-files-into-a-user-specified-output-directory.cs](./create-a-utility-that-copies-all-extracted-image-files-into-a-user-specified-output-directory.cs) |  | Create a utility that copies all extracted image files into a user‑specified out... |
| [develop-a-routine-that-reads-the-base64-text-file-and-reconstructs-original-images-in-an-output-folder.cs](./develop-a-routine-that-reads-the-base64-text-file-and-reconstructs-original-images-in-an-output-folder.cs) |  | Develop a routine that reads the Base64 text file and reconstructs original imag... |
| [write-a-routine-that-renames-extracted-image-files-to-include-their-original-entry-index-prefix.cs](./write-a-routine-that-renames-extracted-image-files-to-include-their-original-entry-index-prefix.cs) |  | Write a routine that renames extracted image files to include their original ent... |
| [process-a-list-of-docx-paths-extract-images-from-each-and-save-them-to-separate-folders.cs](./process-a-list-of-docx-paths-extract-images-from-each-and-save-them-to-separate-folders.cs) |  | Process a list of DOCX paths, extract images from each, and save them to separat... |
| [batch-extract-images-from-docx-files-in-a-folder-and-archive-each-set-into-a-zip-file.cs](./batch-extract-images-from-docx-files-in-a-folder-and-archive-each-set-into-a-zip-file.cs) | `ArchiveSaveOptions` | Batch extract images from DOCX files in a folder and archive each set into a ZIP... |
| [implement-a-function-that-writes-total-image-count-and-combined-size-to-a-json-summary-file.cs](./implement-a-function-that-writes-total-image-count-and-combined-size-to-a-json-summary-file.cs) |  | Implement a function that writes total image count and combined size to a JSON s... |

## Category Statistics
- Total examples: 21
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveSaveOptions`
- `JsonSerializerOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-10-28 | Run: `20261028_173247` | Examples: 21
<!-- AUTOGENERATED:END -->