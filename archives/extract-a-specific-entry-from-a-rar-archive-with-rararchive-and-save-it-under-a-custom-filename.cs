// HOW-TO: Extract Specific File from RAR Archive to Custom Path in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Rar;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.rar";
        string outputPath = "output/extractedFile.txt";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Name of the entry to extract (case‑insensitive match)
            string entryName = "folder/file.txt";

            // Open the RAR archive
            using (RarArchive archive = new RarArchive(inputPath))
            {
                // Locate the specific entry
                RarArchiveEntry entry = archive.Entries
                    .FirstOrDefault(e => string.Equals(e.Name, entryName, StringComparison.OrdinalIgnoreCase));

                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry to the desired output file
                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    entry.Extract(outputStream);
                }
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
 * 1. When you need to pull a single document out of a large RAR backup and save it with a different name or location in a C# application.
 * 2. When an automated process must verify the presence of a particular file inside a RAR package before further processing.
 * 3. When a desktop tool extracts a configuration file from a compressed distribution archive to a user‑specified folder.
 * 4. When a server‑side service extracts a log file from a received RAR attachment and stores it in a monitoring directory.
 * 5. When a migration script retrieves a specific resource from a legacy RAR archive and writes it to a new directory structure.
 */
