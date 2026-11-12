// HOW-TO: Compress an EXE File to LZ Format Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\myExecutable.exe";
            string outputPath = @"C:\Data\myExecutable.lz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create LzipArchive, set the source file, and save to a file stream
            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);

                using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    archive.Save(outStream);
                }
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a Windows executable before distributing it over a network, you can compress it to an .lz file with Aspose.Zip.
 * 2. When creating an installer that stores binaries in Lzip archives for faster download and lower bandwidth usage, this code shows how to generate the .lz file in C#.
 * 3. When implementing a backup system that archives executable files in Lzip format to save disk space, you can use this snippet to write the compressed stream directly to a file.
 * 4. When building a CI/CD pipeline that automatically compresses build artifacts (e.g., .exe) into Lzip archives for storage in artifact repositories, the example demonstrates the required steps.
 * 5. When developing a custom deployment tool that needs to send executables as Lzip-compressed payloads to remote machines, this code illustrates how to create the .lz file programmatically.
 */
