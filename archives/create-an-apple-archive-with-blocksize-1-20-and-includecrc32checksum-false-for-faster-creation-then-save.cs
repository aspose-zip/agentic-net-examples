// HOW-TO: Create Bzip2 and Store ZIP Archives with Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputFile = "data/input.txt";
            if (!File.Exists(inputFile))
            {
                Console.Error.WriteLine($"File not found: {inputFile}");
                return;
            }

            string outputPathBzip2 = "output/compressed_bzip2.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathBzip2));

            using (FileStream zipStream = File.Open(outputPathBzip2, FileMode.Create))
            {
                ArchiveEntrySettings bzip2Settings = new ArchiveEntrySettings(new Bzip2CompressionSettings());
                using (Archive archive = new Archive(bzip2Settings))
                {
                    archive.CreateEntry("input.txt", inputFile);
                    archive.Save(zipStream);
                }
            }

            string outputPathStore = "output/compressed_store.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathStore));

            using (FileStream zipStoreStream = File.Open(outputPathStore, FileMode.Create))
            {
                ArchiveEntrySettings storeSettings = new ArchiveEntrySettings(new StoreCompressionSettings());
                using (Archive archive = new Archive(storeSettings))
                {
                    archive.CreateEntry("input.txt", inputFile);
                    archive.Save(zipStoreStream);
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
 * 1. When you need to package a text file into a ZIP using Bzip2 compression for maximum size reduction in a .NET application.
 * 2. When you want to generate a ZIP archive that stores files without compression to speed up creation and enable instant access.
 * 3. When you must produce both compressed and uncompressed ZIP files programmatically to satisfy different client or system requirements.
 * 4. When you are building an automated backup routine that saves files into ZIP archives with specific compression settings using Aspose.Zip.
 * 5. When you need to ensure output directories exist and handle missing input files gracefully while creating ZIP archives in a C# service.
 */
