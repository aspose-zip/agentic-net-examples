// HOW-TO: Convert ZIP to 7z in C# Skipping Directory Entries (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
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

            // Verify input ZIP exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new 7z archive
                using (SevenZipArchive sevenZip = new SevenZipArchive())
                {
                    // Keep entry streams open until the 7z archive is saved
                    List<Stream> openStreams = new List<Stream>();

                    // Iterate over ZIP entries and add only files
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directory entries
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Open the entry stream and add it to the 7z archive
                        Stream entryStream = zipEntry.Open();
                        openStreams.Add(entryStream);
                        sevenZip.CreateEntry(zipEntry.Name, entryStream);
                    }

                    // Save the 7z archive to the output path
                    sevenZip.Save(output7zPath);

                    // Dispose all opened entry streams
                    foreach (Stream s in openStreams)
                    {
                        s.Dispose();
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
 * 1. When you need to migrate legacy ZIP backups to 7z format while preserving only actual files and omitting empty folders.
 * 2. When building a .NET utility that creates smaller 7z archives from user‑uploaded ZIP files by excluding directory entries.
 * 3. When automating a deployment pipeline that repackages ZIP packages into 7z for faster download, and you want to ignore folder placeholders.
 * 4. When developing a data‑archiving service that reads ZIP streams and writes them to 7z storage, ensuring only file streams are transferred.
 * 5. When converting archived logs from ZIP to 7z in a C# application, and you must skip directory entries to avoid unnecessary entries in the target archive.
 */
