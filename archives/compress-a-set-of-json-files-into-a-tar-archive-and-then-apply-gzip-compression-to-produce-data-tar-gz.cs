// HOW-TO: Create Gzipped TAR Archive of JSON Files in C# with Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing JSON files
            string inputDir = "input";
            // Hardcoded output path for the compressed TAR.GZ archive
            string outputPath = "output/data.tar.gz";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get all JSON files in the input directory
            string[] jsonFiles = Directory.GetFiles(inputDir, "*.json");

            using (TarArchive archive = new TarArchive())
            {
                // Add each JSON file as an entry in the TAR archive
                foreach (string filePath in jsonFiles)
                {
                    // Verify each file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Save the TAR archive with GZIP compression
                archive.SaveGzipped(outputPath);
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
 * 1. When you need to bundle multiple JSON configuration files into a single compressed .tar.gz package for easy distribution or backup.
 * 2. When deploying a web service that requires sending a set of JSON payloads as one compressed archive to reduce network bandwidth.
 * 3. When archiving log files generated in JSON format for long‑term storage while keeping the archive size small.
 * 4. When integrating with Linux‑based systems that expect data in tar.gz format, such as container images or CI pipelines.
 * 5. When creating a downloadable data set of JSON records for end‑users, ensuring the files are packaged and compressed in one step.
 */
