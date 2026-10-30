// HOW-TO: Extract Nested ZIP Files to Separate Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "input.zip";

            // Hardcoded output directory for extracted nested ZIPs
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the outer ZIP archive
            using (Archive outerArchive = new Archive(inputPath))
            {
                // Iterate through all entries in the outer archive
                foreach (ArchiveEntry entry in outerArchive.Entries)
                {
                    // Identify nested ZIP entries by file extension (case‑insensitive)
                    if (entry.Name != null && entry.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        // Open the entry stream
                        using (Stream entryStream = entry.Open())
                        {
                            // Copy entry data to a memory stream
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                entryStream.CopyTo(memoryStream);
                                memoryStream.Position = 0; // Reset position for reading

                                // Determine output file path for the extracted nested ZIP
                                string outputPath = Path.Combine(outputDirectory, entry.Name);

                                // Ensure the directory for the output file exists
                                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                                // Write the memory stream contents to the output file
                                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                                {
                                    memoryStream.CopyTo(fileStream);
                                }

                                Console.WriteLine($"Extracted nested ZIP: {entry.Name} to {outputPath}");
                            }
                        }
                    }
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
 * 1. When you receive a master ZIP that contains multiple ZIP archives and need to extract each inner archive as an independent file for further processing.
 * 2. When a deployment pipeline must unpack nested compressed packages and store them on disk without writing the outer archive to a temporary location.
 * 3. When a document management system imports a ZIP bundle of ZIP‑packed documents and you must isolate each inner ZIP for indexing.
 * 4. When you want to read a nested ZIP entry into a MemoryStream for validation before saving it as a separate file.
 * 5. When automating data migration you need to separate embedded ZIP files from a larger archive using Aspose.Zip in C#.
 */
