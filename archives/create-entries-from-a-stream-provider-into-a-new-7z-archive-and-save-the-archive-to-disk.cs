// HOW-TO: Create 7z Archive From Directory Streams And Save To Disk In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing files to add
            string inputDirectory = @"C:\InputFiles";
            // Hardcoded output 7z archive path
            string outputArchivePath = @"C:\Output\archive.7z";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputArchivePath);
            Directory.CreateDirectory(outputDir);

            // Create a new 7z archive
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Get all files in the input directory
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    // Verify each file exists (redundant but follows rule)
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Open file stream for the current file
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        // Use the file name as the entry name inside the archive
                        string entryName = Path.GetFileName(filePath);
                        // Add entry to the archive from the stream
                        archive.CreateEntry(entryName, fileStream);
                    }
                }

                // Save the archive to disk
                archive.Save(outputArchivePath);
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
 * 1. When you need to bundle a set of log files into a compressed 7z package for backup or transfer.
 * 2. When you want to generate a 7z archive on the fly from files stored on a server without loading them entirely into memory.
 * 3. When an application must create a portable archive of user‑uploaded documents before sending it to a third‑party service.
 * 4. When you need to automate the creation of a compressed deployment package that can be extracted on any platform supporting 7z.
 * 5. When you are implementing a scheduled job that archives daily reports into a single 7z file for long‑term storage.
 */
