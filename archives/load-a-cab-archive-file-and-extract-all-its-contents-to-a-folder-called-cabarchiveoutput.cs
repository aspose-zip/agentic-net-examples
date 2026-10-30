// HOW-TO: Extract All Files From a CAB Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CAB file path
            string inputPath = "Data/sample.cab";

            // Hardcoded output folder path
            string outputPath = "Data/CabArchiveOutput";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the CAB archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                // Load the archive from the stream
                using (CabArchive archive = new CabArchive(fs))
                {
                    // Extract all entries to the specified directory
                    archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack driver installation packages delivered as CAB files into a working directory for further processing.
 * 2. When a deployment script must programmatically extract resources from a CAB archive on a Windows server using C#.
 * 3. When you want to read the contents of a legacy CAB backup and copy them to a new location during a migration.
 * 4. When an application must automatically decompress bundled assets stored in a CAB file before runtime execution.
 * 5. When a CI/CD pipeline requires extracting files from a CAB archive to validate or test its contents in .NET.
 */
