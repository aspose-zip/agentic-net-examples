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
            string inputPath = "C:\\Data\\sample.wim";
            string outputDir = "C:\\Data\\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                if (archive.Images.Count > 0)
                {
                    archive.Images[0].ExtractToDirectory(outputDir);
                }
                else
                {
                    Console.Error.WriteLine("No images found in the WIM archive.");
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
 * 1. When you need to programmatically unpack the first image of a Windows Imaging Format (WIM) file to a deployment folder during automated OS deployment.
 * 2. When a backup utility must read a WIM archive and extract its contents to a temporary directory for validation or scanning.
 * 3. When a DevOps script has to pull files from a captured system image to compare them against a baseline configuration.
 * 4. When a software installer wants to retrieve resources stored inside a WIM file and place them in the application's data directory.
 * 5. When a migration tool extracts the initial image of a WIM archive to copy user profiles and system files to a new machine.
 */
