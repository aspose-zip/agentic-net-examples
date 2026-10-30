// HOW-TO: Create In-Memory Zip Archive With Bzip2 Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = "C:\\Data\\file1.txt";
            string inputPath2 = "C:\\Data\\file2.txt";

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

            // Open source files
            using (FileStream source1 = File.Open(inputPath1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputPath2, FileMode.Open, FileAccess.Read))
            // Memory stream to hold the ZIP archive
            using (MemoryStream zipStream = new MemoryStream())
            // Create ZIP archive with custom Bzip2 compression for all entries
            using (Archive archive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
            {
                // Add files to the archive
                archive.CreateEntry("file1.txt", source1);
                archive.CreateEntry("file2.txt", source2);

                // Save the archive into the memory stream
                archive.Save(zipStream);

                // The archive is now stored in memory; display its size
                Console.WriteLine($"ZIP archive created in memory, size: {zipStream.Length} bytes.");
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
 * 1. When you need to bundle several text files into a compressed package for transmission over a network without writing a temporary file to disk.
 * 2. When you want to generate a ZIP file on the fly with Bzip2 compression to reduce size before sending it as an email attachment.
 * 3. When an application must create a downloadable archive in memory for a web API response, ensuring the archive is not persisted on the server.
 * 4. When you need to compress log files using a high‑ratio algorithm before storing them in a database as a binary BLOB.
 * 5. When a background service creates backup archives of configuration files and keeps them in memory for immediate upload to cloud storage.
 */
