// HOW-TO: List All Media Files Inside a DOCX Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.docx";
            string outputPath = "report.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            List<string> mediaEntries = new List<string>();

            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name.StartsWith("word/media/", StringComparison.OrdinalIgnoreCase))
                    {
                        mediaEntries.Add(entry.Name);
                    }
                }
            }

            File.WriteAllLines(outputPath, mediaEntries);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit which images, audio, or video files are embedded in a Word document, you can extract the full paths of all word/media entries to a report.
 * 2. When building a document management system that validates or indexes media assets inside uploaded DOCX files, this code generates a list of those assets for further processing.
 * 3. When troubleshooting missing or corrupted media in a DOCX, developers can use this snippet to quickly identify which media files are actually present in the package.
 * 4. When creating a compliance check that ensures no prohibited media types are stored in Word documents, the script extracts the media entry names for policy evaluation.
 * 5. When automating bulk analysis of multiple DOCX files to catalog embedded pictures or videos, you can run this code to produce a text file listing each media entry for every document.
 */
