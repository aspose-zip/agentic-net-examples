// HOW-TO: Extract Encrypted Multi‑Volume 7z Archive to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = @"C:\Data\SevenZipParts";
            string outputDirectory = @"C:\Data\ExtractedSevenZip";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory's parent exists and create output directory
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));
            Directory.CreateDirectory(outputDirectory);

            // Collect all parts of the multi‑volume 7z archive, ordered correctly
            string[] parts = Directory.GetFiles(inputDirectory, "*.7z.*")
                                      .OrderBy(f => f)
                                      .ToArray();

            // Verify that at least one part was found
            if (parts.Length == 0)
            {
                Console.Error.WriteLine($"No archive parts found in: {inputDirectory}");
                return;
            }

            // Verify each part file exists (redundant but follows safety rule)
            foreach (string part in parts)
            {
                if (!File.Exists(part))
                {
                    Console.Error.WriteLine($"File not found: {part}");
                    return;
                }
            }

            // Open the multi‑volume 7z archive
            using (SevenZipArchive archive = new SevenZipArchive(parts))
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
 * 1. When you receive a password‑protected split 7z backup and need to programmatically combine and extract its contents to a specific directory in a .NET application.
 * 2. When an automated deployment script must unpack a multi‑part encrypted archive containing configuration files before starting a service.
 * 3. When a data‑migration tool has to read several .7z.* segments, supply the decryption password, and write the extracted data to a target folder on Windows.
 * 4. When a secure file‑transfer system stores large files as encrypted 7z volumes and your C# code must reconstruct and extract them for processing.
 * 5. When a backup restoration utility must validate the presence of all archive parts, handle missing files gracefully, and extract the protected archive to a user‑defined location.
 */
