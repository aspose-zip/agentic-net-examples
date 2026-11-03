// HOW-TO: Convert RAR Archive to ZIP on the Fly in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.rar";
        string outputPath = @"C:\Data\sample_converted.zip";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Open the RAR archive for reading
            using (FileStream rarStream = File.OpenRead(inputPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            // Create a new ZIP archive
            using (Archive zipArchive = new Archive())
            {
                // Iterate through each entry in the RAR archive
                foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                {
                    // Open the entry stream from the RAR archive
                    using (Stream entryStream = rarEntry.Open())
                    {
                        // Add the entry to the ZIP archive with the same name
                        zipArchive.CreateEntry(rarEntry.Name, entryStream);
                    }
                }

                // Save the ZIP archive to the specified output path
                zipArchive.Save(outputPath);
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
 * 1. When you need to replace legacy RAR files with ZIP files for better compatibility in a .NET application.
 * 2. When a batch process must read RAR archives and create ZIP archives without extracting to disk first.
 * 3. When an automated migration tool has to convert user‑uploaded RAR uploads into ZIP for storage in a cloud repository.
 * 4. When a Windows service has to re‑package archived logs from RAR to ZIP to meet corporate compression standards.
 * 5. When a backup script must transform existing RAR backups into ZIP format to unify archive types across multiple platforms.
 */
