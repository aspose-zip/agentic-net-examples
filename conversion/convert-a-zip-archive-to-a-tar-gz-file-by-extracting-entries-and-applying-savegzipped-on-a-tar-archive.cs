// HOW-TO: Convert ZIP Archive to Gzipped TAR File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string outputTarGzPath = "output.tar.gz";
            string tempExtractPath = "tempExtract";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));
            Directory.CreateDirectory(tempExtractPath);

            // Extract ZIP archive to temporary folder
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                zipArchive.ExtractToDirectory(tempExtractPath);
            }

            // Create TAR archive from extracted files and save as gzipped TAR
            using (TarArchive tarArchive = new TarArchive())
            {
                tarArchive.CreateEntries(new DirectoryInfo(tempExtractPath));
                tarArchive.SaveGzipped(outputTarGzPath);
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
 * 1. When you need to repackage a downloaded ZIP distribution as a tar.gz for deployment on Linux servers using C#.
 * 2. When you want to convert user‑uploaded ZIP files into gzipped TAR archives before storing them in a cloud backup system.
 * 3. When a build pipeline requires extracting a ZIP, modifying its contents, and then creating a compressed TAR for later extraction on Unix environments.
 * 4. When you must migrate legacy archives from ZIP to tar.gz format to maintain compatibility with tools that only accept tarballs.
 * 5. When automating data archiving in a .NET application, you extract the ZIP to a temporary folder and then generate a gzipped TAR to reduce storage size.
 */
