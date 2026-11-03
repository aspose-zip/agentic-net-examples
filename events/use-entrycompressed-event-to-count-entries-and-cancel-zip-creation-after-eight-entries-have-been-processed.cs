// HOW-TO: How to Stop ZIP Creation After Eight Files Using EntryCompressed Event in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = @"C:\InputFolder";
        string outputPath = @"C:\Output\archive.zip";

        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Directory not found: {inputDirectory}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Archive archive = new Archive())
            {
                // Add all files from the input directory to the archive
                archive.CreateEntries(inputDirectory);

                int entryCount = 0;
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();

                // Subscribe to the EntryCompressed event to count entries and cancel after eight
                saveOptions.EventsBag.EntryCompressed += (sender, e) =>
                {
                    entryCount++;
                    Console.WriteLine($"Compressed entry: {e.Entry.Name} (count = {entryCount})");

                    if (entryCount >= 8)
                    {
                        // Cancel further compression
                        e.Cancel = true;
                    }
                };

                // Save the archive; compression will stop after eight entries
                archive.Save(outputPath, saveOptions);
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
 * 1. When you need to limit a ZIP archive to a maximum number of files to meet size or policy constraints.
 * 2. When processing large batches of files and want to abort compression after a certain count to save time.
 * 3. When implementing a preview feature that only compresses the first few entries for quick user feedback.
 * 4. When integrating with a system that only accepts archives with a fixed number of entries, such as legacy upload APIs.
 * 5. When testing or debugging the compression pipeline and need to stop after a few entries to inspect intermediate results.
 */
