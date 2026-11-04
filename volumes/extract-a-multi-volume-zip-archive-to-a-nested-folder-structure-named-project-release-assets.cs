// HOW-TO: Extract Multi‑Volume ZIP to Project Release Assets Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = @"C:\Data";
            string mainSegment = Path.Combine(dataDir, "archive.zip");
            string outputDir = Path.Combine(dataDir, "Project", "Release", "Assets");

            // Validate main segment existence
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Prepare list of additional segments (e.g., .z01, .z02, ...)
            string[] segments = Directory.GetFiles(dataDir, "archive.*")
                .OrderBy(f => f)
                .Where(f => !f.EndsWith("archive.zip"))
                .ToArray();

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Open multivolume archive
            using (Archive archive = new Archive(mainSegment, segments))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string outPath = Path.Combine(outputDir, entry.Name);
                    // Ensure directory for the entry exists
                    string entryDir = Path.GetDirectoryName(outPath);
                    if (!string.IsNullOrEmpty(entryDir))
                    {
                        Directory.CreateDirectory(entryDir);
                    }

                    using (FileStream output = new FileStream(outPath, FileMode.Create))
                    {
                        entry.Extract(output);
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
 * 1. When you receive a large split ZIP archive from a vendor and need to programmatically combine and extract its contents into a structured Project/Release/Assets directory for automated build pipelines.
 * 2. When a deployment script must unpack a multi‑part archive containing application resources into a specific folder hierarchy before copying files to a production server.
 * 3. When a backup system stores data in segmented ZIP files and you need to restore the files into the original nested folder layout using C#.
 * 4. When an integration test requires extracting test assets from a split archive into a known Project/Release/Assets path to ensure consistent test environments.
 * 5. When a content management tool needs to read a multi‑volume ZIP package and place its files into a predefined assets folder hierarchy for further processing.
 */
