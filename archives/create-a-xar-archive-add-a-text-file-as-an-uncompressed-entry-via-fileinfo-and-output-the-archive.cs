// HOW-TO: Create XAR Archive with Uncompressed Text File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputFilePath = @"C:\Temp\sample.txt";
            string outputArchivePath = @"C:\Temp\output.xar";

            // Validate input file existence
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Compression settings
            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            // Create XAR archive and add uncompressed entry
            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                archive.CreateEntry(
                    "sample.txt",
                    inputFilePath,
                    false,
                    storeCompression);

                // Save the archive to disk
                archive.Save(outputArchivePath);
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
 * 1. When you need to package a log file into a XAR archive without compression for fast retrieval.
 * 2. When you must generate a XAR package on the fly in a .NET service and keep certain files stored unchanged.
 * 3. When integrating with macOS XAR‑based deployment pipelines that require uncompressed entries for configuration files.
 * 4. When creating backup archives where specific text documents must remain uncompressed to allow direct editing without extraction.
 * 5. When building a custom installer that bundles resources in XAR format and needs to preserve the original file size of selected files.
 */
