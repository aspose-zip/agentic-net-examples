// HOW-TO: Extract All Files from a .tar.xz Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Xz;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "assets_bundle.tar.xz";
            string outputDirectory = "extracted_assets";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (XzArchive xzArchive = new XzArchive(inputPath))
            {
                using (MemoryStream tarStream = new MemoryStream())
                {
                    // Decompress the .xz layer into a TAR stream
                    xzArchive.Extract(tarStream);
                    tarStream.Position = 0;

                    using (TarArchive tarArchive = new TarArchive(tarStream))
                    {
                        foreach (TarEntry entry in tarArchive.Entries)
                        {
                            string destinationPath = Path.Combine(outputDirectory, entry.Name);
                            string destinationDir = Path.GetDirectoryName(destinationPath);
                            if (!string.IsNullOrEmpty(destinationDir))
                            {
                                Directory.CreateDirectory(destinationDir);
                            }

                            // Extract each entry to the destination path
                            entry.Extract(destinationPath);
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
 * 1. When you need to unpack a compressed asset bundle (.tar.xz) for a game or application and place its contents into a local assets directory.
 * 2. When a CI/CD pipeline must decompress a .xz‑compressed TAR package containing configuration files before deploying them to a server.
 * 3. When you receive backup data delivered as a .tar.xz file and want to restore all files to a specific folder using Aspose.Zip in a .NET service.
 * 4. When a desktop utility has to read a .tar.xz archive of documentation PDFs and extract each file to a user‑chosen output folder.
 * 5. When an automated script processes third‑party plugin packages distributed as .tar.xz archives and needs to extract every entry for further analysis.
 */
