// HOW-TO: Extract All Files From Password Protected ZIP In C# With Aspose (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Path\\To\\ProtectedArchive.zip";
            string outputPath = "C:\\Path\\To\\ExtractedFiles";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Load the password‑protected ZIP archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "password123";

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to the target directory
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically unpack a secured ZIP sent by a client and place its contents into a specific folder on a Windows server.
 * 2. When an automated build process must retrieve configuration files from an encrypted archive before deploying an application.
 * 3. When a desktop application has to read user‑provided password‑protected backup archives and restore the files to a chosen location.
 * 4. When a scheduled service extracts daily reports stored in a protected ZIP to a network share for further processing.
 * 5. When a migration script pulls data from legacy encrypted ZIP packages and writes the extracted files to a new directory structure.
 */
