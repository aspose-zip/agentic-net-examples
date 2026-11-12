// HOW-TO: Add Multiple Files to Existing 7z Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputArchivePath = "input.7z";
            string dataDirectory = "Data";
            string outputArchivePath = "output.7z";

            // Validate input archive
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Validate source directory
            if (!Directory.Exists(dataDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {dataDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Open existing 7z archive, add files, and save updated archive
            using (SevenZipArchive archive = new SevenZipArchive(inputArchivePath))
            {
                // Add all files from the specified directory
                archive.CreateEntries(dataDirectory);

                // Save the updated archive to the output path
                archive.Save(outputArchivePath);
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
 * 1. When you need to programmatically add new documents to an existing 7z backup without recreating the archive from scratch.
 * 2. When a C# application must merge a folder of generated reports into a previously created 7z package for distribution.
 * 3. When automating deployment pipelines that require updating a compressed archive with additional configuration files using Aspose.Zip.
 * 4. When preserving the original archive’s compression settings while appending log files or assets in a .NET service.
 * 5. When building a desktop utility that lets users select a directory and seamlessly update an existing 7z archive with those files.
 */
