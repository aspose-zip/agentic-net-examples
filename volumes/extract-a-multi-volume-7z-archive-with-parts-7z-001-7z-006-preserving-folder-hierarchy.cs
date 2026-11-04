// HOW-TO: Extract Multi‑Volume 7z Archive with Folder Structure Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths for the first volume of the multi‑volume archive and the extraction folder
            string inputPath = @"C:\Archives\multi.7z.001";
            string outputPath = @"C:\Extracted";

            // Verify that the first volume exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the multi‑volume 7z archive; Aspose.Zip will automatically locate the remaining volumes
            using (SevenZipArchive archive = new SevenZipArchive(inputPath))
            {
                // Extract all entries while preserving the original folder hierarchy
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
 * 1. When you need to restore a large backup that was split into .7z.001‑.7z.006 parts while keeping the original directory layout.
 * 2. When a deployment script must unpack a multi‑volume 7z package containing application files into a target folder automatically.
 * 3. When processing archived log files that were compressed into several 7z volumes and you want to extract them preserving their sub‑folder organization.
 * 4. When distributing a software update as a split 7z archive and the installer needs to extract all parts in one step using C#.
 * 5. When migrating data from an archived multi‑volume 7z collection to a new server and you require a programmatic way to extract everything with its hierarchy intact.
 */
