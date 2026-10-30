// HOW-TO: Create XZ Compressed TAR Archive With CRC32 From Directory In C# (Aspose.ZIP for .NET)
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
            string inputDir = "assets";
            string outputPath = "assets_bundle.tar.xz";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            using (TarArchive archive = new TarArchive())
            {
                foreach (string filePath in Directory.GetFiles(inputDir, "*", SearchOption.AllDirectories))
                {
                    string entryName = Path.GetRelativePath(inputDir, filePath).Replace('\\', '/');
                    archive.CreateEntry(entryName, filePath);
                }

                // Save the TAR archive compressed with XZ (includes CRC32 checks by default)
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
 * 1. When you need to bundle a web project's static assets into a single .tar.xz file for efficient deployment to Linux servers.
 * 2. When you want to create a checksum‑verified backup of a folder by compressing it with XZ and CRC32 using C#.
 * 3. When you must prepare a portable archive of configuration files that can be extracted on any platform supporting TAR and XZ.
 * 4. When you are automating CI/CD pipelines and need to archive build output with high compression and integrity checks in .NET.
 * 5. When you are distributing game resources and want to reduce download size while ensuring data integrity with CRC32 in a TAR.XZ package.
 */
