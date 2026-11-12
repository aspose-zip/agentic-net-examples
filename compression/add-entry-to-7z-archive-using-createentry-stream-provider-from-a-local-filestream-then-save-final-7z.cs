// HOW-TO: Add a File to a 7z Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file and output archive paths
            string inputFilePath = "input.txt";
            string outputArchivePath = "final.7z";

            // Verify the input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputArchivePath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the source file stream (will be used as entry data)
            using (FileStream sourceStream = File.OpenRead(inputFilePath))
            // Open the output archive stream
            using (FileStream archiveStream = File.Open(outputArchivePath, FileMode.Create))
            // Create a new 7z archive
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Add the entry to the archive using the source stream
                archive.CreateEntry(Path.GetFileName(inputFilePath), sourceStream);

                // Save the archive to the output stream
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
 * 1. When you need to programmatically bundle a text file into a 7z archive for distribution or backup in a .NET application.
 * 2. When you want to compress log files on the fly before uploading them to cloud storage using Aspose.Zip.
 * 3. When an automated build process must create a 7z package containing configuration files for deployment.
 * 4. When a desktop utility must add user‑selected documents to a secure 7z container without loading the entire archive into memory.
 * 5. When a server‑side service generates reports and needs to archive each report as a separate entry in a 7z file for later retrieval.
 */
