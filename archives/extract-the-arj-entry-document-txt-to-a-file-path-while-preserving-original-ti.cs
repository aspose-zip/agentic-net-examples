// HOW-TO: Extract ARJ Archive to Directory Using Aspose.Zip for .NET (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\archive.arj";
            string outputDirectory = @"C:\Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream fs = File.OpenRead(inputPath))
            using (ArjArchive archive = new ArjArchive(fs))
            {
                archive.ExtractToDirectory(outputDirectory);
            }

            Console.WriteLine($"Extracted ARJ archive to {outputDirectory}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack legacy ARJ backup files on a Windows server using C# and Aspose.Zip.
 * 2. When a migration tool must extract all files from an ARJ archive to a specified output folder before converting them to a new format.
 * 3. When an automated deployment script has to retrieve configuration files stored in an ARJ package during a CI/CD pipeline.
 * 4. When a desktop application processes user‑uploaded ARJ archives and saves their contents to a local directory for further analysis.
 * 5. When you want to batch‑extract multiple ARJ archives in a scheduled job while preserving the original directory structure.
 */
