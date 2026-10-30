// HOW-TO: Extract All Files From XAR Archive To Folder Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.xar";
            string outputPath = "extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (XarArchive archive = new XarArchive(inputPath))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a macOS XAR installer on a Windows server to access its resources programmatically.
 * 2. When an automated build pipeline must extract bundled assets from a XAR package before further processing.
 * 3. When a desktop application offers users the ability to view or modify files contained in a XAR archive.
 * 4. When migrating data from legacy XAR archives to a new file system structure in a .NET migration tool.
 * 5. When performing forensic analysis on a XAR archive and need to extract its contents to a temporary directory for inspection.
 */
