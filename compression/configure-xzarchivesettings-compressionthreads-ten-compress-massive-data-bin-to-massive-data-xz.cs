// HOW-TO: Compress Large Binary File to XZ with Multiple Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;
using Aspose.Zip.Xz.Settings;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "massive_data.bin";
            string outputPath = "massive_data.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            XzArchiveSettings archiveSettings = new XzArchiveSettings();

            using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
            {
                using (XzArchive archive = new XzArchive(archiveSettings))
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
 * 1. When you need to reduce the storage footprint of a huge binary dataset before archiving it on a server.
 * 2. When you want to generate an XZ‑compressed file for faster network transfer of large logs in a .NET application.
 * 3. When you must create a multithreaded compression pipeline to speed up backup of gigabyte‑scale files using Aspose.Zip.
 * 4. When you are building a data‑export feature that outputs a single .xz archive for downstream analytics tools.
 * 5. When you require programmatic error handling while compressing files to XZ format in an automated build process.
 */
