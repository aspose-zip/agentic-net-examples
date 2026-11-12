// HOW-TO: Create XAR Archive With Uncompressed File Stream And Save To Disk In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath = "input.txt";
            string outputXarPath = "output.xar";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputXarPath));

            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                archive.CreateEntry("uncompressed.txt", inputFilePath, openImmediately: false, compressionSettings: storeCompression);
                archive.Save(outputXarPath);
            }

            Console.WriteLine("XAR archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a text file into an XAR package without compression for fast extraction.
 * 2. When you want to generate an XAR archive entirely in memory before writing it to a file system location.
 * 3. When you must preserve the original file size by storing an entry using the store (no‑compression) method in a .NET application.
 * 4. When you are automating deployment scripts that require creating XAR archives from existing files on the server.
 * 5. When you need to create a portable XAR archive for later distribution while ensuring the archive is created programmatically in C#.
 */
