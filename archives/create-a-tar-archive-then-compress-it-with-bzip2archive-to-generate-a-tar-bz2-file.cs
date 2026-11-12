// HOW-TO: Create Tar Bz2 Archive From Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceDir = @"C:\Data\Source";
            string tarPath = @"C:\Data\output.tar";
            string tarBz2Path = @"C:\Data\output.tar.bz2";

            if (!Directory.Exists(sourceDir))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDir}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tarPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tarBz2Path));

            using (TarArchive tarArchive = new TarArchive())
            {
                string[] files = Directory.GetFiles(sourceDir);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    tarArchive.CreateEntry(entryName, filePath);
                }

                tarArchive.Save(tarPath);

                using (Bzip2Archive bz2 = new Bzip2Archive())
                {
                    bz2.SetSource(tarArchive);
                    bz2.Save(tarBz2Path);
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
 * 1. When you need to back up a directory into a single .tar.bz2 file for efficient storage or transfer.
 * 2. When you want to package source files into a TAR archive before applying Bzip2 compression for Linux distribution.
 * 3. When you must generate a compressed tarball to upload to a remote server that only accepts .tar.bz2 archives.
 * 4. When you are creating a portable archive of log files to preserve them with high compression while maintaining TAR compatibility.
 * 5. When you need to automate the creation of a .tar.bz2 archive as part of a CI/CD pipeline for deployment artifacts.
 */
