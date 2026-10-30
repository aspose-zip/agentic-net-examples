// HOW-TO: Extract All Files From a WIM Image to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\sample.wim";
            string outputPath = "C:\\Data\\ExtractedEntries";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                archive.Images[0].ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a Windows Imaging Format (WIM) file to access its contents for deployment or analysis.
 * 2. When you want to programmatically extract the first image of a multi‑image WIM archive in a C# application.
 * 3. When you need to automate the retrieval of files from a WIM archive to a specific directory during a build or CI pipeline.
 * 4. When you are developing a tool that reads WIM archives and stores the extracted files for further processing or backup.
 * 5. When you must verify the integrity of a WIM archive by extracting its entries and comparing them with expected file structures.
 */
