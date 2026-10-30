// HOW-TO: Create CAB Archive from Folder Without Root Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output CAB file paths
            string inputDirectory = @"C:\InputFolder";
            string outputCabPath = @"C:\Output\archive.cab";

            // Validate input directory existence
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCabPath));

            // Create a new CAB archive
            using (CabArchive cabArchive = new CabArchive())
            {
                // Add all files from the input directory without including the root folder itself
                foreach (string filePath in Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories))
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetRelativePath(inputDirectory, filePath);
                    using (FileStream fileStream = File.OpenRead(filePath))
                    {
                        CabEntrySettings entrySettings = new CabEntrySettings();
                        cabArchive.CreateEntry(entryName, fileStream, entrySettings);
                    }
                }

                // Save the CAB archive to the specified path
                cabArchive.Save(outputCabPath);
            }

            Console.WriteLine($"CAB archive created successfully at: {outputCabPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package application files into a CAB for Windows installation without preserving the top‑level folder structure.
 * 2. When you want to compress a set of log files into a CAB archive for easy distribution while keeping only relative paths.
 * 3. When building a deployment pipeline that generates CAB archives from build output directories for driver or system updates.
 * 4. When creating backup archives of configuration files where the root directory should be omitted to simplify extraction on target machines.
 * 5. When automating the creation of CAB files for legacy installers that require flat entry paths rather than nested folder names.
 */
