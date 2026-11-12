// HOW-TO: Extract All File Names From a ZIP Archive to Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.zip";
            string outputPath = "entry_names.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive archive = new Archive(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        writer.WriteLine(entry.Name);
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
 * 1. When you need to generate an inventory list of all files inside a ZIP package for documentation or auditing purposes.
 * 2. When a deployment script must verify the presence of expected resources by reading entry names without extracting the archive.
 * 3. When a backup system wants to log the contents of each archived backup to a searchable text report.
 * 4. When a file‑management tool needs to display a simple list of archive entries to the user without loading the full file data.
 * 5. When you are building a compliance check that compares the names of files in a ZIP against a whitelist stored in a text file.
 */
