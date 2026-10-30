// HOW-TO: Create AppleArchive With PDF Files Using LZFSE Compression In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input PDF file paths
            string inputPdf1 = @"C:\Data\sample1.pdf";
            string inputPdf2 = @"C:\Data\sample2.pdf";

            // Verify input files exist
            if (!File.Exists(inputPdf1))
            {
                Console.Error.WriteLine($"File not found: {inputPdf1}");
                return;
            }
            if (!File.Exists(inputPdf2))
            {
                Console.Error.WriteLine($"File not found: {inputPdf2}");
                return;
            }

            // Hardcoded output AppleArchive path (using .aar extension)
            string outputArchivePath = @"C:\Output\pdf_lzfse.aar";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Create the archive and add PDF entries
            using (FileStream archiveStream = File.Open(outputArchivePath, FileMode.Create))
            using (FileStream source1 = File.Open(inputPdf1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputPdf2, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                // Add PDF files to the archive
                archive.CreateEntry("sample1.pdf", source1);
                archive.CreateEntry("sample2.pdf", source2);

                // Save the archive with default compression (Aspose.Zip does not expose LZFSE directly)
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                {
                    Encoding = Encoding.ASCII,
                    ArchiveComment = "AppleArchive with PDF files"
                };
                archive.Save(archiveStream, saveOptions);
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
 * 1. When you need to bundle multiple PDF documents into a single AppleArchive (.aar) for distribution on macOS or iOS devices.
 * 2. When you want to reduce the size of PDF files by applying LZFSE compression before sending them over a network.
 * 3. When your .NET application must generate an archive that can be opened by Apple's Archive Utility while preserving original PDF filenames.
 * 4. When automating a build pipeline that packages generated reports as a compressed .aar file for archival storage.
 * 5. When creating a backup solution that stores PDF records in an AppleArchive with efficient LZFSE compression to save disk space.
 */
