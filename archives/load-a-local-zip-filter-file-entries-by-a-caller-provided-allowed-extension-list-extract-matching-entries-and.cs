// HOW-TO: Extract Specific File Types From ZIP and Log Excluded Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\sample.zip";
            string extractDir = "C:\\Data\\Extracted";
            string reportPath = "C:\\Data\\excluded_report.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(extractDir);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            List<string> allowedExtensions = new List<string> { ".txt", ".cs", ".xml" };
            List<string> excludedEntries = new List<string>();

            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            string extension = Path.GetExtension(entry.Name);
                            bool isAllowed = false;
                            foreach (string ext in allowedExtensions)
                            {
                                if (string.Equals(ext, extension, StringComparison.OrdinalIgnoreCase))
                                {
                                    isAllowed = true;
                                    break;
                                }
                            }

                            if (isAllowed)
                            {
                                string destinationPath = Path.Combine(extractDir, entry.Name);
                                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                                entry.Extract(destinationPath);
                            }
                            else
                            {
                                excludedEntries.Add(entry.Name);
                            }
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(reportPath, false, Encoding.UTF8))
            {
                writer.WriteLine("Excluded entries:");
                foreach (string name in excludedEntries)
                {
                    writer.WriteLine(name);
                }
            }

            Console.WriteLine("Extraction completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a build server receives a ZIP containing source code and documentation, you can extract only .cs, .txt, and .xml files while generating a list of all other files that were ignored.
 * 2. When an application needs to import user‑uploaded ZIP packages but must restrict processing to safe file types, this code extracts the permitted extensions and records any disallowed entries for audit.
 * 3. When migrating legacy data stored in mixed‑type archives, you can pull out only the relevant configuration and script files and produce a report of the remaining assets that require separate handling.
 * 4. When creating a custom installer that unpacks only executable scripts from a distribution bundle, the routine extracts the allowed files and logs the excluded binaries for compliance verification.
 * 5. When performing periodic cleanup of archived logs, you can extract only text‑based log files from each ZIP and keep a record of non‑text entries that should be archived elsewhere.
 */
