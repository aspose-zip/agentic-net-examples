// HOW-TO: Extract First Image Files From WIM Archive To Folder In C# (Aspose.ZIP for .NET)
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
            string outputDir = "WimEntriesFolder";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    archive.Images[0].ExtractToDirectory(outputDir);
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
 * 1. When you need to unpack the contents of a Windows Imaging (WIM) file to inspect or modify individual files during a system backup restoration process.
 * 2. When deploying a Windows image and you want to extract only the first image’s files to a staging directory before applying custom configuration scripts.
 * 3. When creating a forensic analysis tool that reads a WIM archive and extracts its file entries to a folder for further examination.
 * 4. When building an automated build pipeline that pulls resources from a WIM package and copies them into a project’s assets directory.
 * 5. When developing a migration utility that converts files stored in a WIM image into a regular file system structure for legacy application compatibility.
 */
