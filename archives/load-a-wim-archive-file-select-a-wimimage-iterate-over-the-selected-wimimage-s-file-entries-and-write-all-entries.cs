// HOW-TO: Extract All Files From First Image Of WIM Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.wim";
            string outputDirectory = "WimEntriesOutput";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                archive.Images[0].ExtractToDirectory(outputDirectory);
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
 * 1. When you need to unpack the contents of a WIM file to inspect or modify its files during deployment automation.
 * 2. When building a backup restoration tool that must extract the first image of a WIM backup to a temporary folder before further processing.
 * 3. When creating a CI/CD pipeline that validates the integrity of files inside a WIM image by extracting them to a known directory for comparison.
 * 4. When developing a migration script that moves files from a legacy WIM‑based system image to a new file system by extracting all entries.
 * 5. When troubleshooting a corrupted Windows installation and you want to extract the original system files from the WIM image for analysis.
 */
