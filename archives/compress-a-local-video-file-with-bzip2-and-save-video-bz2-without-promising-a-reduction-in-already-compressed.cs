// HOW-TO: Compress a MP4 video to BZIP2 archive using C# Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\video.mp4";
            string outputPath = @"C:\Data\video.bz2";

            // Verify that the input video file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BZIP2 archive, set the source file, and save the compressed file
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("Video file compressed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce storage size of raw video files before uploading them to a backup server, you can compress the MP4 with BZIP2 using Aspose.Zip in C#.
 * 2. When a media processing pipeline requires archiving intermediate video outputs in a portable .bz2 format for later retrieval, this code creates the archive programmatically.
 * 3. When integrating a desktop application that stores user‑generated videos, you can use the snippet to generate a BZIP2‑compressed file to conserve disk space.
 * 4. When automating nightly jobs that package surveillance footage for secure transfer, the example shows how to compress each video file with BZIP2 via C#.
 * 5. When building a cross‑platform tool that needs to create BZIP2 archives of video assets without external command‑line utilities, this code demonstrates the Aspose.Zip approach.
 */
