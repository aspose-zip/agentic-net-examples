// HOW-TO: Compress a DOCX File to LZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\document.docx";
            string outputPath = @"C:\Output\document.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    archive.Save(outStream);
                }
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
 * 1. When you need to reduce the size of a Word document for faster network transfer or storage, you can compress it into an LZIP archive using C# and Aspose.Zip.
 * 2. When an application must generate LZIP‑compressed backups of user‑generated documents on Windows servers, this code creates the .lz file programmatically.
 * 3. When integrating with a legacy system that only accepts LZIP files, developers can convert incoming DOCX files to the required format before sending them.
 * 4. When building a batch processing tool that archives multiple Office files into LZIP archives to meet storage quota limits, this snippet shows how to handle each file.
 * 5. When you want to automate the creation of compressed packages for deployment pipelines, the code demonstrates how to produce a .lz archive from a document using Aspose.Zip in .NET.
 */
