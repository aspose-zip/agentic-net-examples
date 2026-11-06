// HOW-TO: Compress Multiple Files Into a ZIP Using FileInfo and FileStream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "input1.txt";
            string inputPath2 = "input2.txt";
            string outputPath = "output.zip";

            // Validate input files
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

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            else
            {
                Directory.CreateDirectory(".");
            }

            // Open a FileStream for the ZIP archive
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Create FileInfo objects for the source files
                FileInfo fileInfo1 = new FileInfo(inputPath1);
                FileInfo fileInfo2 = new FileInfo(inputPath2);

                // Create the archive and add entries using FileInfo
                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("file1.txt", fileInfo1);
                    archive.CreateEntry("file2.txt", fileInfo2);

                    // Save the archive with ASCII encoding for entry names
                    archive.Save(zipFile, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
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
 * 1. When you need to bundle several log files into a single ZIP archive for easy email attachment in a C# application.
 * 2. When automating backup of configuration files on a server and you want to create the archive using FileInfo objects for precise file metadata.
 * 3. When generating downloadable content packages that combine multiple text resources into a compressed ZIP for web users.
 * 4. When implementing a utility that compresses user‑selected documents into a ZIP file while ensuring the output stream is properly closed.
 * 5. When writing a batch process that archives temporary report files into a ZIP archive with ASCII‑encoded entry names for compatibility with legacy systems.
 */
