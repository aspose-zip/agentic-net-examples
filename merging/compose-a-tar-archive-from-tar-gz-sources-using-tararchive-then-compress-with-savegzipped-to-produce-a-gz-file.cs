// HOW-TO: Create a Gzipped TAR Archive from Multiple Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input files
            string inputFile1 = @"C:\Data\file1.txt";
            string inputFile2 = @"C:\Data\file2.txt";

            // Hardcoded output path
            string outputPath = @"C:\Output\archive.tar.gz";

            // Validate input files
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add entries
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("file1.txt", inputFile1);
                archive.CreateEntry("file2.txt", inputFile2);

                // Save the archive compressed as GZIP
                archive.SaveGzipped(outputPath);
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
 * 1. When you need to bundle several log files into a single compressed TAR.GZ package for efficient storage or transfer in a C# application.
 * 2. When deploying a .NET service that must create backup archives of configuration files on Windows servers using Aspose.Zip's TarArchive.
 * 3. When automating the creation of distribution packages that combine source code files into a gzipped TAR for cross‑platform compatibility.
 * 4. When implementing a scheduled job that archives daily reports into a .tar.gz file to reduce disk usage and simplify archival retrieval.
 * 5. When integrating with Linux‑based systems that expect input as a gzipped TAR, and you must generate that archive directly from C# code.
 */
