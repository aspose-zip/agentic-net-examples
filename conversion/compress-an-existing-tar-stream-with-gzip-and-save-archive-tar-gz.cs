// HOW-TO: Create Gzipped TAR Archive From Directory Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string sourceDirectory = "Data";
            string outputPath = "output.tar.gz";

            // Validate input directory existence
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Create TAR archive and add files, then save as GZIP
            using (TarArchive archive = new TarArchive())
            {
                string[] files = Directory.GetFiles(sourceDirectory);
                foreach (string filePath in files)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

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
 * 1. When you need to package a group of log files into a .tar.gz archive for Linux‑compatible backup using C#.
 * 2. When you must generate a compressed TAR file to upload to cloud storage that only accepts .tar.gz bundles.
 * 3. When you want to send multiple configuration files over a network and reduce bandwidth by gzipping a TAR stream in a .NET application.
 * 4. When an automated build pipeline has to create a .tar.gz artifact from the build output folder for distribution to Linux clients.
 * 5. When you are adding a data‑export feature that bundles database dump files into a gzipped TAR archive for end‑users.
 */
