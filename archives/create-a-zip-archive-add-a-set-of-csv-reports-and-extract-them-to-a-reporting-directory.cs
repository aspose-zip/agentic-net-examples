// HOW-TO: Create ZIP Archive With Multiple CSV Reports In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input CSV file paths
            string csvPath1 = "C:\\Data\\Reports\\Report1.csv";
            string csvPath2 = "C:\\Data\\Reports\\Report2.csv";
            string csvPath3 = "C:\\Data\\Reports\\Report3.csv";

            // Verify each CSV file exists
            if (!File.Exists(csvPath1))
            {
                Console.Error.WriteLine($"File not found: {csvPath1}");
                return;
            }
            if (!File.Exists(csvPath2))
            {
                Console.Error.WriteLine($"File not found: {csvPath2}");
                return;
            }
            if (!File.Exists(csvPath3))
            {
                Console.Error.WriteLine($"File not found: {csvPath3}");
                return;
            }

            // Define ZIP archive output path
            string zipPath = "C:\\Data\\Reports\\ReportsArchive.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // Create ZIP archive and add CSV files
            using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
            using (FileStream source1 = File.Open(csvPath1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(csvPath2, FileMode.Open, FileAccess.Read))
            using (FileStream source3 = File.Open(csvPath3, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("Report1.csv", source1);
                archive.CreateEntry("Report2.csv", source2);
                archive.CreateEntry("Report3.csv", source3);

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                {
                    Encoding = Encoding.ASCII,
                    ArchiveComment = "CSV Reports Archive"
                };

                archive.Save(zipStream, saveOptions);
            }

            // Define extraction directory
            string extractDir = "C:\\Data\\Reports\\Extracted";

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Verify the created ZIP file exists before extraction
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Extract all entries to the reporting directory
            using (FileStream zipReadStream = File.Open(zipPath, FileMode.Open))
            using (Archive archive = new Archive(zipReadStream))
            {
                archive.ExtractToDirectory(extractDir);
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
 * 1. When you need to bundle daily generated CSV reports into a single ZIP file for easy distribution or backup.
 * 2. When an automated reporting system must verify each CSV file exists before adding it to the archive to avoid missing data.
 * 3. When you want to compress several related CSV files into a ZIP archive to reduce storage space on a server.
 * 4. When a scheduled job creates a ZIP of financial CSV statements that will later be extracted to a reporting directory for analysis.
 * 5. When building a C# application that packages CSV logs into a ZIP file for secure transfer to a client’s system.
 */
