// HOW-TO: Extract Split Zip Archive With Separate Volume Paths In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded paths
            string dataDir = @"C:\Data\Multivolume";
            string outputDir = @"C:\Output\Extracted";

            // Main .zip file (final segment)
            string mainZipPath = Path.Combine(dataDir, "archive.zip");

            // Preceding volume files (.z01, .z02, etc.)
            string[] volumeFiles = new string[]
            {
                Path.Combine(dataDir, "archive.z01"),
                Path.Combine(dataDir, "archive.z02")
            };

            // Verify that the main segment exists
            if (!File.Exists(mainZipPath))
            {
                Console.Error.WriteLine($"File not found: {mainZipPath}");
                return;
            }

            // Verify that each preceding volume exists
            foreach (string volPath in volumeFiles)
            {
                if (!File.Exists(volPath))
                {
                    Console.Error.WriteLine($"File not found: {volPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the multivolume ZIP archive
            using (Archive archive = new Archive(mainZipPath, volumeFiles))
            {
                // Iterate through all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Determine the full output path for the entry
                    string outPath = Path.Combine(outputDir, entry.Name);

                    // Create any necessary subdirectories for the entry
                    string outDir = Path.GetDirectoryName(outPath);
                    if (!string.IsNullOrEmpty(outDir))
                    {
                        Directory.CreateDirectory(outDir);
                    }

                    // Extract the entry to the output file
                    using (FileStream output = new FileStream(outPath, FileMode.Create, FileAccess.Write))
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
 * 1. When you receive a large backup that was divided into .z01, .z02, and .zip parts and need to programmatically combine and extract the full archive using C#.
 * 2. When automating the processing of multi‑volume zip files downloaded from a server where each segment is stored in a different folder.
 * 3. When building a deployment tool that must unpack split zip packages delivered on limited‑size media such as DVDs or USB sticks.
 * 4. When creating a data migration script that extracts archived project files that were split to fit on removable drives.
 * 5. When developing a file‑recovery utility that restores the original contents of a split zip created by a compression utility.
 */
