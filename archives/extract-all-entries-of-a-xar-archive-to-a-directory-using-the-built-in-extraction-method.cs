// HOW-TO: Extract All Files from a XAR Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input XAR archive and output directory paths
            string inputPath = "input.xar";
            string outputPath = "output\\extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Also ensure the final output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the XAR archive and extract all entries
            using (XarArchive archive = new XarArchive(inputPath))
            {
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
 * 1. When you need to unpack a XAR package received from a macOS installer to inspect its contents on a Windows server.
 * 2. When automating a deployment pipeline that extracts configuration files stored in a XAR archive before applying them.
 * 3. When building a backup restoration tool that reads XAR backups and restores the original directory structure.
 * 4. When creating a file‑conversion utility that first extracts assets from a XAR archive to process them further.
 * 5. When developing a cross‑platform application that must read XAR bundles and place their files into a user‑specified output folder.
 */
