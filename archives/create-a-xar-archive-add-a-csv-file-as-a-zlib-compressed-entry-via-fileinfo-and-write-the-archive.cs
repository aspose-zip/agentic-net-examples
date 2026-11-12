// HOW-TO: Create XAR Archive With Zlib Compressed CSV File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string csvFilePath = "input.csv";
            string xarOutputPath = "output.xar";

            if (!File.Exists(csvFilePath))
            {
                Console.Error.WriteLine($"File not found: {csvFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(xarOutputPath));

            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();

            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                archive.CreateEntry("data.csv", csvFilePath, false, defaultCompression);
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
 * 1. When you need to package a CSV report into a XAR container for secure distribution while reducing size with Zlib compression in a .NET application.
 * 2. When integrating legacy macOS XAR archives into a C# workflow and must add new data files without decompressing the whole archive.
 * 3. When automating backup of log or data files and want to store them as a single compressed XAR file to simplify transfer and storage.
 * 4. When creating a portable data bundle for a cross‑platform tool that expects XAR archives, ensuring the CSV content is compressed to meet size constraints.
 * 5. When implementing a custom export feature that generates CSV output and immediately archives it in XAR format for compliance with an external system’s import requirements.
 */
