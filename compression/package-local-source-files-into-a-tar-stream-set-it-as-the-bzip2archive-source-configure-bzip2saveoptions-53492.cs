// HOW-TO: Create a Bzip2 Compressed TAR Archive with Single Thread in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Tar;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputFile1 = "data/file1.txt";
            string inputFile2 = "data/file2.txt";

            // Verify input files exist
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

            // Hardcoded output path
            string outputPath = "output/parallel.tar.bz2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add files
            using (TarArchive tar = new TarArchive())
            {
                tar.CreateEntry("file1.txt", inputFile1);
                tar.CreateEntry("file2.txt", inputFile2);

                // Create BZIP2 archive, set TAR as source, configure options, and save
                using (Bzip2Archive bz2 = new Bzip2Archive())
                {
                    bz2.SetSource(tar);

                    Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                    saveOptions.CompressionThreads = 1;

                    bz2.Save(outputPath, saveOptions);
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
 * 1. When you need to bundle multiple local files into a .tar.bz2 package for distribution while controlling threading to reduce CPU usage.
 * 2. When deploying configuration or log files to a Linux server and want a single‑threaded BZIP2 archive to meet resource limits.
 * 3. When creating backup archives of small datasets on a Windows service that must run in a constrained environment.
 * 4. When generating compressed tarballs for a CI/CD pipeline that requires deterministic single‑threaded compression for reproducible builds.
 * 5. When integrating Aspose.Zip into an application that must produce BZIP2 archives compatible with Unix tools without using external command‑line utilities.
 */
