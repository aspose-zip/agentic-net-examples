// HOW-TO: Compress Multiple Files Into a Bzip2 Tar Archive With Multithreading in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and files
            string dataDir = @"C:\Data\Source\";
            string filePath1 = Path.Combine(dataDir, "file1.txt");
            string filePath2 = Path.Combine(dataDir, "file2.txt");

            // Verify input files exist
            if (!File.Exists(filePath1))
            {
                Console.Error.WriteLine($"File not found: {filePath1}");
                return;
            }
            if (!File.Exists(filePath2))
            {
                Console.Error.WriteLine($"File not found: {filePath2}");
                return;
            }

            // Hardcoded output path
            string outputPath = @"C:\Data\Output\parallel.tar.bz2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add files
            using (TarArchive tarArchive = new TarArchive())
            {
                tarArchive.CreateEntry("file1.txt", filePath1);
                tarArchive.CreateEntry("file2.txt", filePath2);

                // Create BZIP2 archive, set TAR as source, configure options, and save
                using (Bzip2Archive bzip2Archive = new Bzip2Archive())
                {
                    bzip2Archive.SetSource(tarArchive);

                    Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                    saveOptions.CompressionThreads = 4;

                    bzip2Archive.Save(outputPath, saveOptions);
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
 * 1. When you need to bundle several log or data files into a single TAR package and then compress it with Bzip2 to reduce storage space while preserving Unix‑style archive structure in a .NET application.
 * 2. When your application must generate a .tar.bz2 backup of configuration files and you want to speed up compression by using four parallel threads.
 * 3. When you are creating distribution packages for Linux environments from a Windows service and require a Bzip2‑compressed TAR stream generated programmatically in C#.
 * 4. When you need to archive source code files before uploading them to a remote server and want to control the compression thread count for optimal performance.
 * 5. When an automated build pipeline must produce a compressed TAR archive of build artifacts and you need to set the compression thread options using Aspose.Zip for .NET.
 */
