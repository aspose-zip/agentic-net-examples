// HOW-TO: Create XZ Archive Without Checksum From a DOC File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\notes.doc";
            string outputPath = @"C:\Data\plain.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
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
 * 1. When you need to compress a Word document for fast transfer over limited bandwidth without generating a checksum, you can use XzArchive to create a plain .xz file in C#.
 * 2. When archiving legal or confidential documents where checksum verification is unnecessary, this code lets you produce a lightweight XZ archive directly from the file system.
 * 3. When integrating file compression into a .NET application that stores backups on cloud storage that already handles integrity, you can generate a checksum‑free XZ archive to reduce overhead.
 * 4. When automating batch processing of reports and you want each report saved as a single .xz file without extra metadata, the XzArchive example provides a simple way to do it.
 * 5. When building a deployment pipeline that packages configuration files into XZ archives for Linux servers, this code shows how to create the archive in C# without adding a checksum.
 */
