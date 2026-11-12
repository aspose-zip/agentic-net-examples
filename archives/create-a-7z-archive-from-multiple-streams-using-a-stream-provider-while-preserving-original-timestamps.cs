// HOW-TO: Create 7z Archive From Multiple Memory Streams In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] fileNames = new string[] { "Document1.txt", "Image1.png", "Report.pdf" };
            byte[][] fileContents = new byte[][]
            {
                System.Text.Encoding.UTF8.GetBytes("This is the content of Document1."),
                new byte[] { 0x89, 0x50, 0x4E, 0x47 },
                new byte[] { 0x25, 0x50, 0x44, 0x46 }
            };

            string outputPath = @"C:\Temp\Output\ArchiveFromStreams.7z";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (SevenZipArchive archive = new SevenZipArchive())
            {
                for (int i = 0; i < fileNames.Length; i++)
                {
                    using (MemoryStream contentStream = new MemoryStream(fileContents[i]))
                    {
                        archive.CreateEntry(fileNames[i], contentStream);
                    }
                }

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
 * 1. When you need to bundle dynamically generated files such as logs, images, or reports into a single 7z archive without writing temporary files to disk.
 * 2. When an application must compress data received from different sources (e.g., database blobs, user uploads) into a 7z package for efficient storage or transmission.
 * 3. When you want to create a 7z backup of in‑memory documents while preserving their original timestamps for audit compliance.
 * 4. When a service streams large files directly into a compressed archive to reduce memory usage and avoid intermediate file handling.
 * 5. When you are implementing a custom export feature that packages multiple streams into a 7z file for download in a web or desktop application.
 */
