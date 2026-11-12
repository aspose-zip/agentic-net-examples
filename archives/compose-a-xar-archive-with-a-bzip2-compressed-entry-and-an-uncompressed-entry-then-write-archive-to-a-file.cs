// HOW-TO: Create XAR Archive with Compressed and Uncompressed Files in C# (Aspose.ZIP for .NET)
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
            string textFilePath = "sample.txt";
            string htmlFilePath = "sample.html";
            string xarOutputPath = "output.xar";

            // Validate input files
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(xarOutputPath));

            // Create compression settings
            XarCompressionSettings zlibCompression = new XarZlibCompressionSettings();
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            // Create XAR archive and add entries
            using (XarArchive archive = new XarArchive(zlibCompression))
            {
                // Add a compressed entry (using Zlib as the closest available compression)
                archive.CreateEntry("text.txt", textFilePath, openImmediately: false, compressionSettings: zlibCompression);

                // Add an uncompressed entry
                archive.CreateEntry("page.html", htmlFilePath, openImmediately: false, compressionSettings: storeCompression);

                // Save the archive to file
                archive.Save(xarOutputPath);
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
 * 1. When you need to package a text file and an HTML page into a single XAR bundle, compressing the text while keeping the HTML unchanged for faster access.
 * 2. When distributing software resources that require different compression levels, such as compressing large logs but leaving configuration files uncompressed for quick reads.
 * 3. When creating backup archives for a mixed set of files where some must remain stored without compression to preserve their original size or format.
 * 4. When integrating with macOS XAR‑based deployment pipelines that expect certain entries to be compressed and others to be stored raw.
 * 5. When automating build scripts in C# that generate XAR archives with both compressed and uncompressed entries for downstream processing or archiving.
 */
