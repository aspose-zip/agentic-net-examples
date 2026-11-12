// HOW-TO: Create XAR Archive with Mixed Compression Settings in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string textFilePath = "sample.txt";
            string htmlFilePath = "sample.html";
            string directoryToPack = "FolderToPack";
            string outputPath = "varied_block.xar";

            // Validate input file paths
            if (!File.Exists(textFilePath))
            {
                Console.Error.WriteLine($"File not found: {textFilePath}");
                return;
            }
            if (!File.Exists(htmlFilePath))
            {
                Console.Error.WriteLine($"File not found: {htmlFilePath}");
                return;
            }

            // Validate input directory path
            if (!Directory.Exists(directoryToPack))
            {
                Console.Error.WriteLine($"Directory not found: {directoryToPack}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Compression settings
            XarZlibCompressionSettings defaultCompression = new XarZlibCompressionSettings();
            XarStoreCompressionSettings storeCompression = new XarStoreCompressionSettings();

            // Create XAR archive and add entries
            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                // Add individual files with specific compression settings
                archive.CreateEntry("text/sample.txt", textFilePath, openImmediately: false, compressionSettings: defaultCompression);
                archive.CreateEntry("html/sample.html", htmlFilePath, openImmediately: false, compressionSettings: storeCompression);

                // Add all files from a directory using default compression
                archive.CreateEntries(directoryToPack, includeRootDirectory: false, compressionSettings: defaultCompression);

                // Save the XAR archive
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
 * 1. When you need to package text and HTML files together in an Apple XAR archive while applying different compression methods to each file.
 * 2. When you want to include an entire folder in a XAR archive using the default Zlib compression for all its contents.
 * 3. When you must generate a XAR archive programmatically in C# for distribution on macOS platforms that require specific block size settings.
 * 4. When you need to ensure that certain files are stored without compression (store mode) to allow faster extraction from the XAR archive.
 * 5. When you are automating backup processes that require creating a single XAR file from multiple sources with varied compression configurations.
 */
