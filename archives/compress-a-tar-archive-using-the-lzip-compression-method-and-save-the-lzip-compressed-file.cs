// HOW-TO: Compress a Directory into a TAR Lzip Archive Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceDirectory = @"C:\Data\SourceFolder";
            string outputFilePath = @"C:\Data\Output\archive.tar.lz";

            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            using (TarArchive tarArchive = new TarArchive())
            {
                string[] files = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    string entryName = Path.GetRelativePath(sourceDirectory, filePath).Replace('\\', '/');
                    tarArchive.CreateEntry(entryName, filePath);
                }

                using (MemoryStream tarStream = new MemoryStream())
                {
                    tarArchive.Save(tarStream);
                    tarStream.Position = 0;

                    using (LzipArchive lzipArchive = new LzipArchive())
                    {
                        lzipArchive.SetSource(tarStream);
                        lzipArchive.Save(outputFilePath);
                    }
                }
            }

            Console.WriteLine("TAR archive compressed with Lzip successfully saved to: " + outputFilePath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to create a portable backup of a folder for Linux systems and want the smallest size, you can compress it into a TAR archive and then apply Lzip compression in C#.
 * 2. When distributing source code or assets to users who prefer Lzip‑compressed tarballs, this code lets you generate the .tar.lz file programmatically.
 * 3. When automating a build pipeline that packages build outputs into a tarball and compresses it with Lzip for efficient storage or transfer, you can use this approach.
 * 4. When you must archive log files from multiple subdirectories and compress them with a high‑ratio Lzip algorithm before uploading to cloud storage, the sample provides the necessary steps.
 * 5. When integrating Aspose.Zip into a .NET application to support legacy Unix compression formats, this example shows how to create and save a Lzip‑compressed TAR archive.
 */
