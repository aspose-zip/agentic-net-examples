// HOW-TO: Create CAB Archive with Duplicate Filenames in Different Folders Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"C:\Input\folder1\file.txt";
            string inputPath2 = @"C:\Input\folder2\file.txt";

            // Hardcoded output CAB file path
            string outputPath = @"C:\Output\duplicate_files.cab";

            // Validate input files
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

            // Default compression settings for CAB entries
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            // Create CAB archive and add entries preserving folder paths
            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add first file under its folder
                archive.CreateEntry("folder1/file.txt", inputPath1);

                // Add second file with the same name under a different folder
                archive.CreateEntry("folder2/file.txt", inputPath2);

                // Save the CAB archive to the specified output path
                archive.Save(outputPath);
            }

            Console.WriteLine("CAB archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package configuration files that share the same name but reside in separate module directories for a Windows installer, this code creates a CAB preserving each folder path.
 * 2. When backing up log files from multiple services that each generate a "log.txt" file, you can archive them into a single CAB without overwriting by keeping their directory structure.
 * 3. When distributing a software update that includes resource files with identical names in different language subfolders, this approach ensures the CAB retains the language‑specific paths.
 * 4. When automating the creation of a compressed deployment bundle for embedded devices where duplicate filenames exist in distinct component folders, the code generates a CAB that maintains the hierarchy.
 * 5. When migrating legacy data that stores files with the same name in separate project folders, you can use this method to compress them into a CAB while preserving the original folder organization for later extraction.
 */
