// HOW-TO: Extract All Files From a CAB Archive To a Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.cab";
            string outputDirectory = "CabEntriesExtract";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream fs = File.OpenRead(inputPath))
            using (CabArchive archive = new CabArchive(fs))
            {
                archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to unpack driver packages delivered as CAB files to inspect or modify their contents using C#.
 * 2. When a deployment script must programmatically extract installation resources from a CAB archive to a temporary directory before running setup.
 * 3. When a Windows application has to read embedded CAB resources and write them to disk for later processing.
 * 4. When automating backup restoration that stores files in CAB format and you need to extract them to a specific folder with .NET.
 * 5. When testing or validating the contents of a CAB file by extracting all entries to a known location during unit tests.
 */
