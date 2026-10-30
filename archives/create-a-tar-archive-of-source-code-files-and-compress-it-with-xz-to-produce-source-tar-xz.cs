// HOW-TO: Create a Tar.Xz Archive of Source Code Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing source files
            string inputDir = "C:\\SourceFiles";
            // Hardcoded output path for the compressed TAR archive
            string outputPath = "C:\\Output\\source.tar.xz";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a TAR archive and add all files from the input directory
            using (TarArchive archive = new TarArchive())
            {
                string[] files = Directory.GetFiles(inputDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Compute relative path for the entry inside the TAR
                    string entryName = Path.GetRelativePath(inputDir, filePath).Replace('\\', '/');
                    archive.CreateEntry(entryName, filePath);
                }

                // Save the TAR archive compressed with XZ
                archive.SaveXzCompressed(outputPath);
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
 * 1. When you need to package multiple source code files into a single, portable TAR archive and compress it with XZ for efficient distribution or backup in a .NET application.
 * 2. When deploying a C# project to Linux servers that require .tar.xz packages for installation scripts.
 * 3. When creating release bundles for open‑source libraries where the standard distribution format is a compressed TAR file.
 * 4. When archiving build artifacts to reduce storage space while preserving the original directory structure for later extraction.
 * 5. When automating CI/CD pipelines that must generate a .tar.xz archive of source files before uploading to an artifact repository.
 */
