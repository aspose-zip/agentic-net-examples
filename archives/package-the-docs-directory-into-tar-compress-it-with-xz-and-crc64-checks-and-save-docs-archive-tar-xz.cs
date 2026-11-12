// HOW-TO: Create Tar.Xz Archive With CRC64 From Directory In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "docs";
            string outputPath = "docs_archive.tar.xz";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (TarArchive archive = new TarArchive())
            {
                foreach (string filePath in Directory.GetFiles(inputDir, "*", SearchOption.AllDirectories))
                {
                    string entryName = Path.GetRelativePath(inputDir, filePath).Replace('\\', '/');
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
 * 1. When you need to back up a project's documentation folder into a single, space‑efficient TAR.XZ file with CRC64 integrity verification using C#.
 * 2. When deploying a web application and you must package configuration files into a tar archive compressed with XZ for Linux servers, ensuring data integrity via CRC64.
 * 3. When creating a portable archive of source code to send to a client, and you want the archive to be compressed with XZ and include a CRC64 checksum for error detection.
 * 4. When automating nightly backups of log files on Windows and you require a .tar.xz archive that can be easily extracted on Unix systems with built‑in CRC64 validation.
 * 5. When integrating a build pipeline that needs to bundle generated reports into a tar archive, compress them with XZ, and store the result as docs_archive.tar.xz for long‑term storage.
 */
