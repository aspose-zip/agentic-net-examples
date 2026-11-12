// HOW-TO: Load Multi‑Volume 7z Archive From Three Files And Extract In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths to the three 7z volumes
            string volumePath1 = @"C:\Archives\sample.7z.001";
            string volumePath2 = @"C:\Archives\sample.7z.002";
            string volumePath3 = @"C:\Archives\sample.7z.003";

            // Verify each volume exists
            if (!File.Exists(volumePath1))
            {
                Console.Error.WriteLine($"File not found: {volumePath1}");
                return;
            }
            if (!File.Exists(volumePath2))
            {
                Console.Error.WriteLine($"File not found: {volumePath2}");
                return;
            }
            if (!File.Exists(volumePath3))
            {
                Console.Error.WriteLine($"File not found: {volumePath3}");
                return;
            }

            // Output directory for extraction
            string outputPath = @"C:\Archives\extracted_7z";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑volume 7z archive using the volume‑path constructor
            string[] volumePaths = new string[] { volumePath1, volumePath2, volumePath3 };
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
 * 1. When you receive a split 7z backup divided into .001, .002, and .003 files and need to programmatically combine and extract its contents in a .NET application.
 * 2. When automating deployment scripts that must unpack large multi‑volume archives stored on a file server without manually joining them first.
 * 3. When building a data‑processing pipeline that ingests archived logs delivered as three‑part 7z volumes and extracts them to a working directory.
 * 4. When creating a desktop utility that validates the presence of all required 7z parts before extraction to avoid corrupted output.
 * 5. When integrating Aspose.Zip into a C# service that extracts user‑uploaded multi‑volume archives to a specific folder for further processing.
 */
