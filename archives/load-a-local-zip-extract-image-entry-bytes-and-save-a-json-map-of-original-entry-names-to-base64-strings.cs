// HOW-TO: Extract Images from ZIP and Save as Base64 JSON in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.zip";
            string outputPath = @"C:\Data\imageMap.json";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Dictionary to hold entry name -> Base64 string
            Dictionary<string, string> imageBase64Map = new Dictionary<string, string>();

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                        continue;

                    // Check for image file extensions (case-insensitive)
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" ||
                        extension == ".gif" || extension == ".bmp")
                    {
                        // Read entry bytes
                        using (Stream entryStream = entry.Open())
                        using (MemoryStream ms = new MemoryStream())
                        {
                            entryStream.CopyTo(ms);
                            byte[] bytes = ms.ToArray();
                            string base64 = Convert.ToBase64String(bytes);
                            imageBase64Map[entry.Name] = base64;
                        }
                    }
                }
            }

            // Build simple JSON string
            using (StringWriter sw = new StringWriter())
            {
                sw.Write("{");
                bool first = true;
                foreach (KeyValuePair<string, string> kvp in imageBase64Map)
                {
                    if (!first)
                    {
                        sw.Write(",");
                    }
                    // Escape double quotes in the key if necessary
                    string escapedKey = kvp.Key.Replace("\\", "\\\\").Replace("\"", "\\\"");
                    string escapedValue = kvp.Value.Replace("\\", "\\\\").Replace("\"", "\\\"");
                    sw.Write($"\"{escapedKey}\":\"{escapedValue}\"");
                    first = false;
                }
                sw.Write("}");
                string json = sw.ToString();

                // Save JSON to file
                File.WriteAllText(outputPath, json);
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
 * 1. When you need to embed images from a zip archive into a web API response without storing the files on disk, you can convert them to Base64 strings and return a JSON map.
 * 2. When a mobile app requires all image assets bundled in a zip to be sent over a text‑only protocol, extracting and encoding them to Base64 in a JSON file simplifies transmission.
 * 3. When generating a data‑driven report that references images stored in a zip, converting each image to a Base64 string allows the report engine to embed them directly in HTML or PDF.
 * 4. When migrating legacy zip‑based image collections to a cloud database, creating a JSON map of entry names to Base64 strings provides an easy import format for NoSQL stores.
 * 5. When implementing a security‑aware workflow that must avoid writing raw image files to disk, extracting the bytes, encoding them, and storing only the JSON map keeps the data in memory‑safe form.
 */
