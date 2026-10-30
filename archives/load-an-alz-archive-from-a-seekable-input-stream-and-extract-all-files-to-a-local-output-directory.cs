// HOW-TO: Extract All Files From an ALZ Archive Using a Seekable Stream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ALZ archive path
            string inputPath = "C:\\Data\\archive.alz";

            // Hardcoded output directory path
            string outputPath = "C:\\Data\\Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open a seekable stream for the ALZ archive
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Load the archive from the stream
                using (IArchive archive = ArchiveFactory.GetArchive(inputStream))
                {
                    // Extract all entries to the output directory
                    archive.ExtractToDirectory(outputPath);
                }
            }

            Console.WriteLine($"Extraction completed to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack a compressed ALZ backup received from a partner system onto a server.
 * 2. When an application must read an ALZ archive from a network stream and write its contents to a local folder for further processing.
 * 3. When you want to automate the extraction of multiple files from an ALZ package stored on disk as part of a nightly data pipeline.
 * 4. When a migration tool has to load an ALZ archive from a seekable file stream and place all extracted resources into a target directory.
 * 5. When you are building a C# utility that validates the integrity of an ALZ archive by extracting its entries to a temporary directory.
 */
