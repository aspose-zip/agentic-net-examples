// HOW-TO: Extract ZIP Files By Extension To Separate Folders With Report In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path
            string inputPath = @"C:\Data\sample.zip";

            // Hardcoded report output path
            string reportPath = @"C:\Data\ExtractionReport.txt";

            // Verify input ZIP exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare a map of file extensions to target directories
            Dictionary<string, string> extensionDirectories = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { ".txt", @"C:\Data\Extracted\TextFiles" },
                { ".jpg", @"C:\Data\Extracted\Images" },
                { ".png", @"C:\Data\Extracted\Images" },
                { ".pdf", @"C:\Data\Extracted\Documents" },
                // Default folder for other extensions
                { "*", @"C:\Data\Extracted\Others" }
            };

            // StringBuilder for the directory map report
            StringBuilder reportBuilder = new StringBuilder();

            // Open the ZIP file stream
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Load the archive
                using (Archive archive = new Archive(zipStream))
                {
                    // Iterate over each entry in the archive
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Skip directories
                        if (entry.IsDirectory)
                        {
                            continue;
                        }

                        // Determine the file extension
                        string extension = Path.GetExtension(entry.Name);
                        string targetDir;

                        if (!extensionDirectories.TryGetValue(extension, out targetDir))
                        {
                            // Use the default folder for unknown extensions
                            targetDir = extensionDirectories["*"];
                        }

                        // Ensure the target directory exists
                        Directory.CreateDirectory(targetDir);

                        // Build the full output file path
                        string outputFilePath = Path.Combine(targetDir, entry.Name);

                        // Ensure the directory for the output file exists (covers nested paths)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                        // Extract the entry to the target path
                        entry.Extract(outputFilePath);

                        // Append entry information to the report
                        reportBuilder.AppendLine($"{entry.Name} -> {outputFilePath}");
                    }
                }
            }

            // Ensure the directory for the report exists
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Write the report to the file system
            File.WriteAllText(reportPath, reportBuilder.ToString());

            Console.WriteLine("Extraction completed. Report saved to: " + reportPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unpack a large ZIP containing mixed file types and automatically sort each file into dedicated folders such as TextFiles, Images, and Documents while generating a log of where each file was placed.
 * 2. When a deployment script must extract configuration and resource files from a packaged archive and organize them by extension into predefined directories for easier post‑deployment validation.
 * 3. When an application processes user‑uploaded ZIP bundles and must separate image, PDF, and text assets into separate storage locations, then produce a summary report for auditing.
 * 4. When a data‑migration tool has to read a backup ZIP, distribute its contents into category‑specific folders, and keep a record of the extraction paths for troubleshooting.
 * 5. When a scheduled job extracts daily report archives, categorizes the files by type into designated folders, and creates a text file map to inform downstream processes.
 */
