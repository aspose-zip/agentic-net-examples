// HOW-TO: Extract All Files From a TAR Archive to a Directory in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input TAR file path
            string inputPath = @"C:\Archives\sample.tar";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory path
            string outputDirectory = @"C:\ExtractedFiles";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the TAR archive and extract all entries
            using (TarArchive archive = new TarArchive(inputPath))
            {
                archive.ExtractToDirectory(outputDirectory);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unpack a TAR backup received from a Linux server into a Windows folder using C#.
 * 2. When an automated deployment script must extract bundled resources from a TAR package before copying them to the application’s runtime directory.
 * 3. When a data‑processing pipeline receives TAR files containing CSV datasets and you must programmatically extract them to a local directory for analysis.
 * 4. When you want to validate that a TAR archive uploaded by a user can be safely extracted to a specific folder in a .NET application.
 * 5. When a scheduled service has to decompress nightly TAR logs into a designated folder for archiving or further processing.
 */
