// HOW-TO: Extract All Files From a RAR Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input RAR archive path
            string inputPath = "C:\\Archives\\sample.rar";
            // Hardcoded output folder for extracted files
            string outputFolder = "C:\\Extracted\\Sample";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Open the RAR archive and extract all entries
            using (RarArchive archive = new RarArchive(inputPath))
            {
                // Extract preserving the original directory structure
                archive.ExtractToDirectory(outputFolder);
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
 * 1. When you need to programmatically unpack a downloaded RAR package of installation resources into a specific directory on a Windows server.
 * 2. When an application must automatically extract user‑submitted RAR backups to a designated folder for further processing.
 * 3. When a build pipeline has to decompress RAR‑compressed assets before copying them to the deployment folder.
 * 4. When a desktop utility needs to read a local RAR file and preserve its original folder hierarchy while extracting its contents.
 * 5. When a data‑migration script must read archived RAR logs and extract them to a target directory for analysis.
 */
