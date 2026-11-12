// HOW-TO: Extract ZIP Files Smaller Than Specified Size and Log Rejected Entries in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\Data\sample.zip";
            string outputDirectory = @"C:\Data\Extracted";
            string reportPath = @"C:\Data\rejected_report.txt";

            // Uncompressed size limit in bytes (example: 5 MB)
            long sizeLimit = 5_000_000;

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(outputDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // List to hold names of rejected entries
            List<string> rejectedEntries = new List<string>();

            // Open the ZIP archive
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            {
                // Iterate through entries
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.UncompressedSize <= (ulong)sizeLimit)
                    {
                        // Build full destination path
                        string destinationPath = Path.Combine(outputDirectory, entry.Name);
                        string destinationDir = Path.GetDirectoryName(destinationPath);
                        if (!string.IsNullOrEmpty(destinationDir))
                        {
                            Directory.CreateDirectory(destinationDir);
                        }

                        // Extract entry to file
                        using (FileStream outputFile = File.Create(destinationPath))
                        using (Stream entryStream = entry.Open())
                        {
                            byte[] buffer = new byte[81920];
                            int bytesRead;
                            while ((bytesRead = entryStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                outputFile.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                    else
                    {
                        // Add to rejected list
                        rejectedEntries.Add(entry.Name);
                    }
                }
            }

            // Write rejected entry report
            using (StreamWriter writer = new StreamWriter(reportPath, false, Encoding.UTF8))
            {
                writer.WriteLine($"Rejected entries (uncompressed size > {sizeLimit} bytes):");
                foreach (string name in rejectedEntries)
                {
                    writer.WriteLine(name);
                }
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
 * 1. When you need to unpack only files that fit within a bandwidth or storage limit, such as extracting documents under 5 MB from a large archive while ignoring larger ones.
 * 2. When an application must enforce a maximum uncompressed size policy for security or compliance, extracting allowed files and generating a report of disallowed entries.
 * 3. When processing user‑uploaded zip bundles on a server, you may want to automatically filter out oversized files before saving them to the file system.
 * 4. When creating a backup restoration tool that restores only files below a certain size to avoid exhausting disk space, while keeping a log of files that were skipped.
 * 5. When building a data‑ingestion pipeline that extracts small CSV or JSON files from archives and records any large files for later manual review.
 */
