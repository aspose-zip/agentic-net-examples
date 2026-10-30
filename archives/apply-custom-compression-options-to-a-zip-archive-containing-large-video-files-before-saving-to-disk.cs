// HOW-TO: Create ZIP Archive with Enhanced Deflate Compression for Large Videos in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input video file paths
            string videoPath1 = @"C:\Videos\video1.mp4";
            string videoPath2 = @"C:\Videos\video2.mp4";

            // Verify input files exist
            if (!File.Exists(videoPath1))
            {
                Console.Error.WriteLine($"File not found: {videoPath1}");
                return;
            }
            if (!File.Exists(videoPath2))
            {
                Console.Error.WriteLine($"File not found: {videoPath2}");
                return;
            }

            // Hardcoded output ZIP path
            string outputZipPath = @"C:\Output\videos_archive.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create ZIP archive with custom compression (Enhanced Deflate)
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            using (Archive archive = new Archive(new ArchiveEntrySettings(new EnhancedDeflateCompressionSettings())))
            {
                // Add video files to the archive
                archive.CreateEntry("video1.mp4", videoPath1);
                archive.CreateEntry("video2.mp4", videoPath2);

                // Save the archive to disk
                archive.Save(zipStream);
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
 * 1. When you need to bundle multiple high‑resolution video files into a single ZIP file while reducing size with a stronger deflate algorithm for faster upload or storage.
 * 2. When an application must generate a downloadable archive of user‑uploaded videos and wants to apply custom compression settings to meet bandwidth constraints.
 * 3. When a media processing pipeline archives processed video assets on a server and requires consistent compression to ensure predictable archive size.
 * 4. When a backup utility creates compressed archives of large video libraries and wants to use Enhanced Deflate to achieve better compression than the default.
 * 5. When a desktop tool prepares video files for distribution on removable media and needs to compress them into a ZIP with custom settings before writing to disk.
 */
