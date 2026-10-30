// HOW-TO: How To Set Enhanced Deflate Compression For A Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file path
            string inputPath = "input.txt";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output file path (used to demonstrate writing the memory stream to disk)
            string outputPath = "output.zip";
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a memory stream to hold the ZIP archive
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Configure custom compression settings (Enhanced Deflate)
                using (Archive archive = new Archive(new ArchiveEntrySettings(new EnhancedDeflateCompressionSettings())))
                {
                    // Add the input file to the archive
                    archive.CreateEntry("input.txt", inputPath);

                    // Save the archive into the memory stream
                    archive.Save(memoryStream);
                }

                // Reset stream position before reading
                memoryStream.Position = 0;

                // Example: write the memory stream to a file
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(fileStream);
                }
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
 * 1. When you need to create a ZIP file with higher compression efficiency using Enhanced Deflate before sending it over a network in a C# application.
 * 2. When you want to generate a ZIP archive in memory, apply custom compression settings, and later write it to disk or stream it to a client.
 * 3. When your software must compress large log files with a specific algorithm to reduce storage costs while keeping the process entirely in .NET.
 * 4. When you are building a cloud service that assembles files into a ZIP with custom compression and returns the archive as a byte array.
 * 5. When you need to ensure consistent compression parameters across multiple ZIP entries by configuring the ArchiveEntrySettings once in C#.
 */
