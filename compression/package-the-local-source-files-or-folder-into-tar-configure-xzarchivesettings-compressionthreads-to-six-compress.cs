// HOW-TO: Create TAR.XZ Archive with Six Compression Threads Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceFolder = @"C:\Data\SourceFolder";
            string outputPath = @"C:\Data\folder.tar.xz";

            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntries(sourceFolder);
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
 * 1. When you need to bundle a directory of log files into a single .tar.xz package for efficient storage or transfer in a .NET application.
 * 2. When you want to generate a compressed backup of a project's source code folder using XZ compression to reduce disk usage.
 * 3. When an automated deployment script must create a portable archive of configuration files that can be extracted on Linux systems.
 * 4. When a cloud service requires uploading data as a .tar.xz stream and you need to produce it directly from C# without external tools.
 * 5. When you are implementing a file‑archiving feature that must use multiple CPU threads for faster XZ compression of large folders.
 */
