// HOW-TO: Create XAR Archive with Uncompressed Text and Zlib Image in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string textFilePath = "input.txt";
            string imageFilePath = "image.png";
            string xarOutput = "output/output.xar";

            if (!File.Exists(textFilePath))
            {
                Console.Error.WriteLine($"File not found: {textFilePath}");
                return;
            }

            if (!File.Exists(imageFilePath))
            {
                Console.Error.WriteLine($"File not found: {imageFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(xarOutput));

            // Compression settings
            XarCompressionSettings zlibCompression = new XarZlibCompressionSettings();
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            using (XarArchive archive = new XarArchive(zlibCompression))
            {
                // Uncompressed text entry
                archive.CreateEntry("text.txt", textFilePath, openImmediately: false, compressionSettings: storeCompression);

                // Zlib-compressed image entry
                archive.CreateEntry("image.png", imageFilePath, openImmediately: false, compressionSettings: zlibCompression);

                // Save the XAR archive
                archive.Save(xarOutput);
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
 * 1. When you need to bundle configuration files and assets into a single XAR package for macOS installers while keeping the config files uncompressed for quick access.
 * 2. When you want to distribute a software update that includes a plain‑text changelog and a compressed PNG screenshot using Aspose.Zip for .NET.
 * 3. When you are creating backup archives that store log files as plain text and compress large image resources with Zlib to reduce size.
 * 4. When you need to generate an XAR archive programmatically in C# to send over a network where the text entry must remain uncompressed for streaming.
 * 5. When you are integrating XAR archive creation into a CI pipeline to package documentation and visual assets with mixed compression settings.
 */
