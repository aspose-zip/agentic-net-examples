// HOW-TO: Extract Nested ZIP and Recompress Contents into FlattenedContent Entry in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "nested.zip";
        string outputPath = "flattened.zip";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Archive outer = new Archive(inputPath))
            {
                // Locate the first nested archive entry (e.g., a .zip file)
                ArchiveEntry nestedEntry = null;
                foreach (ArchiveEntry entry in outer.Entries)
                {
                    if (entry.Name.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        nestedEntry = entry;
                        break;
                    }
                }

                if (nestedEntry == null)
                {
                    Console.Error.WriteLine("No nested archive entry found.");
                    return;
                }

                // Extract the nested archive into a memory stream
                using (MemoryStream nestedStream = new MemoryStream())
                {
                    nestedEntry.Open().CopyTo(nestedStream);
                    nestedStream.Position = 0;

                    // Open the inner archive from the memory stream
                    using (Archive inner = new Archive(nestedStream))
                    {
                        // Create a new in‑memory archive that will hold the flattened content
                        using (MemoryStream flattenedStream = new MemoryStream())
                        {
                            using (Archive flattened = new Archive())
                            {
                                foreach (ArchiveEntry innerEntry in inner.Entries)
                                {
                                    using (MemoryStream entryContent = new MemoryStream())
                                    {
                                        innerEntry.Open().CopyTo(entryContent);
                                        entryContent.Position = 0;
                                        flattened.CreateEntry(innerEntry.Name, entryContent);
                                    }
                                }

                                // Save the flattened archive into the memory stream
                                flattened.Save(flattenedStream);
                            }

                            flattenedStream.Position = 0;

                            // Remove the original nested archive entry
                            outer.DeleteEntry(nestedEntry);

                            // Add the new entry containing the flattened content
                            outer.CreateEntry("FlattenedContent", flattenedStream);
                        }
                    }
                }

                // Save the modified outer archive
                outer.Save(outputPath);
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
 * 1. When you receive a ZIP file that contains another ZIP and need to provide a single‑level archive for downstream systems that cannot handle nested archives.
 * 2. When you want to simplify deployment packages by flattening inner files into a new entry so that installers can read all resources from one archive.
 * 3. When you need to programmatically extract a nested archive in memory and re‑package its files without writing temporary files to disk, improving performance and security.
 * 4. When a cloud service expects a specific entry name like “FlattenedContent” inside a ZIP and you must transform an existing nested archive to meet that requirement.
 * 5. When you are building a migration tool that consolidates multiple inner archives into a single outer archive to reduce storage overhead and simplify backup processes.
 */
