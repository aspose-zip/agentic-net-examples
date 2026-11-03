// HOW-TO: Convert ZIP Archive to 7Z on the Fly in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP and output 7Z paths
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            // Verify input ZIP exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            string outputDirectory = Path.GetDirectoryName(output7zPath);
            Directory.CreateDirectory(outputDirectory);

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new 7Z archive in memory
                using (SevenZipArchive sevenZip = new SevenZipArchive())
                {
                    // Iterate through each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directories
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Open the ZIP entry stream
                        using (Stream zipEntryStream = zipEntry.Open())
                        {
                            // Add the entry to the 7Z archive using the same name
                            sevenZip.CreateEntry(zipEntry.Name, zipEntryStream);
                        }
                    }

                    // Save the 7Z archive to the specified output path
                    sevenZip.Save(output7zPath);
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
 * 1. When you need to migrate legacy ZIP files to 7Z for better compression before uploading to cloud storage.
 * 2. When you want to programmatically repackage user‑uploaded ZIP archives into 7Z to reduce download size.
 * 3. When an automated build pipeline must convert generated ZIP artifacts into 7Z for distribution.
 * 4. When a desktop utility must read a ZIP backup and save it as a 7Z archive without extracting to disk.
 * 5. When integrating with a system that only accepts 7Z files, you can transform incoming ZIPs on the fly.
 */
