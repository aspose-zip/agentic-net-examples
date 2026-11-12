// HOW-TO: Find Nested Zip Files in Archive and Export Paths to CSV in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Input\archive.zip";
            string outputPath = @"C:\Output\zip_entries.csv";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<string> zipEntryPaths = new List<string>();

            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name != null && entry.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        zipEntryPaths.Add(entry.Name);
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            {
                writer.WriteLine("Path");
                foreach (string path in zipEntryPaths)
                {
                    writer.WriteLine(path);
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
 * 1. When you need to inventory all embedded zip files inside a larger archive for further processing or reporting.
 * 2. When a build pipeline must generate a CSV list of inner zip entries to feed downstream tools.
 * 3. When auditing a backup archive to locate nested zip packages that may contain sensitive data.
 * 4. When creating a manifest of compressed sub‑archives for a data migration project.
 * 5. When automating compliance checks that require extracting the paths of zip files stored within a master archive.
 */
