// HOW-TO: Create LZ4 Compressed TAR Archive from Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input folder and output file paths
            string inputFolder = @"C:\Data\MyFolder";
            string outputPath = @"C:\Data\MyFolder.tar.lz4";

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a TAR archive and add all files from the input folder
            using (TarArchive tarArchive = new TarArchive())
            {
                string[] files = Directory.GetFiles(inputFolder, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Compute entry name relative to the input folder and use forward slashes
                    string relativePath = Path.GetRelativePath(inputFolder, filePath);
                    string entryName = relativePath.Replace('\\', '/');

                    // Add the file to the TAR archive
                    tarArchive.CreateEntry(entryName, filePath);
                }

                // Save the TAR archive compressed with LZ4
                tarArchive.SaveLZ4Compressed(outputPath);
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
 * 1. When you need to back up a directory to a single .tar.lz4 file for fast network transfer in a .NET application.
 * 2. When you want to create a portable TAR archive with LZ4 compression to reduce storage size while preserving Unix‑style paths.
 * 3. When you are building a deployment pipeline that packages build artifacts into a compressed TAR stream for cross‑platform extraction.
 * 4. When you must generate a checksum‑protected LZ4 archive to ensure data integrity during archival of log files.
 * 5. When you are implementing a custom backup utility in C# that archives and compresses user‑selected folders into a .tar.lz4 container.
 */
