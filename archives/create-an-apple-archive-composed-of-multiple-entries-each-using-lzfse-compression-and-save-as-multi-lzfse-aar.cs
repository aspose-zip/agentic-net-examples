// HOW-TO: Create XAR Archive With Mixed Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string textFilePath = @"C:\Data\sample.txt";
            string htmlFilePath = @"C:\Data\sample.html";
            string directoryToPack = @"C:\Data\FolderToPack";
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

            if (!Directory.Exists(directoryToPack))
            {
                Console.Error.WriteLine($"Directory not found: {directoryToPack}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(xarOutput));

            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                archive.CreateEntry("sample.txt", textFilePath, openImmediately: false, compressionSettings: defaultCompression);
                archive.CreateEntry("sample.html", htmlFilePath, openImmediately: false, compressionSettings: storeCompression);
                archive.CreateEntries(directoryToPack, includeRootDirectory: false, compressionSettings: defaultCompression);
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
 * 1. When you need to bundle text, HTML, and a folder into a single XAR package for macOS distribution, this code creates the archive with appropriate compression.
 * 2. When you want to keep some files uncompressed for faster access while compressing others to save space, the example shows how to apply different compression settings per entry.
 * 3. When automating backups of configuration files and resources in a CI pipeline, you can generate a XAR archive programmatically using Aspose.Zip for .NET.
 * 4. When delivering software updates that require Apple’s XAR format, this snippet demonstrates creating the archive directly from C# without external tools.
 * 5. When you need to verify the existence of source files and directories before archiving to avoid runtime errors, the code includes checks and error handling for reliable archive creation.
 */
