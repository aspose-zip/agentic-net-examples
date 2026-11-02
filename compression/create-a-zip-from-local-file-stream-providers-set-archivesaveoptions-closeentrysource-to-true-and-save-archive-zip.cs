// HOW-TO: Create ZIP from File Streams and Auto‑Close Sources in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input file paths
            string inputPath1 = @"C:\Data\file1.txt";
            string inputPath2 = @"C:\Data\file2.txt";

            // Hardcoded output archive path
            string outputPath = @"C:\Output\archive.zip";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create output stream for the ZIP archive
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Open source file streams
                using (FileStream source1 = File.OpenRead(inputPath1))
                {
                    using (FileStream source2 = File.OpenRead(inputPath2))
                    {
                        // Create a new ZIP archive
                        using (Archive archive = new Archive())
                        {
                            // Add entries from the source streams
                            archive.CreateEntry("file1.txt", source1);
                            archive.CreateEntry("file2.txt", source2);

                            // Configure save options to close entry source streams after saving
                            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                            saveOptions.CloseEntrySource = true;

                            // Save the archive to the output stream
                            archive.Save(zipFile, saveOptions);
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
 * 1. When you need to bundle multiple local files into a single ZIP archive while ensuring the original file streams are closed automatically after saving.
 * 2. When generating a downloadable package of logs or reports on the fly in a C# web application without leaving open file handles.
 * 3. When creating backup archives of configuration files in a scheduled service and you want the source streams released immediately after the archive is written.
 * 4. When exporting selected documents from a desktop tool into a compressed ZIP file and you must guarantee that the source streams are disposed to avoid file‑lock issues.
 * 5. When implementing a file‑transfer feature that compresses user‑chosen files into a ZIP and requires the streams to be closed to free system resources before further processing.
 */
