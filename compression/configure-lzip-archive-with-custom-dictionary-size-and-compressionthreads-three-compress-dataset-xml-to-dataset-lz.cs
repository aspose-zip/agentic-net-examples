// HOW-TO: Compress XML File to LZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\dataset.xml";
            string outputPath = @"C:\Data\dataset.lz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Lzip archive and compress the file
            using (LzipArchive archive = new LzipArchive())
            {
                // Set the source file to be compressed
                archive.SetSource(inputPath);

                // Save the compressed archive
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of large XML configuration files for faster network transfer, you can compress them into an LZIP archive with Aspose.Zip in C#.
 * 2. When archiving daily data exports from a .NET application, you can create .lz files to store the XML payloads efficiently on disk.
 * 3. When integrating with a Linux‑based system that only accepts LZIP‑compressed inputs, you can generate the required .lz files directly from C# code.
 * 4. When implementing backup routines that require a specific compression format, you can use Aspose.Zip to compress XML logs into LZIP archives before uploading to cloud storage.
 * 5. When building a data pipeline that stages XML datasets for later processing, you can compress each dataset into a .lz file to minimize storage costs and I/O overhead.
 */
