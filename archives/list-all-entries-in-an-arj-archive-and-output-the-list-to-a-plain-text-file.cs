// HOW-TO: List All Files in an ARJ Archive to Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.arj";
        string outputPath = "output/entries.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Open the ARJ archive
            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                // Create a writer for the output text file
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                {
                    // List each entry name in the archive
                    foreach (var entry in archive.Entries)
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
 * 1. When you need to generate an inventory of every file inside an ARJ archive for documentation or auditing purposes.
 * 2. When you want to create a simple manifest that can be shared with team members to verify the contents of a compressed backup.
 * 3. When a build script must log the names of archived resources before extracting them to ensure correct versioning.
 * 4. When a migration tool needs to compare the file list of an ARJ package against a target directory to detect missing or extra files.
 * 5. When an automated reporting system must read archive entries and output them to a text file for further processing or search indexing.
 */
