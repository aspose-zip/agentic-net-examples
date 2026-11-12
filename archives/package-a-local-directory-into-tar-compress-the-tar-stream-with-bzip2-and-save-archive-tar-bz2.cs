// HOW-TO: Create a BZIP2 Compressed TAR Archive from a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded source directory and output file paths
            string sourceDirectory = @"C:\Data\SourceFolder";
            string outputFilePath = @"C:\Data\archive.tar.bz2";

            // Validate source directory existence
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputFilePath);
            Directory.CreateDirectory(outputDirectory);

            // Create a TAR archive and add files from the source directory
            using (TarArchive tarArchive = new TarArchive())
            {
                string[] files = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Compute relative path for the entry inside the TAR
                    string relativePath = Path.GetRelativePath(sourceDirectory, filePath);
                    // TAR expects forward slashes as path separators
                    string entryPath = relativePath.Replace(Path.DirectorySeparatorChar, '/');

                    // Add the file to the TAR archive
                    tarArchive.CreateEntry(entryPath, filePath);
                }

                // Compress the TAR archive using BZIP2 and save the result
                using (Bzip2Archive bzip2Archive = new Bzip2Archive())
                {
                    bzip2Archive.SetSource(tarArchive);
                    bzip2Archive.Save(outputFilePath);
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
 * 1. When you need to back up a project's source files into a single .tar.bz2 file for efficient storage or transfer.
 * 2. When deploying a Linux application from a Windows build server and the target environment requires a BZIP2‑compressed TAR package.
 * 3. When archiving log files daily and want to reduce disk usage by creating a compressed TAR archive using C#.
 * 4. When integrating with a third‑party system that only accepts .tar.bz2 archives, you can generate the required file programmatically.
 * 5. When implementing a custom backup solution that must preserve directory structure while applying BZIP2 compression for faster uploads.
 */
