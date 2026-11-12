// HOW-TO: Extract All Files From 7z Archive To Folder Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input 7z archive and output directory
            string inputPath = "sample.7z";
            string outputPath = "ExtractedFiles";

            // Verify the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the 7z archive and extract all entries to the output directory
            using (SevenZipArchive archive = new SevenZipArchive(inputPath))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a downloaded 7z package containing installation resources on a server.
 * 2. When automating the deployment of configuration files stored in a 7z archive to a specific directory.
 * 3. When processing user‑uploaded 7z archives and extracting their contents for further analysis.
 * 4. When migrating legacy backup data compressed in 7z format to a new file system.
 * 5. When creating a scheduled task that extracts log archives from 7z files into a readable folder structure.
 */
