// HOW-TO: Create ZIP Archive From Multiple Files And Save To Disk In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"C:\Temp\input1.txt";
            string inputPath2 = @"C:\Temp\input2.txt";

            // Verify that each input file exists
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Hardcoded output archive path
            string outputPath = @"C:\Temp\output.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new ZIP archive and add entries
            using (Archive archive = new Archive())
            {
                // Add first file as an entry
                FileInfo fileInfo1 = new FileInfo(inputPath1);
                archive.CreateEntry(fileInfo1.Name, fileInfo1);

                // Add second file as an entry
                FileInfo fileInfo2 = new FileInfo(inputPath2);
                archive.CreateEntry(fileInfo2.Name, fileInfo2);

                // Save the composed archive to disk
                archive.Save(outputPath);
            }

            Console.WriteLine($"Archive saved successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several log files into a single ZIP for easy transfer or archival in a C# application.
 * 2. When you want to programmatically create a compressed package of configuration files before uploading them to a server.
 * 3. When an automated build script must generate a ZIP of output artifacts and store it on disk for later distribution.
 * 4. When you are implementing a simple backup routine that collects selected documents into a ZIP file using .NET.
 * 5. When a desktop utility must combine user‑selected text files into a compressed archive for download or email attachment.
 */
