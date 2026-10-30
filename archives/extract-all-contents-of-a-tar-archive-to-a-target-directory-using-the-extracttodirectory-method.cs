// HOW-TO: Extract All Files from a TAR Archive to a Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input TAR file and output directory
            string inputPath = "input.tar";
            string outputPath = "output\\extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the TAR archive and extract its contents
            using (TarArchive archive = new TarArchive(inputPath))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you receive a .tar backup from a Linux server and need to unpack it into a Windows folder using C#.
 * 2. When a deployment pipeline delivers application assets packaged as a TAR file and you must extract them to a target directory during a .NET build.
 * 3. When a user uploads a compressed TAR archive through a web API and you need to programmatically extract its contents on the server.
 * 4. When migrating data from legacy systems that export data as TAR archives and you want to automate the extraction process in a C# utility.
 * 5. When creating a desktop tool that reads configuration files stored inside a TAR package and extracts them to a specified folder for further processing.
 */
