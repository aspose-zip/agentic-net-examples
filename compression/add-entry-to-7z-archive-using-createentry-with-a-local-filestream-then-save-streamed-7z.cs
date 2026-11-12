// HOW-TO: Create a 7z Archive from a File Stream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file and output archive paths
            string inputFilePath = "input.txt";
            string outputArchivePath = "streamed.7z";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputArchivePath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            // Open streams and create the 7z archive
            using (FileStream sourceStream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream archiveStream = File.Open(outputArchivePath, FileMode.Create))
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Add entry to the archive using the source stream
                archive.CreateEntry("input.txt", sourceStream);

                // Save the archive to the output stream
                archive.Save(archiveStream);
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
 * 1. When you need to compress a single local file into a 7z archive without loading the entire file into memory.
 * 2. When you want to generate a 7z archive on the fly and write it directly to a disk or network stream.
 * 3. When your application must create a password‑free 7z package for backup or transfer using Aspose.Zip.
 * 4. When you are building a service that streams large log files into a compressed 7z container for efficient storage.
 * 5. When you need to programmatically add entries to a 7z file using a FileStream and then save the archive to a specific path.
 */
