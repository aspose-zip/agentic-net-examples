// HOW-TO: Compress Multiple Text Files to Individual BZ2 Archives in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "InputTexts";
            string outputDir = "CompressedBz2";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Verify the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Get all .txt files in the input directory
            string[] files = Directory.GetFiles(inputDir, "*.txt");
            foreach (string inputPath in files)
            {
                // Validate the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output file path with .bz2 extension
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".bz2");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Compress the file using Bzip2Archive
                using (Bzip2Archive archive = new Bzip2Archive())
                {
                    archive.SetSource(inputPath);
                    archive.Save(outputPath);
                }

                Console.WriteLine($"Compressed {inputPath} to {outputPath}");
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
 * 1. When you need to batch‑compress a collection of log or report .txt files into separate .bz2 archives for efficient storage or transmission.
 * 2. When a data‑processing pipeline must generate individual BZIP2 files for each document before uploading them to a cloud bucket.
 * 3. When you want to create lightweight, per‑file backups of configuration files using Aspose.Zip’s Bzip2Archive in a C# application.
 * 4. When an automated script has to prepare separate compressed packages of user‑generated text content for archival compliance.
 * 5. When a desktop utility must compress each exported text report into its own .bz2 file to reduce disk usage while preserving file‑by‑file access.
 */
