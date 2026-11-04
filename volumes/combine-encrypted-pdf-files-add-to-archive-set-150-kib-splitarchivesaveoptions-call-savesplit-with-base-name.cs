// HOW-TO: Create Split ZIP of Encrypted PDFs with 150KB Segments in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PDF file paths (encrypted PDFs)
            string[] inputPdfPaths = {
                "C:\\Input\\encrypted1.pdf",
                "C:\\Input\\encrypted2.pdf"
            };

            // Hardcoded output directory and base name for split archive
            string outputDirectory = "C:\\Output";
            string baseName = "secure";

            // Validate each input file exists
            foreach (string inputPath in inputPdfPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Create a new ZIP archive and add each PDF as an entry
            using (Archive archive = new Archive())
            {
                foreach (string inputPath in inputPdfPaths)
                {
                    // Use the file name as the entry name inside the archive
                    string entryName = Path.GetFileName(inputPath);
                    // Add the PDF file to the archive
                    archive.CreateEntry(entryName, new FileInfo(inputPath));
                }

                // Configure split options: each segment limited to 150 KiB
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(150 * 1024);

                // Build the full base path for the split archive files
                string basePath = Path.Combine(outputDirectory, baseName);

                // Save the archive as split segments
                archive.SaveSplit(basePath, saveOptions);
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
 * 1. When you need to bundle multiple password‑protected PDF reports into a single archive that can be transferred over a network with size limits.
 * 2. When a compliance system requires encrypted documents to be stored in split ZIP files to avoid exceeding email attachment size restrictions.
 * 3. When an application must generate a downloadable package of confidential PDFs, splitting it into 150 KiB parts for easier resumable download.
 * 4. When you want to archive sensitive PDFs on disk while preserving their original filenames and ensuring each archive segment fits on a removable storage device.
 * 5. When a backup script must create a multi‑part ZIP of encrypted PDFs so each part can be processed independently by downstream tools.
 */
