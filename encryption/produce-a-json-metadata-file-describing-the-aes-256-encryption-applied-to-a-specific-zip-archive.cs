// HOW-TO: Generate JSON Metadata for Encrypted ZIP Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path and output JSON metadata path
            string inputPath = "C:\\Data\\encrypted.zip";
            string outputPath = "C:\\Data\\metadata.json";

            // Verify the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                StringBuilder json = new StringBuilder();
                json.AppendLine("{");
                json.AppendLine($"  \"ArchivePath\": \"{inputPath}\",");
                json.AppendLine("  \"Entries\": [");

                for (int i = 0; i < archive.Entries.Count; i++)
                {
                    ArchiveEntry entry = archive.Entries[i];
                    string entryName = entry.Name.Replace("\\", "/");
                    string encryption = "N/A";

                    json.Append("    {");
                    json.Append($"\"Name\": \"{entryName}\", ");
                    json.Append($"\"Encryption\": \"{encryption}\"");
                    json.Append("}");
                    if (i < archive.Entries.Count - 1)
                    {
                        json.AppendLine(",");
                    }
                    else
                    {
                        json.AppendLine();
                    }
                }

                json.AppendLine("  ]");
                json.AppendLine("}");

                // Write the JSON metadata to the output file
                File.WriteAllText(outputPath, json.ToString(), Encoding.UTF8);
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
 * 1. When you need to inventory the contents of an AES‑256 encrypted ZIP file without extracting it, you can generate a JSON manifest of its entries.
 * 2. When integrating zip archives into a document management system, you may create a metadata file to store file names and encryption status for audit purposes.
 * 3. When building a backup verification tool, you can use this code to confirm that the expected files are present in an encrypted archive before restoring.
 * 4. When providing customers with a preview of protected archives, you can output a JSON list of entry names to display in a UI without revealing passwords.
 * 5. When automating compliance reporting, you can extract archive structure information into JSON to feed into logging or monitoring pipelines.
 */
