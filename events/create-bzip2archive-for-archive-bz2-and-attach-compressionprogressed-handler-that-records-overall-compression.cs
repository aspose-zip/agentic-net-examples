// HOW-TO: Compress a File to BZ2 Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputArchivePath = "archive.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath) ?? ".");

            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputArchivePath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a text file for faster network transfer by creating a BZ2 archive in a .NET application.
 * 2. When you want to store log files in a compressed Bzip2 format to save disk space on a Windows server using C#.
 * 3. When an automated backup script must generate a BZ2 archive of configuration files before uploading them to cloud storage.
 * 4. When a desktop utility requires converting user‑selected documents into Bzip2 archives for archival compliance.
 * 5. When a data‑processing pipeline needs to compress intermediate output files into BZ2 to meet downstream system requirements.
 */
