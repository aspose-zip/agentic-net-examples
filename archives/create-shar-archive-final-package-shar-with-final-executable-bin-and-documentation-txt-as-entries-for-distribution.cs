// HOW-TO: Create SHAR Archive With Multiple Files Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFile1 = "final_executable.bin";
            string inputFile2 = "documentation.txt";
            string outputPath = "final_package.shar";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create SHAR archive and add entries
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("final_executable.bin", inputFile1);
                archive.CreateEntry("documentation.txt", inputFile2);
                archive.Save(outputPath);
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
 * 1. When you need to bundle an executable and its documentation into a single SHAR file for easy distribution to Linux users.
 * 2. When you want to automate the creation of a SHAR package in a build script without relying on external command-line tools.
 * 3. When you must ensure the output directory exists before saving the archive to prevent runtime errors in deployment pipelines.
 * 4. When you require programmatic validation of source files before adding them to a SHAR archive to avoid missing-file issues.
 * 5. When you prefer using Aspose.Zip's .NET API to create SHAR archives with custom entry names for versioned releases.
 */
