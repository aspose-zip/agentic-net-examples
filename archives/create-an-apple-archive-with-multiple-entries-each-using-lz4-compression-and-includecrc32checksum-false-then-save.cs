// HOW-TO: Create XAR Archive With Multiple Files Using Different Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string textFilePath = @"C:\Data\file1.txt";
            string htmlFilePath = @"C:\Data\file2.html";
            string xarOutput = @"C:\Output\archive.xar";

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

            Directory.CreateDirectory(Path.GetDirectoryName(xarOutput));

            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();
            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                archive.CreateEntry("file1.txt", textFilePath, openImmediately: false, compressionSettings: defaultCompression);
                XarCompressionSettings storeCompression = new XarStoreCompressionSettings();
                archive.CreateEntry("file2.html", htmlFilePath, openImmediately: false, compressionSettings: storeCompression);
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
 * 1. When you need to package a text file and an HTML file into a single XAR archive for macOS distribution using C#.
 * 2. When you want to compress larger files with Zlib while storing smaller files uncompressed to balance archive size and performance.
 * 3. When an automated build process must generate XAR archives with different compression settings for each file before publishing.
 * 4. When a .NET service creates backup archives that must be compatible with Apple’s XAR format and preserve original file paths.
 * 5. When integrating with macOS deployment tools that require XAR archives, you can create them programmatically without manual command‑line steps.
 */
