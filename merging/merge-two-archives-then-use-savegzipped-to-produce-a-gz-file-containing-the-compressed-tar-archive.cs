// HOW-TO: Merge Two TAR Archives and Create GZipped TAR in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = @"C:\Data\archive1.tar";
            string inputPath2 = @"C:\Data\archive2.tar";
            string outputPath = @"C:\Data\merged.tar.gz";

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive mergedArchive = new TarArchive())
            {
                mergedArchive.CreateEntry("archive1.tar", inputPath1);
                mergedArchive.CreateEntry("archive2.tar", inputPath2);
                mergedArchive.SaveGzipped(outputPath);
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
 * 1. When you need to combine multiple backup tar files into a single compressed archive for easier storage or transfer.
 * 2. When you want to package several tar archives into one .tar.gz file before uploading to a cloud service that only accepts gzipped files.
 * 3. When you are consolidating log archives from different servers into a single compressed tarball for centralized analysis.
 * 4. When you must create a gzipped tar archive that contains other tar files to meet a legacy system’s input format requirements.
 * 5. When you are automating a deployment pipeline that merges component tar packages and compresses them into a .tar.gz for distribution.
 */
