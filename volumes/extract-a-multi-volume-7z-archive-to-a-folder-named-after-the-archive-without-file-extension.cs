// HOW-TO: Extract Multi‑Volume 7z Archive to Folder Named After Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input path to the first volume of the multi‑volume 7z archive
            string inputPath = @"C:\Archives\myarchive.7z.001";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output folder name (archive name without extensions)
            string baseName = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(inputPath));
            string outputFolder = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, baseName);

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Open the multi‑volume 7z archive (Aspose.Zip handles additional volumes automatically)
            using (SevenZipArchive archive = new SevenZipArchive(inputPath))
            {
                // Extract each entry to the output folder
                foreach (SevenZipArchiveEntry entry in archive.Entries)
                {
                    string entryPath = Path.Combine(outputFolder, entry.Name);
                    // Ensure the directory for the entry exists
                    Directory.CreateDirectory(Path.GetDirectoryName(entryPath) ?? string.Empty);

                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = new FileStream(entryPath, FileMode.Create, FileAccess.Write))
                    {
                        entryStream.CopyTo(fileStream);
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
 * 1. When you receive a large split 7z backup that was divided into .001, .002 files and need to programmatically extract it to a directory automatically named after the original archive.
 * 2. When an automated deployment pipeline must unpack multi‑volume 7z packages and place the contents in a dedicated folder without manually specifying the folder name.
 * 3. When a desktop application offers users the ability to open archived project files that are stored as multi‑part 7z archives and should extract them to a clean, self‑named workspace.
 * 4. When a server‑side service processes incoming compressed data streams split across several 7z volumes and must extract them to a predictable location for further processing.
 * 5. When you need to integrate Aspose.Zip for .NET to handle multi‑volume 7z extraction while ensuring the output directory matches the archive’s base name for easy organization.
 */
