// HOW-TO: Compress a CPIO Archive to GZipped File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.cpio";
            string outputPath = "output.cpio.gz";

            // Verify that the input CPIO file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists before saving
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CPIO archive and save it as a gzipped CPIO file
            using (CpioArchive archive = new CpioArchive(inputPath))
            {
                archive.SaveGzipped(outputPath);
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
 * 1. When you need to reduce the size of a CPIO package before transferring it over a network, you can compress it to a .cpio.gz file with Aspose.Zip in C#.
 * 2. When deploying Linux firmware updates packaged as CPIO archives, you may want to store them in a gzipped format to save disk space on the target system.
 * 3. When creating backup archives of container images that are originally in CPIO format, compressing them with SaveGzipped ensures faster backup and restore operations.
 * 4. When integrating a C# application with a CI/CD pipeline that expects gzipped CPIO artifacts, this code lets you generate the required .cpio.gz files automatically.
 * 5. When archiving log files collected in a CPIO archive and needing to comply with storage quotas, you can use the provided snippet to gzip the archive before archiving it further.
 */
