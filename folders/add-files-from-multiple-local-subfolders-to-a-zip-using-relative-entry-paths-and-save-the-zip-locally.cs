// HOW-TO: Create Zip From Multiple Subfolders With Relative Paths In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input files from two subfolders
            string baseInputDir = "InputData";

            string filePath1 = Path.Combine(baseInputDir, "FolderA", "file1.txt");
            if (!File.Exists(filePath1))
            {
                Console.Error.WriteLine($"File not found: {filePath1}");
                return;
            }

            string filePath2 = Path.Combine(baseInputDir, "FolderA", "file2.txt");
            if (!File.Exists(filePath2))
            {
                Console.Error.WriteLine($"File not found: {filePath2}");
                return;
            }

            string filePath3 = Path.Combine(baseInputDir, "FolderB", "file3.txt");
            if (!File.Exists(filePath3))
            {
                Console.Error.WriteLine($"File not found: {filePath3}");
                return;
            }

            string filePath4 = Path.Combine(baseInputDir, "FolderB", "file4.txt");
            if (!File.Exists(filePath4))
            {
                Console.Error.WriteLine($"File not found: {filePath4}");
                return;
            }

            // Output ZIP path
            string outputPath = Path.Combine("Output", "archive.zip");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open file streams (keep them open until archive is saved)
            List<FileStream> streams = new List<FileStream>();
            FileStream stream1 = File.Open(filePath1, FileMode.Open, FileAccess.Read);
            streams.Add(stream1);
            FileStream stream2 = File.Open(filePath2, FileMode.Open, FileAccess.Read);
            streams.Add(stream2);
            FileStream stream3 = File.Open(filePath3, FileMode.Open, FileAccess.Read);
            streams.Add(stream3);
            FileStream stream4 = File.Open(filePath4, FileMode.Open, FileAccess.Read);
            streams.Add(stream4);

            // Create archive and add entries with relative paths
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("FolderA/file1.txt", stream1);
                archive.CreateEntry("FolderA/file2.txt", stream2);
                archive.CreateEntry("FolderB/file3.txt", stream3);
                archive.CreateEntry("FolderB/file4.txt", stream4);

                // Save the archive
                using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
                {
                    archive.Save(zipFile, new ArchiveSaveOptions());
                }
            }

            // Dispose all opened file streams
            foreach (FileStream fs in streams)
            {
                fs.Dispose();
            }

            Console.WriteLine($"ZIP archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package configuration files located in different project folders into a single ZIP archive for deployment.
 * 2. When you want to generate a backup ZIP that preserves the original folder hierarchy of log files before uploading to cloud storage.
 * 3. When an application must bundle resource files from separate modules into one archive to distribute to end‑users.
 * 4. When a build script has to create a ZIP of assets spread across several directories while keeping their relative paths for later extraction.
 * 5. When you are implementing a feature that collects user‑generated documents from multiple subfolders and saves them as a single compressed archive on the server.
 */
