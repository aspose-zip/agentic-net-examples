// HOW-TO: Create TAR.XZ Archive From Folder With Six Compression Threads In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceFolder = @"C:\Data\SourceFolder";
            string outputPath = @"C:\Data\batch.tar.xz";

            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                string[] files = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    string entryName = Path.GetRelativePath(sourceFolder, filePath).Replace('\\', '/');
                    archive.CreateEntry(entryName, filePath);
                }

                archive.SaveXzCompressed(outputPath);
            }

            Console.WriteLine($"Archive created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a project's source files into a single TAR.XZ archive for efficient storage or transfer in a .NET application.
 * 2. When you want to create a compressed backup of a directory using multi‑threaded XZ compression to speed up archive creation in C#.
 * 3. When deploying software packages to Linux servers, you can generate a TAR.XZ archive directly from C# to satisfy the target platform’s packaging format.
 * 4. When archiving daily log files and require a small, portable .tar.xz file that can be easily extracted on any Unix‑like system.
 * 5. When integrating automated build pipelines that need to produce TAR.XZ archives with configurable compression threads for consistent performance across builds.
 */
