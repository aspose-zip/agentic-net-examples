// HOW-TO: Extract Single ALZ Archive Entry To File Using MemoryStream In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.alz";
        string outputPath = "output\\extracted.bin";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ALZ archive
            using (Archive archive = new Archive(inputPath))
            {
                // Assume the archive contains a single entry; get the first entry
                ArchiveEntry entry = archive.Entries[0];

                // Open the entry as a stream and copy its contents to a memory stream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (Stream entryStream = entry.Open())
                    {
                        entryStream.CopyTo(memoryStream);
                    }

                    // Reset position before writing to file
                    memoryStream.Position = 0;

                    // Save the memory stream to the output file
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
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
 * 1. When you need to programmatically read a compressed ALZ file and write its sole contained file to disk without loading the entire archive into memory.
 * 2. When you want to validate the contents of an ALZ archive in a .NET application by extracting the entry to a memory stream before further processing.
 * 3. When you are building a deployment tool that extracts a single configuration binary from an ALZ package and saves it to a specific folder.
 * 4. When you must ensure the output directory exists and handle missing input files gracefully while extracting data from an ALZ archive.
 * 5. When you are integrating Aspose.Zip into a C# service that streams archived data to a file for later analysis or backup.
 */
