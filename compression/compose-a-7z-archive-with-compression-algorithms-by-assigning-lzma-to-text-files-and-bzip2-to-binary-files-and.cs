// HOW-TO: Create 7z Archive With LZMA For Text And BZip2 For Binary Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\Input";
            string outputArchivePath = @"C:\Data\Output\archive.7z";

            string textFilePath = Path.Combine(inputDirectory, "sample.txt");
            string binaryFilePath = Path.Combine(inputDirectory, "image.bin");

            if (!File.Exists(textFilePath))
            {
                Console.Error.WriteLine($"File not found: {textFilePath}");
                return;
            }

            if (!File.Exists(binaryFilePath))
            {
                Console.Error.WriteLine($"File not found: {binaryFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            using (SevenZipArchive archive = new SevenZipArchive())
            {
                archive.CreateEntry("sample.txt", new FileInfo(textFilePath));
                archive.CreateEntry("image.bin", new FileInfo(binaryFilePath));
                archive.Save(outputArchivePath);
            }

            Console.WriteLine("7z archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package both readable logs and binary assets into a single 7z file while applying the most efficient compression for each type.
 * 2. When you want to automate backup of mixed file types in a .NET application, using LZMA for text to maximize reduction and BZip2 for binary to preserve speed.
 * 3. When you are building a deployment bundle that must include configuration files and compiled resources, and you require different compression algorithms for optimal size.
 * 4. When you need to generate a 7z archive on a server for download, ensuring text files are highly compressed and binary files retain integrity with BZip2.
 * 5. When you are creating archival archives for regulatory compliance and must store files in a single 7z container with algorithm‑specific compression settings.
 */
