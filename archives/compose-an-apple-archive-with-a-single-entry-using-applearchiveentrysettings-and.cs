// HOW-TO: Create Zip Archive With Single File Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample.txt";
            string outputPath = "output/archive.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream sourceStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (FileStream archiveStream = File.Open(outputPath, FileMode.Create, FileAccess.Write))
            using (Archive archive = new Archive(new ArchiveEntrySettings()))
            {
                archive.CreateEntry("sample.txt", sourceStream);
                archive.Save(archiveStream);
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
 * 1. When you need to bundle a configuration file into a zip for deployment scripts.
 * 2. When generating a downloadable package of server logs in a C# application.
 * 3. When creating a backup of a single document before sending it via email.
 * 4. When preparing a compressed payload for an API that accepts zip files.
 * 5. When automating the creation of an archive for archiving user‑generated reports.
 */
