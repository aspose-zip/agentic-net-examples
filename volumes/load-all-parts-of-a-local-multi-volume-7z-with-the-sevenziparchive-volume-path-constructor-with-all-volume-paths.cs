// HOW-TO: Load and Extract Split 7z Files with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing the 7z volumes
            string volumeDirectory = "C:\\Input7z";
            // Hardcoded output directory for extracted files
            string outputDirectory = "C:\\Output7z";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));
            Directory.CreateDirectory(outputDirectory);

            // Retrieve all volume files and order them numerically
            string[] volumePaths = Directory.GetFiles(volumeDirectory, "*.7z.*")
                                            .OrderBy(path => path)
                                            .ToArray();

            // Verify each volume file exists before proceeding
            foreach (string path in volumePaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Load the multi-volume 7z archive using the volume-path constructor
            using (SevenZipArchive archive = new SevenZipArchive(volumePaths))
            {
                // Extract all entries to the output directory
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
 * 1. When you receive a large 7z archive that has been divided into numbered volume files and need to programmatically combine and extract its contents in a .NET application.
 * 2. When automating deployment scripts that must unpack multi‑volume backup archives stored on a server before installing software.
 * 3. When building a data‑ingestion pipeline that processes archived logs split across several 7z parts and extracts them to a processing folder.
 * 4. When creating a desktop utility that lets users select a folder of split 7z volumes and extracts all files to a chosen output directory without manual merging.
 * 5. When integrating Aspose.Zip into a C# service that validates the presence of each volume file before extraction to avoid runtime errors.
 */
