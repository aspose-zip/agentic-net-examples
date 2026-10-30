// HOW-TO: Compress PNG to XZ Archive with CRC32 Checksum in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\image.png";
            string outputPath = @"C:\Data\image_archive.xz";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create XZ archive and compress the file
            using (XzArchive archive = new XzArchive())
            {
                // Set the source file to be compressed
                archive.SetSource(inputPath);

                // The XZ format includes a CRC32 checksum by default.
                // If explicit checksum configuration were required, it would be set here.

                // Save the compressed archive
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of a PNG image for faster network transfer while ensuring data integrity with a CRC32 checksum.
 * 2. When you want to store PNG assets in an XZ archive for long‑term backup on a Windows server using C#.
 * 3. When a build pipeline must package image resources into a single compressed file that can be verified during deployment.
 * 4. When a desktop application requires on‑the‑fly compression of user‑selected images into XZ format before uploading to cloud storage.
 * 5. When you are implementing a custom archiving tool that must compress files with XZ and include built‑in checksum validation for error detection.
 */
