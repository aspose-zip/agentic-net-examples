// HOW-TO: Compress a Text File to Z Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Z;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.txt";
            string outputPath = "output.z";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a ZArchive, set the source file, and save the archive
            using (ZArchive archive = new ZArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of log files before uploading them to a server, you can compress the .txt log into a .z archive with Aspose.Zip in C#.
 * 2. When an application must bundle configuration files into a single portable package for distribution, you can create a .z archive from the text files using ZArchive.
 * 3. When you want to archive user-generated notes securely on disk while keeping the original format, you can compress each .txt note into a .z file programmatically.
 * 4. When integrating with legacy systems that only accept .z compressed files, you can convert incoming text data into the required format using C# and Aspose.Zip.
 * 5. When implementing a backup routine that stores daily reports as compressed archives to save storage space, you can use ZArchive to save each report as a .z file.
 */
