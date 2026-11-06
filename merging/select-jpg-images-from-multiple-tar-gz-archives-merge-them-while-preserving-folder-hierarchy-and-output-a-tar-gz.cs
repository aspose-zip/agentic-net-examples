// HOW-TO: Extract and Merge JPG Images from Multiple TAR.GZ Archives in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputArchives = new string[]
            {
                @"C:\Data\Archive1.tar.gz",
                @"C:\Data\Archive2.tar.gz"
            };

            string outputPath = @"C:\Data\MergedImages.tar.gz";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive outputArchive = new TarArchive())
            {
                foreach (string inputPath in inputArchives)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                    using (GzipArchive gzip = new GzipArchive())
                    {
                        gzip.SetSource(fileStream);

                        using (MemoryStream tarStream = new MemoryStream())
                        {
                            gzip.Extract(tarStream);
                            tarStream.Position = 0;

                            using (TarArchive tar = new TarArchive(tarStream))
                            {
                                foreach (TarEntry entry in tar.Entries)
                                {
                                    if (!entry.IsDirectory && entry.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                                    {
                                        using (MemoryStream entryData = new MemoryStream())
                                        {
                                            entry.Extract(entryData);
                                            entryData.Position = 0;
                                            outputArchive.CreateEntry(entry.Name, entryData);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                outputArchive.SaveGzipped(outputPath);
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
 * 1. When you need to gather all JPEG photos stored across several backup tar.gz files and create a single compressed archive for easy distribution.
 * 2. When a web service must preprocess image assets by extracting only .jpg files from multiple tar.gz packages while keeping their original folder structure.
 * 3. When automating a migration of image resources from legacy tar.gz backups to a new system that expects a single tar.gz bundle.
 * 4. When building a CI pipeline that validates that all JPEG files in archived releases are present and combines them into one archive for further testing.
 * 5. When creating a downloadable media package that consolidates JPEG images from various tar.gz archives while preserving directory hierarchy for proper organization.
 */
