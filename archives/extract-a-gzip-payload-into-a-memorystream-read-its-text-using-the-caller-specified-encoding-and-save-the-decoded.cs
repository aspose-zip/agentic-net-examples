// HOW-TO: Extract GZIP File to Text Using Specified Encoding in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gz";
            string outputPath = "output\\decoded.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Extract GZIP payload into a memory stream
            MemoryStream memoryStream = new MemoryStream();
            using (GzipArchive archive = new GzipArchive(File.OpenRead(inputPath)))
            {
                archive.Open().CopyTo(memoryStream);
                Console.WriteLine(archive.Name);
            }

            // Read extracted data as text using specified encoding
            string encodingName = "utf-8";
            Encoding encoding = Encoding.GetEncoding(encodingName);
            memoryStream.Position = 0;
            string decodedText;
            using (StreamReader reader = new StreamReader(memoryStream, encoding))
            {
                decodedText = reader.ReadToEnd();
            }

            // Save the decoded text to a file
            File.WriteAllText(outputPath, decodedText, encoding);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to decompress a .gz log file in memory and convert it to UTF‑8 text for further processing.
 * 2. When an application receives a GZIP payload over a network and must extract the contained string without writing intermediate files.
 * 3. When you want to read compressed configuration files stored as GZIP and save the decoded content to a readable .txt file.
 * 4. When migrating legacy GZIP archives to plain‑text resources while preserving the original character encoding.
 * 5. When debugging compressed data streams by extracting and viewing their textual representation on disk.
 */
