// HOW-TO: Add Bzip2 Compressed File to XAR Archive Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file and output XAR archive paths
            string inputFilePath = "input.txt";
            string outputArchivePath = "output.xar";

            // Validate input file existence
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputArchivePath);
            Directory.CreateDirectory(outputDir);

            // Temporary path for Bzip2-compressed file
            string tempCompressedPath = Path.Combine(Path.GetTempPath(), "temp_compressed.bz2");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCompressedPath));

            // Compress the input file using Bzip2 into a temporary file
            using (FileStream sourceStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream compressedFileStream = new FileStream(tempCompressedPath, FileMode.Create, FileAccess.Write))
            {
                using (Bzip2Archive bzip2 = new Bzip2Archive())
                {
                    bzip2.SetSource(sourceStream);
                    bzip2.Save(compressedFileStream);
                }
            }

            // Create a new XAR archive and add the Bzip2-compressed entry
            using (XarArchive xar = new XarArchive())
            {
                // Store compression because data is already compressed
                XarStoreCompressionSettings storeSettings = new XarStoreCompressionSettings();

                FileInfo compressedFileInfo = new FileInfo(tempCompressedPath);
                xar.CreateEntry("compressed_entry.bz2", compressedFileInfo, false, storeSettings);

                // Save the XAR archive to disk
                xar.Save(outputArchivePath);
            }

            // Clean up temporary compressed file
            if (File.Exists(tempCompressedPath))
            {
                File.Delete(tempCompressedPath);
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
 * 1. When you need to package a pre‑compressed log file into a XAR container for distribution without recompressing it.
 * 2. When creating a software update bundle that includes Bzip2‑compressed resources and must preserve their original compression.
 * 3. When archiving large data files on macOS where XAR is the native format and you want to embed already compressed assets.
 * 4. When building a backup system that stores files in XAR archives while keeping existing Bzip2 compression to save processing time.
 * 5. When generating a portable archive for cross‑platform deployment that contains Bzip2‑compressed configuration files alongside other entries.
 */
