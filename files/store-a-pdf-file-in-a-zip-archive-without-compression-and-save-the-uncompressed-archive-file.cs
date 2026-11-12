// HOW-TO: Store PDF in Uncompressed ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PDF file path
            string inputPath = @"C:\Data\sample.pdf";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output ZIP file path
            string outputPath = @"C:\Output\uncompressed.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a FileInfo for the PDF file
            FileInfo pdfFileInfo = new FileInfo(inputPath);

            // Open a FileStream for the output ZIP archive
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Create an Archive with Store (no compression) settings
                using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
                {
                    // Add the PDF file to the archive with the desired entry name
                    archive.CreateEntry("sample.pdf", pdfFileInfo);

                    // Save the archive with ASCII encoding for the ZIP comment (if any)
                    archive.Save(zipFile, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
                }
            }

            Console.WriteLine("PDF file stored in uncompressed ZIP archive successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a PDF with other files for delivery but must keep the original file size unchanged for regulatory compliance, you can store it in an uncompressed ZIP using Aspose.Zip in C#.
 * 2. When creating a backup of legal documents where compression could alter checksum verification, this code lets you archive a PDF without compression in .NET.
 * 3. When generating a ZIP package for a client that requires the PDF to be directly accessible without decompression overhead, you can use this approach to store the PDF as a stored entry.
 * 4. When integrating with a system that only accepts uncompressed ZIP archives for security scanning, the example shows how to add a PDF to such an archive in C#.
 * 5. When automating the preparation of PDF files for digital signing services that reject compressed entries, this code creates an uncompressed ZIP archive ready for upload.
 */
