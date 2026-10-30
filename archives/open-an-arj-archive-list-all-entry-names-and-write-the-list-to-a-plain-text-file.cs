// HOW-TO: List All Files in an ARJ Archive and Save to Text File in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.arj";

            // Hardcoded output text file path (includes directory)
            string outputPath = "output/entries.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ARJ archive
            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                // Collect entry names
                string[] entryNames = new string[archive.Entries.Count];
                for (int i = 0; i < archive.Entries.Count; i++)
                {
                    entryNames[i] = archive.Entries[i].Name;
                }

                // Write the list of entry names to the text file
                File.WriteAllLines(outputPath, entryNames);
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
 * 1. When you need to audit the contents of an ARJ backup without extracting the files, you can list the entry names and export them to a text report.
 * 2. When building a migration tool that moves files from legacy ARJ archives to a new system, generating a plain‑text inventory helps verify which files are present before processing.
 * 3. When creating a documentation generator that includes a catalog of archived resources, extracting the file list to a .txt file provides an easy reference for developers and users.
 * 4. When troubleshooting compression issues in an ARJ archive, writing the entry names to a log file lets you quickly identify missing or corrupted members.
 * 5. When automating a nightly scan of incoming ARJ packages, saving the list of entries to a text file enables downstream scripts to decide which files to extract or ignore.
 */
