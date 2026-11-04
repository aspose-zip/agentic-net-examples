// HOW-TO: Extract Multi-Volume ZIP to Hidden Folder and Verify Files in C# (Aspose.ZIP for .NET)
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
            string outputDir = Path.Combine(dataDir, "HiddenOutput");

            // Validate input archive
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Gather multivolume segment files (e.g., archive.z01, archive.z02, ...)
            string[] segmentFiles = Directory.GetFiles(dataDir, "archive.z*")
                .OrderBy(f => f)
                .Where(f => !f.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            // Ensure output directory exists and set it as hidden
            Directory.CreateDirectory(outputDir);
            DirectoryInfo outputInfo = new DirectoryInfo(outputDir);
            outputInfo.Attributes |= FileAttributes.Hidden;

            // Open the multivolume archive
            using (Archive archive = new Archive(mainSegment, segmentFiles))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Determine full output path for the entry
                    string entryPath = Path.Combine(outputDir, entry.Name);
                    string entryDir = Path.GetDirectoryName(entryPath);
                    if (!string.IsNullOrEmpty(entryDir))
                    {
                        Directory.CreateDirectory(entryDir);
                    }

                    // Extract entry to the destination file
                    using (FileStream output = new FileStream(entryPath, FileMode.Create))
                    {
                        entry.Extract(output);
                    }
                }
            }

            // Confirm extraction by listing extracted files
            Console.WriteLine("Extraction completed. Files created:");
            foreach (string file in Directory.GetFiles(outputDir, "*", SearchOption.AllDirectories))
            {
                Console.WriteLine(file);
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
 * 1. When you need to unpack a split ZIP archive received via email into a concealed directory to keep extracted data out of casual view.
 * 2. When an application must automatically combine and extract multi-part backup archives while ensuring the output folder remains hidden for security compliance.
 * 3. When a deployment script extracts large, segmented ZIP packages to a hidden location before moving them to their final destination.
 * 4. When a data-processing pipeline validates that all files from a multi-volume archive are correctly written to a hidden staging folder.
 * 5. When you want to programmatically extract confidential documents from a split ZIP archive without exposing the extracted files in the file explorer.
 */
