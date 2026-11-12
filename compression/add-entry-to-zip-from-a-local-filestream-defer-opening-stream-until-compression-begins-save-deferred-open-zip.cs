// HOW-TO: Add Local File to ZIP Archive Using FileStream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file and output archive paths
            string inputFilePath = @"C:\Data\sample.txt";
            string outputArchivePath = @"C:\Data\deferred_open.zip";

            // Verify the input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Open the source file stream and create a new ZIP archive
            using (FileStream sourceStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                // Add the entry to the archive using the opened stream
                archive.CreateEntry("sample.txt", sourceStream);

                // Save the archive to the specified output path
                archive.Save(outputArchivePath);
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
 * 1. When you need to programmatically bundle a text log file into a ZIP archive for backup or transfer without loading the entire file into memory.
 * 2. When an application must create a compressed package of configuration files on the fly, using a FileStream to read each file as it is added to the archive.
 * 3. When you want to generate a downloadable ZIP containing user‑generated reports, reading each report through a FileStream to keep the process memory‑efficient.
 * 4. When integrating Aspose.Zip into a server‑side service that archives uploaded documents, opening the source streams only when the archive is saved.
 * 5. When automating archival of daily data exports, using C# to add each export file via a FileStream and save the result as a deferred_open.zip file.
 */
