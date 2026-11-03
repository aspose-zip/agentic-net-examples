// HOW-TO: Add File to Existing ZIP and Save Updated Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define the base data directory and file names
            string dataDir = @"C:\Data\";
            string sourceArchivePath = dataDir + "source.zip";
            string fileToAppend = dataDir + "newfile.txt";
            string resultPath = dataDir + "updated.zip";

            // Verify that the source ZIP archive exists
            if (!File.Exists(sourceArchivePath))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath}");
                return;
            }

            // Verify that the file to be added exists
            if (!File.Exists(fileToAppend))
            {
                Console.Error.WriteLine($"File not found: {fileToAppend}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(resultPath));

            // Open the existing archive, add the new entry, and save to a new file
            using (Archive archive = new Archive(sourceArchivePath))
            {
                // Add a new entry using the file name as the entry name
                archive.CreateEntry(Path.GetFileName(fileToAppend), fileToAppend);
                // Save the updated archive to the result path
                archive.Save(resultPath);
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
 * 1. When you need to include a newly generated report in an existing backup ZIP without modifying the original file.
 * 2. When a deployment script must bundle additional configuration files into a pre‑built archive before distribution.
 * 3. When an application updates a user’s document package by inserting a new attachment and creates a fresh ZIP for download.
 * 4. When a server process adds log files to a stored ZIP archive and saves the result as a separate version for auditing.
 * 5. When a build pipeline appends a compiled asset to a template ZIP and writes the combined package to a new location.
 */
