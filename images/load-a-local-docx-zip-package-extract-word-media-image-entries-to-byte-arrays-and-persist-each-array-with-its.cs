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
            // Hardcoded input DOCX (ZIP) file and output directory
            string inputPath = @"C:\Docs\sample.docx";
            string outputDir = @"C:\Docs\ExtractedImages";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            // Open the DOCX package as a ZIP archive
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            {
                // Iterate through all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Look for image entries under word/media/
                    if (!entry.IsDirectory && entry.Name.StartsWith("word/media/", StringComparison.OrdinalIgnoreCase))
                    {
                        // Determine output file path preserving original file name and extension
                        string fileName = Path.GetFileName(entry.Name);
                        string outputPath = Path.Combine(outputDir, fileName);

                        // Read entry content into a byte array
                        byte[] imageBytes;
                        using (MemoryStream ms = new MemoryStream())
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.CopyTo(ms);
                            imageBytes = ms.ToArray();
                        }

                        // Write the byte array to the output file
                        File.WriteAllBytes(outputPath, imageBytes);
                        Console.WriteLine($"Extracted: {outputPath}");
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
 * 2. When you want to generate a gallery of images from a DOCX file to display on a website or application.
 * 3. When you must migrate or backup the original image assets from a collection of Word files without losing their original formats.
 * 4. When you are building a document conversion tool that extracts media files before converting the rest of the document.
 * 5. When you need to validate or scan embedded images for compliance, size, or content before publishing the document.
 */
