// HOW-TO: Extract Files from Fourth Image of a WIM Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WIM file path
            string inputPath = @"C:\Data\sample.wim";
            // Hardcoded output directory for the fourth image entries
            string outputPath = @"C:\Data\Image4Files";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Check that the archive contains at least four images (zero‑based index)
                    if (archive.Images.Count > 3)
                    {
                        // Extract all entries of the fourth image to the specified directory
                        archive.Images[3].ExtractToDirectory(outputPath);
                    }
                    else
                    {
                        Console.Error.WriteLine("The archive does not contain a fourth image.");
                    }
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
 * 1. When you need to retrieve files from a specific image in a Windows Imaging Format (WIM) backup to restore only that part of the system.
 * 2. When deploying a customized Windows image and you want to extract the fourth image’s contents to a folder for inspection or modification before applying it.
 * 3. When automating a migration script that pulls configuration files from the fourth snapshot of a WIM archive to a staging directory.
 * 4. When performing forensic analysis on a WIM file and you must isolate the fourth image’s files for detailed examination.
 * 5. When creating a CI/CD pipeline that extracts assets from a particular image inside a WIM package to include them in a build process.
 */
