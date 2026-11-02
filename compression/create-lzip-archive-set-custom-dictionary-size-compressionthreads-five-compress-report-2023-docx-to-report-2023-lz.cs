// HOW-TO: Compress DOCX to Lzip File Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\report_2023.docx";
            string outputPath = @"C:\Data\report_2023.lz";

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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a Word document for faster network transfer by creating an Lzip archive in a C# application.
 * 2. When you want to store legal or financial reports in a compact, single‑file format that can be later extracted with standard Lzip tools.
 * 3. When automating backup scripts that compress daily generated .docx files into .lz archives to save disk space on a Windows server.
 * 4. When integrating a C# service that prepares documents for email attachment by compressing them into Lzip to stay under attachment size limits.
 * 5. When building a document‑management system that archives older versions of files using Lzip compression for long‑term storage and integrity verification.
 */
