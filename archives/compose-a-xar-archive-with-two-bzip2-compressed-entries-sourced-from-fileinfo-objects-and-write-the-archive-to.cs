// HOW-TO: Create XAR Archive With Bzip2 Compression From Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFile1 = "file1.txt";
            string inputFile2 = "file2.txt";
            string outputXar = "archive.xar";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputXar));

            // Create FileInfo objects for the entries
            FileInfo fi1 = new FileInfo(inputFile1);
            FileInfo fi2 = new FileInfo(inputFile2);

            // Bzip2 compression settings for XAR entries
            XarCompressionSettings bzip2Settings = new XarBzip2CompressionSettings();

            // Create XAR archive and add entries with Bzip2 compression
            using (XarArchive archive = new XarArchive())
            {
                archive.CreateEntry("entry1.txt", fi1, openImmediately: false, compressionSettings: bzip2Settings);
                archive.CreateEntry("entry2.txt", fi2, openImmediately: false, compressionSettings: bzip2Settings);
                archive.Save(outputXar);
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
 * 1. When you need to bundle multiple text files into a single XAR package with Bzip2 compression for efficient storage or distribution in a .NET application.
 * 2. When you want to generate a platform‑specific XAR archive on Windows that can be unpacked by macOS or iOS tools while preserving original file metadata.
 * 3. When automating backup scripts that require creating compressed XAR archives from existing FileInfo objects without loading the entire file into memory.
 * 4. When delivering software updates as a single compressed XAR file to reduce download size and simplify version management in C# projects.
 * 5. When integrating with legacy systems that only accept XAR archives with Bzip2 compression for secure transmission of configuration files.
 */
