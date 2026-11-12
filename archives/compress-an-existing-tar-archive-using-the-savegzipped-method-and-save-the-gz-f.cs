// HOW-TO: Compress Multiple Files Into a Tar Gz Archive Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = "Data";
            string outputPath = Path.Combine(dataDir, "archive.tar.gz");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define input files
            string file1Path = Path.Combine(dataDir, "file1.txt");
            string file2Path = Path.Combine(dataDir, "file2.txt");

            // Verify input files exist
            if (!File.Exists(file1Path))
            {
                Console.Error.WriteLine($"File not found: {file1Path}");
                return;
            }
            if (!File.Exists(file2Path))
            {
                Console.Error.WriteLine($"File not found: {file2Path}");
                return;
            }

            // Create TAR archive and compress to GZIP
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("file1.txt", file1Path);
                archive.CreateEntry("file2.txt", file2Path);
                archive.SaveGzipped(outputPath);
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
 * 1. When you need to bundle several log or data files into a single .tar.gz package for easy distribution or backup in a .NET application.
 * 2. When a deployment script must create a compressed archive that can be unpacked on Linux systems that expect tar.gz format.
 * 3. When you want to reduce network bandwidth by sending multiple files as one gzipped TAR stream from a C# service.
 * 4. When archiving configuration files for long‑term storage while preserving Unix file permissions inside a .tar.gz container.
 * 5. When integrating with third‑party tools that only accept .tar.gz inputs, you can generate the archive directly in C# without external utilities.
 */
