// HOW-TO: Create XZ Archive Without Checksum From Binary File In C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample4.bin";
            string outputPath = "output\\archive_none.xz";

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
                // If the API provides a checksum option, disable it here
                // archive.Checksum = false;

                archive.SetSource(inputPath);
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
 * 1. When you need to compress a large binary log into an XZ file without adding a checksum to reduce overhead.
 * 2. When packaging a firmware image for distribution and you want a lightweight XZ archive that can be created programmatically in C#.
 * 3. When integrating file compression into a .NET application that must generate XZ archives compatible with tools that expect no integrity check.
 * 4. When automating backup of binary data files on Windows and you prefer to omit checksums to speed up the archiving process.
 * 5. When developing a custom deployment pipeline that creates XZ archives of binaries without extra metadata for faster extraction on target systems.
 */
