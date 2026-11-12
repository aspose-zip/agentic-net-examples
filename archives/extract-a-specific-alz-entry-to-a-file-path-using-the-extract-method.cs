// HOW-TO: Extract Specific File from ALZ Archive to Disk in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ALZ archive path
            string inputPath = @"C:\Data\sample.alz";
            // Hardcoded output file path for the extracted entry
            string outputPath = @"C:\Output\extractedFile.txt";

            // Verify the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ALZ archive for reading
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (Archive archive = new Archive(fileStream))
            {
                // Locate the specific entry by its name (adjust the name as needed)
                ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals("file.txt", StringComparison.OrdinalIgnoreCase));

                if (entry == null)
                {
                    Console.WriteLine("Specified entry not found in the archive.");
                    return;
                }

                // Extract the entry to the desired file path
                entry.Extract(outputPath);
                Console.WriteLine($"Entry extracted to: {outputPath}");
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
 * 1. When you need to pull a single text file out of an ALZ compressed package and save it to a known location in a .NET application.
 * 2. When a deployment script must verify the presence of a specific entry inside an ALZ archive before processing it further.
 * 3. When you are building a data import tool that reads configuration files stored inside ALZ archives and extracts them to a working directory.
 * 4. When you want to programmatically retrieve a log file from an ALZ backup without extracting the entire archive in C#.
 * 5. When a user interface allows end‑users to select an ALZ archive and automatically extracts a chosen document to a predefined output folder.
 */
