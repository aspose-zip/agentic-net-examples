// HOW-TO: Compress Text File to Lzip Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\notes_collection.txt";
            string outputPath = @"C:\Data\notes_collection.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (LzipArchive archive = new LzipArchive())
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
 * 1. When you need to reduce the size of a large log or notes file for faster transfer or storage, you can use Aspose.Zip to create an Lzip archive in C#.
 * 2. When your application must generate Lzip‑compressed backups of user‑generated text files on Windows, this code shows how to compress them programmatically.
 * 3. When integrating a .NET service that sends data to a Linux system that expects Lzip format, you can compress the payload with Aspose.Zip before transmission.
 * 4. When you want to automate archiving of daily reports into a single .lz file with minimal code, this example demonstrates setting the source and saving the Lzip archive.
 * 5. When building a cross‑platform utility that archives configuration files for version control, you can use the LzipArchive class to create compact .lz files directly from C#.
 */
