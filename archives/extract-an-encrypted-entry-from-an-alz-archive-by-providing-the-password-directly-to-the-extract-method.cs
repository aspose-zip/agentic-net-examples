// HOW-TO: Extract Encrypted File From ALZ Archive With Password In C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Archives\encrypted.alz";
            string outputPath = @"C:\Extracted\secret.txt";
            string entryName = "secret.txt";
            string password = "MyPassword";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ALZ archive
            using (Archive archive = new Archive(inputPath))
            {
                // Locate the encrypted entry
                ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry using the provided password
                entry.Extract(outputPath, password);
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
 * 1. When you need to programmatically retrieve a confidential document stored in an encrypted ALZ archive during a deployment script.
 * 2. When a desktop application must automatically extract a password‑protected log file from an ALZ backup without user interaction.
 * 3. When a server process has to read a secured configuration file packaged in an ALZ archive as part of a scheduled task.
 * 4. When integrating Aspose.Zip in a C# service to pull a specific encrypted entry from an ALZ archive received via email.
 * 5. When building a migration tool that extracts selected encrypted files from legacy ALZ archives for import into a new system.
 */
