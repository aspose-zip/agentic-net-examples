// HOW-TO: Extract Password-Protected Multi-Volume 7z Archive to Secure Folder in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing the 7z volumes
            string volumesDirectory = @"C:\Input\Volumes";
            // Hardcoded output directory for extraction
            string outputDirectory = @"C:\SecureOutput";

            // Verify the input directory exists
            if (!Directory.Exists(volumesDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {volumesDirectory}");
                return;
            }

            // Retrieve all volume files (e.g., archive.7z.001, archive.7z.002, ...)
            string[] volumeFiles = Directory.GetFiles(volumesDirectory, "*.7z.*")
                .OrderBy(path =>
                {
                    // Extract numeric part after the last dot
                    string fileName = Path.GetFileName(path);
                    string[] parts = fileName.Split('.');
                    string numberPart = parts.Last();
                    if (int.TryParse(numberPart, out int num))
                        return num;
                    return int.MaxValue;
                })
                .ToArray();

            // Ensure each volume file exists before proceeding
            foreach (string volumePath in volumeFiles)
            {
                if (!File.Exists(volumePath))
                {
                    Console.Error.WriteLine($"File not found: {volumePath}");
                    return;
                }
            }

            // Create the output directory unconditionally
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Password for the encrypted 7z archive
            string password = "YourPasswordHere";

            // Open the multi‑volume 7z archive with the supplied password
            using (SevenZipArchive archive = new SevenZipArchive(volumeFiles, password))
            {
                // Extract all entries to the secure output directory
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
 * 1. When you need to programmatically unpack a split 7z backup that is encrypted and place the files in a protected directory.
 * 2. When an application must read a large encrypted archive split across several .001, .002 files and extract its contents without manual reassembly.
 * 3. When a deployment script has to automatically decrypt and extract multi‑volume 7z packages supplied by a vendor into a safe output location.
 * 4. When a backup restoration tool must verify each volume exists, order them correctly, and extract the data using a known password.
 * 5. When a secure file‑transfer system stores encrypted archives in multiple parts and the receiving service must combine and extract them to a restricted folder.
 */
