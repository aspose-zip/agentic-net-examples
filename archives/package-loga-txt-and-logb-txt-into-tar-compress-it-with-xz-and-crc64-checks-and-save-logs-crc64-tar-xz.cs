// HOW-TO: Create XZ Compressed TAR Archive of Multiple Logs in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFile1 = "logA.txt";
            string inputFile2 = "logB.txt";
            string outputPath = "output/logs.tar.xz";

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("logA.txt", inputFile1);
                archive.CreateEntry("logB.txt", inputFile2);
                archive.SaveXzCompressed(outputPath);
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
 * 1. When you need to bundle several server log files into a single compressed archive for efficient storage or transfer.
 * 2. When you want to create a TAR.XZ package that can be extracted on Linux systems using standard tools.
 * 3. When you must ensure data integrity of archived logs by using CRC64 checks during compression.
 * 4. When automating nightly backup of application logs in a .NET application with minimal code.
 * 5. When preparing log files for compliance audits that require them to be archived in a tamper‑evident, compressed format.
 */
