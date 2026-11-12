// HOW-TO: Compress DOCX to XZ Archive with CRC64 Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;
using Aspose.Zip.Xz.Settings;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\documentation.docx";
            string outputPath = @"C:\Data\doc_archive.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            XzArchiveSettings archiveSettings = new XzArchiveSettings();

            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            {
                using (XzArchive archive = new XzArchive(archiveSettings))
                {
                    archive.SetSource(inputPath);
                    archive.Save(outputStream);
                }
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
 * 1. When you need to reduce the size of a Word document before sending it over a network, you can compress the .docx into an XZ file with CRC64 verification using Aspose.Zip in C#.
 * 2. When archiving legal or compliance documents, you may want to store them in a high‑compression XZ container with a strong CRC64 checksum to ensure integrity during long‑term storage.
 * 3. When building a backup utility that packages individual files into a single compressed archive, this code shows how to create an XZ archive of a .docx file programmatically in a .NET application.
 * 4. When integrating file compression into a document‑management system, you can use the XzArchive class to generate an XZ file that can later be extracted by standard XZ tools while preserving data integrity.
 * 5. When automating a deployment pipeline that needs to bundle documentation assets, you can compress them into an XZ archive with CRC64 using C# to minimize bandwidth and detect corruption.
 */
