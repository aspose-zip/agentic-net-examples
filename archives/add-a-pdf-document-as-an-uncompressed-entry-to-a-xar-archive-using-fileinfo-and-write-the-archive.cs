// HOW-TO: Add PDF As Uncompressed Entry To XAR Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PDF and output XAR paths
            string pdfPath = "input.pdf";
            string xarOutput = "output.xar";

            // Verify the PDF file exists
            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"File not found: {pdfPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(xarOutput);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Compression settings for uncompressed (store) entries
            XarStoreCompressionSettings storeCompression = new XarStoreCompressionSettings();

            // Create a new XAR archive using the store compression as the default
            using (XarArchive archive = new XarArchive(storeCompression))
            {
                // Add the PDF file as an uncompressed entry
                archive.CreateEntry("document.pdf", pdfPath, openImmediately: false, compressionSettings: storeCompression);

                // Save the archive to disk
                archive.Save(xarOutput);
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
 * 1. When you need to bundle a PDF with other files into a XAR package for macOS installers while keeping the PDF uncompressed to allow instant opening.
 * 2. When you want to create a XAR archive that stores legal documents exactly as they are, avoiding any compression that could alter binary data.
 * 3. When a build script must add a PDF to a XAR archive using FileInfo without loading the file into memory, ensuring fast packaging.
 * 4. When you are generating a backup of PDF reports in a XAR container and require the entries to be stored (no compression) for quick extraction.
 * 5. When an application needs to programmatically create a XAR archive in C# and include a PDF as a store‑compressed entry to meet a third‑party specification.
 */
