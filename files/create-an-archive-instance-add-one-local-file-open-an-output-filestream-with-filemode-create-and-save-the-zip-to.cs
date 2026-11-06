// HOW-TO: Create a ZIP Archive From a Single File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\sample.txt";
            string outputPath = @"C:\Output\archive.zip";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the output stream for the ZIP archive
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Open the source file to be added to the archive
                using (FileStream source = File.Open(inputPath, FileMode.Open, FileAccess.Read))
                {
                    // Create a new ZIP archive instance
                    using (Archive archive = new Archive(new ArchiveEntrySettings()))
                    {
                        // Add the source file to the archive with its file name as the entry name
                        archive.CreateEntry(Path.GetFileName(inputPath), source);

                        // Save the archive to the output stream
                        archive.Save(zipFile);
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
 * 1. When you need to programmatically package a log file into a ZIP for automated backup in a .NET service.
 * 2. When you want to generate a downloadable ZIP on the fly from a user‑uploaded document in a web application.
 * 3. When you must compress a configuration file before sending it over a network socket using a FileStream.
 * 4. When you are building a scheduled task that archives daily reports into separate ZIP files without using external tools.
 * 5. When you require a simple way to create a ZIP archive in memory and write it directly to disk with Aspose.Zip for later extraction.
 */
