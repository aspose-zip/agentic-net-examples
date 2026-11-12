// HOW-TO: Generate Text Report of ZIP Entry Names Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.zip";
            string outputPath = "report.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDirectory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Collect entry names from the ZIP archive
            List<string> entryNames = new List<string>();
            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    entryNames.Add(entry.Name);
                }
            }

            // Write the entry names to a text report
            using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            {
                writer.WriteLine("ZIP Archive Entry Names:");
                foreach (string name in entryNames)
                {
                    writer.WriteLine(name);
                }
            }

            Console.WriteLine($"Report saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit the contents of a ZIP file without extracting it, you can generate a plain‑text list of all entry names for review.
 * 2. When building a deployment pipeline that must verify which files are packaged in an archive, this code creates a quick inventory report.
 * 3. When providing customers or auditors a readable summary of a compressed archive’s structure, you can output the entry list to a report file.
 * 4. When troubleshooting missing or unexpected files in a ZIP, the generated report helps pinpoint which items are actually present.
 * 5. When integrating with logging or monitoring tools that require a simple text log of archive contents, this approach writes the entry names directly to a file.
 */
