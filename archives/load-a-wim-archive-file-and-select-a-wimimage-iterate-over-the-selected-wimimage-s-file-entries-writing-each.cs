// HOW-TO: Extract First Image From WIM Archive To Folder Using C# (Aspose.ZIP for .NET)
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
            string outputPath = @"C:\Output\WimExtract";

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
 * 1. When you need to unpack the primary image of a Windows Imaging Format (WIM) file to deploy files onto a new system using C#.
 * 2. When automating a backup restoration process that requires extracting the first image from a .wim archive to a specific directory in a .NET application.
 * 3. When building a deployment tool that reads a WIM file and copies its contents to a staging folder before applying Windows updates.
 * 4. When creating a script to verify the integrity of a WIM archive by extracting its first image and comparing the extracted files with expected results.
 * 5. When integrating Aspose.Zip for .NET into a CI pipeline to extract WIM images as part of a build step that prepares installation assets.
 */
