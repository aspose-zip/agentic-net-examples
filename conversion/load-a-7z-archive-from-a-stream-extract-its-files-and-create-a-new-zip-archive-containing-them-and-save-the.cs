// HOW-TO: Convert 7z Archive to Zip File Using Aspose in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.7z";
            string outputPath = "converted.zip";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary folder for extracting 7z entries
            string tempExtractDir = Path.Combine(Path.GetTempPath(), "SevenZipExtractTemp_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempExtractDir);

            // Load 7z archive from stream and extract entries to temporary folder
            using (FileStream sevenZipStream = File.OpenRead(inputPath))
            using (SevenZipArchive sevenArchive = new SevenZipArchive(sevenZipStream))
            {
                foreach (SevenZipArchiveEntry entry in sevenArchive.Entries)
                {
                    string destinationFile = Path.Combine(tempExtractDir, entry.Name);
                    string destinationDir = Path.GetDirectoryName(destinationFile);
                    if (!string.IsNullOrEmpty(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    using (Stream entryStream = entry.Open())
                    using (FileStream outFile = File.Create(destinationFile))
                    {
                        entryStream.CopyTo(outFile);
                    }
                }
            }

            // Create a new ZIP archive and add all extracted files
            using (Archive zipArchive = new Archive())
            {
                zipArchive.CreateEntries(tempExtractDir);
                zipArchive.Save(outputPath);
            }

            // Clean up temporary extraction folder
            try
            {
                Directory.Delete(tempExtractDir, true);
            }
            catch
            {
                // Ignore cleanup errors
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate legacy 7z backups to a standard ZIP format for compatibility with tools that only read ZIP files.
 * 2. When an application receives a 7z archive via a network stream and must unpack its contents before repackaging them as a ZIP for further processing.
 * 3. When you want to automate the conversion of user‑uploaded 7z packages into ZIP archives to store them in a cloud storage service that only supports ZIP.
 * 4. When a build pipeline extracts resources from a 7z bundle and creates a ZIP bundle to be consumed by downstream deployment scripts.
 * 5. When you need to extract all files from a 7z archive on disk and create a single ZIP archive to send as an email attachment.
 */
