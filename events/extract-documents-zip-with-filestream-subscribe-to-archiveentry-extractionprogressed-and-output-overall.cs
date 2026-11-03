// HOW-TO: Extract ZIP With FileStream And Track Overall Progress To Text File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "documents.zip";
            string outputDir = "ExtractedDocs";
            string progressFile = "doc_extract_percent.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(progressFile) ?? ".");

            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(fileStream))
            {
                ulong totalUncompressed = 0;
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    totalUncompressed += entry.UncompressedSize;
                }

                ulong cumulativeProgress = 0;

                foreach (ArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractionProgressed += (sender, e) =>
                    {
                        double percent = ((double)(cumulativeProgress + e.ProceededBytes) / (double)totalUncompressed) * 100.0;
                        int intPercent = (int)percent;
                        File.WriteAllText(progressFile, intPercent.ToString());
                    };

                    string destinationPath = Path.Combine(outputDir, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath) ?? outputDir);
                    entry.Extract(destinationPath);
                    cumulativeProgress += entry.UncompressedSize;
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
 * 1. When you need to unzip a large archive in a .NET application while writing the extraction percentage to a log file for user feedback.
 * 2. When processing batch document packages and you want to extract each file to a specific folder and record overall progress for monitoring or reporting.
 * 3. When integrating a file‑upload service that receives ZIP files and you must extract them using a FileStream while updating a progress file for downstream automation.
 * 4. When building a desktop utility that extracts archives and provides real‑time progress to a status file that other components can read.
 * 5. When automating deployment scripts that unpack ZIP resources and need a persistent progress indicator for error handling or retry logic.
 */
