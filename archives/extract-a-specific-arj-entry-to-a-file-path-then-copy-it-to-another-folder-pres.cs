// HOW-TO: Extract Specific ARJ Entry to File and Copy to Another Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputArchivePath = @"C:\Archives\sample.arj";
        string entryNameToExtract = "document.txt";
        string extractedFilePath = @"C:\Extracted\document.txt";
        string copyDestinationPath = @"C:\CopyFolder\document_copy.txt";

        try
        {
            // Verify input archive exists
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(extractedFilePath));
            Directory.CreateDirectory(Path.GetDirectoryName(copyDestinationPath));

            // Open ARJ archive and extract the specified entry
            using (ArjArchive archive = new ArjArchive(inputArchivePath))
            {
                var entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryNameToExtract, StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found in archive: {entryNameToExtract}");
                    return;
                }

                entry.Extract(extractedFilePath);
            }

            // Copy the extracted file to another folder
            File.Copy(extractedFilePath, copyDestinationPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to retrieve a single document from an ARJ archive and place it in a specific directory for further processing.
 * 2. When an application must extract a configuration file from a compressed ARJ package and then duplicate it to a deployment folder.
 * 3. When automating a data pipeline that pulls a log file out of an ARJ backup and copies it to a staging area for analysis.
 * 4. When a user wants to programmatically extract a report stored in an ARJ archive and create a backup copy in another location.
 * 5. When integrating legacy ARJ archives into a modern C# system that requires extracting a file and moving it to a shared network folder.
 */
