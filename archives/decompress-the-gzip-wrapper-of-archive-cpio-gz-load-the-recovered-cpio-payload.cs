// HOW-TO: Decompress GZIP Wrapped CPIO Archive and Extract Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputGzipPath = "archive.cpio.gz";
            string tempCpioPath = "archive.cpio";
            string outputDirectory = "extracted";

            // Validate input GZIP file
            if (!File.Exists(inputGzipPath))
            {
                Console.Error.WriteLine($"File not found: {inputGzipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Ensure directory for temporary CPIO file exists (current directory in this case)
            Directory.CreateDirectory(Path.GetDirectoryName(tempCpioPath) ?? ".");

            // Decompress GZIP wrapper to obtain the CPIO payload
            using (GzipArchive gzipArchive = new GzipArchive(inputGzipPath))
            {
                using (Stream gzipStream = gzipArchive.Open())
                {
                    using (FileStream cpioFileStream = File.Create(tempCpioPath))
                    {
                        gzipStream.CopyTo(cpioFileStream);
                    }
                }
            }

            // Load the recovered CPIO archive
            using (CpioArchive cpioArchive = new CpioArchive(tempCpioPath))
            {
                // Extract all entries to the output directory
                cpioArchive.ExtractToDirectory(outputDirectory);
            }

            // Clean up temporary CPIO file
            File.Delete(tempCpioPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a .cpio.gz package from a Linux build system and need to programmatically unpack its contents in a C# application.
 * 2. When you must automate the extraction of configuration files stored inside a GZIP‑compressed CPIO archive during a deployment pipeline.
 * 3. When you want to process firmware update bundles that are distributed as GZIP‑wrapped CPIO files without using external command‑line tools.
 * 4. When you need to convert a compressed CPIO backup into a regular directory structure for further analysis in a .NET service.
 * 5. When you are building a cross‑platform utility that cleans up temporary CPIO files after extracting their payload from a GZIP stream.
 */
