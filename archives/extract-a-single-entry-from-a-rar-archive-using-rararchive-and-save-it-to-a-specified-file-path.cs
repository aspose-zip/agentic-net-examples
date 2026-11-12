// HOW-TO: Extract First File from RAR Archive to Specific Path in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input RAR archive and output file paths
            string inputPath = @"C:\Data\sample.rar";
            string outputPath = @"C:\Data\Extracted\file.txt";

            // Verify that the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the RAR archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                // Load the archive using Aspose.Zip.Rar
                using (RarArchive archive = new RarArchive(fs))
                {
                    // Extract the first entry (index 0) to the specified output file
                    archive.Entries[0].Extract(outputPath);
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
 * 1. When you need to programmatically pull a single document out of a RAR backup and place it in a known folder.
 * 2. When an application must read a specific log file stored inside a compressed RAR package without extracting the whole archive.
 * 3. When automating deployment scripts that retrieve a configuration file from a RAR bundle and write it to the target server.
 * 4. When processing user‑uploaded RAR archives and you only need to extract the first entry for preview or validation.
 * 5. When integrating with legacy systems that provide data in RAR format and you must extract a single entry to feed downstream processing.
 */
