// HOW-TO: Compress Multiple CSV Files Into TAR.XZ Archive Using Aspose.Zip for .NET (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing CSV files
            string inputDir = "C:\\Data\\CsvFiles";
            // Hardcoded output path for the compressed TAR.XZ archive
            string outputPath = "C:\\Data\\data.tar.xz";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a TAR archive and add CSV files
            using (TarArchive archive = new TarArchive())
            {
                string[] csvFiles = Directory.GetFiles(inputDir, "*.csv");
                foreach (string filePath in csvFiles)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Save the TAR archive with XZ compression
                archive.SaveXzCompressed(outputPath);
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
 * 1. When you need to bundle a collection of CSV reports for transfer to a Linux server that expects a .tar.xz package.
 * 2. When you want to reduce the size of CSV data before uploading it to cloud storage while preserving a standard Unix tar format.
 * 3. When an automated backup job must archive daily CSV logs into a single compressed file for long‑term retention.
 * 4. When a data‑exchange pipeline requires CSV files to be delivered as a tar archive compressed with XZ to meet bandwidth constraints.
 * 5. When you are integrating with a third‑party system that only accepts .tar.xz archives and you must create them directly from C#.
 */
