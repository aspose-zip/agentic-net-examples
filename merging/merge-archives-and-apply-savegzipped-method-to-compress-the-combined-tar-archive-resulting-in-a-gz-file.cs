// HOW-TO: Merge Two TAR Archives and Create GZ File in C# (Aspose.ZIP for .NET)
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
 * 1. When you need to combine multiple backup tar files into a single compressed .gz archive for easier storage or transfer.
 * 2. When deploying a .NET application that must bundle several tar packages into one gzipped archive before uploading to a remote server.
 * 3. When creating a distribution package that consolidates separate module tar archives into a single gzipped file to reduce download size.
 * 4. When automating log archiving by merging daily tar logs into one gzipped archive for long‑term retention.
 * 5. When implementing a data pipeline that gathers tar‑formatted datasets from different sources and compresses them into a single .tar.gz for downstream processing.
 */
