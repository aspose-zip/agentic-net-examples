// HOW-TO: Extract First Image From WIM Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string outputFolder = @"C:\Data\ExtractedImage";

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
 * 1. When you need to programmatically extract the first image layer from a Windows Imaging Format (WIM) file to prepare files for a deployment script.
 * 2. When automating the retrieval of a specific image from a WIM archive to copy its contents into a staging directory before applying system updates.
 * 3. When building a C# utility that reads a WIM backup, extracts the primary image, and places it in a known folder for further analysis or testing.
 * 4. When integrating Aspose.Zip into a CI/CD pipeline to unpack the first image of a WIM package so that subsequent build steps can access its files.
 * 5. When creating a forensic tool that quickly pulls the initial image from a captured WIM file to examine its directory structure without manual extraction.
 */
