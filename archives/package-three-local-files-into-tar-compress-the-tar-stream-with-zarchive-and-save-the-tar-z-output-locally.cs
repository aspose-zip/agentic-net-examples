// HOW-TO: Create a TAR.Z Archive from Multiple Files Using C# (Aspose.ZIP for .NET)
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
            // Input file paths
            string inputPath1 = "file1.txt";
            string inputPath2 = "file2.txt";
            string inputPath3 = "file3.txt";

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

            // Output TAR.Z file path
            string outputPath = "output.tar.z";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Create TAR archive and add entries
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("file1.txt", inputPath1);
                archive.CreateEntry("file2.txt", inputPath2);
                archive.CreateEntry("file3.txt", inputPath3);

                // Save the TAR archive compressed with Zstandard
                archive.SaveZstandard(outputPath);
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
 * 1. When you need to bundle several configuration files into a single TAR.Z package for easy distribution to Linux servers.
 * 2. When you want to compress log files with Zstandard before uploading them to cloud storage to reduce bandwidth usage.
 * 3. When a build pipeline must generate a compressed tarball of generated assets that downstream tools expect in .tar.z format.
 * 4. When creating backup snapshots of small text documents and requiring a portable, high‑compression archive that can be extracted on Unix systems.
 * 5. When programmatically combining multiple source files into one compressed archive for inclusion in a software installer.
 */
