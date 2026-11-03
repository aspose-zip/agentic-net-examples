// HOW-TO: Extract Encrypted ZIP and Save Total Uncompressed Size in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputZipPath = @"C:\Data\encrypted.zip";
            string outputFolderPath = @"C:\Data\Extracted";
            string resultFilePath = @"C:\Data\extracted_total_size.txt";
            string zipPassword = "Password123";

            // Validate input ZIP file
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(outputFolderPath);
            Directory.CreateDirectory(Path.GetDirectoryName(resultFilePath));

            // Load encrypted ZIP with password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
            {
                DecryptionPassword = zipPassword
            };

            using (FileStream zipStream = File.Open(inputZipPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream, loadOptions))
            {
                ulong totalSize = 0UL;

                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    string destinationPath = Path.Combine(outputFolderPath, entry.Name);
                    string destinationDir = Path.GetDirectoryName(destinationPath);
                    if (!string.IsNullOrEmpty(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    entry.Extract(destinationPath);
                    totalSize += entry.UncompressedSize;
                }

                File.WriteAllText(resultFilePath, totalSize.ToString());
                Console.WriteLine($"Total size of extracted files: {totalSize} bytes");
                Console.WriteLine($"Result saved to: {resultFilePath}");
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
 * 1. When a developer needs to unlock a password‑protected ZIP, extract its files, and record the total uncompressed size without exposing any file contents.
 * 2. When building a compliance audit tool that must verify the cumulative size of data extracted from an encrypted archive and store that metric locally.
 * 3. When creating a backup validation script that extracts user‑owned ZIP files and logs the overall extracted size for reporting.
 * 4. When implementing a data‑ingestion pipeline that must decrypt archives, extract files to a working folder, and keep only the aggregate size as a lightweight summary.
 * 5. When developing a desktop utility that extracts confidential ZIP packages and writes the total extracted size to a text file while keeping all other information private.
 */
