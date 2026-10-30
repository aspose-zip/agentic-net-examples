// HOW-TO: Create Apple Archive Without CRC32 Using Store Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output/store_no_crc.aar";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            StoreCompressionSettings storeSettings = new StoreCompressionSettings();
            ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(storeSettings);

            using (Archive archive = new Archive(entrySettings))
            {
                archive.CreateEntry("file.txt", inputPath);
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    archive.Save(outputStream);
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
 * 1. When you need to bundle a single file into an Apple .aar archive without compression for fast packaging in a C# application.
 * 2. When you must generate an Apple Archive that omits the CRC32 checksum to reduce metadata size for embedded resources.
 * 3. When creating a test .aar file with store (no) compression to verify extraction logic in a .NET CI pipeline.
 * 4. When delivering uncompressed assets to iOS devices where the original file integrity is managed elsewhere, using Aspose.Zip in C#.
 * 5. When automating the creation of lightweight Apple archives for configuration files that must remain unchanged during deployment.
 */
