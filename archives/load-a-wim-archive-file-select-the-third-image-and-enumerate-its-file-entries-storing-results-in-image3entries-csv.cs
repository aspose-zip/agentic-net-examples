// HOW-TO: Extract Third Image From WIM Archive To Folder In C# (Aspose.ZIP for .NET)
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
            string outputFolder = @"C:\Data\ExtractedImage3";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                if (archive.Images.Count <= 2)
                {
                    Console.Error.WriteLine("The WIM archive does not contain a third image.");
                    return;
                }

                archive.Images[2].ExtractToDirectory(outputFolder);
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
 * 1. When you need to retrieve the third image from a WIM file to deploy or analyze its contents in a C# application.
 * 2. When automating the extraction of a specific image layer from a Windows Imaging Format backup for further processing.
 * 3. When building a utility that checks a WIM archive for multiple images and extracts the selected one for testing.
 * 4. When creating a script to pull configuration files from the third image of a system image for forensic examination.
 * 5. When integrating Aspose.Zip for .NET into a CI pipeline to automatically unpack a particular image from a WIM package during a build.
 */
