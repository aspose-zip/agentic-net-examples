// HOW-TO: Create Split ZIP Archive of INI Files with 64KB Segments in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing INI files
            string inputDirectory = @"C:\Data\IniFiles";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Hardcoded base output path (without extension) for split archive
            string outputBasePath = @"C:\Output\ini";

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputBasePath);
            Directory.CreateDirectory(outputDir);

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Get all INI files in the input directory
                string[] iniFiles = Directory.GetFiles(inputDirectory, "*.ini", SearchOption.TopDirectoryOnly);

                foreach (string filePath in iniFiles)
                {
                    // Verify each file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    // Use the file name as the entry name inside the archive
                    string entryName = Path.GetFileName(filePath);

                    // Add the file to the archive
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                // Configure split archive options with 64 KiB segment size
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(64 * 1024);

                // Save the archive as split ZIP segments
                archive.SaveSplit(outputBasePath, saveOptions);
            }

            Console.WriteLine("Split archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up a folder of configuration (.ini) files and ensure each ZIP part is small enough to fit on legacy storage media or email attachments.
 * 2. When an application must distribute configuration files to remote machines that only accept files under a certain size limit, such as 64 KB per segment.
 * 3. When you want to archive logs or settings for compliance and need the archive split into manageable chunks for incremental upload to cloud storage.
 * 4. When automating deployment scripts that package INI files into split ZIP archives to avoid exceeding maximum file size restrictions on network file shares.
 * 5. When creating multi‑volume archives for archival purposes, allowing users to extract individual 64 KB parts without re‑assembling the whole ZIP.
 */
