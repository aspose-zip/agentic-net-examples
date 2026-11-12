// HOW-TO: Create Tar Xz Archive With Multi‑Threaded Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = @"C:\Data\SourceFolder";
            string outputPath = @"C:\Data\folder_compressed.tar.xz";

            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                string[] files = Directory.GetFiles(inputFolder, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetRelativePath(inputFolder, filePath).Replace('\\', '/');
                    archive.CreateEntry(entryName, filePath);
                }

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
 * 1. When you need to back up a large directory into a single .tar.xz file for efficient storage or transfer using C# and Aspose.Zip.
 * 2. When you want to create a portable Linux‑compatible tar archive from Windows files and compress it with XZ using multiple CPU threads for faster processing.
 * 3. When you must package source code and assets into a tarball before uploading to a CI/CD pipeline that expects a .tar.xz artifact.
 * 4. When you are implementing a custom backup solution that archives a folder hierarchy and reduces its size by using multi‑threaded XZ compression in a .NET application.
 * 5. When you need to generate a compressed archive for distribution to clients who require tar.xz format, while controlling compression performance via thread settings in C#.
 */
