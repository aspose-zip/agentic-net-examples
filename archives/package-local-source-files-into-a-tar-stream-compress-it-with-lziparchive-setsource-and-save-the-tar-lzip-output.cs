// HOW-TO: Create a TAR.LZIP Archive from a Folder in C# (Aspose.ZIP for .NET)
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
            string inputDir = "input";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            string outputPath = "output/output.tar.lz";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive tar = new TarArchive())
            {
                tar.CreateEntries(inputDir);

                using (MemoryStream tarStream = new MemoryStream())
                {
                    tar.Save(tarStream);
                    tarStream.Position = 0;

                    using (LzipArchive lzip = new LzipArchive())
                    {
                        lzip.SetSource(tarStream);
                        lzip.Save(outputPath);
                    }
                }
            }

            Console.WriteLine($"TAR.LZIP archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up a project's source directory into a single compressed TAR.LZIP file for efficient storage or transfer.
 * 2. When you want to package log files into a TAR archive and then compress them with LZIP to meet Linux‑based deployment requirements.
 * 3. When you must generate a TAR.LZIP bundle of configuration files to send to a remote server that only accepts LZIP‑compressed archives.
 * 4. When you are creating an automated build script that archives build artifacts into a TAR.LZIP file before uploading to cloud storage.
 * 5. When you need to compress a set of data files into a TAR.LZIP archive to reduce bandwidth usage during download by end users.
 */
