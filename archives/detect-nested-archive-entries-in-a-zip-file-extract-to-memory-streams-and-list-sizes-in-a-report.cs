// HOW-TO: Detect Nested Archives In Zip And Generate Size Report In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "input.zip";

            // Hardcoded report output file path
            string reportPath = "output/report.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // List to hold report lines
            List<string> reportLines = new List<string>();
            reportLines.Add("Nested Archive Report");
            reportLines.Add("----------------------");

            // Open the outer ZIP archive
            using (Archive outerArchive = new Archive(inputPath))
            {
                // Iterate through all entries in the outer archive
                foreach (ArchiveEntry entry in outerArchive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Determine if the entry is a nested archive by its file extension
                    string entryName = entry.Name;
                    string entryExtension = Path.GetExtension(entryName).ToLowerInvariant();

                    // List of extensions considered as archives (extend as needed)
                    bool isNestedArchive = entryExtension == ".zip" ||
                                           entryExtension == ".7z" ||
                                           entryExtension == ".tar" ||
                                           entryExtension == ".gz" ||
                                           entryExtension == ".bz2" ||
                                           entryExtension == ".xz" ||
                                           entryExtension == ".rar" ||
                                           entryExtension == ".iso";

                    if (isNestedArchive)
                    {
                        // Extract the nested archive entry to a memory stream
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            entry.Extract(memoryStream);
                            long nestedSize = memoryStream.Length;

                            // Add information to the report
                            reportLines.Add($"Entry: {entryName}");
                            reportLines.Add($"  Size (bytes): {nestedSize}");
                        }
                    }
                }
            }

            // Write the report to the output file
            File.WriteAllLines(reportPath, reportLines);
            Console.WriteLine($"Report generated at: {reportPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to scan an incoming ZIP file for embedded archives such as .zip, .7z, or .tar and produce a summary of each inner file’s size without writing them to disk.
 * 2. When building a security tool that must identify and log nested compressed files before unpacking them to prevent hidden malicious payloads.
 * 3. When creating an automated audit that extracts nested archives into memory streams to calculate their storage impact for compliance reporting.
 * 4. When developing a migration script that reads bundled archives, extracts inner archives to memory, and records their dimensions for inventory management.
 * 5. When implementing a CI/CD step that validates package bundles by checking for nested archives and generating a size report for quality assurance.
 */
