// HOW-TO: Add Multiple Files To Existing ZIP Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input directory and file paths
            string dataDir = "C:\\Data\\";
            string sourceArchivePath = Path.Combine(dataDir, "archive.zip");
            string fileToAppend1 = Path.Combine(dataDir, "file1.txt");
            string fileToAppend2 = Path.Combine(dataDir, "file2.txt");

            // Validate input files exist
            if (!File.Exists(sourceArchivePath))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath}");
                return;
            }
            if (!File.Exists(fileToAppend1))
            {
                Console.Error.WriteLine($"File not found: {fileToAppend1}");
                return;
            }
            if (!File.Exists(fileToAppend2))
            {
                Console.Error.WriteLine($"File not found: {fileToAppend2}");
                return;
            }

            // Open existing archive and add multiple entries
            using (Archive archive = new Archive(sourceArchivePath))
            {
                archive.CreateEntry("file1.txt", fileToAppend1);
                archive.CreateEntry("file2.txt", fileToAppend2);

                // Define output path and ensure directory exists
                string outputPath = "C:\\Output\\modified.zip";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified archive
                archive.Save(outputPath);
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
 * 1. When you need to update a previously created ZIP file by appending new documents without recreating the archive from scratch.
 * 2. When your application must combine daily log files into an existing backup ZIP for centralized storage.
 * 3. When a deployment script has to add configuration files to a packaged ZIP before distributing it to servers.
 * 4. When you want to merge user‑uploaded reports into a master archive that is already stored on disk.
 * 5. When a data‑processing pipeline must incrementally add processed CSV files to an existing compressed bundle for later download.
 */
