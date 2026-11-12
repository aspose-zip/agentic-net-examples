// HOW-TO: Extract Allowed Files From ZIP While Blocking Executables In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputZipPath = "C:\\Data\\input.zip";
            string extractDirectory = "C:\\Data\\Extracted";
            string reportFilePath = "C:\\Data\\rejected_report.txt";

            // Validate input ZIP file
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(extractDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(reportFilePath));

            // List of prohibited extensions (lowercase, including the dot)
            string[] prohibitedExtensions = new string[] { ".exe", ".dll" };

            // Builder for rejected entry report
            StringBuilder reportBuilder = new StringBuilder();

            // Open the ZIP archive
            using (FileStream zipStream = File.Open(inputZipPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    // Iterate over each entry in the archive
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        string entryExtension = Path.GetExtension(entry.Name).ToLowerInvariant();

                        // Check if the entry's extension is prohibited
                        bool isProhibited = false;
                        foreach (string prohibited in prohibitedExtensions)
                        {
                            if (entryExtension == prohibited)
                            {
                                isProhibited = true;
                                break;
                            }
                        }

                        if (isProhibited)
                        {
                            // Add to report
                            reportBuilder.AppendLine(entry.Name);
                        }
                        else
                        {
                            // Extract permitted entry
                            string destinationPath = Path.Combine(extractDirectory, entry.Name);
                            string destinationDir = Path.GetDirectoryName(destinationPath);
                            if (!string.IsNullOrEmpty(destinationDir))
                            {
                                Directory.CreateDirectory(destinationDir);
                            }
                            entry.Extract(destinationPath);
                        }
                    }
                }
            }

            // Write the rejected-entry report
            File.WriteAllText(reportFilePath, reportBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unzip a user‑uploaded archive but must prevent any .exe or .dll files from being extracted for security reasons.
 * 2. When you want to extract only safe file types from a backup ZIP and generate a log of the files that were rejected.
 * 3. When an automated deployment script must unpack resources while ensuring prohibited binaries are not placed on the target server.
 * 4. When a data‑processing pipeline has to separate permitted documents from a compressed bundle and keep a report of disallowed entries for audit.
 * 5. When a desktop application offers a “extract” feature that must filter out dangerous extensions and provide users with a clear list of skipped files.
 */
