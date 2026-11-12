// HOW-TO: Extract Tar.bz2 Archive and Preserve File Modification Times in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tar.bz2";
        string outputDirectory = "extracted";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDirectory);

        try
        {
            // Open the BZip2 compressed archive
            using (Bzip2Archive bzip2 = new Bzip2Archive(inputPath))
            {
                // Decompress the TAR layer into a memory stream
                using (MemoryStream tarStream = new MemoryStream())
                {
                    bzip2.Save(tarStream);
                    tarStream.Position = 0;

                    // Load the TAR archive from the decompressed stream
                    using (TarArchive tar = new TarArchive(tarStream))
                    {
                        foreach (TarEntry entry in tar.Entries)
                        {
                            // Skip directories; they will be created as needed
                            if (entry.IsDirectory)
                                continue;

                            string destinationPath = Path.Combine(outputDirectory, entry.Name);
                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                            // Extract the file entry to the destination path
                            using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                            {
                                entry.Extract(fileStream);
                            }

                            // Preserve the original modification time from the TAR entry
                            File.SetLastWriteTime(destinationPath, entry.ModificationTime);
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
 * 1. When you need to unpack a Linux distribution package delivered as a tar.bz2 file and keep the original timestamps for accurate build reproducibility.
 * 2. When a backup system stores compressed tar archives and you must restore the files in a .NET application while maintaining their original modification dates.
 * 3. When processing scientific data sets that are distributed in tar.bz2 format and you require the extracted files to retain their source timestamps for version tracking.
 * 4. When deploying web assets packaged as tar.bz2 and you want the extracted files to preserve timestamps to avoid unnecessary cache invalidation.
 * 5. When migrating legacy archives from a Unix environment to Windows using C# and you need to extract each file with its original modification time intact.
 */
