// HOW-TO: Create TAR.XZ Archive with SHA256 Checksum for Multiple Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "report1.docx";
            string inputPath2 = "report2.docx";
            string outputPath = "reports.tar.xz";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add the two documents
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("report1.docx", inputPath1);
                archive.CreateEntry("report2.docx", inputPath2);

                // Compress the TAR archive using XZ compression
                archive.SaveXzCompressed(outputPath);
            }

            // Compute SHA-256 hash of the compressed archive
            using (FileStream fs = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(fs);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLowerInvariant();
                Console.WriteLine($"SHA-256: {hashString}");
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
 * 1. When you need to bundle several Word documents into a single compressed package for secure transfer and verify its integrity with a SHA‑256 hash.
 * 2. When automating backup of reports on a server, creating a tar.xz archive to save space and later confirm the backup wasn't corrupted.
 * 3. When preparing a software release that includes documentation, packaging the docs into a tar.xz file and generating a checksum for distribution.
 * 4. When sending large legal files via email, compressing them into a tar.xz archive and providing a SHA‑256 hash so the recipient can validate the files.
 * 5. When integrating document archiving into a .NET application, using Aspose.Zip to create a tar archive, compress it with XZ, and compute a hash for audit logging.
 */
