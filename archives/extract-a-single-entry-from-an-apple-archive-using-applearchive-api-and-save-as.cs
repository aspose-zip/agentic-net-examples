// HOW-TO: Extract Specific File From ZIP Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string entryName = "document.txt";
            string outputPath = @"C:\Output\document.txt";

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
                    ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name == entryName);
                    if (entry == null)
                    {
                        Console.Error.WriteLine($"Entry not found: {entryName}");
                        return;
                    }

                    entry.Extract(outputPath);
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
 * 1. When you need to programmatically pull a single document out of a large ZIP package in a .NET application.
 * 2. When automating the processing of uploaded ZIP files and you must retrieve only a specific text file for further analysis.
 * 3. When building a backup restoration tool that extracts a particular configuration file from a compressed archive without decompressing everything.
 * 4. When integrating with a third‑party system that supplies ZIP bundles and you have to extract a required entry to a designated output folder.
 * 5. When creating a batch job that validates the presence of a specific file inside a ZIP and extracts it if found.
 */
