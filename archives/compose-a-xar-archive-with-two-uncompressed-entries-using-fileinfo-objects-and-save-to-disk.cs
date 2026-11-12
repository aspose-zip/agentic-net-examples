// HOW-TO: Create XAR Archive With Uncompressed Files Using FileInfo in C# (Aspose.ZIP for .NET)
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
            string inputPath1 = @"C:\Data\file1.txt";
            string inputPath2 = @"C:\Data\file2.html";
            string outputPath = @"C:\Output\archive.xar";

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

            // Create FileInfo objects for the inputs
            FileInfo fileInfo1 = new FileInfo(inputPath1);
            FileInfo fileInfo2 = new FileInfo(inputPath2);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Compression settings for storing entries without compression
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            // Create the XAR archive and add entries
            using (XarArchive archive = new XarArchive(storeCompression))
            {
                archive.CreateEntry("file1.txt", fileInfo1.FullName, openImmediately: false, compressionSettings: storeCompression);
                archive.CreateEntry("file2.html", fileInfo2.FullName, openImmediately: false, compressionSettings: storeCompression);
                archive.Save(outputPath);
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
 * 1. When you need to bundle multiple files into a XAR package without compression for fast extraction on macOS systems.
 * 2. When you want to generate a XAR archive from existing files on disk using FileInfo objects in a .NET application.
 * 3. When you must preserve the original file sizes and timestamps by storing entries uncompressed in a XAR container.
 * 4. When an automated build process requires creating a XAR archive as part of a deployment pipeline without applying compression.
 * 5. When you need to programmatically create a XAR archive on Windows and save it to a specific output folder for later distribution.
 */
