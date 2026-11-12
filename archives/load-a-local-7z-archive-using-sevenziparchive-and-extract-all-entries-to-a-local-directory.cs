// HOW-TO: Extract All Files From 7z Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input 7z archive path
            string inputPath = "sample.7z";
            // Hardcoded output placeholder file path (directory will be used for extraction)
            string outputPath = "ExtractedFiles\\placeholder.txt";

            // Verify the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string outputDirectory = Path.GetDirectoryName(outputPath);

            // Open the 7z archive
            using (SevenZipArchive archive = new SevenZipArchive(inputPath))
            {
                // Extract each entry to the output directory
                foreach (SevenZipArchiveEntry entry in archive.Entries)
                {
                    entry.Extract(outputDirectory);
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
 * 1. Use this code to unpack a downloaded 7z package of configuration files into a local folder during application installation.
 * 2. Use it in a CI/CD pipeline to automatically extract resources from a 7z archive before compiling or packaging the project.
 * 3. Use it in a desktop utility that lets users open a 7z backup and restore all its files to a chosen directory.
 * 4. Use it in a server‑side service that receives a 7z payload and needs to extract every entry to a temporary folder for further processing.
 * 5. Use it when migrating legacy data stored in 7z archives, programmatically extracting the contents to a new file system layout.
 */
