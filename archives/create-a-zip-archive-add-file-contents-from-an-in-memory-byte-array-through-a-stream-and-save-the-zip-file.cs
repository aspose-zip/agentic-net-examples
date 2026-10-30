// HOW-TO: Create ZIP Archive From In-Memory Byte Array In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path for the ZIP archive
            string outputPath = "output.zip";

            // Create output directory if needed
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // In‑memory byte array representing file content
            byte[] fileData = new byte[] { 72, 101, 108, 108, 111, 44, 32, 87, 111, 114, 108, 100, 33 }; // "Hello, World!"

            using (MemoryStream dataStream = new MemoryStream(fileData))
            {
                using (Archive archive = new Archive())
                {
                    // Add a new entry to the archive from the memory stream
                    archive.CreateEntry("greeting.txt", dataStream);

                    // Save the archive to the specified output path
                    archive.Save(outputPath);
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
 * 1. When you need to generate a ZIP file on the fly from data that exists only in memory, such as dynamically created text or binary content, without writing temporary files first.
 * 2. When an application must package log files, reports, or configuration data into a compressed archive before sending it over a network or storing it in cloud storage.
 * 3. When you want to embed a small file like a greeting message or a generated CSV directly into a ZIP archive using a MemoryStream to avoid disk I/O.
 * 4. When building a server‑side service that creates downloadable ZIP bundles from user‑provided byte arrays, ensuring the archive is saved to a specified path with Aspose.Zip.
 * 5. When implementing automated backup routines that compress in‑memory snapshots of data structures into a ZIP archive for later extraction or archival.
 */
