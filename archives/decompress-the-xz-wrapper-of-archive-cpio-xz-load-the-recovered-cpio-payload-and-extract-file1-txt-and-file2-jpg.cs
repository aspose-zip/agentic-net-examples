// HOW-TO: Extract Specific Files From a .Cpio.Xz Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputXzPath = "archive.cpio.xz";
            string tempCpioPath = "temp.cpio";
            string outputDirectory = "output";

            if (!File.Exists(inputXzPath))
            {
                Console.Error.WriteLine($"File not found: {inputXzPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);
            string tempCpioDir = Path.GetDirectoryName(tempCpioPath);
            if (!string.IsNullOrEmpty(tempCpioDir))
            {
                Directory.CreateDirectory(tempCpioDir);
            }

            using (XzArchive xzArchive = new XzArchive(inputXzPath))
            {
                using (FileStream cpioStream = File.Create(tempCpioPath))
                {
                    xzArchive.Extract(cpioStream);
                }
            }

            using (CpioArchive cpioArchive = new CpioArchive(tempCpioPath))
            {
                foreach (CpioEntry entry in cpioArchive.Entries)
                {
                    string outputPath = Path.Combine(outputDirectory, entry.Name);
                    string entryDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrEmpty(entryDir))
                    {
                        Directory.CreateDirectory(entryDir);
                    }

                    using (FileStream outStream = File.Create(outputPath))
                    {
                        entry.Extract(outStream);
                    }
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
 * 1. When you receive a Linux distribution package compressed as a .cpio.xz file and need to programmatically extract only certain files in a .NET application.
 * 2. When automating deployment scripts that must unpack firmware updates delivered in XZ‑wrapped CPIO archives to retrieve configuration files.
 * 3. When building a backup restoration tool that reads compressed CPIO archives and restores selected documents such as text and image files.
 * 4. When processing data pipelines that ingest archived sensor logs stored as .cpio.xz and you need to extract specific log files for analysis.
 * 5. When creating a cross‑platform utility that decompresses XZ containers, reads the inner CPIO structure, and writes chosen entries to a local directory.
 */
