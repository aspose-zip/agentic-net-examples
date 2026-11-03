// HOW-TO: Add File to ZIP Archive from Stream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath = "input.txt";
            string outputZipPath = "output/archive.zip";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (Archive zip = new Archive())
            {
                using (FileStream sourceStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                {
                    zip.CreateEntry("input.txt", sourceStream);
                }

                zip.Save(outputZipPath);
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
 * 1. When you need to compress a local text file into a ZIP without loading the entire file into memory, using a FileStream in C#.
 * 2. When an application must create a ZIP archive on the fly for download, adding files directly from streams to avoid temporary copies.
 * 3. When you are building a backup utility that stores individual files into a ZIP archive while preserving their original names.
 * 4. When you want to programmatically generate a ZIP package for email attachments, reading source files as streams for efficient I/O.
 * 5. When integrating with a third‑party service that requires a ZIP file containing specific documents, and you need to add each document from a stream before saving.
 */
