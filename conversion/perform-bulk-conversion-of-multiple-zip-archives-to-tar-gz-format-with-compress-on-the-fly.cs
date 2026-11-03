// HOW-TO: Convert Multiple ZIP Files To TAR.GZ In C# With Aspose (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing ZIP files
            string inputDirectory = @"C:\InputZips";
            // Hardcoded output directory for TAR.GZ files
            string outputDirectory = @"C:\OutputTars";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all ZIP files in the input directory
            string[] zipFiles = Directory.GetFiles(inputDirectory, "*.zip");

            foreach (string zipPath in zipFiles)
            {
                // Verify the ZIP file exists
                if (!File.Exists(zipPath))
                {
                    Console.Error.WriteLine($"File not found: {zipPath}");
                    continue;
                }

                // Determine the output TAR.GZ file path
                string tarGzPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(zipPath) + ".tar.gz");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(tarGzPath));

                // Open the source ZIP archive
                using (Archive zipArchive = new Archive(zipPath))
                {
                    // Create a new TAR archive
                    using (TarArchive tarArchive = new TarArchive())
                    {
                        // Iterate over each entry in the ZIP archive
                        foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                        {
                            // Skip directories
                            if (zipEntry.IsDirectory)
                                continue;

                            // Open the ZIP entry as a stream
                            using (Stream entryStream = zipEntry.Open())
                            {
                                // Add the entry to the TAR archive with the same name
                                tarArchive.CreateEntry(zipEntry.Name, entryStream);
                            }
                        }

                        // Save the TAR archive compressed as GZIP
                        tarArchive.SaveGzipped(tarGzPath);
                    }
                }

                Console.WriteLine($"Converted '{zipPath}' to '{tarGzPath}'.");
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
 * 1. When you need to batch‑convert a folder of legacy ZIP backups into compressed TAR.GZ archives for Linux‑based storage pipelines using C#.
 * 2. When a deployment script must shrink multiple ZIP packages into TAR.GZ files on the fly to reduce bandwidth before uploading to a cloud server.
 * 3. When an application processes user‑uploaded ZIP archives and must store them as TAR.GZ to comply with a standardized archival format in a .NET environment.
 * 4. When migrating data from Windows‑centric ZIP archives to a Unix‑friendly TAR.GZ format while preserving file contents without extracting to disk.
 * 5. When automating nightly jobs that archive log files packaged as ZIP into TAR.GZ archives for long‑term retention with Aspose.Zip in C#.
 */
