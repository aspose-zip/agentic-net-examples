// HOW-TO: Create Lzip Archive and Compress Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "notes.txt";
            string outputPath = "output/notes.lz";

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
 * 1. When you need to reduce the size of a log or notes file for faster network transfer using Lzip in a .NET application.
 * 2. When you want to store configuration or documentation files in a compressed Lzip archive to save disk space on Windows servers.
 * 3. When you are building a backup utility that archives individual text files into Lzip format for long‑term storage.
 * 4. When you need to generate an Lzip file that can be decompressed by Unix tools, ensuring cross‑platform compatibility.
 * 5. When you are automating a deployment pipeline that packages release notes into a .lz file before uploading to a repository.
 */
