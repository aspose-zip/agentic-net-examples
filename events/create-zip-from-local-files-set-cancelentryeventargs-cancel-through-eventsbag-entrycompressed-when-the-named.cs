// HOW-TO: Create ZIP and Cancel After Specific File Is Compressed in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string dataDir = "Data";
        string inputPath1 = Path.Combine(dataDir, "file1.txt");
        string inputPath2 = Path.Combine(dataDir, "file2.txt");
        string outputPath = Path.Combine(dataDir, "output.zip");

        // Verify input files exist
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Open source files and add them as entries
                FileStream source1 = File.OpenRead(inputPath1);
                archive.CreateEntry("file1.txt", source1);

                FileStream source2 = File.OpenRead(inputPath2);
                archive.CreateEntry("file2.txt", source2);

                // Configure save options with an event handler
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.EventsBag.EntryCompressed += (sender, eventArgs) =>
                {
                    Console.WriteLine($"Entry compressed: {eventArgs.Entry.Name}");
                    // Cancel further processing after the target entry finishes
                    if (eventArgs.Entry.Name == "file2.txt")
                    {
                        eventArgs.Cancel = true;
                        Console.WriteLine("Cancellation requested after target entry.");
                    }
                };

                // Save the archive to the output path
                archive.Save(outputPath, saveOptions);

                // Close source streams after saving
                source1.Dispose();
                source2.Dispose();
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
 * 1. When you need to generate a ZIP archive from multiple local files but stop the process once a particular file has been added, such as creating a partial backup that ends after a critical document.
 * 2. When you want to monitor the compression progress of each entry and trigger custom logic, like logging or UI updates, as soon as a designated file finishes compressing.
 * 3. When you must enforce a size or time limit by aborting the archive creation after a specific entry, for example limiting the amount of data sent to a remote service.
 * 4. When building a download package where only the first few files are required and you want to cancel further compression to improve performance.
 * 5. When integrating Aspose.Zip into an automated workflow that needs to conditionally stop archiving based on business rules, such as halting after a confidential file is processed.
 */
