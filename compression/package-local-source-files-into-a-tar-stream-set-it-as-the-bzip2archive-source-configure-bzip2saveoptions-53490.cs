// HOW-TO: Create TAR Archive and Compress with Bzip2 Using 8 Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Tar;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = "Data";
            string inputFile1 = Path.Combine(dataDir, "file1.txt");
            string inputFile2 = Path.Combine(dataDir, "file2.txt");
            string outputPath = Path.Combine(dataDir, "parallel.tar.bz2");

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add files
            using (TarArchive tarArchive = new TarArchive())
            {
                tarArchive.CreateEntry("file1.txt", inputFile1);
                tarArchive.CreateEntry("file2.txt", inputFile2);

                // Compress TAR archive using BZIP2 with parallel threads
                using (Bzip2Archive bzip2Archive = new Bzip2Archive())
                {
                    bzip2Archive.SetSource(tarArchive);

                    Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                    saveOptions.CompressionThreads = 8;

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
 * 1. When you need to bundle multiple log files into a single TAR package and compress it with Bzip2 for efficient storage while leveraging multi‑core CPUs in a .NET application.
 * 2. When you want to generate a .tar.bz2 backup of configuration files on a server using C# and control the number of compression threads for faster execution.
 * 3. When an automated build process must create a compressed archive of source code directories for distribution, and you require parallel Bzip2 compression to reduce build time.
 * 4. When a data‑archiving service has to stream local files into a TAR stream before applying Bzip2 compression with eight threads to meet performance SLAs.
 * 5. When you are implementing a cross‑platform .NET utility that packages selected files into a TAR archive and compresses it with Bzip2, using Aspose.Zip to manage the archive and thread‑level compression settings.
 */
