// HOW-TO: Extract First Image From WIM Archive to Folder Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\Data\\sample.wim";
        string outputFolder = "C:\\Data\\Extracted";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                archive.Images[0].ExtractToDirectory(outputFolder);
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
 * 1. When you need to programmatically pull the primary image from a Windows Imaging Format (WIM) file to deploy system files on a new machine.
 * 2. When automating the creation of a clean directory structure from a WIM backup for forensic analysis or inventory.
 * 3. When building a custom installer that extracts the base Windows image from a WIM package before applying additional patches.
 * 4. When migrating user data by extracting the first image of a captured system image to a staging folder for selective file recovery.
 * 5. When testing the contents of a WIM archive in a CI pipeline by extracting its first image to verify expected files are present.
 */
