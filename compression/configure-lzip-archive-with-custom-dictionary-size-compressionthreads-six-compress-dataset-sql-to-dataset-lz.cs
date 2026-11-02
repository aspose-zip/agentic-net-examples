// HOW-TO: Compress SQL File to Lzip Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\dataset.sql";
            string outputPath = @"C:\Data\dataset.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
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
 * 1. When you need to reduce the size of a large .sql dump before uploading it to a remote server, you can compress it into an Lzip archive using Aspose.Zip in C#.
 * 2. When creating automated backup scripts that store database exports in a space‑efficient format, this code lets you generate .lz files programmatically.
 * 3. When integrating data transfer pipelines that require Lzip‑compressed files for compliance with Linux‑based tools, the snippet shows how to produce the archive from C#.
 * 4. When building a desktop utility that lets users select a SQL file and compress it with Aspose.Zip for faster archiving and storage, this example provides the core logic.
 * 5. When implementing a CI/CD step that archives database schema files into Lzip archives to keep build artifacts small, the code demonstrates the necessary API calls.
 */
