// HOW-TO: Create Split ZIP of Multiple ePub Files with 150KB Segments in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing ePub files
            string inputDirectory = "Epubs";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Hardcoded output base path (without extension) for split archive
            string outputBasePath = "Output\\ebooks";

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputBasePath);
            Directory.CreateDirectory(outputDir ?? Directory.GetCurrentDirectory());

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add each ePub file to the archive
                string[] epubFiles = Directory.GetFiles(inputDirectory, "*.epub");
                foreach (string filePath in epubFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    FileInfo fileInfo = new FileInfo(filePath);
                    archive.CreateEntry(entryName, fileInfo);
                }

                // Configure split options: 150 KiB per segment
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(150 * 1024);

                // Save the split archive; segments will be named ebooks.zip, ebooks.z01, etc.
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
 * 1. When you need to bundle a collection of ePub ebooks into a single archive that can be transferred over email or file‑sharing services that limit attachment size.
 * 2. When you want to automatically split a large ZIP containing ePub files into small, fixed‑size parts (e.g., 150 KB) to fit on removable media such as USB flash drives.
 * 3. When you must generate a multi‑volume archive for backup systems that require each volume to stay under a specific size threshold.
 * 4. When you are building a distribution package that groups several ePub resources and needs to be compatible with standard ZIP extractors that understand split archives.
 * 5. When you need a C# solution that programmatically adds files to a ZIP and creates sequential .zip, .z01, .z02 files without manual compression tools.
 */
