// HOW-TO: Split a Large ZIP Archive into 40 MB Volumes Using C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP file path
            string inputPath = "large.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for split volumes
            string outputDir = "split_output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Configure split options: 40 MB per volume
            SplitArchiveSaveOptions splitOptions = new SplitArchiveSaveOptions(40 * 1024 * 1024);

            // Open existing archive and split it into sequential volumes
            using (Archive archive = new Archive(inputPath))
            {
                archive.SaveSplit(outputDir, splitOptions);
            }

            Console.WriteLine("Archive split completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to break a multi‑gigabyte backup ZIP into 40 MB parts so each file fits on a standard USB flash drive.
 * 2. When an email system limits attachments to 40 MB, you can split the archive into sequential volumes before sending.
 * 3. When distributing a large software package over a network with size‑restricted chunks, you can create 40 MB ZIP segments for reliable transfer.
 * 4. When archiving logs that exceed storage quotas, splitting the ZIP into 40 MB volumes helps manage space and simplifies incremental uploads.
 * 5. When integrating with legacy systems that only accept small archive files, you can programmatically split a large ZIP into 40 MB pieces using Aspose.Zip in C#.
 */
