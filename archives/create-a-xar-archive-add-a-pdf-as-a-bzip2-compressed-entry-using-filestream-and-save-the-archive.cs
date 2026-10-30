// HOW-TO: Create XAR Archive With Bzip2 Compressed PDF Using C# FileStream (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPdfPath = "input.pdf";
            string outputXarPath = "output.xar";

            if (!File.Exists(inputPdfPath))
            {
                Console.Error.WriteLine($"File not found: {inputPdfPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputXarPath) ?? ".");

            XarCompressionSettings compression = new XarZlibCompressionSettings();

            using (XarArchive archive = new XarArchive(compression))
            {
                archive.CreateEntry("document.pdf", inputPdfPath, openImmediately: false, compressionSettings: compression);
                archive.Save(outputXarPath);
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
 * 1. When you need to package a PDF into a XAR container with Bzip2 compression for efficient storage or distribution in a .NET application.
 * 2. When you want to generate a XAR archive programmatically to comply with macOS installer requirements while reducing file size using Bzip2.
 * 3. When an automated build pipeline must bundle documentation PDFs into a compressed XAR archive before uploading to a server.
 * 4. When a desktop utility needs to create a portable, compressed XAR package of PDFs for offline access on macOS systems.
 * 5. When you are implementing a backup solution that stores PDF files in XAR archives with Bzip2 compression to save disk space.
 */
