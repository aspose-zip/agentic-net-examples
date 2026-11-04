// HOW-TO: Extract Base64 Strings from ZIP and Save as Text Files in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP file path
            string inputPath = "input.zip";

            // Hardcoded output directory path
            string outputDir = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                // Iterate through each entry in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Read the entry content as a Base64 string
                    using (Stream entryStream = entry.Open())
                    using (MemoryStream ms = new MemoryStream())
                    {
                        entryStream.CopyTo(ms);
                        byte[] data = ms.ToArray();
                        string base64String = Encoding.UTF8.GetString(data);

                        // Determine output .txt file name based on entry name
                        string fileName = Path.GetFileNameWithoutExtension(entry.Name) + ".txt";
                        string outputPath = Path.Combine(outputDir, fileName);

                        // Write the Base64 string to the .txt file
                        File.WriteAllText(outputPath, base64String);
                    }
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
 * 1. When you need to batch‑export Base64‑encoded image data stored inside a ZIP archive into separate .txt files for further processing.
 * 2. When a system receives a compressed package of Base64‑encoded documents and you must extract each string into individual text files for downstream services.
 * 3. When you want to archive multiple Base64 payloads and later retrieve them as plain‑text files without manual decoding.
 * 4. When integrating with an API that expects Base64 content in separate files, you can unpack a ZIP and generate the required .txt files automatically.
 * 5. When performing data migration from a compressed bundle of Base64 strings to a file‑based storage structure for auditing or version control.
 */
