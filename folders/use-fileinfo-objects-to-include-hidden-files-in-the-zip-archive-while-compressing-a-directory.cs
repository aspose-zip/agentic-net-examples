// HOW-TO: Compress a Directory Including Hidden Files to ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output ZIP file paths
            string inputDirectory = @"C:\Data\SourceFolder";
            string outputZipPath = @"C:\Data\Archive\output.zip";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Get all files in the directory tree, including hidden files
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                FileInfo[] allFiles = dirInfo.GetFiles("*", SearchOption.AllDirectories);

                foreach (FileInfo fileInfo in allFiles)
                {
                    // Compute the entry name relative to the input directory, using forward slashes
                    string entryName = Path.GetRelativePath(inputDirectory, fileInfo.FullName)
                                         .Replace('\\', '/');

                    // Add the file to the archive using its FileInfo (preserves hidden attribute)
                    archive.CreateEntry(entryName, fileInfo);
                }

                // Save the archive to the output ZIP file
                using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
                {
                    archive.Save(zipStream);
                }
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
 * 1. When you need to back up a project folder that contains hidden configuration files without losing them during compression.
 * 2. When deploying an application and must package all assets, including system or hidden files, into a single ZIP archive for distribution.
 * 3. When creating an automated archival process that must preserve file attributes such as the hidden flag while compressing logs and reports.
 * 4. When building a C# utility that extracts a directory into a ZIP file for secure transfer, ensuring hidden files are not omitted.
 * 5. When integrating Aspose.Zip into a CI pipeline to generate reproducible ZIP packages that include hidden metadata files.
 */
