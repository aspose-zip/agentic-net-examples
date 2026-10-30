// HOW-TO: Compress Video MP4 to XZ Archive with SHA256 Checksum in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Zip.Xz;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/video.mp4";
            string outputPath = "output/video_archive.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Compute SHA-256 checksum of the source file
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(inputStream);
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                    Console.WriteLine($"SHA-256 checksum: {hashString}");
                }
            }

            // Compress the file into an XZ archive
            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
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
 * 1. When you need to reduce the size of large video files for faster upload while ensuring data integrity with a SHA‑256 hash.
 * 2. When you want to create an XZ‑compressed package of a media asset to meet storage quota limits in a .NET application.
 * 3. When you must generate a verifiable checksum before archiving video content for secure archival or compliance purposes.
 * 4. When your deployment pipeline requires automated compression of MP4 files into XZ archives using C# for cross‑platform distribution.
 * 5. When you are building a backup utility that stores videos in XZ format and records a SHA‑256 fingerprint to detect corruption on restore.
 */
