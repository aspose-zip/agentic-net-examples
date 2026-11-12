// HOW-TO: Extract Multi‑Volume 7z Archive with Three Parts in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths for the three 7z volume files
            string part1 = "archive.7z.001";
            string part2 = "archive.7z.002";
            string part3 = "archive.7z.003";

            string[] volumePaths = new string[] { part1, part2, part3 };

            // Verify that each volume file exists
            foreach (string path in volumePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Destination directory for extracted files
            string outputPath = "output\\extracted_7z";

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Ensure the output directory itself exists
            Directory.CreateDirectory(outputPath);

            // Load the multi‑volume 7z archive using the volume‑path constructor
            using (SevenZipArchive archive = new SevenZipArchive(volumePaths))
            {
                // Extract all entries to the specified directory
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
 * 1. When a C# application must reconstruct and extract a large backup that was split into three 7z volume files.
 * 2. When you need to verify the existence of each 7z part before extraction to avoid runtime errors.
 * 3. When automating deployment scripts that unpack a multi‑volume 7z package into a specific output folder.
 * 4. When processing archived log files that were compressed into sequential .001, .002, .003 volumes and need to be read after extraction.
 * 5. When building a data migration tool that extracts data from a split 7z archive directly to a target directory without manual concatenation.
 */
