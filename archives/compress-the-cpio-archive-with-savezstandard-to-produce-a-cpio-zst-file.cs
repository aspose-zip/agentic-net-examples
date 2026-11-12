// HOW-TO: Compress a CPIO Archive with Zstandard in C# using Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\Input";
            string outputFilePath = @"C:\Data\Output\archive.cpio.zst";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            using (CpioArchive archive = new CpioArchive())
            {
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                archive.SaveZstandard(outputFilePath);
            }

            Console.WriteLine($"CPIO archive compressed with Zstandard saved to: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a set of Linux configuration files into a CPIO archive and reduce its size with Zstandard for fast network transfer in a C# deployment tool.
 * 2. When creating a backup of application logs on Windows and want to store them as a compressed .cpio.zst file using Aspose.Zip for efficient storage.
 * 3. When building a cross‑platform installer that bundles resources into a CPIO archive and compresses it with Zstandard to meet size constraints in a .NET build pipeline.
 * 4. When automating the archival of temporary data directories and require a single command in C# to generate a Zstandard‑compressed CPIO file for long‑term retention.
 * 5. When integrating with a Linux container workflow that expects a .cpio.zst payload, and you need to generate that archive directly from a C# service using Aspose.Zip.
 */
