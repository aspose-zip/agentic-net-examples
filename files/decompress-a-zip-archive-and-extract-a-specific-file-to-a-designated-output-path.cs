// HOW-TO: Extract a Specific File From a ZIP Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Data\sample.zip";
        string outputFilePath = @"C:\Output\extracted.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            using (FileStream fs = File.OpenRead(inputPath))
            using (Archive archive = new Archive(fs))
            {
                ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals("desired.txt", StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine("Specified entry not found in the archive.");
                    return;
                }

                int percentReady = 0;
                entry.ExtractionProgressed += (s, e) =>
                {
                    int percent = (int)(((ulong)percentReady * e.ProceededBytes) / ((ArchiveEntry)s).UncompressedSize);
                    if (percent > percentReady)
                    {
                        Console.WriteLine($"Extraction progress: {percent}%");
                        percentReady = percent;
                    }
                };

                entry.Extract(outputFilePath);
                Console.WriteLine("Extraction completed successfully.");
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
 * 1. When you need to pull a single configuration file out of a large ZIP package during a deployment script.
 * 2. When a desktop application must retrieve a user‑generated document stored inside a compressed archive without extracting the whole archive.
 * 3. When an automated build process has to extract a specific log file from a zipped artifact to a known output directory for analysis.
 * 4. When a server‑side service processes uploaded ZIP files and must safely extract only the required data file while reporting extraction progress.
 * 5. When a data‑migration tool has to locate and extract a particular CSV file from a backup ZIP archive to a target folder.
 */
