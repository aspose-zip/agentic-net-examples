// HOW-TO: Compress a Text File to LZIP Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\sample.txt";
            string outputPath = @"C:\Data\sample.lz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open input file stream
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Create Lzip archive and compress the data
                using (LzipArchive archive = new LzipArchive())
                {
                    archive.SetSource(inputStream);
                    archive.Save(outputPath);
                }
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of log or configuration files before transferring them over a network, you can stream the file and create an LZIP archive with Aspose.Zip in C#.
 * 2. When backing up daily reports to a storage server, you can compress each report on the fly using FileStream and LzipArchive to save disk space.
 * 3. When integrating a .NET application with legacy systems that only accept LZIP‑compressed payloads, this code shows how to generate the required .lz file.
 * 4. When implementing a custom backup utility that must create compressed archives without loading the whole file into memory, you can use the streaming approach demonstrated here.
 * 5. When preparing large text datasets for archival compliance, you can programmatically compress them to LZIP format to meet size‑reduction and format‑specific standards.
 */
