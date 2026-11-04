// HOW-TO: Extract Multi‑Volume 7z Archive to Dated Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "multi_volume_archive.7z";
        string outputPath = $"ExtractionResult_7z_{DateTime.Now:yyyyMMdd}";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory for the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            // Ensure the output directory itself exists
            Directory.CreateDirectory(outputPath);

            // Open the multi‑volume 7z archive and extract its contents
            using (SevenZipArchive archive = new SevenZipArchive(inputPath))
            {
                archive.ExtractToDirectory(outputPath);
            }

            Console.WriteLine($"Extraction completed to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unpack a split 7z backup set into a timestamped directory for daily restore testing.
 * 2. When an application must programmatically extract large multi‑volume archives received from a vendor and store the files in a folder named with the current date.
 * 3. When you want to automate the deployment of compressed resources that are delivered as a multi‑part 7z archive and keep each extraction isolated by date.
 * 4. When a CI/CD pipeline has to validate the contents of a multi‑volume 7z package by extracting it to a uniquely dated folder before running tests.
 * 5. When you are building a file‑management tool that extracts user‑uploaded multi‑volume 7z archives and organizes the output in a date‑based directory for audit purposes.
 */
