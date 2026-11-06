// HOW-TO: Combine Multiple ZIP Files Preserving Entry Order in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string sourceArchive1 = Path.Combine(dataDir, "source1.zip");
            string sourceArchive2 = Path.Combine(dataDir, "source2.zip");
            string destinationArchive = Path.Combine(dataDir, "combined.zip");

            // Validate input files
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(destinationArchive));

            // List of source archives
            string[] sourceArchives = new string[] { sourceArchive1, sourceArchive2 };

            // Keep temporary streams alive until the archive is saved
            List<MemoryStream> tempStreams = new List<MemoryStream>();

            // Create destination archive
            using (Archive destArchive = new Archive())
            {
                foreach (string srcPath in sourceArchives)
                {
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        // Iterate entries in the order they appear
                        foreach (ArchiveEntry srcEntry in srcArchive.Entries)
                        {
                            // Open source entry stream
                            using (Stream srcStream = srcEntry.Open())
                            {
                                // Copy to a memory stream to keep data after source archive is closed
                                MemoryStream ms = new MemoryStream();
                                srcStream.CopyTo(ms);
                                ms.Position = 0;

                                // Add entry to destination archive with the same name
                                destArchive.CreateEntry(srcEntry.Name, ms);

                                // Store the memory stream for later disposal
                                tempStreams.Add(ms);
                            }
                        }
                    }
                }

                // Save the combined archive
                destArchive.Save(destinationArchive);
            }

            // Dispose temporary streams
            foreach (MemoryStream ms in tempStreams)
            {
                ms.Dispose();
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
 * 1. When you need to create a single distribution package from several existing ZIP archives while keeping the original file sequence intact.
 * 2. When a build pipeline must merge component archives into one installer ZIP without reordering the entries.
 * 3. When consolidating backup archives from different sources into a unified ZIP while preserving the chronological order of files.
 * 4. When generating a combined archive for a client that expects the files to appear in the same order as in the original source ZIPs.
 * 5. When automating the packaging of modular resources where the entry order influences processing scripts that read the ZIP sequentially.
 */
