// HOW-TO: Create Uncompressed CAB Archive With Specific Entry Settings In C# (Aspose.ZIP for .NET)
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
            string inputFilePath1 = "sample1.txt";
            string inputFilePath2 = "sample2.txt";
            string outputCabPath = "output/archive.cab";

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
            string outputDirectory = Path.GetDirectoryName(outputCabPath);
            if (!string.IsNullOrEmpty(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Default compression settings (MS-ZIP) for the archive
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            // Settings to store entries without compression
            CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());

            // Create the CAB archive and add entries with uncompressed storage
            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                archive.CreateEntry("sample1.txt", inputFilePath1, storedSettings);
                archive.CreateEntry("sample2.txt", inputFilePath2, storedSettings);
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
 * 1. When you need to package multiple files into a CAB file without compression for faster extraction on Windows installers.
 * 2. When you must preserve original file sizes in a CAB archive for compatibility with legacy systems that expect stored (uncompressed) entries.
 * 3. When creating a deployment package where the installer requires uncompressed files to be read directly from the CAB.
 * 4. When generating a CAB archive programmatically in C# and you want to control compression per entry, storing some files uncompressed.
 * 5. When building a backup solution that stores files in a CAB container but avoids compression to reduce CPU usage during archive creation.
 */
