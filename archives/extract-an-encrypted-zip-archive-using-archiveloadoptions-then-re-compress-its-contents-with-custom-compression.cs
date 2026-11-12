// HOW-TO: Extract Encrypted ZIP and Recompress with Bzip2 in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string inputPath = "encrypted.zip";
            string outputPath = "recompressed.zip";
            string extractDir = "extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Load encrypted ZIP with password
            using (Archive archive = new Archive(inputPath, new ArchiveLoadOptions() { DecryptionPassword = "password123" }))
            {
                // Extract each entry to the temporary folder
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.IsDirectory)
                        continue;

                    string destinationFile = Path.Combine(extractDir, entry.Name);
                    using (FileStream fileStream = File.Open(destinationFile, FileMode.Create, FileAccess.Write))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            // Re‑compress extracted files with custom compression (Bzip2 in this example)
            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            using (Archive newArchive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(extractDir);
                newArchive.CreateEntries(dirInfo);
                newArchive.Save(outputStream);
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
 * 1. When you need to read a password‑protected ZIP file, extract its files, and then create a new archive with a different compression algorithm for better storage efficiency.
 * 2. When migrating legacy encrypted archives to a modern compression format such as Bzip2 to improve compatibility with other systems.
 * 3. When processing secure client uploads that arrive as encrypted ZIPs and you must re‑package the contents for downstream services that require a specific compression level.
 * 4. When automating a backup workflow that decrypts archived logs, extracts them, and recompresses them with a custom setting to reduce disk usage.
 * 5. When building a data‑pipeline that normalizes various encrypted ZIP inputs into a single, uniformly compressed archive for archiving or transmission.
 */
