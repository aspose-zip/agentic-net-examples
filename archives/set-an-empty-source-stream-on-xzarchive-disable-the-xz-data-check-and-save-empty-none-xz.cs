// HOW-TO: Create Empty XZ Archive Without Data Check in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "empty_none.xz";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (MemoryStream emptyStream = new MemoryStream())
            {
                using (XzArchive archive = new XzArchive())
                {
                    archive.SetSource(emptyStream);
                    archive.Save(outputPath);
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
 * 1. When you need to generate a placeholder .xz file for testing pipelines that expect an XZ archive but contain no data.
 * 2. When you want to create an empty compressed package to reserve space in a backup system without writing any actual files.
 * 3. When you need to produce a zero‑byte XZ stream to verify that a downstream extractor correctly handles archives with no entries.
 * 4. When you are building a CI/CD step that must upload an .xz artifact even if the build produced no output files.
 * 5. When you want to initialize an XzArchive object with a MemoryStream to avoid file I/O while creating an empty archive for API compatibility.
 */
