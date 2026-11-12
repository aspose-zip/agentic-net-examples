// HOW-TO: Compress a TAR Archive to LZ4 Format in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define data directory and file names
            string dataDir = "Data";
            string inputFileName = "sample.txt";
            string inputPath = Path.Combine(dataDir, inputFileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output TAR.LZ4 file path
            string outputFileName = "archive.tar.lz4";
            string outputPath = Path.Combine(dataDir, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive, add entry, and save with LZ4 compression
            using (TarArchive archive = new TarArchive())
            {
                // Add the input file to the archive with the same entry name
                archive.CreateEntry(inputFileName, inputPath);
                // Save the archive compressed using LZ4
                archive.SaveLZ4Compressed(outputPath);
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
 * 1. When you need to reduce the size of a TAR backup before uploading it to cloud storage, you can use this code to create a .tar.lz4 file in C#.
 * 2. When deploying a Linux application package from a .NET service and want to send it over a low‑bandwidth network, you can compress the TAR archive with LZ4 using this snippet.
 * 3. When archiving log files on a Windows server for long‑term retention and want fast decompression later, this code lets you generate a LZ4‑compressed TAR file.
 * 4. When integrating with a CI/CD pipeline that expects TAR.LZ4 artifacts, you can programmatically create the compressed archive in C# as shown.
 * 5. When building a backup utility that stores multiple files in a single archive and needs high compression speed, this example demonstrates how to add files and save the archive with LZ4 compression.
 */
