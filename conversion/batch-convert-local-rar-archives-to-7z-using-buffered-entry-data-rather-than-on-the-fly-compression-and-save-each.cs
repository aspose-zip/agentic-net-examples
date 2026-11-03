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
            string inputPath = @"C:\Input\sample.rar";
            string outputPath = @"C:\Output\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (FileStream fs = File.OpenRead(inputPath))
            using (RarArchive archive = new RarArchive(fs))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically unpack a downloaded RAR file to process its contents in a .NET application.
 * 2. When automating a data pipeline that receives RAR archives and must extract them to a staging directory before further analysis.
 * 3. When building a Windows service that monitors a folder for incoming RAR archives and extracts them to a target location for downstream processing.
 * 4. When creating a backup restoration tool that reads RAR backup files and restores their files to a specified directory using C#.
 * 5. When integrating third‑party RAR archives into an existing system and you need to extract them without relying on external command‑line tools.
 */
