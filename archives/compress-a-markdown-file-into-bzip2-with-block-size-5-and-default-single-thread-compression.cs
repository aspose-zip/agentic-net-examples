// HOW-TO: Compress Markdown File to BZIP2 with Default Settings in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "data/input.md";
            string outputPath = "data/output.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of documentation files before uploading them to a server.
 * 2. When you want to store markdown notes in a BZIP2 archive for efficient backup.
 * 3. When a CI pipeline must compress generated .md reports to save bandwidth.
 * 4. When you are preparing a markdown file for distribution over low‑bandwidth connections.
 * 5. When you need to archive a single markdown file using BZIP2 to meet legacy system requirements.
 */
