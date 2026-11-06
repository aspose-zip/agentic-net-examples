// HOW-TO: Create LZMA Compressed ZIP from Multiple Files in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath1 = @"C:\Data\file1.txt";
            string inputPath2 = @"C:\Data\file2.txt";
            string outputPath = @"C:\Output\compressed.zip";

            // Validate input files
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the ZIP archive with LZMA compression for all entries
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            {
                FileInfo fileInfo1 = new FileInfo(inputPath1);
                FileInfo fileInfo2 = new FileInfo(inputPath2);

                using (Archive archive = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
                {
                    // Add entries using FileInfo objects
                    archive.CreateEntry(fileInfo1.Name, fileInfo1);
                    archive.CreateEntry(fileInfo2.Name, fileInfo2);

                    // Save the archive
                    archive.Save(zipStream);
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
 * 1. When you need to package several log files into a single LZMA‑compressed ZIP archive for efficient storage or transfer in a .NET application.
 * 2. When your application must generate a portable backup of configuration files while minimizing size using LZMA compression in C#.
 * 3. When you want to send multiple documents over a network and require a high‑ratio ZIP archive created from FileInfo objects without external tools.
 * 4. When automating deployment scripts that bundle compiled resources into a compressed ZIP to reduce download time for end users.
 * 5. When implementing a feature that archives user‑uploaded files on a server, applying LZMA compression to save disk space and maintain file metadata.
 */
