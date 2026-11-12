// HOW-TO: Create Split ZIP Archive of CSV and XML Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string csvPath = @"C:\Data\sample.csv";
            string xmlPath = @"C:\Data\sample.xml";

            // Verify input files exist
            if (!File.Exists(csvPath))
            {
                Console.Error.WriteLine($"File not found: {csvPath}");
                return;
            }
            if (!File.Exists(xmlPath))
            {
                Console.Error.WriteLine($"File not found: {xmlPath}");
                return;
            }

            // Hardcoded output directory for split archive segments
            string outputDirectory = @"C:\Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add CSV file to the archive
                archive.CreateEntry("sample.csv", new FileInfo(csvPath));

                // Add XML file to the archive
                archive.CreateEntry("sample.xml", new FileInfo(xmlPath));

                // Configure split (multivolume) options: 90 KiB per segment
                SplitArchiveSaveOptions splitOptions = new SplitArchiveSaveOptions(90 * 1024);

                // Save the archive as split segments
                archive.SaveSplit(outputDirectory, splitOptions);
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
 * 1. When you need to package CSV and XML data files into a ZIP that is automatically divided into 90 KB segments for transfer over size‑restricted networks.
 * 2. When you must create multivolume ZIP archives to fit onto removable media or storage devices with strict file‑size limits.
 * 3. When an application requires split ZIP files to enable resumable uploads or downloads of large datasets.
 * 4. When you want to archive configuration and export files while ensuring each ZIP part stays under email attachment size restrictions.
 * 5. When a backup solution needs to generate split ZIP segments to comply with storage quotas or archival policies.
 */
