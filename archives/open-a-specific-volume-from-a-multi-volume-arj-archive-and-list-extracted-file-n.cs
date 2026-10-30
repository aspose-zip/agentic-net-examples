// HOW-TO: Open Specific Volume of Multi‑Volume ARJ Archive and List Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Archives\multi_volume.part2.arj";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                foreach (var entry in archive.Entries)
                {
                    Console.WriteLine(entry.Name);
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
 * 1. When you need to read the contents of the second part of a split ARJ backup to verify which files are stored without extracting them.
 * 2. When a deployment script must enumerate files inside a specific volume of a multi‑volume ARJ package to decide which components to install.
 * 3. When troubleshooting corrupted archives by opening a particular ARJ segment and checking the entry names for missing or unexpected files.
 * 4. When building a file‑inventory tool that scans each part of a large ARJ archive to generate a catalog of archived items.
 * 5. When integrating legacy ARJ archives into a .NET application and you only have access to one volume, requiring you to list its entries before processing.
 */
