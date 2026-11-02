// HOW-TO: Create TAR Archive and Compress to XZ with 12 Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "input";
            string outputPath = "output/parallel.tar.xz";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive tarArchive = new TarArchive())
            {
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    string entryName = Path.GetFileName(filePath);
                    tarArchive.CreateEntry(entryName, filePath);
                }

                tarArchive.SaveXzCompressed(outputPath);
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
 * 1. When you need to bundle multiple binary files into a single portable package for distribution while minimizing size using high‑performance XZ compression in a .NET application.
 * 2. When you want to generate a .tar.xz backup of a folder on a server and take advantage of multi‑threaded compression to speed up the process.
 * 3. When your deployment pipeline requires creating a TAR archive and compressing it with XZ to meet Linux‑based packaging standards from C# code.
 * 4. When you are implementing a data‑archiving feature that must store files in a space‑efficient format and you need to control the number of compression threads for optimal CPU usage.
 * 5. When you need to programmatically create a compressed archive for transferring large binary assets over the network, ensuring the archive is compatible with Unix tools that read .tar.xz files.
 */
