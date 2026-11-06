// HOW-TO: Merge Two ZIP Files Into One Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "input1.zip";
            string inputPath2 = "input2.zip";
            string outputPath = "merged.zip";

            // Validate input files
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
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Open source archives and create a new archive for merging
            using (Archive sourceArchive1 = new Archive(inputPath1))
            using (Archive sourceArchive2 = new Archive(inputPath2))
            using (Archive mergedArchive = new Archive())
            {
                // Copy entries from the first archive
                foreach (ArchiveEntry sourceEntry in sourceArchive1.Entries)
                {
                    using (Stream entryStream = sourceEntry.Open())
                    {
                        mergedArchive.CreateEntry(sourceEntry.Name, entryStream);
                    }
                }

                // Copy entries from the second archive
                foreach (ArchiveEntry sourceEntry in sourceArchive2.Entries)
                {
                    using (Stream entryStream = sourceEntry.Open())
                    {
                        // If an entry with the same name already exists, rename to avoid conflict
                        if (mergedArchive.Entries.Any(e => e.Name == sourceEntry.Name))
                        {
                            string newName = "source2_" + sourceEntry.Name;
                            mergedArchive.CreateEntry(newName, entryStream);
                        }
                        else
                        {
                            mergedArchive.CreateEntry(sourceEntry.Name, entryStream);
                        }
                    }
                }

                // Save the merged archive to the output path
                mergedArchive.Save(outputPath);
            }

            Console.WriteLine("Archives merged successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine multiple zip packages into a single distributable file in a .NET application.
 * 2. When you want to programmatically consolidate backup archives from different sources without extracting them to disk.
 * 3. When you must create a unified deployment bundle that includes resources from separate zip projects while preserving original entry names.
 * 4. When you need to avoid name collisions while merging zip contents by automatically renaming duplicate entries.
 * 5. When you are building an automated pipeline that reads existing zip archives and writes a merged archive using the same Aspose.Zip Archive class.
 */
