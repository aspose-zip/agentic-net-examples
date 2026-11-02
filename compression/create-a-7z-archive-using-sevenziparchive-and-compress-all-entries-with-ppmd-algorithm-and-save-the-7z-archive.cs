// HOW-TO: Create a 7z Archive with PPMd Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing files to archive
            string inputDir = @"C:\Data\MyFolder";
            // Hardcoded output 7z file path
            string outputPath = @"C:\Data\ArchivePPMd.7z";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 7z archive with PPMd compression for all entries
            using (SevenZipArchive archive = new SevenZipArchive(
                new SevenZipEntrySettings(new SevenZipPPMdCompressionSettings())))
            {
                // Add all files from the input directory
                archive.CreateEntries(inputDir);
                // Save the archive to the specified output path
                archive.Save(outputPath);
            }

            Console.WriteLine($"7z archive created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a folder of log files into a highly compressible 7z archive using the PPMd algorithm for efficient storage or transfer in a C# application.
 * 2. When you want to generate a backup of configuration files on Windows and ensure maximum compression with PPMd while creating a 7z archive programmatically with Aspose.Zip.
 * 3. When an automated build process must bundle generated reports into a single 7z file with PPMd compression to reduce disk usage before uploading to a server.
 * 4. When a desktop utility needs to compress user‑selected documents into a 7z archive using PPMd to achieve better compression ratios than standard LZMA.
 * 5. When you are implementing a data archiving service in .NET that creates 7z archives with PPMd compression for compliance‑required long‑term storage.
 */
