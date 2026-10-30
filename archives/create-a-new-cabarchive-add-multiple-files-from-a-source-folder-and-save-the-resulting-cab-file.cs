// HOW-TO: Create CAB Archive From Folder Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input folder containing files to be added to the CAB archive
            string sourceFolder = "input";

            // Hardcoded output CAB file path
            string cabOutputPath = "output\\archive.cab";

            // Verify the source folder exists
            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            // Get all files from the source folder
            string[] files = Directory.GetFiles(sourceFolder);

            // Ensure there is at least one file to add
            if (files.Length == 0)
            {
                Console.Error.WriteLine($"No files found in directory: {sourceFolder}");
                return;
            }

            // Verify each file exists before adding
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Create default CAB entry settings (MS-ZIP compression)
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            // Create the CAB archive with the default settings
            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add each file to the archive
                foreach (string filePath in files)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Ensure the output directory exists
                string outputDirectory = Path.GetDirectoryName(cabOutputPath);
                if (!string.IsNullOrEmpty(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Save the CAB archive to the specified path
                archive.Save(cabOutputPath);
            }

            Console.WriteLine($"CAB archive created successfully at: {cabOutputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a set of installation files into a single CAB file for Windows deployment using C#.
 * 2. When you want to automate the creation of compressed driver bundles for distribution in a .NET application.
 * 3. When you must generate a CAB archive of log files before uploading them to a server for analysis.
 * 4. When you are building a setup program that combines multiple resource files into a CAB to be consumed by MSI installers.
 * 5. When you require a simple C# script to compress a folder’s contents into a CAB archive for backup or archival purposes.
 */
