// HOW-TO: Create XZ Archive Without Checksum Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.txt";
            string outputPath = @"C:\Data\checksum_none.xz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create XZ archive without checksum
            using (XzArchive archive = new XzArchive())
            {
                // Set the source file to be compressed
                archive.SetSource(inputPath);

                // Save the archive to the specified output path
                archive.Save(outputPath);
            }

            Console.WriteLine("XZ archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a log file into an XZ archive for storage but want to skip the checksum to reduce processing overhead.
 * 2. When integrating file backup into a .NET application and the target system does not support checksum verification for XZ files.
 * 3. When generating lightweight XZ packages for embedded devices that have limited CPU resources and cannot compute checksums.
 * 4. When creating XZ archives for data that will be transmitted over a trusted channel, making checksum validation unnecessary.
 * 5. When automating a build pipeline that packages source files into XZ format using Aspose.Zip and you prefer a faster compression without the extra checksum step.
 */
