// HOW-TO: Merge Multiple ZIP Archives Into One File Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputArchivePath1 = @"C:\Data\archive1.zip";
            string inputArchivePath2 = @"C:\Data\archive2.zip";
            string outputArchivePath = @"C:\Data\merged.zip";

            // Validate input files
            if (!File.Exists(inputArchivePath1))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath1}");
                return;
            }
            if (!File.Exists(inputArchivePath2))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // List of temporary streams that hold entry data until the archive is saved
            List<MemoryStream> tempStreams = new List<MemoryStream>();

            // Create the merged archive
            using (Archive mergedArchive = new Archive())
            {
                // Array of source archive paths
                string[] sourceArchives = new string[] { inputArchivePath1, inputArchivePath2 };

                foreach (string srcPath in sourceArchives)
                {
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        foreach (ArchiveEntry srcEntry in srcArchive.Entries)
                        {
                            // Skip duplicate entry names
                            bool exists = mergedArchive.Entries.Any(e => e.Name == srcEntry.Name);
                            if (exists)
                                continue;

                            // Read entry data into a memory stream
                            using (Stream srcStream = srcEntry.Open())
                            {
                                MemoryStream ms = new MemoryStream();
                                srcStream.CopyTo(ms);
                                ms.Position = 0;

                                // Add entry to the merged archive
                                mergedArchive.CreateEntry(srcEntry.Name, ms);
                                tempStreams.Add(ms);
                            }
                        }
                    }
                }

                // Save the merged archive to the output file
                using (FileStream outStream = File.Open(outputArchivePath, FileMode.Create))
                {
                    mergedArchive.Save(outStream);
                }
            }

            // Dispose temporary streams
            foreach (MemoryStream ms in tempStreams)
            {
                ms.Dispose();
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
 * 1. When you need to combine several backup ZIP files into a single archive for easier distribution without using command‑line tools.
 * 2. When an application must programmatically consolidate user‑uploaded ZIP packages into one downloadable bundle.
 * 3. When a build process generates separate component archives and you want to merge them into a single deployment package.
 * 4. When you have duplicate file names across archives and need to create a merged ZIP that keeps only the first occurrence.
 * 5. When you want to automate the merging of log archives on a server before archiving them to cloud storage.
 */
