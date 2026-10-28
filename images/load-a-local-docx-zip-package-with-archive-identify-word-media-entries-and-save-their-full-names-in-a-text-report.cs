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
            string inputPath = "sample.docx";
            string outputPath = "media_report.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

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
 * 1. When you need to generate an inventory of every image, audio, or video embedded in a Word document using Aspose.Zip for compliance auditing.
 * 2. When a migration tool must list all media resources in DOCX files with Aspose.Zip before moving them to a digital asset management system.
 * 3. When a QA process requires verifying that a DOCX package contains the expected media files after automated document generation by extracting entries with Aspose.Zip.
 * 4. When you want to create a simple text report of all media entries in a DOCX to assist non‑technical users in locating embedded assets using C# and Aspose.Zip.
 * 5. When a batch script processes multiple DOCX archives and needs to extract the full paths of media files for further compression or backup using Aspose.Zip.
 */
