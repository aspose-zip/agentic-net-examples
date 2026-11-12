// HOW-TO: Extract ARJ Archive Metadata and Save as JSON in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.arj";
            string outputPath = "metadata.json";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open ARJ archive and retrieve metadata
            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                string commentary = string.Empty;
                string fileName = Path.GetFileName(inputPath);

                // Escape characters for JSON
                string escapedCommentary = commentary.Replace("\\", "\\\\").Replace("\"", "\\\"");
                string escapedFileName = fileName.Replace("\\", "\\\\").Replace("\"", "\\\"");

                // Build JSON string
                string json = $"{{\"FileName\":\"{escapedFileName}\",\"Commentary\":\"{escapedCommentary}\"}}";

                // Write JSON to output file
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
 * 1. When you need to log the file name and commentary of an ARJ archive for inventory tracking.
 * 2. When integrating legacy ARJ files into a modern .NET application that stores archive metadata in JSON.
 * 3. When building a reporting tool that extracts ARJ archive details without extracting the contained files.
 * 4. When creating a backup verification script that records ARJ archive information for audit purposes.
 * 5. When developing a migration utility that reads ARJ archive headers and writes them to a JSON configuration file.
 */
