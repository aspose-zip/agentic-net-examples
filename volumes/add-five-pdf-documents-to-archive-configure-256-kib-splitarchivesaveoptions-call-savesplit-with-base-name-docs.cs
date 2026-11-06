// HOW-TO: Create Split ZIP Archive of PDFs with 256KB Parts in C# (Aspose.ZIP for .NET)
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
            string[] inputPaths = new string[]
            {
                "input/doc1.pdf",
                "input/doc2.pdf",
                "input/doc3.pdf",
                "input/doc4.pdf",
                "input/doc5.pdf"
            };

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);

            using (Archive archive = new Archive())
            {
                foreach (string inputPath in inputPaths)
                {
                    string entryName = Path.GetFileName(inputPath);
                    archive.CreateEntry(entryName, new FileInfo(inputPath));
                }

                SplitArchiveSaveOptions splitOptions = new SplitArchiveSaveOptions("docs", 256 * 1024);
                archive.SaveSplit(outputDirectory, splitOptions);
            }

            Console.WriteLine("Multivolume ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple PDF reports into a multivolume ZIP that fits on storage media with a 256 KB size limit.
 * 2. When distributing large sets of PDF manuals over email or file‑sharing services that restrict attachment size, requiring the archive to be split into small parts.
 * 3. When creating backup archives of PDF documents for archival tape or USB drives that only accept fixed‑size chunks, using Aspose.Zip to automate the process in C#.
 * 4. When implementing a download manager that serves PDF files in segmented ZIP files so clients can resume interrupted transfers.
 * 5. When complying with legacy systems that only read split ZIP archives, needing to generate the correct base name and segment size programmatically.
 */
