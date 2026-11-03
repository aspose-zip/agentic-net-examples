// HOW-TO: How To Decompress A BZIP2 File To A Text File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bz2";
            string outputPath = "output/decompressed.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive(inputPath))
            {
                using (FileStream outputStream = File.Create(outputPath))
                {
                    archive.Extract(outputStream);
                }
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
 * 1. When you receive a .bz2 log file from a Linux server and need to extract its contents in a .NET application.
 * 2. When you want to programmatically unpack a compressed configuration file before processing it in C#.
 * 3. When an automated pipeline must convert BZIP2 archives into plain text for downstream analytics.
 * 4. When a desktop utility needs to allow users to open and view compressed documentation files stored as .bz2.
 * 5. When migrating legacy backup data compressed with BZIP2 into a modern system that expects uncompressed files.
 */
