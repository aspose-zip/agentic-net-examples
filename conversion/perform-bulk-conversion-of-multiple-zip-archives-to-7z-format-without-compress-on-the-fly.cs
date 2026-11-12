// HOW-TO: Convert Multiple ZIP Files To 7Z Archives In C# Without Recompressing (Aspose.ZIP for .NET)
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
            // Hardcoded list of ZIP files to convert
            string[] inputZips = new string[]
            {
                @"C:\Input\archive1.zip",
                @"C:\Input\archive2.zip"
            };

            // Output folder for the generated 7z files
            string outputFolder = @"C:\Output\7z";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            foreach (string inputPath in inputZips)
            {
                // Verify the input ZIP file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output 7z file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".7z");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Open the source ZIP archive
                using (Archive zipArchive = new Archive(inputPath))
                {
                    // Create a new 7z archive
                    using (SevenZipArchive sevenZip = new SevenZipArchive())
                    {
                        // Copy each entry from the ZIP to the 7z archive
                        foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                        {
                            using (Stream entryStream = zipEntry.Open())
                            {
                                // Add entry to the 7z archive with the same name
                                sevenZip.CreateEntry(zipEntry.Name, entryStream);
                            }
                        }

                        // Save the 7z archive to the output path
                        sevenZip.Save(outputPath);
                    }
                }

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
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
 * 1. When you need to migrate a batch of existing ZIP backups to 7z format for compatibility with a 7‑Zip‑only deployment pipeline.
 * 2. When you want to reduce storage costs by converting many ZIP archives to 7z while preserving the original compression level (no recompression).
 * 3. When an application must package files for distribution to users who only have 7‑Zip installed, and you have a list of ZIP archives ready to convert.
 * 4. When automating a nightly job that consolidates archived logs stored as ZIP files into 7z containers for faster upload to a remote server.
 * 5. When you are building a migration tool that replaces legacy ZIP archives with 7z archives across multiple directories without extracting the contents.
 */
