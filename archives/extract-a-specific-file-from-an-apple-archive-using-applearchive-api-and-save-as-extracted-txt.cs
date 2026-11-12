// HOW-TO: Extract Specific File from ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\sample.zip";
            string outputPath = @"C:\Data\extracted.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (Archive archive = new Archive(fs))
                {
                    ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals("target.txt", StringComparison.OrdinalIgnoreCase));

                    if (entry != null)
                    {
                        entry.Extract(outputPath);
                        Console.WriteLine($"Extracted '{entry.Name}' to '{outputPath}'.");
                    }
                    else
                    {
                        Console.WriteLine("Specified entry not found in the archive.");
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
 * 1. When you need to pull a single configuration file out of a large ZIP package during application startup.
 * 2. When a web service must retrieve a particular document from a user‑uploaded archive without extracting the entire contents.
 * 3. When an automated build script has to extract a generated report (e.g., target.txt) from a zip produced by another tool.
 * 4. When a desktop utility offers a “Save As” feature that lets users download only the selected file from a compressed bundle.
 * 5. When a migration process requires reading a specific data file from an archived backup before moving it to a new system.
 */
