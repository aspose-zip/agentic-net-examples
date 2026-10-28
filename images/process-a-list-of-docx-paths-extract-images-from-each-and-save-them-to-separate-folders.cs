// HOW-TO: Extract Images from Multiple DOCX Files to Separate Folders in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded list of DOCX files to process
        string[] docxPaths = new string[]
        {
            "C:\\Docs\\file1.docx",
            "C:\\Docs\\file2.docx"
        };

        // Base output directory for extracted images
        string outputBase = "C:\\ExtractedImages";

        // Ensure base output directory exists
        Directory.CreateDirectory(outputBase);

        try
        {
            foreach (string docxPath in docxPaths)
            {
                // Verify input DOCX file exists
                if (!File.Exists(docxPath))
                {
                    Console.Error.WriteLine($"File not found: {docxPath}");
                    continue;
                }

                // Create a subfolder named after the DOCX file (without extension)
                string docName = Path.GetFileNameWithoutExtension(docxPath);
                string outputFolder = Path.Combine(outputBase, docName);
                Directory.CreateDirectory(outputFolder);

                // Open the DOCX (ZIP) archive
                using (FileStream zipStream = File.Open(docxPath, FileMode.Open, FileAccess.Read))
                {
                    using (Archive archive = new Archive(zipStream))
                    {
                        // Iterate through entries and extract image files
                        foreach (ArchiveEntry entry in archive.Entries)
                        {
                            // Images are stored under the "word/media/" folder inside a DOCX
                            if (entry.Name.StartsWith("word/media/"))
                            {
                                string imageFileName = Path.GetFileName(entry.Name);
                                string destinationPath = Path.Combine(outputFolder, imageFileName);

                                // Extract the image entry to the destination file
                                entry.Extract(destinationPath);
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
 * 1. When you need to batch‑process a collection of Word documents and pull out every embedded picture for archival or further analysis.
 * 2. When a document‑management system must store each DOCX’s images in its own directory to keep file organization consistent.
 * 3. When you are building a migration tool that extracts media from legacy DOCX files before converting them to another format.
 * 4. When an automated QA script must verify that all images inside a set of DOCX files are present and correctly extracted.
 * 5. When a reporting application has to generate a gallery of images per document by extracting them into separate folders at runtime.
 */
