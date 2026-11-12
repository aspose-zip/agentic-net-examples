// HOW-TO: Create ZIP Archive Without In-Memory Compression Using Aspose.Zip C# (Aspose.ZIP for .NET)
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
            string dataDir = "data\\";
            string sourceFile1 = dataDir + "file1.txt";
            string sourceFile2 = dataDir + "file2.txt";
            string outputPath = dataDir + "neverEntry.zip";

            if (!File.Exists(sourceFile1))
            {
                Console.Error.WriteLine($"File not found: {sourceFile1}");
                return;
            }
            if (!File.Exists(sourceFile2))
            {
                Console.Error.WriteLine($"File not found: {sourceFile2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.txt", sourceFile1);
                archive.CreateEntry("file2.txt", sourceFile2);

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.ParallelOptions = new Aspose.Zip.Saving.ParallelOptions();
                saveOptions.ParallelOptions.ParallelCompressInMemory = ParallelCompressionMode.Never;

                archive.Save(outputPath, saveOptions);
            }

            Console.WriteLine($"Archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a ZIP file on a server with limited RAM and want to avoid temporary in‑memory compression.
 * 2. When you must add multiple files to a ZIP archive sequentially without using parallel compression to ensure deterministic output.
 * 3. When you are packaging log files for archival and want to control memory usage during the save operation.
 * 4. When you are building a .NET application that creates ZIP backups on low‑end devices and need to disable in‑memory compression.
 * 5. When you want to use Aspose.Zip to create a ZIP archive while guaranteeing that compression is performed only on disk, not in RAM.
 */
