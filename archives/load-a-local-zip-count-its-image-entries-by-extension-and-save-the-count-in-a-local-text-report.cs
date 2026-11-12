// HOW-TO: Count Image Files in a ZIP and Save Report with C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "input.zip";

            // Hardcoded output text report path
            string outputReportPath = "report.txt";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create output directory if the report is placed in a folder
            string outputDir = Path.GetDirectoryName(outputReportPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                int imageCount = 0;

                // Iterate through all entries and count image files by extension
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string extension = Path.GetExtension(entry.Name);
                    if (!string.IsNullOrEmpty(extension))
                    {
                        string lowerExt = extension.ToLowerInvariant();
                        if (lowerExt == ".png" ||
                            lowerExt == ".jpg" ||
                            lowerExt == ".jpeg" ||
                            lowerExt == ".gif" ||
                            lowerExt == ".bmp" ||
                            lowerExt == ".tiff")
                        {
                            imageCount++;
                        }
                    }
                }

                // Prepare report content
                string reportContent = $"Image entries count: {imageCount}";

                // Write the report to the output file
                File.WriteAllText(outputReportPath, reportContent);
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
 * 1. When you need to generate a quick inventory of all pictures stored inside a zip archive for quality‑control or documentation purposes.
 * 2. When an automated build process must verify that a packaged resource bundle contains the expected number of image assets before deployment.
 * 3. When a desktop application needs to display a summary of image content in user‑uploaded zip files without extracting the files themselves.
 * 4. When a reporting tool must create a plain‑text log of image counts from multiple zip archives for audit or compliance tracking.
 * 5. When a migration script has to assess image density in legacy zip packages to decide whether to re‑compress or reorganize the assets.
 */
