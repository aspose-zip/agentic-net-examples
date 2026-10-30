// HOW-TO: Extract a Single File from Password Protected ZIP in C# Using Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path (password‑protected) and output file path
            string inputPath = @"C:\Data\protected.zip";
            string outputFilePath = @"C:\Data\Extracted\file.txt";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Set the password for the protected archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "password123";

            // Open the archive with the specified load options
            using (FileStream fs = File.OpenRead(inputPath))
            using (Archive archive = new Archive(fs, loadOptions))
            {
                // Extract the first entry (index 0) to the output path
                ArchiveEntry entry = archive.Entries[0];
                entry.Extract(outputFilePath);
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
 * 1. When you need to programmatically retrieve a confidential document stored in a password‑protected ZIP file and save it to a specific folder.
 * 2. When an automated deployment script must unpack a single configuration file from an encrypted archive without extracting the entire contents.
 * 3. When a desktop application processes user‑uploaded encrypted ZIPs and extracts only the required report file for further analysis.
 * 4. When a scheduled job pulls a protected backup archive and extracts a log file to monitor system health.
 * 5. When a data migration tool reads a secured ZIP and extracts a single CSV file to import into a database.
 */
