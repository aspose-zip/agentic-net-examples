// HOW-TO: Create XAR Archive with CSV, JSON, XML Using Different Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = "data";
            string csvPath = Path.Combine(dataDir, "sample.csv");
            string jsonPath = Path.Combine(dataDir, "sample.json");
            string xmlPath = Path.Combine(dataDir, "sample.xml");
            string xarOutput = Path.Combine(dataDir, "archive.xar");

            if (!File.Exists(csvPath))
            {
                Console.Error.WriteLine($"File not found: {csvPath}");
                return;
            }
            if (!File.Exists(jsonPath))
            {
                Console.Error.WriteLine($"File not found: {jsonPath}");
                return;
            }
            if (!File.Exists(xmlPath))
            {
                Console.Error.WriteLine($"File not found: {xmlPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(xarOutput));

            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();
            XarCompressionSettings zlibCompression = new XarZlibCompressionSettings();
            XarCompressionSettings bzip2Compression = new XarBzip2CompressionSettings();

            using (XarArchive archive = new XarArchive(zlibCompression))
            {
                archive.CreateEntry("sample.csv", csvPath, openImmediately: false, compressionSettings: storeCompression);
                archive.CreateEntry("sample.json", jsonPath, openImmediately: false, compressionSettings: zlibCompression);
                archive.CreateEntry("sample.xml", xmlPath, openImmediately: false, compressionSettings: bzip2Compression);
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
 * 1. When you need to bundle data files of various formats into a single XAR package while applying optimal compression per file type.
 * 2. When you want to distribute a CSV report uncompressed for quick access alongside compressed JSON and XML payloads in a portable archive.
 * 3. When your application must generate XAR archives on the fly for backup purposes, using store compression for small text files and Zlib/Bzip2 for larger structured data.
 * 4. When integrating with macOS or iOS tools that expect XAR archives, and you need to control compression settings for each entry from C#.
 * 5. When automating deployment pipelines that require archiving configuration files with different compression algorithms to reduce overall package size.
 */
