// HOW-TO: Extract RAR Archive to Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputRarPath = @"C:\RarArchives\sample.rar";
            string outputDirectory = @"C:\RarArchives\Extracted";

            // Validate input file
            if (!File.Exists(inputRarPath))
            {
                Console.Error.WriteLine($"File not found: {inputRarPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            using (FileStream fs = File.OpenRead(inputRarPath))
            using (RarArchive archive = new RarArchive(fs))
            {
                archive.ExtractToDirectory(outputDirectory);
            }

            Console.WriteLine($"Extraction completed to '{outputDirectory}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack a downloaded RAR file to process its contents on a Windows server.
 * 2. When an application must extract user‑submitted RAR archives into a specific directory for further analysis or conversion.
 * 3. When automating a data‑ingestion pipeline that receives RAR‑compressed logs and requires them to be extracted before parsing.
 * 4. When integrating legacy RAR archives into a modern .NET system without relying on external command‑line tools.
 * 5. When building a batch job that validates and extracts multiple RAR files to a common folder for archival or backup purposes.
 */
