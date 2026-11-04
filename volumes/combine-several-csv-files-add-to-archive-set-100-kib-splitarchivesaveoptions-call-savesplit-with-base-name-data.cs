// HOW-TO: Combine Multiple CSV Files Into Split ZIP Archive Of 100KB Segments In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input CSV file paths
            string[] inputFiles = new string[]
            {
                "input1.csv",
                "input2.csv",
                "input3.csv"
            };

            // Verify each input file exists
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Combine CSV files into a single in‑memory stream
            using (MemoryStream combinedStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(combinedStream, Encoding.UTF8, 1024, true))
                {
                    foreach (string inputPath in inputFiles)
                    {
                        string[] lines = File.ReadAllLines(inputPath);
                        foreach (string line in lines)
                        {
                            writer.WriteLine(line);
                        }
                    }
                    writer.Flush();
                }

                // Reset stream position for reading by the archive
                combinedStream.Position = 0;

                // Create a new ZIP archive and add the combined CSV as an entry
                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("combined.csv", combinedStream);

                    // Configure split (multivolume) options: 100 KiB per segment
                    SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(100 * 1024); // volume size in bytes

                    // Hardcoded output base path (directory + base file name)
                    string outputDirectory = "output";
                    string basePath = Path.Combine(outputDirectory, "data");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(basePath));

                    // Save the archive as split segments
                    archive.SaveSplit(basePath, saveOptions);
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
 * 1. When you need to merge several CSV reports into a single file and distribute it as a multi‑volume ZIP that fits email attachment size limits.
 * 2. When you must archive large combined datasets but want each ZIP part limited to 100 KiB for storage on media with size constraints.
 * 3. When an application generates separate CSV logs throughout the day and you want to package them into a split archive for incremental backup.
 * 4. When you need to create a ZIP archive that can be uploaded in chunks to a web service that only accepts files under a specific size.
 * 5. When you want to combine CSV configuration files and split the resulting archive for easy download on slow or restricted network connections.
 */
