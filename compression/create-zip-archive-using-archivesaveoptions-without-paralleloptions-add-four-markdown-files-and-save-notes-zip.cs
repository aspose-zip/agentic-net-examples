// HOW-TO: Create ZIP Archive With Multiple Markdown Files Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string outputPath = @"C:\Output\notes.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Input markdown files
            string[] inputFiles = new string[]
            {
                Path.Combine(dataDir, "note1.md"),
                Path.Combine(dataDir, "note2.md"),
                Path.Combine(dataDir, "note3.md"),
                Path.Combine(dataDir, "note4.md")
            };

            // Validate input files
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Create ZIP archive and add files
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            using (FileStream source1 = File.Open(inputFiles[0], FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputFiles[1], FileMode.Open, FileAccess.Read))
            using (FileStream source3 = File.Open(inputFiles[2], FileMode.Open, FileAccess.Read))
            using (FileStream source4 = File.Open(inputFiles[3], FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("note1.md", source1);
                archive.CreateEntry("note2.md", source2);
                archive.CreateEntry("note3.md", source3);
                archive.CreateEntry("note4.md", source4);

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.Encoding = Encoding.ASCII;
                saveOptions.ArchiveComment = "Notes archive";

                archive.Save(zipStream, saveOptions);
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
 * 1. When you need to bundle several documentation markdown files into a single compressed ZIP for easy distribution or backup in a .NET application.
 * 2. When an automated build process must generate a notes package without parallel processing to ensure deterministic file ordering.
 * 3. When a desktop utility creates a portable archive of user‑generated notes to upload to a cloud storage service.
 * 4. When a reporting tool exports multiple markdown reports and saves them as a single ZIP file for email attachment.
 * 5. When a legacy system requires ASCII‑encoded ZIP entries for compatibility with older unzip utilities.
 */
