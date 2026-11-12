// HOW-TO: Create a ZIP Archive of Multiple Documents Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output ZIP file path
            string inputDir = "C:\\InputDocs";
            string outputPath = "C:\\Output\\DocumentsArchive.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define full paths for the documents to compress
            string file1Path = Path.Combine(inputDir, "doc1.txt");
            string file2Path = Path.Combine(inputDir, "doc2.pdf");
            string file3Path = Path.Combine(inputDir, "doc3.docx");

            // Validate each input file exists
            if (!File.Exists(file1Path))
            {
                Console.Error.WriteLine($"File not found: {file1Path}");
                return;
            }
            if (!File.Exists(file2Path))
            {
                Console.Error.WriteLine($"File not found: {file2Path}");
                return;
            }
            if (!File.Exists(file3Path))
            {
                Console.Error.WriteLine($"File not found: {file3Path}");
                return;
            }

            // Open the output ZIP file stream and source file streams, then create the archive
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            using (FileStream source1 = File.Open(file1Path, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(file2Path, FileMode.Open, FileAccess.Read))
            using (FileStream source3 = File.Open(file3Path, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                // Add each document to the archive with default Deflate compression
                archive.CreateEntry("doc1.txt", source1);
                archive.CreateEntry("doc2.pdf", source2);
                archive.CreateEntry("doc3.docx", source3);

                // Save the archive to the ZIP file
                archive.Save(zipFile);
            }

            Console.WriteLine("Documents compressed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several text, PDF, and Word files into a single ZIP for easy download or transfer in a .NET application.
 * 2. When you want to generate a compressed archive on the server before sending it as an email attachment.
 * 3. When you must create a backup of a set of documents with default Deflate compression to reduce storage space.
 * 4. When you are building a document‑export feature that packages selected files into a ZIP file for the user.
 * 5. When you need to programmatically create a portable archive that can be opened by any standard ZIP utility without custom compression settings.
 */
