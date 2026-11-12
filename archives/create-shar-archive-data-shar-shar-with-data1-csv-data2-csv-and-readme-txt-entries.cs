// HOW-TO: Create SHAR Archive with Multiple Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"data1.csv";
            string inputPath2 = @"data2.csv";
            string inputPath3 = @"readme.txt";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Hardcoded output SHAR archive path
            string outputPath = @"data_shar.shar";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new archive and add entries
            using (Archive archive = new Archive())
            {
                // Add first file
                archive.CreateEntry(inputPath1, Path.GetFileName(inputPath1));

                // Add second file
                archive.CreateEntry(inputPath2, Path.GetFileName(inputPath2));

                // Add third file
                archive.CreateEntry(inputPath3, Path.GetFileName(inputPath3));

                // Save the archive with .shar extension
                archive.Save(outputPath);
            }

            Console.WriteLine($"SHAR archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several CSV reports and a README into a single SHAR file for easy distribution to Linux users.
 * 2. When automating backup of configuration files in a .shar archive as part of a C# deployment script.
 * 3. When creating a portable package of data files that can be unpacked with the shar command on Unix systems.
 * 4. When generating a simple archive without compression to preserve original file timestamps for audit logs.
 * 5. When integrating Aspose.Zip into a .NET application to programmatically create SHAR archives for cross‑platform data exchange.
 */
