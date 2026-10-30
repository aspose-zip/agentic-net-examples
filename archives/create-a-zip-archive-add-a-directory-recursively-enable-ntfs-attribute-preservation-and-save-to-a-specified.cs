// HOW-TO: Create ZIP Archive From Folder Recursively With NTFS Attributes In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\MyFolder";
            string outputZipPath = @"C:\Output\MyArchive.zip";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                archive.CreateEntries(dirInfo);
                archive.Save(zipStream);
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
 * 1. When you need to back up a whole project directory, preserving file permissions and timestamps, you can zip the folder recursively in C#.
 * 2. When deploying a web application you want to package all its files, including subfolders, into a single ZIP file for easy transfer.
 * 3. When creating an archive for compliance auditing, preserving NTFS attributes ensures the original security settings are retained.
 * 4. When generating downloadable content bundles from a user‑selected folder, you can create the ZIP on the fly without manual file enumeration.
 * 5. When automating nightly builds, you can compress the output folder into a ZIP archive to store or upload to a remote server.
 */
