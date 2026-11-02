// HOW-TO: Create CAB Archive from CSV Files with Stream Providers in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CSV file paths
            string csvPath1 = @"C:\Data\file1.csv";
            string csvPath2 = @"C:\Data\file2.csv";

            // Hardcoded output CAB file path
            string cabOutputPath = @"C:\Data\data.cab";

            // Validate input files
            if (!File.Exists(csvPath1))
            {
                Console.Error.WriteLine($"File not found: {csvPath1}");
                return;
            }
            if (!File.Exists(csvPath2))
            {
                Console.Error.WriteLine($"File not found: {csvPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(cabOutputPath));

            // Default compression settings for CAB entries
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add first CSV using a stream provider with default compression
                using (FileStream stream1 = new FileStream(csvPath1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("file1.csv", stream1);
                }

                // Add second CSV using stored (no compression) settings
                CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());
                using (FileStream stream2 = new FileStream(csvPath2, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("file2.csv", stream2, storedSettings);
                }

                // Save the CAB archive with CloseEntrySource set to true
                CabSaveOptions saveOptions = new CabSaveOptions();
                saveOptions.CloseEntrySource = true;
                archive.Save(cabOutputPath, saveOptions);
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
 * 1. When you need to package multiple CSV reports into a single CAB file for efficient distribution over a network.
 * 2. When you want to apply different compression methods—default MSZIP for one file and no compression for another—within the same CAB archive.
 * 3. When you must ensure that the source file streams are automatically closed after the archive is saved by setting CloseEntrySource to true.
 * 4. When you are automating backup of data tables and require a lightweight, Windows‑compatible CAB container generated from C# code.
 * 5. When you need to create a CAB archive from files located on disk using stream providers without loading the entire files into memory.
 */
