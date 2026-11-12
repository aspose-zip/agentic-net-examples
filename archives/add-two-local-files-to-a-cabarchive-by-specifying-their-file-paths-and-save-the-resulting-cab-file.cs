// HOW-TO: Create CAB Archive from Two Files with Mixed Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputFilePath1 = "C:\\Temp\\file1.txt";
            string inputFilePath2 = "C:\\Temp\\file2.html";

            // Hardcoded output CAB file path
            string outputCabPath = "C:\\Temp\\output.cab";

            // Validate input files
            if (!File.Exists(inputFilePath1))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath1}");
                return;
            }
            if (!File.Exists(inputFilePath2))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath2}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCabPath));

            // Default compression (MSZIP) for the archive
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add first file with default compression
                archive.CreateEntry("file1.txt", inputFilePath1);

                // Add second file with no compression (store)
                CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());
                archive.CreateEntry("file2.html", inputFilePath2, storedSettings);

                // Save the CAB archive
                archive.Save(outputCabPath);
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
 * 1. When you need to package configuration and documentation files into a single CAB for Windows deployment using C#.
 * 2. When you want to distribute a small text file and an HTML help page together, applying compression to the text but storing the HTML unchanged.
 * 3. When automating build scripts that generate CAB installers and must include files from specific file system paths.
 * 4. When creating backup archives for legacy Windows systems that require CAB format with both MSZIP and stored entries.
 * 5. When integrating CAB creation into a .NET application to bundle resources before sending them to a client or service.
 */
