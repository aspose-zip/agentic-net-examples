// HOW-TO: List .txt Files In a ZIP Archive and Export to JSON in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file and output JSON file paths
            string inputPath = "C:\\Data\\sample.zip";
            string outputPath = "C:\\Data\\filteredEntries.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect entry names with the desired extension
            List<string> filteredNames = new List<string>();
            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        filteredNames.Add(entry.Name);
                    }
                }
            }

            // Build JSON array string
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("[");
            for (int i = 0; i < filteredNames.Count; i++)
            {
                jsonBuilder.Append("\"");
                jsonBuilder.Append(filteredNames[i].Replace("\\", "\\\\").Replace("\"", "\\\""));
                jsonBuilder.Append("\"");
                if (i < filteredNames.Count - 1)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("]");

            // Write JSON to output file
            File.WriteAllText(outputPath, jsonBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a manifest of all text documents inside a ZIP package for downstream processing or reporting.
 * 2. When an application must extract only .txt files from a compressed archive and share their names with a web service via a JSON payload.
 * 3. When you want to audit the contents of a ZIP file to verify that required configuration files are present without extracting the entire archive.
 * 4. When a build pipeline needs to list specific file types from a bundled artifact and store the list in a machine‑readable JSON file for further automation.
 * 5. When a data‑migration script must identify and record the paths of text files inside legacy ZIP archives before moving them to a new storage system.
 */
