// HOW-TO: Extract All Files from RAR Archive Preserving Folder Structure in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input RAR file path
            string inputPath = @"C:\Data\sample.rar";

            // Hardcoded output directory path
            string outputPath = @"C:\Data\Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the RAR archive for reading
            using (FileStream fileStream = File.OpenRead(inputPath))
            {
                using (RarArchive archive = new RarArchive(fileStream))
                {
                    // Extract all entries preserving the directory hierarchy
                    archive.ExtractToDirectory(outputPath);
                }
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
 * 1. When you need to unpack a downloaded RAR backup and keep the original folder hierarchy on a Windows server.
 * 2. When an application must programmatically extract user‑submitted RAR files to a specific directory for further processing.
 * 3. When migrating legacy data stored in RAR archives to a new system that requires the files to be available in their original subfolders.
 * 4. When automating a nightly job that extracts log files from compressed RAR packages while preserving their directory layout.
 * 5. When building a file‑management tool that lets users select a RAR archive and extracts its contents to a chosen location without losing folder structure.
 */
