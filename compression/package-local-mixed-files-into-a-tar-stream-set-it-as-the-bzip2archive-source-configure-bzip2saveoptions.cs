// HOW-TO: Create Parallel Bzip2 Compressed TAR Archive from Multiple Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output file paths
            string inputDir = @"C:\Data\Input";
            string outputPath = @"C:\Data\Output\parallel.tar.bz2";
            int threadCount = 4; // Positive thread count for parallel compression

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Files to be added to the TAR archive
            string[] files = new string[]
            {
                Path.Combine(inputDir, "file1.txt"),
                Path.Combine(inputDir, "image.png"),
                Path.Combine(inputDir, "data.bin")
            };

            // Verify each input file exists
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Create TAR archive and add entries
            using (TarArchive tarArchive = new TarArchive())
            {
                foreach (string filePath in files)
                {
                    string entryName = Path.GetFileName(filePath);
                    tarArchive.CreateEntry(entryName, filePath);
                }

                // Create Bzip2 archive, set TAR as its source, and configure parallel compression
                using (Bzip2Archive bz2Archive = new Bzip2Archive())
                {
                    bz2Archive.SetSource(tarArchive);

                    Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                    saveOptions.CompressionThreads = threadCount;

                    // Save the compressed TAR.BZ2 file
                    bz2Archive.Save(outputPath, saveOptions);
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
 * 1. When you need to bundle text, images, and binary data into a single TAR file before compressing it with Bzip2 for efficient storage or transfer.
 * 2. When you want to speed up Bzip2 compression by using multiple CPU threads while creating a .tar.bz2 archive in a .NET application.
 * 3. When you must ensure all required files exist and are packaged into a portable TAR archive that can be extracted on Unix-like systems.
 * 4. When you are automating backup of a specific folder and need a compressed TAR.BZ2 file that can be generated programmatically in C#.
 * 5. When you require a .NET solution to create a Bzip2‑compressed TAR stream for sending mixed file types over a network or saving to cloud storage.
 */
