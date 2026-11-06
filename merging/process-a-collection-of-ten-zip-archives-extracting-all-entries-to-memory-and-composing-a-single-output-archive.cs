// HOW-TO: Combine Multiple ZIP Files into One Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing the ten ZIP files
            string inputDirectory = "C:\\Data\\Input";
            // Hardcoded output ZIP file path
            string outputPath = "C:\\Data\\Output\\combined.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold entry names and their in‑memory data
            List<Tuple<string, MemoryStream>> collectedEntries = new List<Tuple<string, MemoryStream>>();

            // Process ten ZIP archives named input1.zip … input10.zip
            for (int i = 1; i <= 10; i++)
            {
                string inputPath = Path.Combine(inputDirectory, $"input{i}.zip");

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Open the source archive
                using (Archive sourceArchive = new Archive(inputPath))
                {
                    // Iterate through all entries in the current archive
                    foreach (ArchiveEntry entry in sourceArchive.Entries)
                    {
                        // Open the entry stream
                        using (Stream entryStream = entry.Open())
                        {
                            // Copy entry data to a memory stream
                            MemoryStream memory = new MemoryStream();
                            entryStream.CopyTo(memory);
                            memory.Position = 0;

                            // Store the entry name and its memory stream for later addition
                            collectedEntries.Add(Tuple.Create(entry.Name, memory));
                        }
                    }
                }
            }

            // Create the combined output archive
            using (Archive outputArchive = new Archive())
            {
                // Add each collected entry to the output archive
                foreach (Tuple<string, MemoryStream> item in collectedEntries)
                {
                    outputArchive.CreateEntry(item.Item1, item.Item2);
                }

                // Save the combined archive to the output file
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    outputArchive.Save(outStream, new ArchiveSaveOptions());
                }
            }

            // Dispose all memory streams after the archive has been saved
            foreach (Tuple<string, MemoryStream> item in collectedEntries)
            {
                item.Item2.Dispose();
            }

            Console.WriteLine("Combined archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to merge several related ZIP packages into a single archive for easier distribution.
 * 2. When you must extract files from multiple ZIPs into memory before applying further processing or validation.
 * 3. When you want to create a combined backup archive from a set of daily ZIP snapshots without writing intermediate files to disk.
 * 4. When you are building a web service that receives multiple uploaded ZIPs and returns one consolidated ZIP to the client.
 * 5. When you need to programmatically repackage contents of many archives while preserving original entry names using C# and Aspose.Zip.
 */
