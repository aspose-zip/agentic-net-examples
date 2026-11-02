// HOW-TO: Create ZIP Archive of Multiple XML Files Without Parallel Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "data/file1.xml";
            string inputPath2 = "data/file2.xml";
            string inputPath3 = "data/file3.xml";
            string outputPath = "output/xml.zip";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create archive and add entries
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.xml", inputPath1);
                archive.CreateEntry("file2.xml", inputPath2);
                archive.CreateEntry("file3.xml", inputPath3);

                // Save archive to file
                using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
                {
                    archive.Save(zipStream);
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
 * 1. When you need to package several XML configuration files into a single zip file for deployment.
 * 2. When you want to create a portable archive that can be opened on any operating system without extra software.
 * 3. When you are automating backup of XML data files and need a simple C# script to generate the zip.
 * 4. When you must ensure the output directory exists before saving the archive in a .NET application.
 * 5. When you need to validate the presence of input files before creating a zip to avoid runtime errors.
 */
