// HOW-TO: Batch Extract Images from DOCX Files and Create ZIP Archives in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputDocs";
            string outputFolder = @"C:\OutputZips";

            // Validate input folder
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure output folder exists
            Directory.CreateDirectory(outputFolder);

            // Get all DOCX files in the input folder
            string[] docxFiles = Directory.GetFiles(inputFolder, "*.docx");
            foreach (string docxPath in docxFiles)
            {
                // Validate each DOCX file exists
                if (!File.Exists(docxPath))
                {
                    Console.Error.WriteLine($"File not found: {docxPath}");
                    continue;
                }

                // Prepare output ZIP path for the extracted images
                string docxFileName = Path.GetFileNameWithoutExtension(docxPath);
                string zipOutputPath = Path.Combine(outputFolder, docxFileName + "_images.zip");

                // Create output directory (handles cases where outputFolder may be a subpath)
                Directory.CreateDirectory(Path.GetDirectoryName(zipOutputPath));

                // Open the DOCX file as a ZIP archive
                using (FileStream docxStream = File.Open(docxPath, FileMode.Open, FileAccess.Read))
                using (Archive docxArchive = new Archive(docxStream))
                // Create a new archive to hold the extracted images
                using (Archive imagesArchive = new Archive())
                {
                    // Iterate over entries in the DOCX archive
                    foreach (ArchiveEntry entry in docxArchive.Entries)
                    {
                        // DOCX stores images under the "word/media/" folder
                        if (entry.Name != null && entry.Name.StartsWith("word/media/", StringComparison.OrdinalIgnoreCase))
                        {
                            // Extract the image entry stream
                            using (Stream entryStream = entry.Open())
                            {
                                // Determine the image file name (strip the folder prefix)
                                string imageFileName = entry.Name.Substring("word/media/".Length);

                                // Add the image to the new archive
                                imagesArchive.CreateEntry(imageFileName, entryStream);
                            }
                        }
                    }

                    // Save the images archive to the output ZIP file
                    using (FileStream outStream = File.Open(zipOutputPath, FileMode.Create, FileAccess.Write))
                    {
                        imagesArchive.Save(outStream);
                    }
                }

                Console.WriteLine($"Extracted images from '{docxPath}' to '{zipOutputPath}'.");
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
 * 1. When you need to automatically pull all pictures from multiple Word documents and store each set in a separate zip for easy distribution.
 * 2. When a document management system must archive the visual assets of each uploaded DOCX without manual extraction.
 * 3. When preparing a batch of client reports for backup, you want to extract embedded images and compress them into individual zip files.
 * 4. When generating content packages for a web portal, you need to separate images from DOCX templates and deliver them as zip bundles.
 * 5. When performing a compliance audit, you must collect and archive every image from a folder of Word files in a searchable, compressed format.
 */
