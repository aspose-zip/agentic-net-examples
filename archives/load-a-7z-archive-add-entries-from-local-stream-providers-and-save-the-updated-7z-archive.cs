// HOW-TO: Add Files to Existing 7z Archive From Streams in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputArchivePath = "input.7z";
            string outputArchivePath = "output.7z";
            string fileToAdd1 = "add1.txt";
            string fileToAdd2 = "add2.txt";

            // Validate input archive and files
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }
            if (!File.Exists(fileToAdd1))
            {
                Console.Error.WriteLine($"File not found: {fileToAdd1}");
                return;
            }
            if (!File.Exists(fileToAdd2))
            {
                Console.Error.WriteLine($"File not found: {fileToAdd2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Load existing 7z archive, add entries from streams, and save
            using (SevenZipArchive archive = new SevenZipArchive(inputArchivePath))
            {
                using (FileStream stream1 = new FileStream(fileToAdd1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry(Path.GetFileName(fileToAdd1), stream1);
                }

                using (FileStream stream2 = new FileStream(fileToAdd2, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry(Path.GetFileName(fileToAdd2), stream2);
                }

                archive.Save(outputArchivePath);
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
 * 1. When you need to programmatically update a 7z backup by inserting new log files without recreating the whole archive.
 * 2. When a desktop application must merge user‑generated reports into an existing 7z package before sending it to a server.
 * 3. When an automated build script has to add compiled artifacts to a pre‑existing 7z distribution bundle using file streams.
 * 4. When a cloud service processes incoming files and appends them to a stored 7z archive while preserving the original compression.
 * 5. When a migration tool reads large files as streams and updates an existing 7z archive to include additional configuration files.
 */
