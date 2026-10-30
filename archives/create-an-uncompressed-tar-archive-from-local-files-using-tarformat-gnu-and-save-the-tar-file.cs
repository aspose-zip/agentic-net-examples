// HOW-TO: Create Uncompressed Gnu Tar Archive From Multiple Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFile1 = @"C:\Data\file1.txt";
            string inputFile2 = @"C:\Data\file2.txt";
            string outputPath = @"C:\Output\archive.tar";

            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry(inputFile1, Path.GetFileName(inputFile1));
                archive.CreateEntry(inputFile2, Path.GetFileName(inputFile2));
                archive.Save(outputPath);
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
 * 1. When you need to bundle several log or configuration files into a standard TAR package for cross‑platform distribution without applying compression.
 * 2. When a build pipeline must generate a GNU‑compatible TAR archive on Windows so that Linux tools can extract the files unchanged.
 * 3. When you want to create a backup of specific documents and preserve their original sizes by using an uncompressed TAR file in a .NET application.
 * 4. When integrating with legacy systems that only accept plain TAR archives, you can programmatically add files and save the archive using Aspose.Zip for .NET.
 * 5. When automating the packaging of deployment assets for container images, an uncompressed TAR simplifies layer creation and checksum verification.
 */
