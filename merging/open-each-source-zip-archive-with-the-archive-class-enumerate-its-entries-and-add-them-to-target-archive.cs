// HOW-TO: Copy All Files From One Zip To Another Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string sourcePath = @"C:\Data\source.zip";
            string targetPath = @"C:\Data\target.zip";

            // Verify source archive exists
            if (!File.Exists(sourcePath))
            {
                Console.Error.WriteLine($"File not found: {sourcePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

            // Open source archive for reading and create a new target archive
            using (Archive sourceArchive = new Archive(sourcePath))
            using (Archive targetArchive = new Archive())
            {
                // Enumerate each entry in the source archive and add it to the target archive
                foreach (ArchiveEntry entry in sourceArchive.Entries)
                {
                    // Add entry to target archive using the same entry name and stream
                    targetArchive.CreateEntry(entry.Name, entry.Open());
                }

                // Save the target archive to the specified path
                targetArchive.Save(targetPath);
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
 * 1. When you need to duplicate the contents of an existing ZIP archive into a new archive without extracting the files to disk.
 * 2. When you want to programmatically create a backup ZIP file that contains the same entries as the original archive.
 * 3. When you are consolidating multiple ZIP archives and need to copy entries from one archive into a target archive as part of a merge process.
 * 4. When you must preserve the original entry names and streams while re‑saving them into a different location or with different compression settings.
 * 5. When you are building a custom deployment package that starts from a template ZIP and you need to copy its files into a newly generated archive.
 */
