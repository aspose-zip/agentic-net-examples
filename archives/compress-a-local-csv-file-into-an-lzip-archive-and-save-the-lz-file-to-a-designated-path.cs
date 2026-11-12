// HOW-TO: Compress CSV File to LZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CSV file path
            string inputPath = @"C:\Data\sample.csv";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output LZIP archive path
            string outputPath = @"C:\Data\sample.lz";

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Create LZIP archive, add the CSV file, and save
            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine($"Successfully compressed '{inputPath}' to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of large CSV logs before uploading them to a remote server, you can compress them into an LZIP file with C#.
 * 2. When you want to create a portable backup of a CSV dataset that can be decompressed on Linux systems using LZIP utilities, this code generates the .lz archive.
 * 3. When integrating data export functionality into a .NET application, you may compress the generated CSV report into an LZIP archive to save bandwidth.
 * 4. When automating nightly archiving of CSV transaction files, the script ensures each file is stored as a compact LZIP archive in a designated folder.
 * 5. When complying with storage policies that require archived files to use LZIP compression, developers can use this code to convert CSV files to .lz format programmatically.
 */
