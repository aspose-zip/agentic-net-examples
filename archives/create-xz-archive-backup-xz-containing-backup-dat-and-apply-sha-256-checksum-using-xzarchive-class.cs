// HOW-TO: Create XZ Archive and Compute SHA256 Checksum in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "backup.dat";
            string outputPath = "output/backup.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(fs);
                string hashString = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
                Console.WriteLine($"SHA-256 checksum of {inputPath}: {hashString}");
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
 * 1. When you need to compress a large data file into an XZ archive for efficient storage while preserving the original file for later verification.
 * 2. When you want to generate a SHA‑256 hash of a backup file to ensure its integrity after transferring it to another system.
 * 3. When you are building an automated backup routine in C# that creates compressed XZ archives and logs checksums for audit purposes.
 * 4. When you must create a portable XZ package of a configuration file and provide a checksum so users can validate the download.
 * 5. When you are integrating Aspose.Zip XZ support into a .NET application to archive logs and verify they have not been tampered with.
 */
