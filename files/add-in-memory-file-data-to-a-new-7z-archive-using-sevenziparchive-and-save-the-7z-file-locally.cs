// HOW-TO: Create a 7z Archive from In-Memory Data in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output 7z file path
            string outputPath = "output.7z";

            // Ensure the output directory exists (handle case when only file name is provided)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory());
            }

            // Prepare in‑memory file data
            byte[] fileBytes = Encoding.UTF8.GetBytes("Hello, Aspose.Zip 7z in-memory!");
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                // Create the 7z archive and add the in‑memory entry
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                using (SevenZipArchive archive = new SevenZipArchive())
                {
                    archive.CreateEntry("hello.txt", memoryStream);
                    archive.Save(outStream);
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
 * 1. When you need to generate a 7z compressed file directly from data held in memory without writing temporary files to disk.
 * 2. When you want to bundle dynamically created text or binary content into a single 7z package for download or email attachment.
 * 3. When an application must archive logs, reports, or configuration files on the fly before sending them to a remote server.
 * 4. When you are building a cloud service that creates compressed archives in memory to reduce I/O latency and storage usage.
 * 5. When you need to programmatically create a 7z archive in C# for backup or distribution of files that are produced at runtime.
 */
