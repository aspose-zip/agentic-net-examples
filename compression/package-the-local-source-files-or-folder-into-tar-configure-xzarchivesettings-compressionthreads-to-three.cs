// HOW-TO: Create TAR.XZ Archive With Three Compression Threads In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = @"C:\SourceFolder";
            string outputPath = @"C:\Output\multi.tar.xz";

            if (!Directory.Exists(sourcePath))
            {
                Console.Error.WriteLine($"Directory not found: {sourcePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                foreach (string filePath in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
                {
                    string entryName = Path.GetRelativePath(sourcePath, filePath).Replace('\\', '/');
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
 * 1. When you need to bundle a project's source files into a single TAR.XZ file for efficient distribution over limited bandwidth.
 * 2. When you want to archive log files from multiple subfolders into a compressed XZ archive to save disk space on backup servers.
 * 3. When deploying a .NET application that requires delivering resources as a TAR.XZ package that can be extracted on Linux systems.
 * 4. When creating a reproducible build artifact that must be compressed with multiple threads to speed up the packaging process.
 * 5. When integrating Aspose.Zip into an automated pipeline to generate multi‑threaded XZ archives for archival compliance.
 */
