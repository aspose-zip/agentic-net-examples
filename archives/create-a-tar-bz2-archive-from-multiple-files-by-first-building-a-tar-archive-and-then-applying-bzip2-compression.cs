// HOW-TO: Create a Tar.Bz2 Archive From Multiple Files in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputDirectory = "InputData";
            string[] inputFiles = new string[] { "file1.txt", "file2.txt", "file3.txt" };
            string outputDirectory = "OutputData";
            string outputPath = Path.Combine(outputDirectory, "archive.tar.bz2");

            // Verify each input file exists
            foreach (string fileName in inputFiles)
            {
                string filePath = Path.Combine(inputDirectory, fileName);
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add entries
            using (TarArchive tarArchive = new TarArchive())
            {
                foreach (string fileName in inputFiles)
                {
                    string sourcePath = Path.Combine(inputDirectory, fileName);
                    // Add file to TAR with entry name equal to the file name
                    tarArchive.CreateEntry(fileName, sourcePath);
                }

                // Compress TAR archive using BZIP2
                using (Bzip2Archive bzip2 = new Bzip2Archive())
                {
                    bzip2.SetSource(tarArchive);
                    bzip2.Save(outputPath);
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
 * 1. When you need to bundle several log files into a single compressed tar.bz2 package for efficient storage or transfer using C#.
 * 2. When you want to generate a portable Unix‑style tar archive and then apply BZIP2 compression before uploading it to a Linux server.
 * 3. When your application must create backup archives of configuration files that can be extracted with standard tar tools on any platform.
 * 4. When you are preparing a software release that requires a tar.bz2 distribution bundle containing documentation and binaries, created programmatically in .NET.
 * 5. When you have to compress a set of data files into a single archive to meet size‑limit constraints for email or API payloads.
 */
