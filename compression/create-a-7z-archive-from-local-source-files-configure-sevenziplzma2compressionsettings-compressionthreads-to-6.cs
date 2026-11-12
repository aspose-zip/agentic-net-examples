// HOW-TO: Create 7z Archive With Multi‑Threaded LZMA2 Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output archive path
            string sourceDir = @"C:\Data\SourceFiles";
            string outputPath = @"C:\Data\Output\parallel.7z";

            // Verify input directory exists
            if (!Directory.Exists(sourceDir))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure 7z compression settings
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings());

            // Create the 7z archive with the specified settings
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                // Add each file from the source directory to the archive
                foreach (string filePath in Directory.GetFiles(sourceDir))
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        archive.CreateEntry(entryName, fileStream);
                    }
                }

                // Save the archive to the output path
                archive.Save(outputPath);
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
 * 1. When you need to package a batch of log files into a single 7z archive quickly by using six parallel compression threads in a C# application.
 * 2. When you want to generate a high‑performance backup of a directory on a server, leveraging Aspose.Zip’s SevenZipLZMA2 settings to reduce compression time.
 * 3. When an automated build process must compress generated artifacts into a 7z file with controlled threading to avoid overloading the CPU.
 * 4. When a desktop utility has to create a portable archive of user‑selected documents while ensuring consistent compression performance across different machines.
 * 5. When a cloud‑based service prepares data for transfer by creating a 7z archive with multi‑threaded LZMA2 compression directly from C# code.
 */
