// HOW-TO: Create a Tar.bz2 Archive from an Image Folder in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input folder containing images
            string inputFolder = @"C:\Data\Images";
            // Output tar.bz2 archive path
            string outputTarBz2Path = @"C:\Data\output.tar.bz2";

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Folder not found: {inputFolder}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTarBz2Path));

            // Create TAR archive in memory
            using (TarArchive tarArchive = new TarArchive())
            {
                // Add each file in the input folder to the TAR archive
                string[] files = Directory.GetFiles(inputFolder);
                foreach (string filePath in files)
                {
                    // Verify each file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    tarArchive.CreateEntry(entryName, filePath);
                }

                // Compress the TAR archive to BZIP2 (tar.bz2)
                using (Bzip2Archive bz2Archive = new Bzip2Archive())
                {
                    bz2Archive.SetSource(tarArchive);
                    bz2Archive.Save(outputTarBz2Path);
                }
            }

            Console.WriteLine($"Successfully created tar.bz2 archive at: {outputTarBz2Path}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a collection of photos for backup and send them over a network with high compression, you can create a tar.bz2 archive using C#.
 * 2. When a web service must deliver a set of image assets as a single compressed file to clients, this code generates a tar.bz2 package on the fly.
 * 3. When automating deployment of static image resources to Linux servers, you can archive the folder into tar.bz2 before uploading via SSH.
 * 4. When archiving daily screenshots for long‑term storage while minimizing disk usage, the program creates a tar.bz2 file directly from the source directory.
 * 5. When integrating with legacy Unix tools that expect tar.bz2 inputs, developers can use this C# routine to produce compatible archives from Windows file systems.
 */
