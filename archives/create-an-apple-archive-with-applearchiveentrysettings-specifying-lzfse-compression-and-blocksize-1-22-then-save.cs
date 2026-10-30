// HOW-TO: Create a ZIP Archive with Bzip2 Compression in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.txt";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(new Bzip2CompressionSettings());

            using (Archive archive = new Archive(entrySettings))
            {
                archive.CreateEntry("input.txt", inputPath);
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
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
 * 1. When you need to package a text file into a ZIP file using Bzip2 compression to reduce size before uploading it from a .NET application.
 * 2. When your C# program must generate a compressed archive for backup purposes and you want to control the compression algorithm with ArchiveEntrySettings.
 * 3. When you are building a file‑transfer service that creates ZIP bundles on the fly and requires Bzip2 to meet specific client compression requirements.
 * 4. When you want to automate the creation of a compressed archive in a scheduled task, ensuring the output directory exists before saving the ZIP.
 * 5. When you need to handle errors gracefully while creating and saving a ZIP archive with custom compression settings in a .NET environment.
 */
