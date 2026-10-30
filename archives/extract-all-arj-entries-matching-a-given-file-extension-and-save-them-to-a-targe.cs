// HOW-TO: Extract Only .txt Files From ARJ Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.arj";
            string outputDir = @"C:\Data\Extracted";
            string extension = ".txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                foreach (ArjEntryPlain entry in archive.Entries)
                {
                    if (entry.Name != null && entry.Name.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.Combine(outputDir, entry.Name);
                        string entryDirectory = Path.GetDirectoryName(destinationPath);
                        if (!string.IsNullOrEmpty(entryDirectory))
                        {
                            Directory.CreateDirectory(entryDirectory);
                        }

                        entry.Extract(destinationPath);
                    }
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
 * 1. When you need to pull only text documents out of a large ARJ backup without extracting the entire archive.
 * 2. When a migration script must filter and extract files with a specific extension from ARJ packages to a new directory structure.
 * 3. When an automated process scans ARJ logs and extracts only .txt logs for further analysis.
 * 4. When a developer wants to selectively unpack configuration files from an ARJ deployment bundle in a C# application.
 * 5. When a data pipeline requires extracting only certain file types from archived ARJ archives to reduce I/O and storage usage.
 */
