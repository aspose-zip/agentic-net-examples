// HOW-TO: Extract Report2.Docx From Reports.Tar.Xz Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "reports.tar.xz";
        string outputPath = "report2.docx";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            string tempTarPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".tar");

            using (XzArchive xz = new XzArchive())
            {
                xz.SetSource(inputPath);
                xz.Extract(tempTarPath);
            }

            using (TarArchive tar = new TarArchive(tempTarPath))
            {
                TarEntry entry = tar.Entries
                    .FirstOrDefault(e => e.Name.Equals("report2.docx", StringComparison.OrdinalIgnoreCase));

                if (entry != null)
                {
                    entry.Extract(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Entry not found: report2.docx");
                }
            }

            if (File.Exists(tempTarPath))
            {
                File.Delete(tempTarPath);
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
 * 1. When you receive a compressed .tar.xz backup containing multiple documents and need to programmatically pull out a single Word file in a .NET application.
 * 2. When an automated data pipeline must decompress a .tar.xz archive, read its TAR contents, and save a specific report to a local directory without manual extraction.
 * 3. When building a file‑processing service that extracts a particular document from a multi‑file XZ‑compressed TAR archive on the fly using Aspose.Zip for .NET.
 * 4. When migrating legacy archives stored as .tar.xz and you need to retrieve individual files like report2.docx directly in C# code.
 * 5. When creating a scheduled task that cleans up temporary extraction files after extracting a required document from a compressed TAR archive.
 */
