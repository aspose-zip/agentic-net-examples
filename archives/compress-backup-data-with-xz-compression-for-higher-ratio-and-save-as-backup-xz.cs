// HOW-TO: Compress a File to XZ Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\backup.dat";
            string outputPath = @"C:\Output\backup.xz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create XZ archive and compress the input file
            using (XzArchive archive = new XzArchive())
            {
                // Set the source file to be compressed
                archive.SetSource(inputPath);

                // Save the compressed XZ archive to the output file
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    archive.Save(outStream);
                }
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a high‑ratio XZ backup of a large data file in a .NET application.
 * 2. When you want to automate daily backups of logs or databases and store them as .xz archives for efficient storage.
 * 3. When you must ensure the output directory exists before saving a compressed XZ file from a C# service.
 * 4. When you need to verify the source file exists and handle missing‑file errors while compressing with Aspose.Zip.
 * 5. When you are building a utility that compresses files to XZ format for later extraction on Linux or other platforms.
 */
