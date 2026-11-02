// HOW-TO: Compress DOCX to LZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\report.docx";
            string outputPath = @"C:\Data\report.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a Word document for faster email transmission by creating an LZIP archive in a .NET application.
 * 2. When you want to store large reports on limited‑space storage devices and require reliable LZIP compression using Aspose.Zip in C#.
 * 3. When an automated backup system must compress generated DOCX files into LZIP format before uploading them to cloud storage.
 * 4. When a document‑management workflow requires programmatically archiving DOCX files into LZIP archives for compliance and archival purposes.
 * 5. When a Windows service processes daily reports and must compress each report.docx into a .lz file to minimize network bandwidth usage.
 */
