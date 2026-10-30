// HOW-TO: Create XAR Archive with Mixed Compression (Store and Zlib) in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string readmePath = "C:\\Input\\README.txt";
            string changelogPath = "C:\\Input\\CHANGELOG.txt";

            // Hardcoded output XAR file path
            string outputPath = "C:\\Release\\MyRelease.xar";

            // Validate input files
            if (!File.Exists(readmePath))
            {
                Console.Error.WriteLine($"File not found: {readmePath}");
                return;
            }
            if (!File.Exists(changelogPath))
            {
                Console.Error.WriteLine($"File not found: {changelogPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define compression settings
            XarCompressionSettings zlibCompression = new XarZlibCompressionSettings();   // Zlib-compressed entries
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings(); // Uncompressed (store) entries

            // Create the XAR archive with default compression (Zlib)
            using (XarArchive archive = new XarArchive(zlibCompression))
            {
                // Add uncompressed README file
                archive.CreateEntry("README.txt", readmePath, openImmediately: false, compressionSettings: storeCompression);

                // Add Zlib-compressed changelog file
                archive.CreateEntry("CHANGELOG.txt", changelogPath, openImmediately: false, compressionSettings: zlibCompression);

                // Save the archive to the specified output path
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
 * 1. When you need to package release notes and a changelog into a single XAR file, keeping the README uncompressed for quick access while compressing the changelog to save space.
 * 2. When automating build pipelines that generate XAR archives for macOS installers, and you want different compression methods per file.
 * 3. When distributing software updates where the license file must remain readable without decompression, but other documentation can be compressed.
 * 4. When creating backup archives that require certain files stored verbatim for integrity checks while compressing larger logs.
 * 5. When integrating Aspose.Zip into a C# application to programmatically assemble versioned release bundles with mixed compression settings.
 */
