// HOW-TO: Create a Tar.Xz Archive with Single Thread Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Xz;
using Aspose.Zip.Xz.Settings;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceDirectory = "C:\\Data\\Source";
            string outputPath = "C:\\Data\\parallel.tar.xz";

            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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

                    XzArchiveSettings xzSettings = new XzArchiveSettings();
                    xzSettings.CompressionThreads = 1;

                    using (XzArchive xzArchive = new XzArchive(xzSettings))
                    {
                        xzArchive.SetSource(tarStream);
                        using (FileStream outputFile = File.Open(outputPath, FileMode.Create))
                        {
                            xzArchive.Save(outputFile);
                        }
                    }
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
 * 1. When you need to bundle a directory of log files into a portable .tar.xz package for efficient storage or transfer using C#.
 * 2. When you want to generate a reproducible archive with deterministic single‑threaded XZ compression to meet CI build requirements.
 * 3. When you must create a compressed backup of configuration files on Windows and need to limit CPU usage by setting the compression threads to one.
 * 4. When an application has to stream a TAR archive directly into an XZ compressor without writing intermediate files to disk.
 * 5. When deploying software updates that must be delivered as a .tar.xz archive and you need to produce it programmatically in a .NET environment.
 */
