// HOW-TO: Extract Multi-Volume 7z Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input volume paths (ordered)
            string[] volumePaths = new string[]
            {
                "myarchive.7z.001",
                "myarchive.7z.002",
                "myarchive.7z.003"
            };

            // Verify each volume file exists
            foreach (string path in volumePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Output directory for extraction
            string outputPath = "output\\extracted_7z";

            // Ensure parent directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load multi-volume 7z archive using the volume-path constructor
            using (SevenZipArchive archive = new SevenZipArchive(volumePaths))
            {
                // Extract all entries to the output directory
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
 * 1. When you receive a large backup split into several .7z.001, .002, .003 files and need to programmatically combine and extract them in a .NET application.
 * 2. When an automated deployment script must unpack a multi-part 7z package containing installation files onto a server using C#.
 * 3. When a file‑sharing service stores archives as split 7z volumes and you need to reconstruct and extract the contents on the client side.
 * 4. When a data‑migration tool processes archived logs that are divided into multiple 7z segments and must extract them to a specific folder.
 * 5. When a backup restoration utility has to verify the existence of each volume before extracting the full archive to a target directory.
 */
