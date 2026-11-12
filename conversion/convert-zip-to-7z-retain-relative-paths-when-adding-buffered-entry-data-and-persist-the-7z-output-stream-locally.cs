// HOW-TO: Convert ZIP Archive to 7z with Preserved Paths in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP and output 7z paths
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            // Validate input file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(output7zPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new 7z archive in memory
                using (SevenZipArchive sevenZip = new SevenZipArchive())
                {
                    // Iterate through each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directory entries
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Read the ZIP entry data into a memory buffer
                        using (Stream zipStream = zipEntry.Open())
                        {
                            using (MemoryStream buffer = new MemoryStream())
                            {
                                zipStream.CopyTo(buffer);
                                buffer.Position = 0;

                                // Create a corresponding entry in the 7z archive with the same relative path
                                sevenZip.CreateEntry(zipEntry.Name, buffer);
                            }
                        }
                    }

                    // Save the 7z archive to a file stream
                    using (FileStream outStream = new FileStream(output7zPath, FileMode.Create, FileAccess.Write))
                    {
                        sevenZip.Save(outStream);
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
 * 1. When you need to migrate existing ZIP files to the more efficient 7z format while keeping the folder structure intact.
 * 2. When a .NET application must programmatically repackage user‑uploaded ZIP archives into 7z for reduced storage size.
 * 3. When you want to read each file from a ZIP, process it in memory, and write it to a new 7z archive without extracting to disk.
 * 4. When an automated build pipeline has to convert generated ZIP artifacts to 7z before publishing them to a repository.
 * 5. When you need to ensure that the relative paths of files inside a ZIP are preserved after conversion to a 7z archive for later extraction.
 */
