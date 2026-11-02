// HOW-TO: Add a File to Existing ZIP Archive Using Stream Provider in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string sourceArchivePath = dataDir + "archive.zip";
            string fileToAppendPath = dataDir + "newfile.txt";
            string resultPath = dataDir + "archive_updated.zip";

            // Validate input files
            if (!File.Exists(sourceArchivePath))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath}");
                return;
            }

            if (!File.Exists(fileToAppendPath))
            {
                Console.Error.WriteLine($"File not found: {fileToAppendPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(resultPath));

            // Open the file to be added
            using (FileStream fileStream = new FileStream(fileToAppendPath, FileMode.Open, FileAccess.Read))
            {
                // Open existing archive
                using (Archive archive = new Archive(sourceArchivePath))
                {
                    // Add entry using a stream provider
                    archive.CreateEntry("newfile.txt", () => fileStream);

                    // Save the modified archive
                    archive.Save(resultPath);
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
 * 1. When you need to programmatically append a new document to an existing ZIP package without loading the whole archive into memory.
 * 2. When you want to add a large log file to a backup ZIP archive using a FileStream to avoid high memory consumption.
 * 3. When you must preserve the original archive and create an updated version with an additional file for versioned distribution.
 * 4. When you are building a server‑side service that merges user‑uploaded files into a pre‑existing ZIP template.
 * 5. When you need to automate the creation of a new ZIP file that includes a specific file while keeping the original archive unchanged for compliance auditing.
 */
