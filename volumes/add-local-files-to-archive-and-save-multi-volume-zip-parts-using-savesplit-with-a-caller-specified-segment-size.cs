// HOW-TO: Create Multi‑Volume ZIP with Specified Segment Size in C# (Aspose.ZIP for .NET)
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
            string inputPath1 = @"C:\Data\file1.txt";
            string inputPath2 = @"C:\Data\file2.txt";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            string outputDirectory = @"C:\Output";
            string outputPath = Path.Combine(outputDirectory, "MultiVolumeArchive.zip");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.txt", new FileInfo(inputPath1));
                archive.CreateEntry("file2.txt", new FileInfo(inputPath2));

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(65536);

                archive.SaveSplit(outputPath, saveOptions);
            }

            Console.WriteLine("Multi‑volume ZIP created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up large log files but the destination media only accepts files up to 64 KB, you can split the ZIP into multiple parts using Aspose.Zip.
 * 2. When transferring a big dataset over a network that imposes a maximum packet size, creating a multi‑volume archive lets each segment fit within the limit.
 * 3. When archiving files for distribution on removable drives that have a file‑size restriction, you can generate split ZIP parts that each stay under the specified segment size.
 * 4. When implementing a custom download manager that streams archive chunks to clients, you can pre‑create split ZIP files so each chunk can be served independently.
 * 5. When integrating with legacy backup software that only reads fixed‑size archive volumes, you can produce compatible multi‑volume ZIP archives directly from C# code.
 */
