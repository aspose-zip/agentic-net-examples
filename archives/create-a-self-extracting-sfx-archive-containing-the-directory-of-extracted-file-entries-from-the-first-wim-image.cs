// HOW-TO: Extract First Image From WIM Archive to Directory Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string wimPath = @"C:\Data\input.wim";
            string outputDir = @"C:\Data\WimExtract";

            if (!File.Exists(wimPath))
            {
                Console.Error.WriteLine($"File not found: {wimPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (FileStream wimStream = File.OpenRead(wimPath))
            {
                using (WimArchive wimArchive = new WimArchive(wimStream))
                {
                    wimArchive.Images[0].ExtractToDirectory(outputDir);
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
 * 1. When you need to programmatically unpack the first image of a Windows Imaging Format (WIM) file to a folder for further processing or analysis in a C# application.
 * 2. When automating deployment scripts that must extract system files from a WIM image before copying them to a target machine.
 * 3. When building a backup utility that reads a WIM archive and restores its initial image contents to a specified directory on demand.
 * 4. When creating a custom installer that pulls configuration files from a WIM image into a temporary directory for runtime configuration.
 * 5. When developing a forensic tool that examines the first image of a captured WIM file by extracting its files to a local path for inspection.
 */
