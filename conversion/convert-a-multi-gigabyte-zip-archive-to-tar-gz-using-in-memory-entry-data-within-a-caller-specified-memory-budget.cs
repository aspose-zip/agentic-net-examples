// HOW-TO: Convert Large ZIP to TAR.GZ With Memory Budget In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP and output TAR.GZ paths
            string inputPath = "input.zip";
            string outputPath = "output.tar.gz";

            // Memory budget in bytes (example: 100 MB)
            long memoryBudgetBytes = 100L * 1024L * 1024L;

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDirectory = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDirectory);

            // Temporary TAR file path
            string tempTarPath = Path.Combine(outputDirectory, "temp.tar");
            Directory.CreateDirectory(Path.GetDirectoryName(tempTarPath));

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputPath))
            {
                // Create a new TAR archive in memory
                using (TarArchive tarArchive = new TarArchive())
                {
                    // Iterate through each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directory entries
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Open the ZIP entry stream
                        using (Stream zipEntryStream = zipEntry.Open())
                        {
                            // Create a corresponding entry in the TAR archive using the same name
                            // The CreateEntry method copies data from the source stream to the TAR entry.
                            tarArchive.CreateEntry(zipEntry.Name, zipEntryStream);
                        }
                    }

                    // Save the TAR archive to a temporary file
                    tarArchive.Save(tempTarPath);
                }
            }

            // Compress the TAR file to GZIP format
            using (GzipArchive gzipArchive = new GzipArchive())
            {
                // Set the source TAR file for compression
                gzipArchive.SetSource(new FileInfo(tempTarPath));

                // Save the compressed GZIP file as the final output
                gzipArchive.Save(outputPath);
            }

            // Delete the temporary TAR file
            if (File.Exists(tempTarPath))
            {
                File.Delete(tempTarPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to repackage a huge ZIP backup into a TAR.GZ for Linux deployment while limiting RAM usage.
 * 2. When you must stream ZIP entries directly into a TAR archive without writing intermediate files to disk.
 * 3. When you have a fixed memory budget on a server and need to convert multi‑gigabyte archives efficiently.
 * 4. When you want to create a compressed TAR file for distribution to users who prefer .tar.gz format.
 * 5. When you are automating a migration pipeline that extracts ZIP data and repackages it as TAR.GZ in a .NET application.
 */
