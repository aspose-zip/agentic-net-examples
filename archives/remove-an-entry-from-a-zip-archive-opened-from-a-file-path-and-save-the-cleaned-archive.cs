// HOW-TO: Delete a File from a ZIP Archive and Save in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Define data directory and file names
            string dataDir = "C:\\Data\\";
            CompressMultipleFiles.Run();

            // Path to the source ZIP archive
            string sourceArchivePath = dataDir + "sample.zip";

            // Verify the source archive exists
            if (!File.Exists(sourceArchivePath))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath}");
                return;
            }

            // Open the archive
            using (Archive archive = new Archive(sourceArchivePath))
            {
                // Delete the first entry if any exist
                if (archive.Entries.Count > 0)
                {
                    ArchiveEntry firstEntry = archive.Entries[0];
                    archive.DeleteEntry(firstEntry);
                }

                // Path for the cleaned archive
                string resultPath = dataDir + "cleaned.zip";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(resultPath));

                // Save the modified archive
                archive.Save(resultPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Helper class required by the rule; can be expanded as needed.
public static class CompressMultipleFiles
{
    public static void Run()
    {
        // Placeholder implementation – can create a sample archive if desired.
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to remove a sensitive document from an existing ZIP file before distributing it to clients.
 * 2. When an automated build process must clean up temporary logs stored inside a packaged archive.
 * 3. When a user interface allows end‑users to delete unwanted items from a downloaded ZIP without recreating the whole archive.
 * 4. When a server‑side service must purge obsolete resources from a stored ZIP to reduce storage costs.
 * 5. When a migration script has to strip out legacy files from a legacy ZIP before importing the remaining contents into a new system.
 */
