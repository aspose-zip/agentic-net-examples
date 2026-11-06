// HOW-TO: Compress a Folder to ZIP Using Aspose.Zip With FileStream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define source directory and output zip file paths
            string sourceDirectory = @"C:\Data\SourceFolder";
            string outputZipPath = @"C:\Data\Compressed\archive.zip";

            // Verify source directory exists
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputZipPath);
            Directory.CreateDirectory(outputDir);

            // Open a FileStream for the zip file with FileMode.Create
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                // Instantiate the Aspose.Zip Archive
                using (Archive archive = new Archive())
                {
                    // Create entries from the source directory
                    DirectoryInfo dirInfo = new DirectoryInfo(sourceDirectory);
                    archive.CreateEntries(dirInfo);

                    // Save the archive to the file stream
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
 * 1. When you need to create a zip archive of a local directory for backup or distribution directly from a .NET application.
 * 2. When you want to ensure the output zip file is written to a specific path and the destination folder is created automatically if it doesn't exist.
 * 3. When you must compress files without loading them into memory, using a FileStream with FileMode.Create for efficient disk I/O.
 * 4. When you are integrating Aspose.Zip into an automated build or deployment pipeline to package build artifacts into a zip file.
 * 5. When you need to handle errors gracefully while verifying the source folder and reporting missing directories before compression.
 */
