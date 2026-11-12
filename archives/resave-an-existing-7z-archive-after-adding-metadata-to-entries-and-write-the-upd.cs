// HOW-TO: Create a 7z Archive from a Folder Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputDirectory = "data";
            string outputPath = "output/archive.7z";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new 7z archive and add entries from the input directory
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                archive.CreateEntries(inputDirectory);
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
 * 1. When you need to package a directory of files into a 7z archive for distribution or backup in a .NET application.
 * 2. When you want to programmatically generate a compressed 7z file from a local folder to reduce storage size before uploading to cloud storage.
 * 3. When you need to automate the creation of a 7z archive as part of a build or deployment pipeline in C#.
 * 4. When you must ensure the output directory exists and handle missing input folders gracefully while creating a 7z archive.
 * 5. When you want to use Aspose.Zip for .NET to create a 7z archive without manually invoking external compression tools.
 */
