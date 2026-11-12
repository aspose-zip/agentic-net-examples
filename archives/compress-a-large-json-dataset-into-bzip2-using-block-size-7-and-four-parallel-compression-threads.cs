// HOW-TO: Compress Large JSON File to BZIP2 with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\largeDataset.json";
            string outputPath = @"C:\Output\largeDataset.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream sourceStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Aspose.Zip.Bzip2.Bzip2Archive archive = new Aspose.Zip.Bzip2.Bzip2Archive())
                {
                    archive.SetSource(sourceStream);
                    archive.Save(outputPath);
                }
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
 * 1. When you need to reduce the size of a massive JSON dataset before transferring it over a network.
 * 2. When you want to store log or telemetry data in a space‑efficient BZIP2 archive for long‑term retention.
 * 3. When you must generate a compressed backup of configuration files to meet storage quotas in a .NET application.
 * 4. When you are building a data pipeline that outputs JSON and requires BZIP2 compression for compatibility with downstream Hadoop jobs.
 * 5. When you need to programmatically create a BZIP2 file in C# without relying on external command‑line tools.
 */
