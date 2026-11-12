// HOW-TO: Create XZ Archive Without Checksum Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input/data.bin";
            string outputPath = "output/data_checksum_none.xz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
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
 * 1. When you need to compress a binary file into an XZ archive for distribution but want to omit the integrity checksum to reduce file size.
 * 2. When integrating file packaging into a .NET build pipeline and the target system does not support XZ checksums.
 * 3. When generating XZ archives for legacy tools that expect no checksum field in the header.
 * 4. When creating lightweight compressed payloads for embedded devices where checksum verification is handled elsewhere.
 * 5. When automating backup scripts in C# that require fast compression without the overhead of checksum calculation.
 */
