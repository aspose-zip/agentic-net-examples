// HOW-TO: Extract Images From DOCX Zip Package To Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Docs\sample.docx";
            string outputDir = @"C:\Docs\ExtractedImages";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (FileStream zipFile = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipFile))
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name.StartsWith("word/media/") && !entry.IsDirectory)
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    entryStream.CopyTo(ms);
                                    byte[] data = ms.ToArray();

                                    string fileName = Path.GetFileName(entry.Name);
                                    string outputPath = Path.Combine(outputDir, fileName);
                                    File.WriteAllBytes(outputPath, data);
                                }
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
 * 1. When you need to programmatically retrieve all embedded pictures from a Word document for further processing or analysis.
 * 2. When building a migration tool that extracts media assets from DOCX files to store them in a separate image repository.
 * 3. When creating a document auditing system that validates the presence and format of images inside Office Open XML packages.
 * 4. When developing a batch job that unpacks multiple DOCX files and saves each image with its original file extension for reuse in web content.
 * 5. When implementing a feature that allows users to download individual images extracted from a DOCX without opening the document manually.
 */
