// HOW-TO: Create TAR.XZ Archive With SHA-256 Checksums For Multiple Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string imagePath = @"C:\Input\image.jpg";
            string documentPath = @"C:\Input\document.pdf";
            string dataPath = @"C:\Input\data.csv";

            // Verify input files exist
            if (!File.Exists(imagePath))
            {
                Console.Error.WriteLine($"File not found: {imagePath}");
                return;
            }
            if (!File.Exists(documentPath))
            {
                Console.Error.WriteLine($"File not found: {documentPath}");
                return;
            }
            if (!File.Exists(dataPath))
            {
                Console.Error.WriteLine($"File not found: {dataPath}");
                return;
            }

            // Compute and display SHA-256 for each input file
            ComputeAndPrintSha256(imagePath);
            ComputeAndPrintSha256(documentPath);
            ComputeAndPrintSha256(dataPath);

            // Hardcoded output path
            string outputPath = @"C:\Output\mixed_content.tar.xz";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive, add entries, and compress with XZ
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("image.jpg", imagePath);
                archive.CreateEntry("document.pdf", documentPath);
                archive.CreateEntry("data.csv", dataPath);
                archive.SaveXzCompressed(outputPath);
            }

            // Compute and display SHA-256 for the resulting archive
            ComputeAndPrintSha256(outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ComputeAndPrintSha256(string filePath)
    {
        using (FileStream fs = File.OpenRead(filePath))
        using (System.Security.Cryptography.SHA256 sha = System.Security.Cryptography.SHA256.Create())
        {
            byte[] hash = sha.ComputeHash(fs);
            string hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            Console.WriteLine($"{Path.GetFileName(filePath)} SHA-256: {hashString}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle image, PDF, and CSV files into a single TAR.XZ package for cross‑platform distribution while ensuring each file’s integrity with SHA‑256 hashes.
 * 2. When you want to create a compressed archive for backup purposes that reduces storage size using XZ compression and provides a checksum to detect corruption.
 * 3. When delivering a set of assets to a Linux server, you can package them as a TAR.XZ file in C# so the target system can extract them natively.
 * 4. When generating a secure data bundle for compliance audits, you can compute SHA‑256 hashes for each source file and the final archive to prove authenticity.
 * 5. When automating a build pipeline that needs to combine various output files into a single compressed archive and verify its integrity before publishing.
 */
