// HOW-TO: Create Cab Archive Using Deferred Stream Providers in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFile1 = @"C:\Data\file1.txt";
            string inputFile2 = @"C:\Data\file2.html";
            string outputCabPath = @"C:\Output\archive.cab";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCabPath));

            // Default MSZIP compression settings
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            // Create the CAB archive with default settings
            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add first entry using a deferred stream provider
                archive.CreateEntry("file1.txt", () => new FileStream(inputFile1, FileMode.Open, FileAccess.Read));

                // Stored (no compression) settings for the second entry
                CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());

                // Add second entry using a deferred stream provider and stored settings
                archive.CreateEntry("file2.html", () => new FileStream(inputFile2, FileMode.Open, FileAccess.Read), storedSettings);

                // Save the archive; the archive will close the streams after reading
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
 * 1. When you need to package multiple files into a single .cab file for Windows installation without loading all file data into memory.
 * 2. When you want to add files to a CAB archive lazily, opening each file stream only when the archive writes it.
 * 3. When you must ensure that all file streams are automatically closed after the archive is saved to avoid file locks.
 * 4. When you require mixing compressed (MSZIP) and uncompressed (store) entries within the same CAB archive.
 * 5. When you are automating deployment scripts that generate CAB files on the fly from existing files on disk.
 */
