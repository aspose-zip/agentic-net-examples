// HOW-TO: Create Split Zip Archive of PDF and DOCX Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pdfPath = "C:\\Data\\report.pdf";
            string docxPath = "C:\\Data\\report.docx";

            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"File not found: {pdfPath}");
                return;
            }
            if (!File.Exists(docxPath))
            {
                Console.Error.WriteLine($"File not found: {docxPath}");
                return;
            }

            string outputDirectory = "C:\\Output";
            string baseName = "reports";
            string outputBasePath = Path.Combine(outputDirectory, baseName);

            Directory.CreateDirectory(Path.GetDirectoryName(outputBasePath));

            using (Archive archive = new Archive())
            {
                archive.CreateEntry("report.pdf", new FileInfo(pdfPath));
                archive.CreateEntry("report.docx", new FileInfo(docxPath));

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(180 * 1024);
                archive.SaveSplit(outputBasePath, saveOptions);
            }

            Console.WriteLine("Split archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package large PDF and Word reports into a ZIP that is automatically divided into small, 180 KB parts for easier email or upload.
 * 2. When a backup system must store documents in multiple split ZIP segments to stay within file‑size limits of legacy storage media.
 * 3. When an application generates combined PDF and DOCX deliverables and must create a standard ZIP that can be reassembled by any unzip tool.
 * 4. When you want to ensure that each part of a ZIP archive can be transferred over networks that restrict individual file size, such as certain cloud APIs.
 * 5. When you are building a C# utility that creates split archives for compliance‑driven archiving policies requiring fixed‑size chunks.
 */
