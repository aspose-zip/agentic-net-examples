// HOW-TO: Extract Encrypted Multi‑Volume ZIP Archive With Password In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string mainArchivePath = @"C:\Archives\EncryptedMultiVolume.zip";
            string outputDirectory = @"C:\Extracted";

            // Verify input archive exists
            if (!File.Exists(mainArchivePath))
            {
                Console.Error.WriteLine($"File not found: {mainArchivePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Collect split segment files (exclude the main .zip file)
            string archiveFolder = Path.GetDirectoryName(mainArchivePath) ?? "";
            string archiveBaseName = Path.GetFileNameWithoutExtension(mainArchivePath);
            string[] segmentFiles = Directory.GetFiles(archiveFolder, $"{archiveBaseName}.*")
                                            .Where(f => !f.Equals(mainArchivePath, StringComparison.OrdinalIgnoreCase))
                                            .OrderBy(f => f)
                                            .ToArray();

            // Load options with password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "ZipPass!";

            // Open the multi‑volume encrypted ZIP archive
            using (Archive archive = new Archive(mainArchivePath, segmentFiles, loadOptions))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDirectory);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically extract a password‑protected split ZIP that was created for secure backup distribution.
 * 2. When your application must read and unpack a multi‑part encrypted archive received from a partner without manual password entry.
 * 3. When automating the deployment of confidential files stored across several ZIP segments that require a decryption password.
 * 4. When processing large encrypted archives that exceed single‑file size limits and are stored as split volumes on a server.
 * 5. When building a C# utility to validate and extract encrypted multi‑volume ZIP archives as part of a data migration workflow.
 */
