// HOW-TO: Create Uncompressed CPIO Archive From Multiple Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing files to compress
            string inputDirectory = "input";

            // Hardcoded output archive path
            string outputPath = "output/archive.cpio";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a CPIO archive, add all files from the input directory, and save it
            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(outputPath);
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
 * 1. When you need to package configuration files for a Linux deployment without compression, you can generate a CPIO archive using Aspose.Zip in C#.
 * 2. When building a backup utility that must create raw CPIO images for use with initramfs, this code creates the archive from a folder of files.
 * 3. When integrating with legacy Unix tools that only accept uncompressed CPIO streams, you can programmatically assemble the archive from local resources.
 * 4. When automating the creation of firmware update bundles that require a CPIO format, this snippet gathers the required binaries into a single .cpio file.
 * 5. When developing a cross‑platform installer that needs to bundle scripts and assets into a CPIO archive for extraction on embedded devices, the code provides a simple .NET solution.
 */
