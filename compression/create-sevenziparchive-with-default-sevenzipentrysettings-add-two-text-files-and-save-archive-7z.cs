// HOW-TO: Create a 7z Archive with Two Text Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"C:\Temp\file1.txt";
            string inputPath2 = @"C:\Temp\file2.txt";
            string outputPath = @"C:\Temp\archive.7z";

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open input streams and create the 7z archive
            using (FileStream stream1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
            using (FileStream stream2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Add entries with default settings
                archive.CreateEntry("file1.txt", stream1);
                archive.CreateEntry("file2.txt", stream2);

                // Save the archive
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
 * 1. When you need to bundle multiple log files into a single 7z package for easier distribution or backup in a .NET application using Aspose.Zip.
 * 2. When you want to programmatically compress configuration text files into a 7z archive before uploading them to cloud storage with C#.
 * 3. When you are building an installer that must create a compressed 7z archive of documentation files on the fly using Aspose.Zip for .NET.
 * 4. When you need to generate a password‑free 7z archive of user‑generated reports for email attachment in an enterprise system.
 * 5. When you are automating the archival of temporary text files to reduce disk usage while preserving their original names in a C# service.
 */
