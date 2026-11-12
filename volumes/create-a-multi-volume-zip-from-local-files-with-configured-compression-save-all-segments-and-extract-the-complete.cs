// HOW-TO: Create Multi-Volume BZIP2 ZIP and Extract It in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input directory containing files to compress
            string inputDir = @"C:\Data\Input";
            // Define output directory for multivolume ZIP segments
            string zipOutputDir = @"C:\Data\Output\Zip";
            // Define extraction directory for the extracted files
            string extractOutputDir = @"C:\Data\Output\Extracted";

            // Ensure output directories exist
            Directory.CreateDirectory(zipOutputDir);
            Directory.CreateDirectory(extractOutputDir);

            // Files to include in the archive
            string[] filesToAdd = new string[]
            {
                Path.Combine(inputDir, "file1.txt"),
                Path.Combine(inputDir, "file2.txt")
            };

            // Verify each input file exists
            foreach (string filePath in filesToAdd)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Create a multivolume ZIP archive with BZIP2 compression for all entries
            using (Archive archive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
            {
                // Add each file as an entry
                foreach (string filePath in filesToAdd)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                // Configure split (multivolume) options: 1 MB per segment
                SplitArchiveSaveOptions splitOptions = new SplitArchiveSaveOptions(1024 * 1024);

                // Save the multivolume archive; segments will be placed in zipOutputDir
                archive.SaveSplit(zipOutputDir, splitOptions);
            }

            // Prepare to extract the multivolume archive
            // Main segment is the .zip file; other segments have extensions like .z01, .z02, etc.
            string mainSegment = Path.Combine(zipOutputDir, "Archive.zip");
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"Main segment not found: {mainSegment}");
                return;
            }

            // Gather all segment files in the directory, order them, and exclude the main .zip file
            string[] segmentFiles = Directory.GetFiles(zipOutputDir, "Archive.*")
                .Where(f => !f.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                .OrderBy(f => f)
                .ToArray();

            // Open the multivolume archive
            using (Archive archive = new Archive(mainSegment, segmentFiles))
            {
                // Extract each entry to the extraction directory
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string destinationPath = Path.Combine(extractOutputDir, entry.Name);
                    // Ensure the destination directory exists (in case of nested entries)
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                    using (FileStream output = new FileStream(destinationPath, FileMode.Create))
                    {
                        entry.Extract(output);
                    }
                }
            }

            Console.WriteLine("Multivolume ZIP created and extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to split a large set of log files into 1 MB BZIP2‑compressed ZIP segments for easier transfer over limited‑size email attachments.
 * 2. When you want to archive multiple configuration files into a multi‑volume archive to store on removable media that has a maximum file size limit.
 * 3. When a backup process must create a compressed archive that can be resumed or combined later, and then automatically extract the full set of files on the destination machine.
 * 4. When you are implementing a download manager that receives ZIP parts separately and needs to reassemble and decompress them using C#.
 * 5. When you need to ensure consistent compression settings across all entries while creating a split archive for archival compliance and later restore the original files programmatically.
 */
