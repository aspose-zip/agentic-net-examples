// HOW-TO: List All Files Inside a DOCX Archive and Save to Text in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DOCX file and output report paths
        string inputPath = @"C:\Docs\sample.docx";
        string outputPath = @"C:\Reports\docx_entries.txt";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold entry names
            List<string> entryNames = new List<string>();

            // Load the DOCX as a ZIP archive and enumerate entries
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
 * 1. When you need to audit the internal structure of a Word document to verify embedded images, custom XML parts, or other components without opening the file in Office.
 * 2. When generating an inventory report of all parts inside multiple DOCX files for compliance or migration projects.
 * 3. When debugging a document generation pipeline by comparing expected ZIP entries against the actual ones produced.
 * 4. When extracting a list of media and resource filenames from a DOCX to feed into a content management system.
 * 5. When creating a lightweight documentation index that lists every part of a DOCX for version‑control diff analysis.
 */
