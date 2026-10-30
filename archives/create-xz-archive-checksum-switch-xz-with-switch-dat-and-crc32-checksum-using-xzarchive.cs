// HOW-TO: Create XZ Archive With CRC32 Checksum Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "switch.dat";
            string outputPath = "checksum_switch.xz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Create XZ archive with CRC32 checksum (default for XZ)
            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine($"XZ archive created: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a binary file into an XZ archive and verify its integrity with a CRC32 checksum before distributing it to clients.
 * 2. When you want to automate the creation of XZ packages for firmware updates, ensuring the archive includes a built‑in checksum for reliable validation on target devices.
 * 3. When you are building a backup script in C# that stores log files as XZ archives and relies on the default CRC32 checksum to detect corruption during restore.
 * 4. When you need to generate a single‑file XZ archive for a data payload that will be transmitted over a network, using Aspose.Zip to guarantee the file’s checksum matches after transfer.
 * 5. When you are integrating XZ compression into a .NET application and require a straightforward way to create the archive with the standard CRC32 integrity check without manually handling streams.
 */
