// HOW-TO: Create CAB Archive With Uncompressed Files Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputFilePath1 = @"C:\Temp\file1.txt";
            string inputFilePath2 = @"C:\Temp\file2.txt";

            // Hardcoded output CAB file path
            string cabOutputPath = @"C:\Temp\output.cab";

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(cabOutputPath));

            // Default settings (compression) for the archive
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            // Settings to store entries without compression
            CabEntrySettings storeSettings = new CabEntrySettings(new CabStoreCompressionSettings());

            // Create CAB archive and add entries
            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                archive.CreateEntry("file1.txt", inputFilePath1, storeSettings);
                archive.CreateEntry("file2.txt", inputFilePath2, storeSettings);
                archive.Save(cabOutputPath);
            }

            Console.WriteLine($"CAB archive created at: {cabOutputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle installation files into a CAB package without increasing their size, such as preserving pre‑compressed drivers for Windows setup.
 * 2. When you must create a CAB archive for legacy Windows deployment tools that require entries stored with the “store” method rather than compressed.
 * 3. When you want to generate a CAB file containing configuration or log files that must remain unchanged for checksum verification.
 * 4. When you are building a software installer that includes already compressed resources (e.g., .zip or .iso) and you want to avoid double‑compression overhead.
 * 5. When you need to programmatically create a CAB archive in a .NET application and control compression per entry, using Aspose.Zip’s CabStoreCompressionSettings.
 */
