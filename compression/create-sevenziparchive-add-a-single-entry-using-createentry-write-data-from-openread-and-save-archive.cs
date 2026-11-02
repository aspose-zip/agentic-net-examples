// HOW-TO: Create a 7z Archive with a Single File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file and output archive paths
            string inputFilePath = "input.txt";
            string outputArchivePath = "output.7z";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Create the 7z archive and add a single entry from the input file
            using (FileStream archiveStream = File.Open(outputArchivePath, FileMode.Create))
            {
                using (SevenZipArchive archive = new SevenZipArchive())
                {
                    // Add entry named "entry.txt" with data from inputFilePath
                    archive.CreateEntry("entry.txt", inputFilePath);
                    // Save the archive to the stream
                    archive.Save(archiveStream);
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
 * 1. When you need to compress a log file into a 7z archive using Aspose.Zip in a .NET application.
 * 2. When you want to programmatically create a 7z package for a configuration file before uploading it to cloud storage.
 * 3. When you are building a deployment tool that bundles a single resource into a 7z container for distribution.
 * 4. When you need to generate a compressed 7z archive on the fly to send as an email attachment from a C# service.
 * 5. When you are creating a simple archiving utility that stores a user‑selected document in a 7z file for later extraction.
 */
