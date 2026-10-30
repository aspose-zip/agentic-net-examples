// HOW-TO: Extract All Files From a ZIP to a Directory Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.zip";
            string outputPath = "output\\extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ZIP archive and extract its contents
            using (Archive archive = new Archive(inputPath))
            {
                archive.ExtractToDirectory(outputPath);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack a downloaded ZIP package into a local folder for further processing.
 * 2. When you want to automate the extraction of deployment resources stored in a ZIP archive as part of a build pipeline.
 * 3. When a desktop application must read user‑provided ZIP files and extract their contents to a temporary workspace.
 * 4. When you are migrating legacy data archived in ZIP files and need to bulk extract them to a structured directory.
 * 5. When you need to verify that a ZIP archive exists and safely extract all entries while handling missing files or errors.
 */
