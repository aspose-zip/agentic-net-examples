// HOW-TO: Extract Encrypted Multi‑Volume 7z Archive with Password in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths for the three encrypted 7z volumes
            string volumePath1 = @"C:\Archives\archive.7z.001";
            string volumePath2 = @"C:\Archives\archive.7z.002";
            string volumePath3 = @"C:\Archives\archive.7z.003";

            // Verify each volume exists
            if (!File.Exists(volumePath1))
            {
                Console.Error.WriteLine($"File not found: {volumePath1}");
                return;
            }
            if (!File.Exists(volumePath2))
            {
                Console.Error.WriteLine($"File not found: {volumePath2}");
                return;
            }
            if (!File.Exists(volumePath3))
            {
                Console.Error.WriteLine($"File not found: {volumePath3}");
                return;
            }

            // Password for the encrypted volumes
            string password = "MySecretPassword";

            // Output directory for extracted files
            string outputPath = @"C:\Extracted\extracted_7z";

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑volume 7z archive using the volume‑path constructor
            string[] volumePaths = new string[] { volumePath1, volumePath2, volumePath3 };
            using (SevenZipArchive archive = new SevenZipArchive(volumePaths, password))
            {
                // Extract all entries to the specified directory
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you receive a split 7z backup that is password‑protected and need to programmatically combine and extract its contents in a .NET application.
 * 2. When an automated deployment script must unpack encrypted multi‑part archives stored on a file server before installing software.
 * 3. When a data‑migration tool has to read large encrypted 7z volumes and write the extracted files to a specific output folder.
 * 4. When a security‑compliant system requires extracting confidential documents from a password‑secured multi‑volume archive without manual intervention.
 * 5. When a cloud‑based service processes user‑uploaded split 7z archives and needs to extract them to a temporary directory for further processing.
 */
