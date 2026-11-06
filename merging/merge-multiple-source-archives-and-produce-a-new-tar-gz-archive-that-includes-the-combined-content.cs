// HOW-TO: Merge Multiple ZIP Files into a Single TAR.GZ Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded source archive paths
            string sourcePath1 = @"C:\Data\source1.zip";
            string sourcePath2 = @"C:\Data\source2.zip";

            // Verify source files exist
            if (!File.Exists(sourcePath1))
            {
                Console.Error.WriteLine($"File not found: {sourcePath1}");
                return;
            }
            if (!File.Exists(sourcePath2))
            {
                Console.Error.WriteLine($"File not found: {sourcePath2}");
                return;
            }

            // Hardcoded output TAR.GZ path
            string outputPath = @"C:\Data\merged.tar.gz";

            // Create output directory unconditionally
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // List to keep entry streams alive until the archive is saved
            List<Stream> openEntryStreams = new List<Stream>();

            using (TarArchive tarArchive = new TarArchive())
            {
                // Process first source archive
                using (Archive srcArchive1 = new Archive(sourcePath1))
                {
                    foreach (ArchiveEntry srcEntry in srcArchive1.Entries)
                    {
                        Stream entryStream = srcEntry.Open();
                        openEntryStreams.Add(entryStream);
                        tarArchive.CreateEntry(srcEntry.Name, entryStream);
                    }
                }

                // Process second source archive
                using (Archive srcArchive2 = new Archive(sourcePath2))
                {
                    foreach (ArchiveEntry srcEntry in srcArchive2.Entries)
                    {
                        Stream entryStream = srcEntry.Open();
                        openEntryStreams.Add(entryStream);
                        tarArchive.CreateEntry(srcEntry.Name, entryStream);
                    }
                }

                // Save the combined archive as TAR.GZ
                tarArchive.SaveGzipped(outputPath);
            }

            // Dispose all entry streams after saving
            foreach (Stream s in openEntryStreams)
            {
                s.Dispose();
            }

            Console.WriteLine("Merged TAR.GZ archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine several ZIP backups into one compressed TAR.GZ package for easier distribution across Linux systems.
 * 2. When a deployment pipeline must gather assets from multiple source archives and create a single archive to upload to a cloud storage bucket.
 * 3. When you want to consolidate log files stored in separate ZIP files into a single TAR.GZ archive for long‑term archival and compliance.
 * 4. When a data migration tool has to merge user‑generated ZIP bundles into one compressed archive before sending it to an external partner.
 * 5. When an automated script must create a portable TAR.GZ bundle from multiple third‑party ZIP resources for use in container images.
 */
