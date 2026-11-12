// HOW-TO: Create and Save ZIP Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputFilePath1 = @"C:\Temp\file1.txt";
            string inputFilePath2 = @"C:\Temp\file2.txt";

            // Hardcoded output ZIP file path
            string outputZipPath = @"C:\Temp\output\archive.zip";

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create a new ZIP archive and add entries
            using (Archive archive = new Archive())
            {
                // Add first file to the archive
                string entryName1 = Path.GetFileName(inputFilePath1);
                FileInfo sourceFile1 = new FileInfo(inputFilePath1);
                archive.CreateEntry(entryName1, sourceFile1);

                // Add second file to the archive
                string entryName2 = Path.GetFileName(inputFilePath2);
                FileInfo sourceFile2 = new FileInfo(inputFilePath2);
                archive.CreateEntry(entryName2, sourceFile2);

                // Save the archive to the specified file path
                archive.Save(outputZipPath);
            }

            Console.WriteLine("ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several log files into a single compressed ZIP for easy transfer or backup.
 * 2. When an application must generate a downloadable package of user‑generated documents on the fly.
 * 3. When a scheduled job archives daily reports into a ZIP file before uploading to cloud storage.
 * 4. When you want to programmatically create a ZIP file to comply with a third‑party API that expects compressed payloads.
 * 5. When you need to store multiple configuration files together in a portable archive for deployment to other environments.
 */
