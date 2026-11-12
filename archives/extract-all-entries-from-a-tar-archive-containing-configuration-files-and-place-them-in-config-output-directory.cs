// HOW-TO: Extract All Files from a TAR Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths for the input TAR archive and the output directory
            string inputPath = "config_archive.tar";
            string outputPath = "config_output";

            // Verify that the input TAR file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = outputPath;
            }
            Directory.CreateDirectory(outputDir);

            // Open the TAR archive for reading
            using (FileStream fileStream = File.OpenRead(inputPath))
            {
                // Load the archive
                using (TarArchive archive = new TarArchive(fileStream))
                {
                    // Extract each entry to the output directory
                    foreach (TarEntry entry in archive.Entries)
                    {
                        entry.Extract(outputDir);
                    }
                }
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
 * 1. When you need to unpack a deployment package containing multiple configuration files stored in a TAR archive onto a server’s config directory using C#.
 * 2. When automating the setup of a development environment that distributes settings as a TAR file and you must extract them programmatically.
 * 3. When building a backup restoration tool that reads a TAR backup of application configs and restores them to a specified folder in a .NET application.
 * 4. When creating a CI/CD pipeline step that pulls configuration TAR archives from artifacts and extracts them to the build workspace with Aspose.Zip for .NET.
 * 5. When writing a utility to migrate legacy system settings packaged in TAR format to a new location without manual unpacking.
 */
