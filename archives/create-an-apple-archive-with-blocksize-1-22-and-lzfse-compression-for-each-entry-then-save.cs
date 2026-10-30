// HOW-TO: Create Zip Archive With Bzip2 Compression For Multiple Files In C# (Aspose.ZIP for .NET)
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
            string inputDir = @"C:\Data\Input";
            string outputPath = @"C:\Data\output.zip";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream outStream = File.Open(outputPath, FileMode.Create))
            {
                ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(new Bzip2CompressionSettings());

                using (Archive archive = new Archive(entrySettings))
                {
                    foreach (string filePath in Directory.GetFiles(inputDir))
                    {
                        if (!File.Exists(filePath))
                        {
                            Console.Error.WriteLine($"File not found: {filePath}");
                            continue;
                        }

                        string entryName = Path.GetFileName(filePath);
                        archive.CreateEntry(entryName, filePath);
                    }

                    archive.Save(outStream);
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
 * 1. When you need to package a batch of log files into a single .zip using Bzip2 compression to reduce storage size in a C# application.
 * 2. When an automated backup script must create a compressed archive of a directory’s contents before uploading to cloud storage using Aspose.Zip.
 * 3. When a desktop utility has to generate a zip file with custom compression settings for each entry to meet performance or compatibility requirements.
 * 4. When a server-side process must validate the existence of input files, compress them into a single archive, and handle errors gracefully in .NET.
 * 5. When you want to programmatically create a zip archive in C# without external tools, using Aspose.Zip’s ArchiveEntrySettings to control compression.
 */
