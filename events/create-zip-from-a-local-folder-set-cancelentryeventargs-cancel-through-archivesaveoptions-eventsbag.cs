// HOW-TO: Create ZIP From Folder And Cancel Compression After Timeout In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input folder and output ZIP file paths
            string inputFolder = @"C:\Data\MyFolder";
            string outputPath = @"C:\Data\MyArchive.zip";

            // Verify the input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the output file stream and create a new archive
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                // Add all files from the input folder to the archive
                DirectoryInfo dirInfo = new DirectoryInfo(inputFolder);
                archive.CreateEntries(dirInfo);

                // Prepare save options with an event handler to cancel after 5 seconds
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                saveOptions.EventsBag.EntryCompressed += (sender, e) =>
                {
                    // Cancel further entry compression if more than 5 seconds have elapsed
                    if (stopwatch.Elapsed.TotalSeconds >= 5)
                    {
                        e.Cancel = true;
                    }
                };

                // Save the archive; only entries processed before cancellation will be stored
                archive.Save(zipStream, saveOptions);
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
 * 1. When you need to generate a ZIP archive from a local directory but must stop the operation if it takes longer than a few seconds to avoid long‑running tasks.
 * 2. When building a backup utility that compresses files and should abort compression after a time limit to keep the application responsive.
 * 3. When processing large batches of files and want to ensure only the files already compressed within a set time are saved, discarding the rest.
 * 4. When implementing a user‑initiated cancel feature that automatically halts archive creation after a timeout without requiring explicit UI interaction.
 * 5. When creating a ZIP for temporary transfer and want to limit the archive size by stopping compression once a time‑based threshold is reached.
 */
