// HOW-TO: Extract All Files From ARJ Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.arj";
            string outputFolder = @"C:\Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (FileStream fs = File.OpenRead(inputPath))
            using (ArjArchive archive = new ArjArchive(fs))
            {
                archive.ExtractToDirectory(outputFolder);
                Console.WriteLine($"Archive extracted to '{outputFolder}'.");
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
 * 1. When you need to unpack legacy ARJ backup files on a Windows server using C#.
 * 2. When a desktop application must programmatically extract archived resources from an ARJ package to a user‑specified directory.
 * 3. When automating migration of old ARJ‑compressed data sets to a new file structure in a .NET batch process.
 * 4. When validating that an ARJ archive is accessible and its contents can be extracted before further processing in a C# service.
 * 5. When integrating third‑party software that supplies ARJ archives and you must extract them to a temporary folder for analysis.
 */
