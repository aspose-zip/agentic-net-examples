// HOW-TO: Create Gzipped TAR Archive From Folder Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory and output archive paths
            string inputDirectory = @"C:\Data\SourceFolder";
            string outputArchivePath = @"C:\Data\output.tar.gz";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Create a new TAR archive and add all files from the input directory
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntries(inputDirectory);
                archive.SaveGzipped(outputArchivePath);
            }

            Console.WriteLine($"Archive created successfully at: {outputArchivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a directory of log files into a single .tar.gz archive for efficient storage or transfer in a C# application.
 * 2. When automating nightly backups of configuration files and want to create a compressed TAR archive using Aspose.Zip without external tools.
 * 3. When deploying a set of resources to a Linux server from a .NET service and must generate a gzip‑compressed TAR file on the fly.
 * 4. When integrating with a third‑party system that only accepts .tar.gz packages, you can create the archive directly in memory with C#.
 * 5. When you want to compress large data sets before uploading them to cloud storage, using Aspose.Zip to produce a .tar.gz file programmatically.
 */
