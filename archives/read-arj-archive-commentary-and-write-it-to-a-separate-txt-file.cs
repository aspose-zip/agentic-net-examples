// HOW-TO: Extract ARJ Archive To Folder In C# With Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.arj";
            string outputPath = "output\\extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream fs = File.OpenRead(inputPath))
            using (ArjArchive archive = new ArjArchive(fs))
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
 * 1. When you need to programmatically unpack legacy ARJ backup files into a specific directory in a C# application.
 * 2. When a migration tool must read ARJ archives and extract their contents to a temporary folder before processing.
 * 3. When an automated deployment script has to decompress ARJ packages on a Windows server using .NET.
 * 4. When a data‑import routine requires reading compressed ARJ logs and saving the extracted files for analysis.
 * 5. When a desktop utility offers users the ability to browse and extract ARJ archives without installing external software.
 */
