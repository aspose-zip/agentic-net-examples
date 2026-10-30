// HOW-TO: Create XAR Archive with Multiple Files and Mixed Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string xarOutput = "output/example.xar";
            Directory.CreateDirectory(Path.GetDirectoryName(xarOutput));

            string tempDir = "temp";
            Directory.CreateDirectory(tempDir);

            string file1Path = Path.Combine(tempDir, "file1.txt");
            string file2Path = Path.Combine(tempDir, "file2.txt");
            string file3Path = Path.Combine(tempDir, "file3.txt");

            File.WriteAllText(file1Path, "Hello, this is the first file.", Encoding.UTF8);
            File.WriteAllText(file2Path, "Second file content goes here.", Encoding.UTF8);
            File.WriteAllText(file3Path, "Third file stored without compression.", Encoding.UTF8);

            if (!File.Exists(file1Path)) { Console.Error.WriteLine($"File not found: {file1Path}"); return; }
            if (!File.Exists(file2Path)) { Console.Error.WriteLine($"File not found: {file2Path}"); return; }
            if (!File.Exists(file3Path)) { Console.Error.WriteLine($"File not found: {file3Path}"); return; }

            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();
            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                archive.CreateEntry("file1.txt", file1Path, openImmediately: false, compressionSettings: defaultCompression);
                archive.CreateEntry("file2.txt", file2Path, openImmediately: false, compressionSettings: defaultCompression);
                archive.CreateEntry("file3.txt", file3Path, openImmediately: false, compressionSettings: storeCompression);
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
 * 1. When you need to package several text files into a single XAR archive for distribution while applying standard compression to most files.
 * 2. When you want to include a file that must remain uncompressed (stored) inside a XAR archive alongside compressed files.
 * 3. When automating backup processes in C# that require creating XAR archives with different compression settings per entry.
 * 4. When integrating with macOS package tools that expect XAR archives containing multiple resources with specific compression types.
 * 5. When generating installer payloads in .NET where some components need fast extraction (store) and others benefit from reduced size (zlib).
 */
