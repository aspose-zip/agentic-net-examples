// HOW-TO: Create Tar.Xz Archive With CRC32 From Multiple Log Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "log1.txt";
            string inputPath2 = "log2.txt";
            string outputPath = "output/logs_crc32.tar.xz";

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

            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("log1.txt", inputPath1);
                archive.CreateEntry("log2.txt", inputPath2);
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
 * 1. When you need to bundle several log files into a single TAR archive, compress it with XZ for reduced size, and add CRC32 checks to ensure data integrity in a C# application.
 * 2. When automating nightly backups of server logs, you can create a .tar.xz package that can be easily transferred and later verified for corruption.
 * 3. When preparing log files for archival storage or compliance audits, using Aspose.Zip to generate a compressed TAR with CRC32 helps meet retention policies while keeping files searchable.
 * 4. When sending diagnostic logs to support teams, compressing them into a TAR.XZ archive reduces bandwidth usage and provides a checksum to confirm the files arrived unchanged.
 * 5. When integrating log management into a .NET service, this code lets you programmatically create a portable, integrity‑checked archive without relying on external command‑line tools.
 */
