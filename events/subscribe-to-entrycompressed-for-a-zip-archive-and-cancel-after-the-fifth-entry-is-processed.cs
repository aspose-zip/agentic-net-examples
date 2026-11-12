// HOW-TO: Cancel Zip Archive Compression After Fifth Entry with Aspose.Zip C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string dataDir = @"C:\Data";
            string inputFile1 = Path.Combine(dataDir, "file1.txt");
            string inputFile2 = Path.Combine(dataDir, "file2.txt");
            string inputFile3 = Path.Combine(dataDir, "file3.txt");
            string inputFile4 = Path.Combine(dataDir, "file4.txt");
            string inputFile5 = Path.Combine(dataDir, "file5.txt");
            string inputFile6 = Path.Combine(dataDir, "file6.txt");
            string outputPath = Path.Combine(dataDir, "output.zip");

            // Verify input files exist
            if (!File.Exists(inputFile1)) { Console.Error.WriteLine($"File not found: {inputFile1}"); return; }
            if (!File.Exists(inputFile2)) { Console.Error.WriteLine($"File not found: {inputFile2}"); return; }
            if (!File.Exists(inputFile3)) { Console.Error.WriteLine($"File not found: {inputFile3}"); return; }
            if (!File.Exists(inputFile4)) { Console.Error.WriteLine($"File not found: {inputFile4}"); return; }
            if (!File.Exists(inputFile5)) { Console.Error.WriteLine($"File not found: {inputFile5}"); return; }
            if (!File.Exists(inputFile6)) { Console.Error.WriteLine($"File not found: {inputFile6}"); return; }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare save options with event handling
            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
            int compressedCount = 0;
            saveOptions.EventsBag.EntryCompressed += (sender, eventArgs) =>
            {
                compressedCount++;
                Console.WriteLine($"Entry compressed: {eventArgs.Entry.Name} (count={compressedCount})");
                if (compressedCount >= 5)
                {
                    // Cancel further compression by throwing
                    throw new OperationCanceledException("Cancellation after five entries.");
                }
            };

            // Create archive and add entries
            using (Archive archive = new Archive())
            {
                using (FileStream fs1 = File.OpenRead(inputFile1))
                {
                    archive.CreateEntry("file1.txt", fs1);
                }
                using (FileStream fs2 = File.OpenRead(inputFile2))
                {
                    archive.CreateEntry("file2.txt", fs2);
                }
                using (FileStream fs3 = File.OpenRead(inputFile3))
                {
                    archive.CreateEntry("file3.txt", fs3);
                }
                using (FileStream fs4 = File.OpenRead(inputFile4))
                {
                    archive.CreateEntry("file4.txt", fs4);
                }
                using (FileStream fs5 = File.OpenRead(inputFile5))
                {
                    archive.CreateEntry("file5.txt", fs5);
                }
                using (FileStream fs6 = File.OpenRead(inputFile6))
                {
                    archive.CreateEntry("file6.txt", fs6);
                }

                // Save archive (may be cancelled by the event)
                archive.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Archive created successfully.");
        }
        catch (OperationCanceledException ex)
        {
            Console.Error.WriteLine($"Operation cancelled: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to limit the size of a zip file by compressing only the first few files and then stop further processing.
 * 2. When processing large batches of files and you want to abort compression after a certain count to save CPU time.
 * 3. When implementing a preview feature that shows compression progress for the first few entries before pausing.
 * 4. When creating a zip archive for a user‑selected subset and you must enforce a maximum number of compressed items.
 * 5. When debugging or testing the EntryCompressed event handling in Aspose.Zip without processing the entire archive.
 */
