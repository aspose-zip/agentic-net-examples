// HOW-TO: Flatten Nested ZIP Archives and Save Output Size in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.zip";
            string outputPath = "output.zip";
            string sizeReportPath = "output_size.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the outer archive
            using (Archive outer = new Archive(inputPath))
            {
                List<ArchiveEntry> entriesToDelete = new List<ArchiveEntry>();
                List<string> namesToInsert = new List<string>();
                List<MemoryStream> contentToInsert = new List<MemoryStream>();

                // Identify nested zip entries
                foreach (ArchiveEntry entry in outer.Entries)
                {
                    if (entry.Name.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        entriesToDelete.Add(entry);

                        // Extract nested zip into memory
                        using (MemoryStream innerCompressed = new MemoryStream())
                        {
                            entry.Open().CopyTo(innerCompressed);
                            innerCompressed.Position = 0;

                            // Open inner archive from memory
                            using (Archive inner = new Archive(innerCompressed))
                            {
                                foreach (ArchiveEntry innerEntry in inner.Entries)
                                {
                                    namesToInsert.Add(innerEntry.Name);
                                    MemoryStream content = new MemoryStream();
                                    innerEntry.Open().CopyTo(content);
                                    content.Position = 0;
                                    contentToInsert.Add(content);
                                }
                            }
                        }
                    }
                }

                // Delete original nested zip entries
                foreach (ArchiveEntry e in entriesToDelete)
                {
                    outer.DeleteEntry(e);
                }

                // Insert flattened entries into outer archive
                for (int i = 0; i < namesToInsert.Count; i++)
                {
                    MemoryStream ms = contentToInsert[i];
                    ms.Position = 0;
                    outer.CreateEntry(namesToInsert[i], ms);
                }

                // Save the modified archive
                outer.Save(outputPath);
            }

            // Record new archive size
            Directory.CreateDirectory(Path.GetDirectoryName(sizeReportPath));
            long newSize = new FileInfo(outputPath).Length;
            File.WriteAllText(sizeReportPath, $"New archive size: {newSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine files from multiple embedded zip files into a single flat zip for easier distribution.
 * 2. When you want to delete the original nested zip entries after extracting their contents to simplify the archive structure.
 * 3. When you must generate a text report that records the final zip file size for logging or compliance purposes.
 * 4. When you are processing uploaded zip packages that may contain inner zip files and need to flatten them before further processing.
 * 5. When you are automating a build pipeline that creates a consolidated archive and need to verify its size after flattening nested archives.
 */
