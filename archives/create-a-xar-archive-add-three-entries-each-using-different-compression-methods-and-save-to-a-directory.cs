// HOW-TO: Create XAR Archive with Mixed Compression Methods in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input files
            string textFilePath = "input.txt";
            string htmlFilePath = "input.html";
            string binaryFilePath = "input.bin";

            // Verify input files exist
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
            if (!File.Exists(binaryFilePath))
            {
                Console.Error.WriteLine($"File not found: {binaryFilePath}");
                return;
            }

            // Output XAR archive path
            string outputDirectory = "output";
            string xarOutputPath = Path.Combine(outputDirectory, "archive.xar");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(xarOutputPath));

            // Default (Zlib) compression settings
            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();

            // Store (no compression) settings
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            // Create XAR archive and add entries with different compression methods
            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                // Text file with default Zlib compression
                archive.CreateEntry("text.txt", textFilePath, openImmediately: false, compressionSettings: defaultCompression);

                // HTML file with store (no) compression
                archive.CreateEntry("page.html", htmlFilePath, openImmediately: false, compressionSettings: storeCompression);

                // Binary file with default Zlib compression
                archive.CreateEntry("data.bin", binaryFilePath, openImmediately: false, compressionSettings: defaultCompression);

                // Save the XAR archive
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
 * 1. When you need to bundle text, HTML, and binary files into a single XAR package while applying the most efficient compression for each file type.
 * 2. When you want to create a portable archive for macOS installers that stores some files uncompressed for faster access and compresses others to reduce size.
 * 3. When you are implementing a backup solution that saves configuration files with Zlib compression but keeps executable binaries stored without compression for quick restoration.
 * 4. When you are preparing a distribution bundle that requires different compression strategies to meet size constraints and performance requirements on different platforms.
 * 5. When you need to generate XAR archives programmatically in a .NET application to integrate with existing CI/CD pipelines that handle mixed‑compression archives.
 */
