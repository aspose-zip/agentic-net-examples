// HOW-TO: Merge Multiple ZIP Archives Sequentially In C# With Aspose (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define source archive paths
            string sourceArchive1 = @"C:\Data\Archive1.zip";
            string sourceArchive2 = @"C:\Data\Archive2.zip";
            string sourceArchive3 = @"C:\Data\Archive3.zip";

            // Define output archive path
            string outputPath = @"C:\Data\MergedArchive.zip";

            // Validate each source archive exists
            if (!File.Exists(sourceArchive1))
            {
                Console.Error.WriteLine($"File not found: {sourceArchive1}");
                return;
            }
            if (!File.Exists(sourceArchive2))
            {
                Console.Error.WriteLine($"File not found: {sourceArchive2}");
                return;
            }
            if (!File.Exists(sourceArchive3))
            {
                Console.Error.WriteLine($"File not found: {sourceArchive3}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the destination archive
            using (Archive destArchive = new Archive())
            {
                // List of source archives to merge
                string[] sourcePaths = new string[] { sourceArchive1, sourceArchive2, sourceArchive3 };

                foreach (string srcPath in sourcePaths)
                {
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        foreach (ArchiveEntry srcEntry in srcArchive.Entries)
                        {
                            // Open the source entry stream
                            using (Stream entryStream = srcEntry.Open())
                            {
                                // Add the entry to the destination archive with the same name
                                destArchive.CreateEntry(srcEntry.Name, entryStream);
                            }
                        }
                    }
                }

                // Save the merged archive
                destArchive.Save(outputPath);
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
 * 1. When you need to combine several project backup ZIP files into a single archive for easier distribution.
 * 2. When an application must batch‑process log archives from multiple sources and create one consolidated ZIP for archiving.
 * 3. When deploying software updates that are split across multiple ZIP packages and you want to merge them into one installer archive.
 * 4. When consolidating user‑generated content archives before uploading them to cloud storage to reduce the number of files.
 * 5. When automating the creation of a master archive from daily generated ZIP reports for long‑term retention.
 */
