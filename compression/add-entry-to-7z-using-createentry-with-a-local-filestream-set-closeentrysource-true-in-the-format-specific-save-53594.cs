// HOW-TO: Add File to 7z Archive and Auto‑Close Source Stream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file to be added to the archive
            string inputFilePath = "input.txt";

            // Hardcoded output 7z archive path
            string outputFilePath = "output/auto_dispose.7z";

            // Verify that the source file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure the output directory exists if a directory part is present
            string outputDir = Path.GetDirectoryName(outputFilePath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create the output file stream and the 7z archive
            using (FileStream outputStream = File.Open(outputFilePath, FileMode.Create))
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Add an entry to the archive from the local file
                archive.CreateEntry("entry.txt", inputFilePath);

                // Configure save options to close the entry source after saving
                SevenZipArchiveSaveOptions saveOptions = new SevenZipArchiveSaveOptions();
                saveOptions.CloseEntrySource = true;

                // Save the archive with the specified options
                archive.Save(outputStream, saveOptions);
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
 * 1. When you need to package a log file into a 7z archive for backup while ensuring the original file stream is closed automatically after saving.
 * 2. When building a deployment tool that creates compressed 7z bundles from configuration files without leaving open file handles.
 * 3. When generating downloadable archives on a web server and you want the source files to be released promptly after the archive is written.
 * 4. When automating archival of temporary reports and you require the archive creation code to clean up resources to avoid file‑lock issues.
 * 5. When integrating Aspose.Zip into a Windows service that periodically compresses data files into 7z containers and must guarantee proper disposal of streams.
 */
