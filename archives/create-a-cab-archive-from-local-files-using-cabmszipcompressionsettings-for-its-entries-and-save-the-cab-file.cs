// HOW-TO: Create CAB Archive with MSZIP Compression from Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFilePath1 = @"C:\Temp\file1.txt";
            string inputFilePath2 = @"C:\Temp\file2.html";
            string outputCabPath = @"C:\Temp\output.cab";

            // Validate input files
            if (!File.Exists(inputFilePath1))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath1}");
                return;
            }
            if (!File.Exists(inputFilePath2))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCabPath));

            // Create default entry settings using MSZIP compression
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            // Create CAB archive and add entries
            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                archive.CreateEntry("file1.txt", inputFilePath1);
                archive.CreateEntry("file2.html", inputFilePath2);
                archive.Save(outputCabPath);
            }

            Console.WriteLine($"CAB archive created at: {outputCabPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package multiple configuration or log files into a single CAB file for distribution to Windows installers.
 * 2. When you want to compress web assets like HTML and text files using MSZIP before deploying them to legacy Windows systems.
 * 3. When an application must generate a CAB archive on the fly to send as an attachment in an automated email workflow.
 * 4. When you are building a backup utility that stores selected documents in a CAB container with consistent compression settings.
 * 5. When you need to create a CAB file for a setup program that expects MSZIP‑compressed entries for proper extraction.
 */
