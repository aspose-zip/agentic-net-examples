// HOW-TO: Create a ZIP Archive From Multiple Binary Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "data1.bin";
            string inputPath2 = "data2.bin";
            string outputPath = "output/combined.zip";

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive archive = new Archive())
            {
                using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("data1.bin", fs1);
                    using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
                    {
                        archive.CreateEntry("data2.bin", fs2);
                        using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
                        {
                            archive.Save(outStream);
                        }
                    }
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
 * 1. When you need to bundle several generated binary logs into a single ZIP file for easier transfer or backup using C# and Aspose.Zip.
 * 2. When an application must combine multiple data files before uploading them to a cloud storage service, creating a compressed archive on the fly.
 * 3. When you want to package binary configuration files into a portable archive to distribute them with a software installer written in .NET.
 * 4. When you have to archive sensor output files periodically and store them locally as a single compressed ZIP to save disk space.
 * 5. When a C# service must create a downloadable archive of user‑uploaded binary assets without relying on external command‑line tools.
 */
