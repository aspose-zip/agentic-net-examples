// HOW-TO: Decompress BZIP2 File to MemoryStream and Save to Disk in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bz2";
            string outputPath = "output.dat";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Decompress BZIP2 stream into a MemoryStream
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (Stream decompressed = archive.Open())
                    {
                        decompressed.CopyTo(memoryStream);
                    }

                    // Write the recovered bytes to the output file
                    memoryStream.Position = 0;
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
 * 1. When you need to extract a .bz2 log archive received from a Linux server and write the raw data to a local file for further analysis.
 * 2. When an application must decompress a BZIP2‑compressed configuration file in memory before persisting it to a user‑specified location.
 * 3. When a background service processes incoming BZIP2 data streams, loads them into a MemoryStream for validation, and then saves the verified content to disk.
 * 4. When you are migrating legacy BZIP2 backups to a new system and require a .NET routine that reads the archive, decompresses it in memory, and writes the original files to a target folder.
 * 5. When a client uploads a BZIP2‑compressed payload to a web API and the server needs to decompress the payload using Aspose.Zip and store the resulting bytes as a file on the server.
 */
