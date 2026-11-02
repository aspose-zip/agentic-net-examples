// HOW-TO: Compress a TAR File to LZ Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\backup.tar";
            string outputPath = @"C:\Data\backup.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of a large .tar backup before transferring it over a network, you can use this code to create an LZ archive in C#.
 * 2. When integrating automated backup scripts into a .NET application, this snippet lets you compress the generated tarball into a lightweight Lzip file for long‑term storage.
 * 3. When building a cross‑platform deployment pipeline that requires Lzip‑compressed packages, the code shows how to produce the archive directly from C# without external tools.
 * 4. When you want to archive log files bundled as a tar archive and store them efficiently on disk, this example demonstrates the conversion to an LZ file using Aspose.Zip.
 * 5. When implementing a custom archiving service that must support Lzip compression, the sample provides a straightforward way to set the source file and save the compressed output programmatically.
 */
