// HOW-TO: Extract a Specific File from an ALZ Archive in C# (Aspose.ZIP for .NET)
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
            string archivePath = "input.alz";
            string entryName = "file.txt";
            string outputFilePath = "output/file.txt";

            // Verify input archive exists
            if (!File.Exists(archivePath))
            {
                Console.Error.WriteLine($"File not found: {archivePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Open the ALZ archive
            using (Archive archive = new Archive(archivePath))
            {
                // Locate the desired entry
                var entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry to the specified file path
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
 * 1. When you need to retrieve a single text file from a compressed ALZ backup to process it in your .NET application.
 * 2. When a deployment script must unpack a configuration file stored inside an ALZ package to a target directory on a Windows server.
 * 3. When a data migration tool extracts a specific log file from an ALZ archive before importing its contents into a database.
 * 4. When an automated build pipeline extracts a resource file from an ALZ archive to include it in the final product bundle.
 * 5. When a user‑facing utility allows end‑users to select and extract a particular document from an ALZ archive without decrypting the whole archive.
 */
