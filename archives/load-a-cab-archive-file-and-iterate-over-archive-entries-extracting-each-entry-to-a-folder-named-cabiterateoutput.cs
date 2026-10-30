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
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "CabIterateOutput";
            Directory.CreateDirectory(outputDir);

            using (FileStream fs = File.OpenRead(inputPath))
            using (CabArchive archive = new CabArchive(fs))
            {
                archive.ExtractToDirectory(outputDir);
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
 * 1. When you need to unpack a Windows installer CAB file to inspect or modify its contents using C#.
 * 2. When a deployment script must extract driver packages stored in a CAB archive before installation.
 * 3. When a backup utility has to restore files from a compressed CAB backup archive on a .NET server.
 * 4. When a migration tool needs to read and copy resources from legacy CAB archives into a new directory structure.
 * 5. When an automated testing framework extracts test data bundled in a CAB file to a temporary folder for execution.
 */
