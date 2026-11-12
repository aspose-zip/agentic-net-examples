// HOW-TO: Create CAB Archive From Multiple PDF Files Using Streams In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputFiles = new string[]
            {
                @"C:\Data\PDFs\file1.pdf",
                @"C:\Data\PDFs\file2.pdf",
                @"C:\Data\PDFs\file3.pdf",
                @"C:\Data\PDFs\file4.pdf",
                @"C:\Data\PDFs\file5.pdf"
            };

            string outputPath = @"C:\Output\pdfs.cab";

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            using (CabArchive cab = new CabArchive())
            {
                List<FileStream> sourceStreams = new List<FileStream>();

                foreach (string inputPath in inputFiles)
                {
                    FileStream sourceStream = File.Open(inputPath, FileMode.Open, FileAccess.Read);
                    sourceStreams.Add(sourceStream);
                    cab.CreateEntry(Path.GetFileName(inputPath), sourceStream);
                }

                cab.Save(outputStream);
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
 * 1. When you need to bundle several PDF documents into a single CAB file for efficient distribution or backup in a .NET application.
 * 2. When you want to generate a CAB archive on the fly from PDF streams without loading the entire files into memory.
 * 3. When deploying a Windows installer that requires PDF resources packaged in a CAB file using C#.
 * 4. When you need to create a compressed archive of PDFs for secure transmission over a network while preserving file names.
 * 5. When automating archival of generated PDF reports into a CAB container for long‑term storage in an enterprise system.
 */
