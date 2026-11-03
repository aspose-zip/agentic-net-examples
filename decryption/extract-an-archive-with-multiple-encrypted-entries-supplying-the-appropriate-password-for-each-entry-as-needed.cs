// HOW-TO: Extract Multiple Password‑Protected Files From a ZIP Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = @"C:\Data\encryptedArchive.zip";

            // Hardcoded output file paths for each entry
            string outputPathEntry1 = @"C:\Data\Extracted\file1.txt";
            string outputPathEntry2 = @"C:\Data\Extracted\file2.txt";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathEntry1));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathEntry2));

            // Open the archive (no archive-level password needed)
            using (Archive archive = new Archive(inputPath))
            {
                // Extract first entry with its specific password
                ArchiveEntry entry1 = archive.Entries[0];
                entry1.Extract(outputPathEntry1, "password1");

                // Extract second entry with its specific password
                ArchiveEntry entry2 = archive.Entries[1];
                entry2.Extract(outputPathEntry2, "password2");
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
 * 1. When you need to programmatically retrieve confidential documents stored in a ZIP where each file uses a different password.
 * 2. When an application must batch‑process encrypted log files delivered in a single archive without a global archive password.
 * 3. When a deployment script has to unpack sensitive configuration files that were individually protected for security compliance.
 * 4. When a data migration tool extracts user‑specific reports from a ZIP that applies separate passwords per entry.
 * 5. When a backup restoration utility reads a ZIP backup where each component was encrypted with its own password.
 */
