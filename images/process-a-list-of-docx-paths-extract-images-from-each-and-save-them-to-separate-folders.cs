// HOW-TO: Extract Images from Multiple DOCX Files to Separate Folders in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded list of DOCX files to process
            string[] docxPaths = new string[]
            {
                @"C:\Docs\Document1.docx",
                @"C:\Docs\Document2.docx"
            };

            foreach (string docxPath in docxPaths)
            {
                if (!File.Exists(docxPath))
                {
                    Console.Error.WriteLine($"File not found: {docxPath}");
                    continue;
                }

                // Create an output folder for each DOCX based on its file name
                string docNameWithoutExt = Path.GetFileNameWithoutExtension(docxPath);
                string outputFolder = Path.Combine(@"C:\ExtractedImages", docNameWithoutExt);
                Directory.CreateDirectory(outputFolder);

                using (FileStream docxStream = File.Open(docxPath, FileMode.Open, FileAccess.Read))
                {
                    using (Archive archive = new Archive(docxStream))
                    {
                        foreach (ArchiveEntry entry in archive.Entries)
                        {
                            if (entry.Name.StartsWith("word/media/"))
                            {
                                string fileName = Path.GetFileName(entry.Name);
                                string destinationPath = Path.Combine(outputFolder, fileName);
                                entry.Extract(destinationPath);
                                Console.WriteLine($"Extracted {fileName} to {destinationPath}");
                            }
                        }
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
 * 1. When you need to batch‑process a collection of Word documents and pull out every embedded picture for reuse in a content‑management system.
 * 2. When a migration project requires extracting all images from DOCX files to store them in a centralized media library organized by document name.
 * 3. When an automated reporting tool must harvest charts and photos from generated DOCX reports and save them to individual folders for further analysis.
 * 4. When a legal‑compliance workflow has to archive every illustration from contract documents separately to meet evidence‑preservation rules.
 * 5. When a desktop application wants to let users select several DOCX files and quickly export all their graphics without opening each file manually.
 */
