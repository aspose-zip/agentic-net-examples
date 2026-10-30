// HOW-TO: Extract All Files From LZFSE Compressed Apple Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input Apple Archive (XAR) file created with LZFSE compression
            string inputPath = "lzfse_input.xar";

            // Output directory for extracted entries
            string outputDir = "lzfse_output";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the archive using Aspose.Zip's ArchiveFactory
            using (IArchive archive = ArchiveFactory.GetArchive(inputPath))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDir);
            }

            Console.WriteLine($"Extraction completed to: {outputDir}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unpack a macOS .xar installer that uses LZFSE compression to retrieve its payload files for analysis or redistribution.
 * 2. When automating a CI pipeline that extracts resources from an Apple Archive before building a cross‑platform application.
 * 3. When migrating legacy macOS package contents to a new system and you must programmatically extract all entries using C#.
 * 4. When creating a backup tool that reads LZFSE‑compressed XAR archives and saves their contents to a local directory.
 * 5. When developing a forensic utility that inspects the contents of Apple Archive files without manual extraction.
 */
