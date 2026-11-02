// HOW-TO: Create a TAR.BZ2 Archive with Four Compression Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded source folder and output file paths
            string sourceFolder = @"C:\Data\SourceFolder";
            string outputPath = @"C:\Data\output\folder.tar.bz2";

            // Verify source folder exists
            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add files from the source folder
            using (TarArchive tarArchive = new TarArchive())
            {
                foreach (string filePath in Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories))
                {
                    // Compute entry name relative to the source folder and use forward slashes
                    string entryName = Path.GetRelativePath(sourceFolder, filePath).Replace('\\', '/');
                    tarArchive.CreateEntry(entryName, filePath);
                }

                // Compress the TAR archive using BZIP2 with 4 compression threads
                using (Bzip2Archive bz2Archive = new Bzip2Archive())
                {
                    bz2Archive.SetSource(tarArchive);

                    Bzip2SaveOptions options = new Bzip2SaveOptions();
                    options.CompressionThreads = 4;

                    bz2Archive.Save(outputPath, options);
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
 * 1. When you need to back up a directory into a single .tar.bz2 file while utilizing multiple CPU cores for faster BZIP2 compression in a C# application.
 * 2. When you want to package source code files into a TAR archive and then compress it with BZIP2 to reduce size before uploading to a Linux server from a .NET service.
 * 3. When an automated build pipeline must generate a compressed TAR.BZ2 artifact with a specific number of compression threads to meet performance requirements.
 * 4. When you are creating a portable backup of configuration files that must be compatible with Unix tools, using C# to produce a .tar.bz2 archive.
 * 5. When you need to compress large log folders into a BZIP2 archive with controlled threading to avoid overwhelming system resources in a Windows environment.
 */
