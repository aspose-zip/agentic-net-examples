// HOW-TO: Create TAR.XZ Archive With SHA-256 Checksum From Nested Folder In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory and output archive paths
            string inputDirectory = "nested_folder";
            string outputArchivePath = "output/nested_folder.tar.xz";

            // Validate input directory existence
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Create TAR archive and add files recursively
            using (TarArchive archive = new TarArchive())
            {
                string[] files = Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Compute entry name relative to the input directory, using forward slashes
                    string entryName = Path.GetRelativePath(inputDirectory, filePath).Replace('\\', '/');
                    archive.CreateEntry(entryName, filePath);
                }

                // Save the archive compressed with XZ
                archive.SaveXzCompressed(outputArchivePath);
            }

            // Compute SHA-256 checksum of the created archive
            using (FileStream stream = new FileStream(outputArchivePath, FileMode.Open, FileAccess.Read))
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(stream);
                    string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                    Console.WriteLine($"SHA-256: {hashString}");
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
 * 1. When you need to package a project's source files preserving directory hierarchy into a TAR archive, compress it with XZ, and verify integrity with a SHA‑256 hash in a C# build script.
 * 2. When deploying a Linux application from a Windows CI pipeline, you can use this code to generate a .tar.xz distribution bundle and provide a checksum for secure download verification.
 * 3. When backing up configuration files on a server, the snippet creates a compressed TAR.XZ archive and calculates its SHA‑256 hash so you can detect corruption during restoration.
 * 4. When creating release assets for an open‑source library, you can automate the creation of a .tar.xz package of the source tree and include the hash in the release notes.
 * 5. When implementing a custom installer that needs to bundle nested resources into a single compressed file and later validate it before extraction, this code provides the necessary archive and checksum generation.
 */
