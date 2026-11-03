// HOW-TO: Compress a File to Bzip2 Using Aspose.Zip with FileMode Create in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "data/input.txt";
            string outputPath = "data/output.bz2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create output stream with FileMode.Create
            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            // Initialize Bzip2 archive and compress the input file
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputStream);
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
 * 1. When you need to compress a large text log into a .bz2 file to save disk space before archiving it on a server.
 * 2. When you want to create a Bzip2‑compressed backup of a configuration file in a .NET application using Aspose.Zip.
 * 3. When you must guarantee that the compressed output file is always overwritten or newly created by using FileMode.Create in automated tasks.
 * 4. When you are building a data‑processing pipeline that stores intermediate results as Bzip2 archives for efficient storage and transfer.
 * 5. When you require a straightforward C# method to compress a single file without packaging it into a full ZIP container.
 */
