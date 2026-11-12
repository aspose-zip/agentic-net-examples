// HOW-TO: Create TAR Archive and Compress with Zstandard to MemoryStream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Zstandard;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = "C:\\Data\\file1.txt";
            string inputPath2 = "C:\\Data\\file2.txt";
            string inputPath3 = "C:\\Data\\file3.txt";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Hardcoded output file path
            string outputPath = "C:\\Output\\archive.tar.zst";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add entries
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("file1.txt", inputPath1);
                archive.CreateEntry("file2.txt", inputPath2);
                archive.CreateEntry("file3.txt", inputPath3);

                // Compress TAR to Zstandard into a memory stream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    archive.SaveZstandard(memoryStream);
                    memoryStream.Position = 0;

                    // Write compressed data to the output file
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
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
 * 1. When you need to bundle several log files into a single TAR archive and compress it with Zstandard for efficient storage or transfer in a .NET application.
 * 2. When an automated backup script must create a portable .tar.zst package from local files without writing intermediate uncompressed files to disk.
 * 3. When a cloud service requires uploading a compressed TAR stream, and you want to generate the Zstandard‑compressed data in memory before sending it.
 * 4. When you want to reduce the size of a collection of configuration files before archiving them for version control or distribution using Aspose.Zip in C#.
 * 5. When a Windows desktop tool must create a .tar.zst archive on the fly for users, ensuring the process runs entirely in memory to improve performance and avoid temporary files.
 */
