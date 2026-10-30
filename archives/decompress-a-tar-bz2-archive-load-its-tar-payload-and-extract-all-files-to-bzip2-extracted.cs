// HOW-TO: Extract All Files from a TAR.BZ2 Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "bzip2_input.tar.bz2";
            string outputPath = "bzip2_extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            string tempTarPath = Path.Combine(Path.GetTempPath(), "temp.tar");
            Directory.CreateDirectory(Path.GetDirectoryName(tempTarPath));

            using (Bzip2Archive bz2 = new Bzip2Archive(inputPath))
            {
                bz2.Extract(tempTarPath);
            }

            using (TarArchive tar = new TarArchive(tempTarPath))
            {
                foreach (TarEntry entry in tar.Entries)
                {
                    string destFile = Path.Combine(outputPath, entry.Name);
                    string destDir = Path.GetDirectoryName(destFile);
                    if (!string.IsNullOrEmpty(destDir))
                    {
                        Directory.CreateDirectory(destDir);
                    }
                    entry.Extract(destFile);
                }
            }

            if (File.Exists(tempTarPath))
            {
                File.Delete(tempTarPath);
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
 * 1. When you receive a .tar.bz2 backup from a Linux server and need to unpack its contents on a Windows .NET application.
 * 2. When you want to programmatically extract deployment packages compressed as TAR.BZ2 before installing files on a client machine.
 * 3. When an automated build pipeline generates TAR.BZ2 artifacts that must be decompressed and processed by a C# service.
 * 4. When you need to read and extract log files stored inside a TAR.BZ2 archive for analysis in a .NET analytics tool.
 * 5. When a desktop application must support opening user‑provided .tar.bz2 archives and save the extracted files to a chosen directory.
 */
