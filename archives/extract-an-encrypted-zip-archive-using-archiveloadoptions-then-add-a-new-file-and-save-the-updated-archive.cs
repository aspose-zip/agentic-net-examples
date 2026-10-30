// HOW-TO: Extract Encrypted ZIP, Add File, and Save Updated Archive in C# (Aspose.ZIP for .NET)
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
            string inputArchivePath = "encrypted.zip";
            string extractionFolder = "extracted";
            string fileToAddPath = "newfile.txt";
            string outputArchivePath = "updated.zip";
            string archivePassword = "password123";

            // Validate input archive
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Validate file to add
            if (!File.Exists(fileToAddPath))
            {
                Console.Error.WriteLine($"File not found: {fileToAddPath}");
                return;
            }

            // Ensure extraction folder exists
            Directory.CreateDirectory(extractionFolder);

            // Ensure output directory exists (if any)
            string outputDir = Path.GetDirectoryName(outputArchivePath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load encrypted archive with password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = archivePassword;

            using (Archive archive = new Archive(inputArchivePath, loadOptions))
            {
                // Extract all entries to the extraction folder
                archive.ExtractToDirectory(extractionFolder);

                // Add a new file to the archive
                archive.CreateEntry("newfile.txt", fileToAddPath);

                // Save the updated archive
                archive.Save(outputArchivePath);
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
 * 1. When you need to programmatically open a password‑protected ZIP, extract its contents, and then include a new document before re‑creating the archive in a .NET application.
 * 2. When an automated backup system must decrypt an existing archive, pull out files for processing, add a log file, and store the refreshed ZIP with the same security.
 * 3. When a secure file‑transfer workflow requires reading an encrypted zip, modifying its payload by inserting a configuration file, and saving the updated package for later distribution.
 * 4. When a desktop utility has to unpack a protected archive, modify its contents by adding a report, and re‑zip it without losing the original password protection.
 * 5. When a cloud service needs to handle user‑uploaded encrypted ZIPs, extract data for validation, append a metadata file, and generate a new archive for storage.
 */
