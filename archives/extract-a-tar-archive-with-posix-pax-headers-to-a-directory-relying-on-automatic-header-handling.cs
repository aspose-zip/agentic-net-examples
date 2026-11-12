// HOW-TO: Extract TAR Archive with POSIX PAX Headers to Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.tar";
        string outputPath = "outputDir\\extracted";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create parent directory for the output path
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            // Create the output directory itself
            Directory.CreateDirectory(outputPath);

            // Open the TAR archive and extract all entries
            using (TarArchive archive = new TarArchive(inputPath))
            {
                // Aspose.Zip automatically handles POSIX/PAX headers
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a Linux‑generated .tar file containing long file names or extended attributes on a Windows server using C#.
 * 2. When a backup system stores data as POSIX/PAX formatted tar archives and your .NET application must restore the files to a specific folder.
 * 3. When you receive tarballs from a CI/CD pipeline that use PAX headers and you want to extract them automatically without manual header parsing.
 * 4. When migrating legacy deployment packages that include Unix metadata and you require a simple C# routine to extract them to a target directory.
 * 5. When building a cross‑platform file‑import tool that must handle tar archives with extended headers and place the contents into a configurable output path.
 */
