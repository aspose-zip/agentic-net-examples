// HOW-TO: Compress Existing CPIO Archive to XZ Format Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cpio";
            string outputPath = "output\\archive.cpio.xz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the existing CPIO archive and save it with XZ compression
            using (CpioArchive archive = new CpioArchive(inputPath))
            {
                archive.SaveXzCompressed(outputPath);
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
 * 1. When you need to shrink a CPIO package before sending it over a network, you can compress it to a .cpio.xz file with Aspose.Zip for .NET.
 * 2. When creating Linux system backups that require XZ compression, this code generates a compressed CPIO archive directly from C#.
 * 3. When integrating CPIO handling into a deployment pipeline, you can compress the archive to meet storage quotas or distribution requirements.
 * 4. When providing downloadable firmware updates that must be delivered in a highly compressed CPIO format, this snippet creates the .cpio.xz file automatically.
 * 5. When automating archival of log files packaged as CPIO, you can use this method to produce an XZ‑compressed archive for long‑term retention.
 */
