// HOW-TO: Bulk Convert ZIP Files to TAR.GZ Preserving Directory Entries in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing ZIP files
            string inputDirectory = @"C:\InputZips";
            // Hardcoded output directory for TAR.GZ files
            string outputDirectory = @"C:\OutputTars";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all ZIP files in the input directory
            string[] zipFiles = Directory.GetFiles(inputDirectory, "*.zip", SearchOption.TopDirectoryOnly);

            foreach (string zipPath in zipFiles)
            {
                // Verify each ZIP file exists
                if (!File.Exists(zipPath))
                {
                    Console.Error.WriteLine($"File not found: {zipPath}");
                    continue;
                }

                // Determine output TAR.GZ path
                string tarGzPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(zipPath) + ".tar.gz");
                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(tarGzPath));

                // List to keep entry streams open until the TAR is saved
                List<Stream> openEntryStreams = new List<Stream>();

                using (Archive zipArchive = new Archive(zipPath))
                using (TarArchive tarArchive = new TarArchive())
                {
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Preserve the entry name (including directory structure)
                        string entryName = zipEntry.Name;

                        // Ensure directory entries end with a trailing slash
                        if (zipEntry.IsDirectory && !entryName.EndsWith("/"))
                        {
                            entryName += "/";
                        }

                        if (zipEntry.IsDirectory)
                        {
                            // Create an empty directory entry in the TAR archive
                            tarArchive.CreateEntry(entryName, (string)null);
                        }
                        else
                        {
                            // Open the ZIP entry stream and add it to the TAR archive
                            Stream entryStream = zipEntry.Open();
                            tarArchive.CreateEntry(entryName, entryStream);
                            openEntryStreams.Add(entryStream);
                        }
                    }

                    // Save the TAR archive with GZIP compression
                    tarArchive.SaveGzipped(tarGzPath);
                }

                // Dispose all entry streams after the TAR has been saved
                foreach (Stream s in openEntryStreams)
                {
                    s.Dispose();
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
 * 1. When you need to migrate a collection of ZIP archives to TAR.GZ format for Linux‑based deployment pipelines while keeping empty folder structures intact.
 * 2. When an automated backup system must repackage daily ZIP snapshots into compressed TAR.GZ files to reduce storage costs on a Unix server.
 * 3. When a data‑processing application receives ZIP uploads and must forward them as TAR.GZ archives to a third‑party service that only accepts that format.
 * 4. When you are consolidating multiple ZIP packages into a single archive format for archival compliance and need to ensure directory entries end with a trailing slash.
 * 5. When a CI/CD workflow requires converting generated ZIP artifacts to TAR.GZ with preserved directory hierarchy before publishing to a package repository.
 */
