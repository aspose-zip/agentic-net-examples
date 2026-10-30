// HOW-TO: List ARJ Archive Entries with Compressed Sizes to Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ARJ archive path
            string inputPath = @"C:\Data\sample.arj";
            // Hardcoded output summary file path
            string outputPath = @"C:\Data\ArjSummary.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open ARJ archive and enumerate entries
            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(outputPath, false))
                {
                    foreach (ArjEntryPlain entry in archive.Entries)
                    {
                        writer.WriteLine($"{entry.Name}\t{entry.CompressedSize}");
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
 * 1. When you need to generate an inventory of files inside an ARJ archive for reporting or auditing purposes.
 * 2. When you want to log the compressed sizes of ARJ archive members to monitor storage savings.
 * 3. When building a migration tool that must verify the contents of legacy ARJ archives before converting them to a newer format.
 * 4. When creating a documentation script that extracts file names and compressed sizes from ARJ packages to include in user manuals.
 * 5. When troubleshooting archive corruption by comparing expected entry names and sizes against a generated summary.
 */
