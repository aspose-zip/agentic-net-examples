// HOW-TO: Extract Files from Password Protected Split ZIP Archive in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths and password
            string mainArchivePath = @"C:\Archives\myarchive.zip";
            string outputDirectory = @"C:\Extracted";
            string password = "myPassword";

            // Verify main archive exists
            if (!File.Exists(mainArchivePath))
            {
                Console.Error.WriteLine($"File not found: {mainArchivePath}");
                return;
            }

            // Collect split segment files (e.g., .z01, .z02, ...) in the same folder
            string archiveFolder = Path.GetDirectoryName(mainArchivePath);
            string[] splitSegments = Directory.GetFiles(archiveFolder, "*.zip.*")
                                              .OrderBy(f => f)
                                              .ToArray();

            // Verify each split segment exists
            foreach (string segment in splitSegments)
            {
                if (!File.Exists(segment))
                {
                    Console.Error.WriteLine($"File not found: {segment}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑volume archive with the password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = password;

            using (Archive archive = new Archive(mainArchivePath, splitSegments, loadOptions))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to programmatically unpack a large encrypted ZIP that was divided into .z01, .z02 parts for distribution.
 * 2. When an application must read confidential backup data stored in a multi‑volume archive that requires a decryption password.
 * 3. When a deployment script has to combine and extract split archives received from a secure file‑transfer service.
 * 4. When you want to automate the extraction of encrypted log archives that were split to fit on removable media.
 * 5. When a .NET service must validate and unpack a password‑protected archive sent by a third‑party vendor in multiple parts.
 */
