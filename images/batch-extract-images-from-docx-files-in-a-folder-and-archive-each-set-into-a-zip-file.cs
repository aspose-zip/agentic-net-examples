// HOW-TO: Batch Extract Images From DOCX Files and Create ZIP Archives in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input folder containing DOCX files
            string inputFolder = @"C:\InputDocs";
            // Hardcoded output folder for the generated image ZIP files
            string outputFolder = @"C:\OutputZips";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all DOCX files in the input folder
            string[] docxFiles = Directory.GetFiles(inputFolder, "*.docx");

            foreach (string docxPath in docxFiles)
            {
                // Verify the DOCX file exists
                if (!File.Exists(docxPath))
                {
                    Console.Error.WriteLine($"File not found: {docxPath}");
                    continue;
                }

                // Open the DOCX file as a ZIP archive
                using (Archive docxArchive = new Archive(docxPath))
                {
                    // Select entries that are images inside the DOCX (word/media folder)
                    List<ArchiveEntry> imageEntries = docxArchive.Entries
                        .Where(entry => entry.Name.StartsWith("word/media/", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (imageEntries.Count == 0)
                    {
                        // No images found in this DOCX; skip to next file
                        continue;
                    }

                    // Create a new ZIP archive to hold the extracted images
                    using (Archive imageZip = new Archive())
                    {
                        foreach (ArchiveEntry imgEntry in imageEntries)
                        {
                            // Open the image entry stream from the DOCX archive
                            using (Stream imgStream = imgEntry.Open())
                            {
                                // Copy the image data into a memory stream
                                using (MemoryStream memory = new MemoryStream())
                                {
                                    imgStream.CopyTo(memory);
                                    memory.Position = 0;

                                    // Add the image to the new ZIP archive using only the file name
                                    string imageFileName = Path.GetFileName(imgEntry.Name);
                                    imageZip.CreateEntry(imageFileName, memory);
                                }
                            }
                        }

                        // Build the output ZIP file path (e.g., Document_images.zip)
                        string zipFileName = Path.GetFileNameWithoutExtension(docxPath) + "_images.zip";
                        string zipPath = Path.Combine(outputFolder, zipFileName);

                        // Ensure the directory for the output ZIP exists
                        Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

                        // Save the image ZIP archive to disk
                        using (FileStream zipFile = File.Open(zipPath, FileMode.Create))
                        {
                            imageZip.Save(zipFile, new ArchiveSaveOptions());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to pull all embedded pictures from multiple Word documents and store them as separate zip files for easy distribution.
 * 2. When automating a content migration workflow that requires extracting images from DOCX files and compressing them for archival storage.
 * 3. When building a document processing service that must provide clients with downloadable image bundles extracted from each submitted Word file.
 * 4. When creating a backup of all graphics used in a collection of reports, saving each report’s images into its own zip archive.
 * 5. When generating asset packages for a design team by programmatically extracting and zipping images from a batch of DOCX templates.
 */
