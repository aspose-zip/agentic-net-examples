// HOW-TO: Convert Tar.Gz to Tar.Bz2 Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tar.gz";
            string outputPath = "output.tar.bz2";

            // Verify the input GZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Decompress the GZIP wrapper to obtain the TAR payload
            using (GzipArchive gzipArchive = new GzipArchive())
            {
                gzipArchive.SetSource(inputPath);
                using (Stream tarStream = gzipArchive.Open())
                {
                    // Compress the TAR payload with BZIP2 and save as .tar.bz2
                    using (Bzip2Archive bzip2Archive = new Bzip2Archive())
                    {
                        bzip2Archive.SetSource(tarStream);
                        bzip2Archive.Save(outputPath);
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
 * 1. When you need to repackage a .tar.gz backup into a .tar.bz2 file for better compression before uploading to a Linux server.
 * 2. When a .NET application must read a GZIP‑compressed TAR archive and store it in BZIP2 format for compatibility with legacy tools.
 * 3. When automating a data‑migration workflow that extracts the TAR payload from a .tar.gz and recompresses it as .tar.bz2 using Aspose.Zip.
 * 4. When you want to convert incoming .tar.gz logs into .tar.bz2 to reduce storage costs in a cloud‑based archive.
 * 5. When integrating a C# service that processes compressed archives and must switch from GZIP to BZIP2 compression without writing intermediate files to disk.
 */
