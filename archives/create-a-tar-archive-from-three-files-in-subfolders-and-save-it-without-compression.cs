// HOW-TO: Create a TAR Archive from Multiple Subfolder Files Without Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = "input/subfolder1/file1.txt";
            string inputPath2 = "input/subfolder2/file2.txt";
            string inputPath3 = "input/subfolder3/file3.txt";

            // Verify each input file exists
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

            // Hardcoded output TAR file path
            string outputPath = "output/archive.tar";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add entries
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("subfolder1/file1.txt", inputPath1);
                archive.CreateEntry("subfolder2/file2.txt", inputPath2);
                archive.CreateEntry("subfolder3/file3.txt", inputPath3);

                // Save the archive without compression
                archive.Save(outputPath);
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
 * 1. When you need to bundle configuration files located in different subdirectories into a single TAR package for deployment without applying any compression.
 * 2. When you want to generate a lightweight, uncompressed TAR archive of log files from several nested folders to simplify transfer to a Linux server.
 * 3. When a build script must collect source code snippets from multiple project subfolders into one TAR file for version‑control snapshots using C#.
 * 4. When an application has to create a TAR archive for backup purposes while preserving the original folder hierarchy and avoiding compression overhead.
 * 5. When you are integrating Aspose.Zip for .NET into a .NET Core service that prepares uncompressed TAR archives for third‑party tools that only accept plain TAR streams.
 */
