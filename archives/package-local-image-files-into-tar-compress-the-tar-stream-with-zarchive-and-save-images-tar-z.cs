// HOW-TO: Create a TAR.Z Archive of Images Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Zstandard;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Images";
            string outputPath = @"C:\Output\images.tar.Z";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                string[] imageFiles = Directory.GetFiles(inputDirectory);
                foreach (string filePath in imageFiles)
                {
                    string fileName = Path.GetFileName(filePath);
                    archive.CreateEntry(fileName, filePath);
                }

                archive.SaveZstandard(outputPath);
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
 * 1. When you need to bundle a folder of JPEG or PNG files into a single TAR archive and compress it with Zstandard for fast network transfer in a C# application.
 * 2. When you want to create a portable, compressed package of screenshots for archiving or emailing, using Aspose.Zip to generate a .tar.Z file programmatically.
 * 3. When a deployment script must archive image assets before uploading them to a Linux server that expects .tar.Z format, and you prefer handling it directly in .NET.
 * 4. When you are implementing a backup routine that stores daily image snapshots in a space‑efficient Zstandard‑compressed TAR file to reduce storage costs.
 * 5. When an automated build process needs to collect generated graphics, compress them with Zstandard, and save the result as images.tar.Z for later extraction by cross‑platform tools.
 */
