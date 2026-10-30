// HOW-TO: Extract All Files From A WIM Image To A Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.wim";
            string outputFolder = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (FileStream fileStream = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fileStream))
            {
                WimImage image = archive.Images[0];
                image.ExtractToDirectory(outputFolder);
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
 * 1. When you need to unpack a Windows Imaging Format (WIM) file to inspect or modify its contents during a deployment script.
 * 2. When a backup solution must restore all files from a captured system image stored as a WIM archive to a target directory.
 * 3. When a CI/CD pipeline needs to extract configuration files from a WIM image to apply environment‑specific settings before building an installer.
 * 4. When a forensic analyst wants to retrieve every file from a WIM snapshot for evidence collection without using Windows tools.
 * 5. When a developer is building a custom installer that must read a WIM image and copy its entire file structure to a temporary folder for further processing.
 */
