// HOW-TO: Create ZIP Archive from Directory Recursively Preserving NTFS Attributes in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\SourceFolder";
            string outputZipPath = @"C:\Data\Output\archive.zip";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputZipPath);
            Directory.CreateDirectory(outputDir);

            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                archive.CreateEntries(dirInfo);
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
 * 1. When you need to back up an entire folder hierarchy to a ZIP file while keeping original NTFS permissions and timestamps intact.
 * 2. When deploying a .NET application that must package configuration files and resources from multiple subfolders into a single archive for distribution.
 * 3. When creating a portable archive of user-generated data that can be transferred to another Windows machine without losing file attributes.
 * 4. When automating archival of log files generated daily across nested directories, ensuring the compressed archive retains original file metadata.
 * 5. When implementing a scheduled task that compresses project source code directories into ZIP archives for versioned storage while preserving NTFS attributes.
 */
