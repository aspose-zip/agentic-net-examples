// HOW-TO: Compress CPIO Archive to LZ Format Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string outputPath = "output.cpio.lz";

            // Verify that the input CPIO file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CPIO archive and save it as a LZ-compressed file
            using (CpioArchive archive = new CpioArchive(inputPath))
            {
                archive.SaveLzipped(outputPath);
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
 * 1. When you need to reduce the size of a CPIO package for faster network transfer by creating an LZ‑compressed .cpio.lz file.
 * 2. When you want to store backup archives in a space‑efficient format while preserving the original CPIO structure.
 * 3. When a Linux‑based deployment pipeline requires an LZ‑compressed CPIO image before flashing firmware.
 * 4. When you are integrating legacy CPIO data into a .NET application and must compress it for archival compliance.
 * 5. When you need to generate a .cpio.lz file programmatically to feed into tools that only accept LZ‑compressed CPIO inputs.
 */
