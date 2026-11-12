// HOW-TO: Extract CAB Archive to Folder and Create CSV File List in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\archive.cab";
            string extractPath = "output\\extracted";
            string csvPath = "output\\files.csv";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(extractPath);
            Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

            // Extract CAB archive
            using (CabArchive archive = new CabArchive(inputPath))
            {
                archive.ExtractToDirectory(extractPath);
            }

            // Gather extracted file names
            string[] files = Directory.GetFiles(extractPath, "*", SearchOption.AllDirectories);

            // Write CSV listing each file's relative path
            using (StreamWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8))
            {
                foreach (string file in files)
                {
                    string relativePath = Path.GetRelativePath(extractPath, file);
                    writer.WriteLine(relativePath);
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
 * 1. When you need to unpack a Windows installer CAB file and produce a spreadsheet of all extracted files for inventory or auditing purposes.
 * 2. When a deployment script must extract resources from a CAB archive and generate a CSV manifest to feed into downstream processing tools.
 * 3. When migrating legacy CAB packages to a new system and you require a simple list of file paths to verify successful extraction.
 * 4. When automating a build pipeline that extracts CAB assets and logs their relative paths in CSV for compliance reporting.
 * 5. When creating a backup verification routine that extracts a CAB backup and records each file name in a CSV to compare against expected contents.
 */
