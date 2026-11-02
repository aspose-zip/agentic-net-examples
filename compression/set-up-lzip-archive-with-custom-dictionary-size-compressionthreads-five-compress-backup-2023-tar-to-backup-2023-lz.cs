// HOW-TO: Compress TAR File to LZIP Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\backup_2023.tar";
            string outputPath = @"C:\Data\backup_2023.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            {
                using (LzipArchive archive = new LzipArchive())
                {
                    archive.SetSource(inputPath);
                    archive.Save(outputStream);
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
 * 1. When you need to reduce the size of a large TAR backup before transferring it over a network using C#.
 * 2. When you want to create an LZIP archive for long‑term storage of Linux tarballs in a .NET application.
 * 3. When automating nightly backups you must compress the generated .tar file into a .lz file to save disk space.
 * 4. When integrating Aspose.Zip into a Windows service that archives log files packaged as TAR archives.
 * 5. When a cross‑platform deployment pipeline requires converting TAR archives to LZIP format programmatically in C#.
 */
