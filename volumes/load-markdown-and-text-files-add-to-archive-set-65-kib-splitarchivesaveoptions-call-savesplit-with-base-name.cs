// HOW-TO: Create Split ZIP Archive of Markdown and Text Files in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input file paths
            string inputFile1 = "sample.md";
            string inputFile2 = "sample.txt";

            // Hardcoded output directory
            string outputDir = "Output";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            using (Archive archive = new Archive())
            {
                // Add markdown file to the archive
                archive.CreateEntry("sample.md", new FileInfo(inputFile1));

                // Add text file to the archive
                archive.CreateEntry("sample.txt", new FileInfo(inputFile2));

                // Configure split archive options (65 KiB per segment)
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(65 * 1024);

                // Save the split archive with base name 'docset' in the output directory
                string basePath = Path.Combine(outputDir, "docset");
                archive.SaveSplit(basePath, saveOptions);
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
 * 1. When you need to package documentation files into smaller ZIP parts to fit email attachment size limits.
 * 2. When distributing a software release that includes markdown and text resources and the target medium only supports files under 64 KB.
 * 3. When backing up project notes to a removable drive that requires split archives to avoid exceeding the drive’s file‑size restriction.
 * 4. When uploading documentation to a cloud storage API that only accepts multipart ZIP uploads of a specific maximum segment size.
 * 5. When creating a multi‑volume archive for archival standards that mandate fixed‑size ZIP segments for long‑term storage.
 */
