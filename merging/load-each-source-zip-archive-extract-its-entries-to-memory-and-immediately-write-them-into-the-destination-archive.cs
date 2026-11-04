// HOW-TO: Copy All Files From One ZIP to Another In Memory Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output ZIP file paths
            string inputPath = @"C:\Data\source.zip";
            string outputPath = @"C:\Data\dest.zip";

            // Verify that the source archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the source archive for reading
            using (Archive sourceArchive = new Archive(inputPath))
            {
                // Create a new destination archive
                using (Archive destArchive = new Archive())
                {
                    // Iterate over each entry in the source archive
                    foreach (ArchiveEntry entry in sourceArchive.Entries)
                    {
                        // Open the entry stream and copy its contents to a memory stream
                        using (Stream sourceStream = entry.Open())
                        {
                            MemoryStream memory = new MemoryStream();
                            sourceStream.CopyTo(memory);
                            memory.Position = 0;

                            // Add the entry to the destination archive using the memory stream
                            destArchive.CreateEntry(entry.Name, memory);
                        }
                    }

                    // Save the destination archive to the specified output path
                    destArchive.Save(outputPath);
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
 * 1. When you need to duplicate the contents of an existing ZIP file into a new archive without writing intermediate files to disk.
 * 2. When you want to programmatically repackage files from a source ZIP into a destination ZIP while applying in‑memory processing for performance.
 * 3. When you are building a backup utility that reads a user’s uploaded ZIP, extracts each entry to memory, and stores them in a new archive on the server.
 * 4. When you must migrate archived data from one storage location to another, preserving entry names and structure using C# and Aspose.Zip.
 * 5. When you are creating a custom compression pipeline that reads entries from a source archive, modifies them in memory, and writes the result to a new ZIP file.
 */
