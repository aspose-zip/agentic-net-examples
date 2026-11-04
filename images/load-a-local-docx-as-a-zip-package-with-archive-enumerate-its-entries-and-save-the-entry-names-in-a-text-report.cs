// HOW-TO: List All Files Inside a DOCX Archive and Save to Text in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.docx";
        string outputPath = "output/report.txt";

        // Ensure any runtime exception is caught and reported
        try
        {
            // Verify the input DOCX file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold entry names
            List<string> entryNames = new List<string>();

            // Open the DOCX as a ZIP archive and enumerate entries
            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    entryNames.Add(entry.Name);
                }
            }

            // Write the entry names to the text report
            File.WriteAllLines(outputPath, entryNames);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit the internal structure of a Word document to verify that required parts like images or custom XML are present.
 * 2. When you want to generate a quick inventory of all files stored in a DOCX for documentation or compliance reporting.
 * 3. When you are building a tool that extracts metadata about embedded resources without opening the document in Word.
 * 4. When you need to compare the contents of two DOCX files by listing their entries side‑by‑side.
 * 5. When you are troubleshooting corrupted Word files by checking which package entries are missing or malformed.
 */
