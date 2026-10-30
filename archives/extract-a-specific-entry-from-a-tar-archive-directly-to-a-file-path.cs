// HOW-TO: Extract a Single File from a TAR Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.tar";
        string entryName = "folder/file.txt";
        string outputPath = "output/file.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDirectory);

            using (FileStream fs = File.OpenRead(inputPath))
            using (TarArchive archive = new TarArchive(fs))
            {
                TarEntry entry = archive.Entries.FirstOrDefault(e => e.Name == entryName);
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                entry.Extract(outputPath);
            }

            Console.WriteLine("Extraction completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to retrieve a configuration file stored inside a large .tar package without extracting the entire archive.
 * 2. When a deployment script must pull a specific log file from a backup TAR archive to analyze recent errors.
 * 3. When a web application allows users to download an individual document from a TAR bundle uploaded to the server.
 * 4. When an automated data pipeline extracts a single CSV file from a TAR archive to feed into a database import process.
 * 5. When a CI/CD process extracts a particular script from a TAR archive to run tests on a build machine.
 */
