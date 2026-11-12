// HOW-TO: Compress an EXE to BZIP2 Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\myExecutable.exe";
            string outputPath = "C:\\Data\\myExecutable.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a Windows executable for faster network distribution or download.
 * 2. When you want to store a binary file in a BZIP2 archive to save disk space while keeping the original format intact.
 * 3. When you are creating an automated build pipeline that generates compressed backups of compiled binaries using C#.
 * 4. When you must produce a .bz2 payload for a deployment script that expects BZIP2‑compressed files.
 * 5. When you are developing a tool that archives executable resources for long‑term storage without requiring the highest possible compression ratio.
 */
