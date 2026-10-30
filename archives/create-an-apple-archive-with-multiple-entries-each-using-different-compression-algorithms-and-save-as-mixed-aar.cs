// HOW-TO: Create Apple Archive With Mixed Compression Types In C# (Aspose.ZIP for .NET)
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
            string inputText = "input.txt";
            string inputHtml = "input.html";
            string dirToPack = "folderToPack";
            string outputPath = "mixed.aar";

            // Validate input files
            if (!File.Exists(inputText))
            {
                Console.Error.WriteLine($"File not found: {inputText}");
                return;
            }
            if (!File.Exists(inputHtml))
            {
                Console.Error.WriteLine($"File not found: {inputHtml}");
                return;
            }

            // Validate input directory
            if (!Directory.Exists(dirToPack))
            {
                Console.Error.WriteLine($"Directory not found: {dirToPack}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Default compression (Zlib)
            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();

            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                // Add a compressed text file entry
                archive.CreateEntry("docs/text.txt", inputText, openImmediately: false, compressionSettings: defaultCompression);

                // Add a stored (uncompressed) HTML file entry
                XarCompressionSettings storeCompression = new XarStoreCompressionSettings();
                archive.CreateEntry("docs/page.html", inputHtml, openImmediately: false, compressionSettings: storeCompression);

                // Add all files from a directory with default compression
                archive.CreateEntries(dirToPack, includeRootDirectory: false, compressionSettings: defaultCompression);

                // Save the mixed archive
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
 * 1. When you need to package text and HTML files together in a single XAR archive while applying different compression methods for size optimization and fast access.
 * 2. When you want to distribute a folder of resources as an Apple Archive that preserves the original directory structure and uses default Zlib compression for most files.
 * 3. When an application must create an uncompressed (stored) entry for HTML content to allow immediate reading without decompression overhead.
 * 4. When a build pipeline requires generating a mixed.aar file that combines compressed and uncompressed entries for compatibility with macOS package installers.
 * 5. When you need to programmatically validate the existence of input files and directories before creating a multi‑entry XAR archive in a .NET environment.
 */
