// HOW-TO: Create ZIP Archive From Multiple Files Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // List of files to compress
            string[] inputFiles = new string[]
            {
                "C:\\Data\\file1.txt",
                "C:\\Data\\file2.txt",
                "C:\\Data\\file3.txt"
            };

            // Output ZIP file path
            string outputPath = "C:\\Data\\output\\urls_archive.zip";

            // Verify each input file exists
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Create archive and add entries
            using (Archive archive = new Archive())
            {
                foreach (string inputPath in inputFiles)
                {
                    // Open source file stream
                    using (FileStream sourceStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
                    {
                        // Use file name as entry name inside the ZIP
                        string entryName = Path.GetFileName(inputPath);
                        archive.CreateEntry(entryName, sourceStream);
                    }
                }

                // Save the archive to the output file
                using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
                {
                    ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                    saveOptions.Encoding = Encoding.ASCII;
                    saveOptions.ArchiveComment = "Created by Aspose.Zip";
                    archive.Save(zipFile, saveOptions);
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
 * 1. When you need to compress several local text files into a single ZIP archive for download using Aspose.Zip in C#.
 * 2. When generating a package of configuration files to distribute with an application, creating entries with CreateEntry and saving the archive.
 * 3. When automating daily backups by bundling report files into a ZIP before uploading them to cloud storage.
 * 4. When sending multiple documents as an email attachment, you can create a ZIP archive on the fly with Aspose.Zip’s Archive and FileStream classes.
 * 5. When building an installer that requires all resource files to be zipped into one archive for efficient extraction on the client side.
 */
