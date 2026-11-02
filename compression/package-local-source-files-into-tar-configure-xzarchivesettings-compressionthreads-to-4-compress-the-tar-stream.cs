// HOW-TO: Create TAR XZ Archive With Four Compression Threads In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = @"C:\Data\";
            string[] sourceFiles = new string[]
            {
                Path.Combine(dataDir, "Program.cs"),
                Path.Combine(dataDir, "Utils.cs"),
                Path.Combine(dataDir, "Readme.md")
            };

            foreach (string filePath in sourceFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            string outputPath = Path.Combine(dataDir, "parallel.tar.xz");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive tarArchive = new TarArchive())
            {
                foreach (string filePath in sourceFiles)
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
 * 1. When you need to bundle multiple source files into a single TAR package and compress it with XZ for efficient distribution in a .NET build pipeline.
 * 2. When you want to reduce the size of deployment artifacts by using multi‑threaded XZ compression while preserving the original file hierarchy.
 * 3. When creating backup archives of code repositories on Windows and require a portable .tar.xz format that can be extracted on Linux systems.
 * 4. When automating the preparation of source bundles for CI/CD systems that expect a compressed TAR file with deterministic entry names.
 * 5. When implementing a custom archiving tool in C# that must generate high‑compression XZ archives without relying on external command‑line utilities.
 */
