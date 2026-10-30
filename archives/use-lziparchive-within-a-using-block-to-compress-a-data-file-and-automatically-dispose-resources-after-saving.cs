// HOW-TO: Compress a File to LZIP Using Aspose Zip in C# (Aspose.ZIP for .NET)
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
            string outputPath = @"C:\Output\sample.lz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Compress the input file into LZIP format using a using block for automatic disposal
            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
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
 * 1. When you need to reduce the size of a log file before uploading it to a remote server, you can compress the file to LZIP format with automatic resource cleanup.
 * 2. When building a backup utility that stores daily snapshots as LZIP archives, the using block ensures the archive object is disposed after each save.
 * 3. When integrating file compression into a .NET service that processes large text files, this code lets you create LZIP archives without manually handling streams.
 * 4. When creating a command‑line tool that compresses user‑selected documents into LZIP for efficient storage, the pattern guarantees the archive is properly closed.
 * 5. When developing a data‑pipeline that archives intermediate CSV outputs, using LzipArchive in a using statement simplifies compression and prevents memory leaks.
 */
