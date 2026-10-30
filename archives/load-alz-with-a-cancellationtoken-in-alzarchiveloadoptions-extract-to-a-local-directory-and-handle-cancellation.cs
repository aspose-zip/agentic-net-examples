// HOW-TO: Extract ZIP Archive to Folder in C# with Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.zip";
            string outputDirectory = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (FileStream zipFile = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipFile))
            {
                archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to programmatically unpack a downloaded ZIP file to a specific directory in a .NET application.
 * 2. When you want to integrate Aspose.Zip into a C# service that processes user‑uploaded archives and stores their contents locally.
 * 3. When an automated build script must extract packaged resources from a ZIP before compiling or deploying the project.
 * 4. When a desktop utility has to read a ZIP archive from disk and extract all files while handling missing‑file errors gracefully.
 * 5. When a background job extracts log files from a compressed archive to a folder for further analysis in a C# environment.
 */
