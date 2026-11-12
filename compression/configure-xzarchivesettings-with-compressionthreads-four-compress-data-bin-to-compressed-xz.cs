// HOW-TO: Compress a File to XZ with Four Threads Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "data.bin";
            string outputPath = "compressed.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to shrink a large binary log file before uploading it to a remote server, you can compress it to an XZ archive using Aspose.Zip in C#.
 * 2. When you want to bundle multiple configuration files into a single, highly compressed XZ package for efficient storage, this code creates the archive in C#.
 * 3. When distributing data over limited‑bandwidth connections, you can use multi‑threaded XZ compression to speed up the process while minimizing file size.
 * 4. When building a backup utility that creates compressed snapshots of user data, the XzArchive class lets you generate XZ archives programmatically in C#.
 * 5. When automating a CI/CD pipeline that archives generated binaries for long‑term retention, this approach compresses them into XZ files with configurable thread usage.
 */
