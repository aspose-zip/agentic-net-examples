// HOW-TO: Convert Zip Archive To Tar.Gz On The Fly In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP and output TAR.GZ paths
            string inputZipPath = "input.zip";
            string outputTarGzPath = "output.tar.gz";

            // Validate input file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputTarGzPath);
            Directory.CreateDirectory(outputDir);

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new TAR archive
                using (TarArchive tarArchive = new TarArchive())
                {
                    // Iterate through each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directories; TAR entries for directories are optional
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Read the ZIP entry into a memory stream
                        using (MemoryStream entryData = new MemoryStream())
                        {
                            using (Stream zipStream = zipEntry.Open())
                            {
                                zipStream.CopyTo(entryData);
                            }
                            entryData.Position = 0;

                            // Add the entry to the TAR archive
                            tarArchive.CreateEntry(zipEntry.Name, entryData);
                        }
                    }

                    // Save the TAR archive compressed as GZIP
                    tarArchive.SaveGzipped(outputTarGzPath);
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
 * 1. When you need to package files from an existing ZIP into a TAR.GZ for Linux deployment pipelines using C#.
 * 2. When you want to stream a ZIP archive’s contents into a compressed TAR.Gz without extracting to disk in a .NET application.
 * 3. When you must convert legacy ZIP backups into TAR.Gz format to meet storage policies that require gzip compression.
 * 4. When you are building a cross‑platform installer that requires TAR.Gz archives and you have source files already zipped.
 * 5. When you need to automate the migration of user‑uploaded ZIP files to TAR.Gz for archival in a cloud storage system.
 */
