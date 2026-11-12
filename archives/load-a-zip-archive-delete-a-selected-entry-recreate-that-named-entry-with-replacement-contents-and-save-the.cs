// HOW-TO: Replace A File Inside A ZIP Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output ZIP file paths
            string inputArchivePath = @"C:\Data\input.zip";
            string outputArchivePath = @"C:\Data\output.zip";

            // Validate input file existence
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Name of the entry to replace
            string targetEntryName = "old.txt";

            // Replacement content for the entry
            string newContent = "This is the new content.";
            byte[] newContentBytes = Encoding.UTF8.GetBytes(newContent);

            using (Archive archive = new Archive(inputArchivePath))
            {
                // Locate the entry to delete
                ArchiveEntry entryToDelete = archive.Entries.FirstOrDefault(e => e.Name == targetEntryName);
                if (entryToDelete != null)
                {
                    archive.DeleteEntry(entryToDelete);
                }

                // Create the new entry with replacement content
                using (MemoryStream contentStream = new MemoryStream(newContentBytes))
                {
                    ArchiveEntrySettings entrySettings = new ArchiveEntrySettings();
                    archive.CreateEntry(targetEntryName, contentStream, entrySettings);
                }

                // Save the updated archive
                archive.Save(outputArchivePath);
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
 * 1. When you need to update a specific text file in an existing ZIP without extracting the whole archive.
 * 2. When you want to programmatically remove an outdated entry from a ZIP and add a new version in a .NET application.
 * 3. When you are building a deployment package and must replace configuration files inside the archive on the fly.
 * 4. When you need to automate the process of fixing corrupted or incorrect files inside a ZIP before sending it to a client.
 * 5. When you are creating a backup system that swaps out log files inside a ZIP with fresh content while preserving other entries.
 */
