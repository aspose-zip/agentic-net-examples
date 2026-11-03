// HOW-TO: Create Partial ZIP Archive After Eight Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputFolder = "input";
            string outputPath = "output/partial.zip";

            // Validate input folder
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                int addedEntries = 0;

                // Add up to eight files from the input folder as entries
                foreach (string filePath in Directory.GetFiles(inputFolder))
                {
                    if (addedEntries >= 8)
                    {
                        break;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                    addedEntries++;
                }

                // Save the archive
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
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
 * 1. When you need to generate a ZIP file but must stop after a specific number of entries, such as limiting a batch to the first eight files for a preview or quota.
 * 2. When building a large archive incrementally and want to keep the partially created ZIP on disk for later resumption or analysis.
 * 3. When creating a sample archive for testing extraction performance without processing the entire source folder.
 * 4. When implementing a user‑controlled cancel operation that saves whatever entries have already been added, allowing the user to retrieve the incomplete archive.
 * 5. When automating a workflow that extracts only a subset of files from a directory into a compressed package for quick download or transfer.
 */
