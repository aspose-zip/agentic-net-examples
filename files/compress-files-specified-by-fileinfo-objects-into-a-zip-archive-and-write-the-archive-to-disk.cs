// HOW-TO: Compress Multiple Files into a ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"C:\Temp\input1.txt";
            string inputPath2 = @"C:\Temp\input2.txt";
            string outputPath = @"C:\Temp\output.zip";

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

            // Open the output ZIP file stream
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Create FileInfo objects for the input files
                FileInfo fi1 = new FileInfo(inputPath1);
                FileInfo fi2 = new FileInfo(inputPath2);

                // Create a new ZIP archive and add entries
                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("input1.txt", fi1);
                    archive.CreateEntry("input2.txt", fi2);

                    // Save the archive with ASCII encoding for entry names
                    archive.Save(zipFile, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
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
 * 1. When you need to bundle several log or configuration files into a single ZIP archive for easier distribution or backup in a .NET application.
 * 2. When an automated process must create a compressed ZIP of generated reports before uploading them to a remote server.
 * 3. When you want to package user‑uploaded documents into a ZIP file on the fly to reduce storage usage and simplify download.
 * 4. When a desktop utility must combine multiple data files into a portable ZIP archive that can be opened by standard extraction tools.
 * 5. When a scheduled job has to archive old CSV exports into a ZIP file with specific entry names for compliance auditing.
 */
