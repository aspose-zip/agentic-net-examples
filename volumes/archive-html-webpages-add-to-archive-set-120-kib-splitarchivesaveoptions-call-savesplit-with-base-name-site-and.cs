// HOW-TO: Split HTML Files Into 120KB ZIP Segments With Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing HTML files
            string inputDirectory = @"C:\InputHtml";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Hardcoded output directory for split ZIP segments
            string outputDirectory = @"C:\OutputZip";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add each HTML file in the input directory to the archive
                string[] htmlFiles = Directory.GetFiles(inputDirectory, "*.html", SearchOption.AllDirectories);
                foreach (string filePath in htmlFiles)
                {
                    // Verify the file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Use the file name as the entry name inside the archive
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                // Configure split archive options (120 KiB per segment) with base file name "site"
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("site", 120 * 1024);

                // Save the archive as split ZIP segments in the output directory
                archive.SaveSplit(outputDirectory, saveOptions);
            }

            Console.WriteLine("Multivolume ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a collection of web pages for distribution over a network that limits file size, you can create split ZIP archives of 120 KB each.
 * 2. When backing up a website’s static HTML content to removable media that only accepts small files, this code creates multiple manageable ZIP parts.
 * 3. When sending HTML documentation via email attachments that have size restrictions, splitting the archive ensures each part stays under the limit.
 * 4. When archiving HTML reports for archival storage systems that require fixed‑size chunks, the split archive options generate uniform segments.
 * 5. When integrating with legacy systems that only process ZIP files up to a certain size, this approach automatically divides the archive into acceptable pieces.
 */
