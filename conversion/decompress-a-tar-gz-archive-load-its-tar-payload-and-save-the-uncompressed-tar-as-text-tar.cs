// HOW-TO: How to Decompress a TAR.GZ File to a TAR Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tar.gz";
            string outputPath = "text.tar";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (GzipArchive gzip = new GzipArchive())
            {
                gzip.SetSource(inputPath);
                using (Stream decompressedStream = gzip.Open())
                {
                    using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        decompressedStream.CopyTo(outputFile);
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
 * 1. When you receive a compressed backup (tar.gz) from a Linux server and need to extract the original tar file in a .NET application.
 * 2. When you want to programmatically unpack a tar.gz package before processing its contents, such as reading log files or configuration files.
 * 3. When you need to convert a gzipped tar archive into a plain tar file to feed into another library that only supports uncompressed tar streams.
 * 4. When automating a deployment pipeline that downloads tar.gz artifacts and must store the extracted tar for further validation or archiving.
 * 5. When building a cross‑platform tool that reads compressed archives and saves the raw tar payload for inspection or manual extraction.
 */
