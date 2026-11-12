// HOW-TO: Extract Tar.Bz2 Archive Preserving Original Directory Structure In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tar.bz2";
        string outputBasePath = "output";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputBasePath);

        try
        {
            using (FileStream bz2FileStream = File.OpenRead(inputPath))
            {
                using (Bzip2Archive bz2Archive = new Bzip2Archive())
                {
                    bz2Archive.SetSource(bz2FileStream);

                    using (MemoryStream tarMemoryStream = new MemoryStream())
                    {
                        // Decompress BZIP2 to obtain the TAR stream
                        bz2Archive.Extract(tarMemoryStream);
                        tarMemoryStream.Position = 0;

                        using (TarArchive tarArchive = new TarArchive(tarMemoryStream))
                        {
                            foreach (TarEntry entry in tarArchive.Entries)
                            {
                                if (!entry.IsDirectory)
                                {
                                    string entryRelativePath = entry.Name;
                                    string destinationPath = Path.Combine(outputBasePath, entryRelativePath);
                                    string destinationDir = Path.GetDirectoryName(destinationPath);
                                    if (!string.IsNullOrEmpty(destinationDir))
                                    {
                                        Directory.CreateDirectory(destinationDir);
                                    }

                                    using (FileStream outFileStream = File.Create(destinationPath))
                                    {
                                        entry.Extract(outFileStream);
                                    }
                                }
                            }
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
 * 1. When you receive a compressed tar.bz2 backup from a Linux server and need to unpack it in a Windows .NET application while keeping the original folder hierarchy.
 * 2. When an automated deployment pipeline must extract packaged resources from a tar.bz2 bundle and place each file into its corresponding subdirectory for further processing.
 * 3. When a data‑migration tool has to read a tar.bz2 archive containing multiple project files and recreate the exact directory layout on the target file system using C#.
 * 4. When a desktop utility needs to allow users to open tar.bz2 archives and view or edit individual files without flattening the archive’s internal structure.
 * 5. When a cloud service ingests tar.bz2 logs, decompresses them, and stores each log file in a directory that mirrors its original path for easy indexing and search.
 */
