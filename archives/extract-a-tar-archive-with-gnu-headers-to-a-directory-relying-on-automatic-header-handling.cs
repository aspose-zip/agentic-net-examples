// HOW-TO: Extract TAR Archive With GNU Headers To Directory Using Aspose.Zip C# (Aspose.ZIP for .NET)
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
            // Hardcoded input TAR archive path
            string inputPath = "sample.tar";

            // Hardcoded output directory path
            string outputPath = "ExtractedFiles";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? outputPath);
            // Ensure the output directory itself exists
            Directory.CreateDirectory(outputPath);

            // Open the TAR archive and extract its contents
            using (TarArchive archive = new TarArchive(inputPath))
            {
                // Aspose.Zip automatically handles GNU headers
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a Linux‑generated TAR file that contains GNU long‑filename headers in a Windows .NET application.
 * 2. When you want to programmatically extract backup archives created by GNU tar into a specific folder without manually parsing header types.
 * 3. When deploying software packages distributed as TAR archives with extended attributes and you need an automated extraction step in a C# build script.
 * 4. When processing uploaded TAR files from users in a web API and you must safely extract their contents to a server directory.
 * 5. When migrating data from a Unix system to a .NET service and you require a reliable way to handle GNU header variations during extraction.
 */
