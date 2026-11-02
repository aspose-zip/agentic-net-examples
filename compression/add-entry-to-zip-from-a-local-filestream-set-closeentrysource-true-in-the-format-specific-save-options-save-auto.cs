// HOW-TO: Add FileStream to ZIP Archive with Auto‑Close Entry Source in C# (Aspose.ZIP for .NET)
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
            // Input file to be added to the ZIP archive
            string inputFilePath = "sample.txt";
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Output ZIP archive path
            string outputArchivePath = "auto_dispose.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath) ?? ".");

            // Open the source file stream
            using (FileStream sourceStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                // Create a new ZIP archive
                using (Archive archive = new Archive())
                {
                    // Add entry from the opened stream
                    archive.CreateEntry("sample.txt", sourceStream);

                    // Configure save options to close the entry source after saving
                    ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                    saveOptions.CloseEntrySource = true;

                    // Save the archive to the specified path
                    archive.Save(outputArchivePath, saveOptions);
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
 * 1. When you need to package a local file into a ZIP archive without loading the entire file into memory, using a FileStream and automatically releasing the stream after saving.
 * 2. When you want to ensure that the source file handle is closed immediately after the ZIP is created to avoid file‑locking issues in subsequent operations.
 * 3. When you are generating temporary ZIP files in a web or desktop application and need the archive to be disposed automatically after creation.
 * 4. When you are processing large log or data files and must add them to a compressed archive while managing resources efficiently in C#.
 * 5. When you require precise control over the save options of an Aspose.Zip archive, such as enabling CloseEntrySource to simplify cleanup code.
 */
