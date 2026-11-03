// HOW-TO: Extract RAR Archive to Directory While Preserving Empty Folders in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\input.rar";
            string outputDir = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (FileStream fs = File.OpenRead(inputPath))
            using (RarArchive archive = new RarArchive(fs))
            {
                archive.ExtractToDirectory(outputDir);
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
 * 1. When a deployment script must unpack a RAR package that only contains folder structures so that the original empty directories are recreated on the target server.
 * 2. When migrating legacy backup data stored in RAR files to a new system that expects the same directory hierarchy, including empty folders, using C# and Aspose.Zip.
 * 3. When building a file‑sync tool that reads RAR archives and extracts them to a local cache while keeping placeholder folders for future file placement.
 * 4. When creating an automated test harness that validates the integrity of archived project templates by extracting them and verifying that all empty directories are present.
 * 5. When developing a content management utility that needs to unpack user‑submitted RAR bundles into a staging area without losing any empty folder entries.
 */
