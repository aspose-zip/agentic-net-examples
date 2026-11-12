// HOW-TO: Extract First Image from WIM Archive to Folder in C# (Aspose.ZIP for .NET)
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
            string outputPath = "TempExtraction";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    archive.Images[0].ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack the first image of a Windows Imaging Format (WIM) file to a temporary directory for further processing or analysis.
 * 2. When deploying software that ships as a WIM package and you must extract its contents on a build server using C#.
 * 3. When creating a backup verification tool that reads a WIM archive and extracts files to compare against original data.
 * 4. When automating the preparation of a Windows PE environment by programmatically extracting the WIM image to a staging folder.
 * 5. When troubleshooting a corrupted WIM file by extracting its first image to inspect individual files with .NET.
 */
