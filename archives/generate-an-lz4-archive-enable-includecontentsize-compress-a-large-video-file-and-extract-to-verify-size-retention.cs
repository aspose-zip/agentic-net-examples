// HOW-TO: Compress and Verify Large Video File with LZ4 Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\video.mp4";
            string archivePath = @"C:\Data\video.lz4";
            string extractedPath = @"C:\Data\extracted_video.mp4";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));
            Directory.CreateDirectory(Path.GetDirectoryName(extractedPath));

            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(archivePath);
            }

            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(archivePath);
                using (FileStream extracted = File.Create(extractedPath))
                {
                    archive.Extract(extracted);
                }
            }

            long originalSize = new FileInfo(inputPath).Length;
            long extractedSize = new FileInfo(extractedPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Extracted size: {extractedSize} bytes");
            Console.WriteLine($"Size match: {originalSize == extractedSize}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce storage space for large video files while ensuring the original size can be validated after extraction.
 * 2. When you want to create an LZ4 compressed archive of a media asset for fast transfer and later confirm data integrity.
 * 3. When your application must programmatically compress a video, store it in an .lz4 file, and later extract it without losing any bytes.
 * 4. When you are building a backup solution that uses LZ4 compression and requires a size check to guarantee successful restoration.
 * 5. When you need to demonstrate or test the Aspose.Zip LZ4 API for archiving and extracting large binary files in a .NET environment.
 */
