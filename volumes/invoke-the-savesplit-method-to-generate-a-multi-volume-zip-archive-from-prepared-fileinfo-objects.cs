// HOW-TO: Create Multi-Volume ZIP Archive with Split Save in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputDir = "InputData";
            string outputDir = "OutputData";

            // Input files
            string file1Path = Path.Combine(inputDir, "file1.txt");
            string file2Path = Path.Combine(inputDir, "file2.txt");

            // Validate input files
            if (!File.Exists(file1Path))
            {
                Console.Error.WriteLine($"File not found: {file1Path}");
                return;
            }
            if (!File.Exists(file2Path))
            {
                Console.Error.WriteLine($"File not found: {file2Path}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Create a new ZIP archive and add entries
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.txt", new FileInfo(file1Path));
                archive.CreateEntry("file2.txt", new FileInfo(file2Path));

                // Configure split (multivolume) save options
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(1024 * 1024); // 1 MB per volume

                // Save the archive as multiple volumes in the output directory
                archive.SaveSplit(outputDir, saveOptions);
            }

            Console.WriteLine("Multivolume ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package large files into smaller 1 MB parts to fit on removable media or meet email attachment size limits.
 * 2. When you want to create a split ZIP for incremental backup where each volume can be stored on separate storage devices.
 * 3. When distributing a software release that exceeds a single archive size and must be delivered as multiple downloadable chunks.
 * 4. When archiving log files that grow beyond a threshold and you need each ZIP segment to be easily manageable and extractable.
 * 5. When implementing a custom upload process that sends ZIP volumes sequentially to a server with size‑restricted API calls.
 */
