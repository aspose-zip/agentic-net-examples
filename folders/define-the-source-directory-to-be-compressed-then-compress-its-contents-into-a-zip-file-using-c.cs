// HOW-TO: Compress a Folder into a ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define source directory and output ZIP file paths
            string sourceDirectory = @"C:\Data\SourceFolder";
            string outputZipPath = @"C:\Data\Compressed\archive.zip";

            // Verify source directory exists
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create a file stream for the ZIP archive
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                // Create a new ZIP archive
                using (Archive archive = new Archive())
                {
                    // Add all entries from the source directory
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
 * 1. When you need to create a backup of a local folder by compressing all its files into a single ZIP file for easy storage or transfer.
 * 2. When you want to package generated reports or logs from a server directory into a ZIP archive before uploading them to a cloud service.
 * 3. When you are building an installer that must bundle application resources from a directory into a compressed archive for distribution.
 * 4. When you need to archive user‑uploaded documents on a web application by zipping the upload folder to reduce disk usage.
 * 5. When you are automating the archiving of daily data exports and require a C# routine that creates a ZIP file using Aspose.Zip.
 */
