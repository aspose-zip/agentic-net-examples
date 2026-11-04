// HOW-TO: Create Split ZIP Archive of Multiple Files with 250KB Parts in C# (Aspose.ZIP for .NET)
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
            string inputFile1 = @"C:\Data\backup1.txt";
            string inputFile2 = @"C:\Data\backup2.txt";

            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            string outputDir = @"C:\Output";

            Directory.CreateDirectory(outputDir);

            using (Archive archive = new Archive())
            {
                archive.CreateEntry("backup1.txt", new FileInfo(inputFile1));
                archive.CreateEntry("backup2.txt", new FileInfo(inputFile2));

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("backup", 250 * 1024);

                archive.SaveSplit(outputDir, saveOptions);
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
 * 1. When you need to back up several log files and store them as a single ZIP that is automatically divided into 250 KB segments for easy transfer on limited‑size media.
 * 2. When you must create a portable archive of multiple documents that can be uploaded in small chunks to a cloud service that imposes a maximum file size per request.
 * 3. When you want to generate a split ZIP for distribution on USB drives that only support files up to a specific size, ensuring each part fits the drive’s capacity.
 * 4. When an application has to package large configuration files into a compressed archive while keeping each piece under a defined size to simplify incremental download or resume functionality.
 * 5. When you are implementing a custom backup routine that combines several files into a single archive and uses Aspose.Zip’s SplitArchiveSaveOptions to produce sequentially named parts for later reconstruction.
 */
