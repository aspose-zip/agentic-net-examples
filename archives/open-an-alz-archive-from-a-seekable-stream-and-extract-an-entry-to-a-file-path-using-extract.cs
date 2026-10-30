// HOW-TO: Extract a Specific File from an ALZ Archive Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input ALZ archive path and output file path
        string inputPath = @"C:\Archives\sample.alz";
        string outputPath = @"C:\Extracted\sample.txt";

        try
        {
            // Verify input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ALZ archive from a seekable FileStream
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(inputStream))
            {
                // Locate the entry to extract (hardcoded entry name)
                string entryName = "sample.txt";
                var entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase));

                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry to the specified output path
                entry.Extract(outputPath);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically retrieve a single document from a large ALZ backup without loading the entire archive into memory.
 * 2. When a desktop application must read a user‑selected ALZ file from disk and save one contained text file to a known output folder.
 * 3. When an automated deployment script extracts a configuration file from an ALZ package stored on a network share.
 * 4. When a data‑migration tool processes archives streamed from a file system and extracts only the required entry for further processing.
 * 5. When you want to validate that a particular entry exists in an ALZ archive and extract it to a path for auditing or logging purposes.
 */
