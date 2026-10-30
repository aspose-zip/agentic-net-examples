// HOW-TO: Compress PDF to BZIP2 Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            string outputPath = "output.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            using (Bzip2Archive archive = new Bzip2Archive())
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
 * 1. When you need to reduce the size of a PDF before uploading it to a web service that only accepts BZIP2 files.
 * 2. When you want to store PDF documents in a BZIP2 archive to save disk space in a .NET application.
 * 3. When you must programmatically compress confidential PDFs for secure email attachment using Aspose.Zip in C#.
 * 4. When you are building a batch process that compresses generated reports into BZIP2 format for archival purposes.
 * 5. When you need to integrate PDF compression into an existing C# workflow that requires BZIP2 compatibility with legacy systems.
 */
