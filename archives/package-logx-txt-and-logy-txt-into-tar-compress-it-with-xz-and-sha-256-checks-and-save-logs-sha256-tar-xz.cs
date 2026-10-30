// HOW-TO: Create TAR.XZ Archive With SHA256 Checksums For Log Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "logX.txt";
            string inputPath2 = "logY.txt";
            string outputPath = "logs_sha256.tar.xz";

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

            // Compute SHA-256 checksums for the input files
            StringBuilder checksumBuilder = new StringBuilder();

            using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(fs1);
                string hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                checksumBuilder.AppendLine($"{Path.GetFileName(inputPath1)}  {hashString}");
            }

            using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(fs2);
                string hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                checksumBuilder.AppendLine($"{Path.GetFileName(inputPath2)}  {hashString}");
            }

            // Prepare checksum content as a stream
            byte[] checksumBytes = Encoding.UTF8.GetBytes(checksumBuilder.ToString());
            using (MemoryStream checksumStream = new MemoryStream(checksumBytes, writable: false))
            {
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (TarArchive archive = new TarArchive())
                {
                    // Add the original log files
                    archive.CreateEntry(Path.GetFileName(inputPath1), inputPath1);
                    archive.CreateEntry(Path.GetFileName(inputPath2), inputPath2);

                    // Add the checksum file
                    archive.CreateEntry("checksums.txt", checksumStream);

                    // Save the TAR archive compressed with XZ
                    archive.SaveXzCompressed(outputPath);
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
 * 1. When you need to bundle multiple server log files into a single compressed archive for efficient storage and transfer, while also generating SHA‑256 checksums to verify integrity.
 * 2. When automating nightly backups of application logs, you can create a TAR archive, compress it with XZ for minimal size, and embed checksum data to ensure the backup hasn't been corrupted.
 * 3. When sending log files to a remote support team, you can package them into a .tar.xz file and provide SHA‑256 hashes so the recipient can confirm the files are unchanged.
 * 4. When implementing a compliance audit that requires archived logs to be tamper‑evident, you can archive and compress the logs and store their SHA‑256 checksums alongside the archive.
 * 5. When developing a C# utility that prepares log bundles for long‑term retention, you can use Aspose.Zip to create a TAR.XZ archive and compute SHA‑256 hashes in a single automated step.
 */
