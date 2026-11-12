// HOW-TO: Create Parallel Bzip2 Compressed TAR Archive from Multiple Files in C# (Aspose.ZIP for .NET)
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
            // Define input directory and files
            string inputDir = "Data";
            string[] fileNames = new string[] { "file1.txt", "file2.txt" };

            // Verify each input file exists
            foreach (string fileName in fileNames)
            {
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Define output path and ensure directory exists
            string outputPath = Path.Combine("Output", "parallel.tar.bz2");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add files
            using (TarArchive tarArchive = new TarArchive())
            {
                foreach (string fileName in fileNames)
                {
                    string sourcePath = Path.Combine(inputDir, fileName);
                    tarArchive.CreateEntry(fileName, sourcePath);
                }

                // Create Bzip2 archive, set TAR as source, configure parallel compression, and save
                using (Bzip2Archive bzip2Archive = new Bzip2Archive())
                {
                    bzip2Archive.SetSource(tarArchive);

                    Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                    saveOptions.CompressionThreads = Environment.ProcessorCount;

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
 * 1. When you need to bundle several log files into a single TAR archive and compress it with Bzip2 using all CPU cores for faster backup in a .NET application.
 * 2. When you want to generate a .tar.bz2 package for distribution of source code files, ensuring optimal compression speed by leveraging parallel threads in C#.
 * 3. When an automated build pipeline must create a compressed archive of deployment assets and requires multi‑threaded Bzip2 compression to reduce build time.
 * 4. When a desktop utility needs to archive user‑selected documents into a TAR stream and then compress it with Bzip2, using the machine’s processor count for efficient performance.
 * 5. When a server‑side service has to archive and compress large data files on the fly, and you want to use Aspose.Zip to handle TAR creation and parallel Bzip2 compression in C#.
 */
