// HOW-TO: Create a .tar.lz4 Archive from Multiple Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "input1.txt";
            string inputPath2 = "input2.txt";
            string inputPath3 = "input3.txt";
            string outputPath = "output.tar.lz4";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("input1.txt", inputPath1);
                archive.CreateEntry("input2.txt", inputPath2);
                archive.CreateEntry("input3.txt", inputPath3);
                archive.SaveLZ4Compressed(outputPath);
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
 * 1. When you need to bundle several related log or configuration files into a single TAR container and compress it with LZ4 for fast transmission over a network.
 * 2. When you want to generate a lightweight .tar.lz4 package for backup purposes that can be quickly decompressed on the receiving side.
 * 3. When an application must create a portable archive of source files to be consumed by a Linux system that expects TAR format with LZ4 compression.
 * 4. When you are implementing a custom deployment pipeline that packages build artifacts into a .tar.lz4 file before uploading to cloud storage.
 * 5. When you need to programmatically combine multiple data files into a single compressed archive for archiving or compliance in a .NET service.
 */
