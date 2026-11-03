// HOW-TO: Extract Password Protected ZIP Using Known Password In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path (password‑protected)
            string inputPath = @"C:\Data\protected.zip";

            // Hardcoded output directory for extraction
            string outputPath = @"C:\Data\Extracted";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ZIP file stream
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Set the password for decryption
                ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                loadOptions.DecryptionPassword = "Password123";

                // Load the archive with the provided password
                using (Archive archive = new Archive(zipStream, loadOptions))
                {
                    // Extract all entries to the output directory
                    archive.ExtractToDirectory(outputPath);
                }
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
 * 1. When you need to automatically unpack a user‑provided encrypted ZIP file on a server using a known password.
 * 2. When a desktop application must batch‑extract confidential documents from a protected archive after verifying the file exists.
 * 3. When a scheduled job processes incoming ZIP backups that are secured with a single password and stores the contents in a specific folder.
 * 4. When integrating a file‑upload feature that accepts password‑protected ZIPs and extracts them for further processing without exposing the password.
 * 5. When migrating legacy data packaged in encrypted ZIP archives to a new system and you need to programmatically decrypt and extract them in C#.
 */
