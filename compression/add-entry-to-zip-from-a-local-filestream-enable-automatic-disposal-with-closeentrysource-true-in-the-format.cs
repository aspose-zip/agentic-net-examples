// HOW-TO: Add FileStream to Existing Zip and Auto‑Close Stream in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string sourceArchivePath = @"C:\Data\existing.zip";
            string fileToAddPath = @"C:\Data\newfile.txt";
            string resultPath = @"C:\Data\streamed.zip";

            // Validate input files
            if (!File.Exists(sourceArchivePath))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath}");
                return;
            }

            if (!File.Exists(fileToAddPath))
            {
                Console.Error.WriteLine($"File not found: {fileToAddPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(resultPath));

            // Open the source archive and the file stream to add
            using (FileStream fileStream = new FileStream(fileToAddPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(sourceArchivePath))
            {
                // Add entry from the opened FileStream
                string entryName = Path.GetFileName(fileToAddPath);
                archive.CreateEntry(entryName, fileStream);

                // Configure save options to automatically close entry source streams
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.CloseEntrySource = true;

                // Save the modified archive
                archive.Save(resultPath, saveOptions);
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
 * 1. When you need to programmatically insert a large log file into an existing ZIP archive without loading the whole file into memory, using a FileStream and automatic disposal.
 * 2. When you want to update a deployment package by adding a configuration file while ensuring the source stream is closed after saving to prevent file locks.
 * 3. When building a backup utility that streams new documents into a master ZIP archive and relies on CloseEntrySource to manage resources efficiently.
 * 4. When creating a web service that receives a file stream and appends it to a stored ZIP, then saves the result as a new archive.
 * 5. When automating the generation of a compressed report bundle that combines existing archives with additional files, using Aspose.Zip’s save options to handle stream cleanup.
 */
