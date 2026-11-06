// HOW-TO: Create Split ZIP of TTF Fonts with 95KB Parts in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = @"C:\Fonts";
            string outputDir = @"C:\Output";

            Directory.CreateDirectory(outputDir);

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            string[] ttfFiles = Directory.GetFiles(inputDir, "*.ttf");
            if (ttfFiles.Length == 0)
            {
                Console.Error.WriteLine($"No TTF files found in: {inputDir}");
                return;
            }

            using (Archive archive = new Archive())
            {
                foreach (string filePath in ttfFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("ttf", 95 * 1024);
                archive.SaveSplit(outputDir, saveOptions);
            }

            Console.WriteLine("Multivolume ZIP created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a large collection of TrueType font files over a network that limits file size, you can create multivolume ZIP archives with 95 KB segments using C# and Aspose.Zip.
 * 2. When a font management system must package fonts for backup onto removable media with small capacity, splitting the ZIP into 95 KB parts ensures each segment fits on the media.
 * 3. When an automated build pipeline generates font bundles and must upload them to a cloud service that imposes a maximum upload size, creating split ZIP files allows each part to stay within the limit.
 * 4. When a desktop application needs to archive user‑selected TTF files and later reassemble them without loading the entire archive into memory, using SplitArchiveSaveOptions creates manageable chunks.
 * 5. When you want to comply with legacy systems that only accept ZIP files of a specific maximum size, generating a split archive of TTF fonts with a defined part size simplifies compatibility.
 */
