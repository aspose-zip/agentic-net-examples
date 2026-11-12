// HOW-TO: Extract Files From a .Tar.Lz4 Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputLz4Path = "C:\\Data\\archive.tar.lz4";
            string tempTarPath = "C:\\Data\\archive.tar";
            string outputDirectory = "C:\\Data\\Extracted";

            if (!File.Exists(inputLz4Path))
            {
                Console.Error.WriteLine($"File not found: {inputLz4Path}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempTarPath));
            Directory.CreateDirectory(outputDirectory);

            using (Lz4Archive lz4Archive = new Lz4Archive(inputLz4Path))
            using (FileStream tarStream = File.Create(tempTarPath))
            {
                lz4Archive.Extract(tarStream);
            }

            using (TarArchive tarArchive = new TarArchive(tempTarPath))
            {
                foreach (TarEntry entry in tarArchive.Entries)
                {
                    string destinationPath = Path.Combine(outputDirectory, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                    using (FileStream outputStream = File.Create(destinationPath))
                    {
                        entry.Extract(outputStream);
                    }
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a .tar.lz4 backup from a Linux server and need to programmatically decompress and extract its contents in a Windows C# application.
 * 2. When you want to automate the processing of large LZ4‑compressed tar archives for data migration without using external command‑line tools.
 * 3. When a .NET service must unpack archived logs that are stored as LZ4‑wrapped tar files before indexing them.
 * 4. When building a deployment pipeline that extracts packaged resources delivered as .tar.lz4 files directly within a C# build script.
 * 5. When creating a desktop utility that lets users select an LZ4‑compressed tar file and extracts all files to a chosen folder using Aspose.Zip.
 */
