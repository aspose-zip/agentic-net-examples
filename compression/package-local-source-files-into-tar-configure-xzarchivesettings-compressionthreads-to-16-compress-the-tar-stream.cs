// HOW-TO: Create TAR Archive and Compress to XZ with 16 Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Xz;
using Aspose.Zip.Xz.Settings;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceDir = "C:\\SourceFiles";
            string outputPath = "C:\\Output\\parallel.tar.xz";

            if (!Directory.Exists(sourceDir))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDir}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (MemoryStream tarStream = new MemoryStream())
            {
                using (TarArchive tarArchive = new TarArchive())
                {
                    string[] files = Directory.GetFiles(sourceDir);
                    foreach (string filePath in files)
                    {
                        string entryName = Path.GetFileName(filePath);
                        tarArchive.CreateEntry(entryName, filePath);
                    }

                    tarArchive.Save(tarStream);
                }

                tarStream.Position = 0;

                XzArchiveSettings xzSettings = new XzArchiveSettings();
                xzSettings.CompressionThreads = 16;

                using (XzArchive xzArchive = new XzArchive(xzSettings))
                {
                    xzArchive.SetSource(tarStream);
                    xzArchive.Save(outputPath);
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
 * 1. When you need to bundle a set of local files into a single TAR file and then compress it to an XZ archive using multiple CPU cores for faster backup creation in a .NET application.
 * 2. When deploying software packages that require a TAR.XZ format for Linux distributions and you want to control the number of compression threads to optimize build server performance.
 * 3. When archiving log files from a Windows directory into a highly compressed XZ archive to reduce storage costs while preserving the original directory structure.
 * 4. When implementing a data export feature that creates a portable TAR container and compresses it with XZ in parallel, enabling quick download of large datasets from a web service.
 * 5. When integrating Aspose.Zip into a C# utility that must generate a .tar.xz archive on the fly, using 16 threads to take advantage of multi‑core processors for time‑critical compression tasks.
 */
