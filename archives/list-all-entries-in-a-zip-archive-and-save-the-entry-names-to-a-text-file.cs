// HOW-TO: List All Files in a ZIP Archive and Export Names to Text in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputZipPath = "input.zip";
        string outputTextPath = "output.txt";

        try
        {
            // Verify that the input ZIP file exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputTextPath);
            if (!string.IsNullOrEmpty(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // List entries in the ZIP archive
            List<string> entryNames = new List<string>();
            using (Archive archive = new Archive(inputZipPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    entryNames.Add(entry.Name);
                }
            }

            // Save entry names to a text file
            using (StreamWriter writer = new StreamWriter(outputTextPath, false, Encoding.UTF8))
            {
                foreach (string name in entryNames)
                {
                    writer.WriteLine(name);
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
 * 1. When you need to generate an inventory of all files inside a ZIP package for reporting or validation purposes.
 * 2. When a build pipeline must verify the contents of a distribution archive before publishing the package.
 * 3. When a desktop application wants to display a searchable list of archived documents without extracting them.
 * 4. When a server‑side service logs the names of uploaded ZIP files to audit which resources were submitted.
 * 5. When a migration script extracts the file list from legacy ZIP backups to compare against a new storage system.
 */
