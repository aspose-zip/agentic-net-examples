// HOW-TO: Create CAB Archive from Multiple Directories Preserving Relative Paths in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directories and output CAB file path
            string[] sourceDirectories = new string[]
            {
                "input/Dir1",
                "input/Dir2"
            };
            string outputPath = "output/archive.cab";

            // Validate input directories
            foreach (string dir in sourceDirectories)
            {
                if (!Directory.Exists(dir))
                {
                    Console.Error.WriteLine($"Directory not found: {dir}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new CAB archive
            using (CabArchive archive = new CabArchive())
            {
                foreach (string dir in sourceDirectories)
                {
                    // Get all files recursively from the current source directory
                    string[] files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
                    foreach (string filePath in files)
                    {
                        // Preserve relative path inside the archive, prefixed with the source folder name
                        string folderName = Path.GetFileName(dir);
                        string relativePath = Path.GetRelativePath(dir, filePath);
                        string entryName = Path.Combine(folderName, relativePath).Replace(Path.DirectorySeparatorChar, '\\');

                        // Verify the file exists before adding
                        if (!File.Exists(filePath))
                        {
                            Console.Error.WriteLine($"File not found: {filePath}");
                            return;
                        }

                        // Add the file to the archive
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            archive.CreateEntry(entryName, fileStream);
                        }
                    }
                }

                // Save the CAB archive to the output path
                archive.Save(outputPath);
            }

            Console.WriteLine($"CAB archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle configuration files from several project folders into a single CAB for deployment while keeping their folder hierarchy.
 * 2. When you want to package log files from multiple source directories into a compressed CAB to archive them without losing their relative paths.
 * 3. When distributing a software update that includes resources spread across different modules, you can create a CAB that preserves each module’s directory structure.
 * 4. When backing up user‑generated content stored in separate directories, you can generate a CAB archive that maintains the original folder layout for easy restoration.
 * 5. When creating an installer that requires a CAB file containing assets from various source locations, this code ensures the files are added with their correct relative paths.
 */
