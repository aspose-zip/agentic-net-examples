// HOW-TO: Compress Large Binary File to Gzip Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\largefile.bin";
            string outputPath = @"C:\Output\largefile.gz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a Gzip archive, set the source file, and save the compressed file
            using (GzipArchive archive = new GzipArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of a huge binary log before transferring it over a network, you can compress it to a .gz file using Aspose.Zip in C#.
 * 2. When archiving backup data files on a server, you can create a Gzip archive in a specific folder to save storage space and keep the directory structure organized.
 * 3. When preparing large binary assets for distribution to clients, you can generate a compressed .gz package programmatically to speed up downloads.
 * 4. When integrating a .NET application with a legacy system that only accepts Gzip-compressed input, you can use this code to produce the required archive on the fly.
 * 5. When automating nightly batch jobs that process massive binary outputs, you can compress each result into a Gzip file and store it in a designated output directory for later retrieval.
 */
