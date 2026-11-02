// HOW-TO: Create Parallel XZ Compressed TAR Archive Using All CPU Cores in C# (Aspose.ZIP for .NET)
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
            string sourceDir = "SourceFiles";
            if (!Directory.Exists(sourceDir))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDir}");
                return;
            }

            string outputPath = "Output/parallel.tar.xz";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive tar = new TarArchive())
            {
                string[] files = Directory.GetFiles(sourceDir);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    tar.CreateEntry(entryName, filePath);
                }

                using (MemoryStream tarStream = new MemoryStream())
                {
                    tar.Save(tarStream);
                    tarStream.Position = 0;

                    XzArchiveSettings xzSettings = new XzArchiveSettings();
                    xzSettings.CompressionThreads = Environment.ProcessorCount;

                    using (XzArchive xz = new XzArchive(xzSettings))
                    {
                        xz.SetSource(tarStream);
                        using (FileStream outFile = File.Open(outputPath, FileMode.Create))
                        {
                            xz.Save(outFile);
                        }
                    }
                }
            }

            Console.WriteLine($"Archive created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a set of log files into a single .tar.xz package for efficient storage and transfer, using all available CPU cores to speed up compression.
 * 2. When deploying a .NET application that must create backup archives of configuration files on the fly, and you want to maximize compression performance by parallelizing the XZ algorithm.
 * 3. When automating nightly builds that generate many output files and you need to create a compressed TAR archive to upload to a remote server, leveraging multi‑threaded compression to reduce processing time.
 * 4. When implementing a cross‑platform data export feature that packages selected files into a .tar.xz archive for users, ensuring the compression utilizes the machine’s full processor count.
 * 5. When integrating Aspose.Zip into a Windows service that periodically archives sensor data, and you require a single .tar.xz file created quickly by using all CPU cores.
 */
