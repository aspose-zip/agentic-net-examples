// HOW-TO: Compress Document and Barcode Image Into a ZIP File Using C# (Aspose.ZIP for .NET)
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
            string inputFile1 = @"C:\Data\document.txt";
            string inputFile2 = @"C:\Data\barcode.png";
            string outputZip = @"C:\Output\files.zip";

            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

            using (FileStream zipStream = File.Open(outputZip, FileMode.Create))
            using (FileStream source1 = File.Open(inputFile1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputFile2, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                archive.CreateEntry(Path.GetFileName(inputFile1), source1);
                archive.CreateEntry(Path.GetFileName(inputFile2), source2);
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                {
                    Encoding = Encoding.ASCII,
                    ArchiveComment = "Sample archive containing document and barcode"
                };
                archive.Save(zipStream, saveOptions);
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
 * 1. When you need to bundle a text report and its generated barcode into a single ZIP archive for email attachment.
 * 2. When an application must create a portable package of configuration files and associated barcode images for distribution.
 * 3. When a server‑side process has to archive log files together with visual identifiers before uploading to cloud storage.
 * 4. When a desktop utility must generate a ZIP containing user‑generated documents and scanned barcodes for backup.
 * 5. When a workflow requires adding a custom comment to a ZIP that includes both data files and barcode graphics.
 */
