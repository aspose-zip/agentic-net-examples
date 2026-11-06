// HOW-TO: Extract Multi‑Volume 7z Archive to Specific Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input multi‑volume 7z parts (hard‑coded)
            string part1 = "ArchiveSetA.7z.001";
            string part2 = "ArchiveSetA.7z.002";
            string part3 = "ArchiveSetA.7z.003";

            // Validate each part exists
            if (!File.Exists(part1))
            {
                Console.Error.WriteLine($"File not found: {part1}");
                return;
            }
            if (!File.Exists(part2))
            {
                Console.Error.WriteLine($"File not found: {part2}");
                return;
            }
            if (!File.Exists(part3))
            {
                Console.Error.WriteLine($"File not found: {part3}");
                return;
            }

            string[] parts = new string[] { part1, part2, part3 };

            // Output directory
            string outputDir = "Output_7z_VolumeSetA";

            // Ensure output directory exists
            string parentDir = Path.GetDirectoryName(outputDir);
            Directory.CreateDirectory(parentDir ?? outputDir);

            // Open the multi‑volume archive and extract
            using (SevenZipArchive archive = new SevenZipArchive(parts))
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
 * 1. When you receive a large 7z backup split into several .001, .002, and .003 files and need to combine and extract them programmatically in a .NET application.
 * 2. When an automated deployment script must unpack a multi‑volume 7z package into a designated output directory on a Windows server.
 * 3. When a file‑archiving service stores data in segmented 7z volumes and you need to reconstruct the original files for further processing in C#.
 * 4. When you want to validate the presence of each archive part before extraction to avoid runtime errors in a production environment.
 * 5. When integrating Aspose.Zip into a desktop utility that organizes extracted content into a specific folder structure for end‑users.
 */
