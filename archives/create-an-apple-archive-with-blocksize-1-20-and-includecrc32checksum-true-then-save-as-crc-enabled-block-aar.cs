// HOW-TO: Create Apple XAR Archive and Save as .aar in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output/crc_enabled_block.aar";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create XAR archive
            using (XarArchive archive = new XarArchive())
            {
                // Save the archive
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
 * 1. When you need to package macOS resources into a single .aar file using C#.
 * 2. When automating the generation of Apple XAR archives in a CI/CD pipeline for macOS deployments.
 * 3. When a .NET application must create an Apple‑compatible archive without relying on external command‑line tools.
 * 4. When building a backup solution that stores files in XAR format for later extraction on macOS.
 * 5. When providing a simple API for users to bundle files into a .aar archive from a Windows service.
 */
