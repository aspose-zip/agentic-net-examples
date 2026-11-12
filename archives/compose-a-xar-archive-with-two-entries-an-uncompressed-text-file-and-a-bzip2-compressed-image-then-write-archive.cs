// HOW-TO: Create XAR Archive with Uncompressed Text and Bzip2 Image in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string textFilePath = "input.txt";
            string imageFilePath = "image.png";
            string tempBzip2Path = "image.png.bz2";
            string xarOutputPath = "output.xar";

            // Validate input files
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(xarOutputPath));

            // Compress the image using Bzip2
            using (Bzip2Archive bzip2Archive = new Bzip2Archive())
            {
                bzip2Archive.SetSource(imageFilePath);
                bzip2Archive.Save(tempBzip2Path);
            }

            // Prepare compression settings for XAR entries
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();
            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();

            // Create XAR archive and add entries
            using (XarArchive xarArchive = new XarArchive(defaultCompression))
            {
                // Add uncompressed text file
                xarArchive.CreateEntry("text.txt", textFilePath, openImmediately: false, compressionSettings: storeCompression);

                // Add Bzip2-compressed image (stored without additional compression)
                xarArchive.CreateEntry("image.png.bz2", tempBzip2Path, openImmediately: false, compressionSettings: storeCompression);

                // Save the XAR archive
                xarArchive.Save(xarOutputPath);
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
 * 1. When you need to bundle a configuration file and a pre‑compressed PNG into a single XAR package for distribution to macOS systems.
 * 2. When you want to create a lightweight installer that stores a text manifest without compression while keeping large images already compressed with Bzip2.
 * 3. When you must generate an archive that preserves the original Bzip2 image file size and avoids double‑compressing it alongside other uncompressed resources.
 * 4. When you are automating backup scripts in C# that require mixing uncompressed logs and Bzip2‑compressed assets inside a XAR container.
 * 5. When you are integrating Aspose.Zip into a .NET application to produce XAR archives that combine plain‑text documentation and pre‑compressed media for cross‑platform deployment.
 */
