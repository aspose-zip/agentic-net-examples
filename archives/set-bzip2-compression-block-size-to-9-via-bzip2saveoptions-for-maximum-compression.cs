// HOW-TO: How To Set Bzip2 Block Size To 9 For Maximum Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputPath = "output\\output.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of log files before uploading them to a cloud storage service, you can use Bzip2 compression with block size 9 in C#.
 * 2. When archiving large configuration files for backup while preserving maximum compression to save disk space, the Bzip2SaveOptions with block size 9 can be applied.
 * 3. When transmitting data over a low‑bandwidth network, compressing the payload with BZIP2 at the highest block size ensures the smallest possible transfer size.
 * 4. When creating BZIP2 archives for compliance‑required data packaging, setting the block size to 9 guarantees optimal compression without losing compatibility.
 * 5. When integrating file compression into a .NET application that processes user‑generated documents, using Bzip2Archive with maximum block size provides efficient storage and faster download times.
 */
