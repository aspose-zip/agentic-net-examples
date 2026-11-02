// HOW-TO: Create ZIP with Automatic Parallel Compression and Memory Limit in C# (Aspose.ZIP for .NET)
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
            // Hardcoded output ZIP path
            string outputPath = "C:\\Output\\combined.zip";

            // Hardcoded input JSON file paths
            string[] inputPaths = new string[]
            {
                "C:\\Input\\file1.json",
                "C:\\Input\\file2.json",
                "C:\\Input\\file3.json",
                "C:\\Input\\file4.json",
                "C:\\Input\\file5.json",
                "C:\\Input\\file6.json"
            };

            // Verify each input file exists
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the output ZIP stream and all source file streams
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            using (FileStream source1 = File.Open(inputPaths[0], FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputPaths[1], FileMode.Open, FileAccess.Read))
            using (FileStream source3 = File.Open(inputPaths[2], FileMode.Open, FileAccess.Read))
            using (FileStream source4 = File.Open(inputPaths[3], FileMode.Open, FileAccess.Read))
            using (FileStream source5 = File.Open(inputPaths[4], FileMode.Open, FileAccess.Read))
            using (FileStream source6 = File.Open(inputPaths[5], FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                // Add each JSON file as an entry in the archive
                archive.CreateEntry("file1.json", source1);
                archive.CreateEntry("file2.json", source2);
                archive.CreateEntry("file3.json", source3);
                archive.CreateEntry("file4.json", source4);
                archive.CreateEntry("file5.json", source5);
                archive.CreateEntry("file6.json", source6);

                // Configure parallel compression options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.ParallelOptions = new Aspose.Zip.Saving.ParallelOptions();
                saveOptions.ParallelOptions.AvailableMemorySize = (int)(300L * 1024L * 1024L); // 300 MB

                // Save the archive with the specified options
                archive.Save(zipStream, saveOptions);
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
 * 1. When you need to bundle multiple JSON configuration files into a single ZIP archive while maximizing compression speed using Aspose.Zip’s automatic parallel mode.
 * 2. When processing large JSON datasets on a server with limited RAM, you can set AvailableMemorySize to 300 MB to prevent out‑of‑memory errors during ZIP creation.
 * 3. When automating deployment packages, this code creates a combined.zip that can be transferred or stored efficiently with C#.
 * 4. When integrating data export features in a .NET application, you can compress several JSON reports into one archive without manually handling each file stream.
 * 5. When building a backup utility that must compress several JSON logs quickly, using ParallelCompressionMode.Auto ensures optimal CPU utilization.
 */
