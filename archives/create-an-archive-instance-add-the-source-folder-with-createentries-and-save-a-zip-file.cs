// HOW-TO: Create a ZIP Archive From a Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input folder and output ZIP file paths
        string inputFolder = @"C:\InputFolder";
        string outputZip = @"C:\Output\archive.zip";

        try
        {
            // Verify that the source folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

            // Create a new ZIP archive, add entries from the source folder, and save it
            using (Archive archive = new Archive())
            {
                // Add all files and subfolders from the source folder
                archive.CreateEntries(inputFolder, true);

                // Save the archive to the specified output path
                archive.Save(outputZip);
            }

            Console.WriteLine($"Archive created successfully at: {outputZip}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up a project's source files by compressing an entire directory into a ZIP file for storage or transfer.
 * 2. When you want to package generated reports and logs from a specific folder into a single archive before uploading them to a cloud service.
 * 3. When deploying a web application and you must bundle all static assets from a folder into a ZIP for easy extraction on the target server.
 * 4. When creating a downloadable data set for end‑users, you can compress the folder containing CSV and image files into a ZIP using Aspose.Zip.
 * 5. When automating nightly maintenance tasks, you can archive log directories into ZIP files to conserve disk space and simplify archival management.
 */
