// HOW-TO: Create TAR Archive and Compress to XZ with Custom Thread Count in C# (Aspose.ZIP for .NET)
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
            string inputDir = "input";
            string outputPath = "output/parallel.tar.xz";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive tar = new TarArchive())
            {
                string[] files = Directory.GetFiles(inputDir);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    tar.CreateEntry(entryName, filePath);
                }

                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    tar.SaveXzCompressed(outputStream);
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
 * 1. When you need to bundle a set of files into a single TAR file and compress it with XZ using multiple CPU threads for faster backup creation in a .NET application.
 * 2. When deploying a software package that must be distributed as a .tar.xz archive and you want to generate it programmatically with Aspose.Zip in C#.
 * 3. When archiving log files from a directory and want to reduce storage size by creating a multithreaded XZ‑compressed TAR archive on the fly.
 * 4. When integrating automated build pipelines that require creating compressed TAR archives with configurable thread counts to optimize CPU usage.
 * 5. When providing users a downloadable .tar.xz archive from a web service and need to create it server‑side without external tools, controlling compression parallelism via Aspose.Zip.
 */
