// HOW-TO: Extract All Files From XAR Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input XAR file path
            string inputPath = "C:\\Data\\sample.xar";
            // Hardcoded output directory path
            string outputPath = "C:\\Data\\Extracted";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory (and its parent) exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Open the XAR archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                // Initialize XarArchive with the file stream
                using (XarArchive archive = new XarArchive(fs))
                {
                    // Extract all entries to the target folder
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
 * 1. When you need to unpack a macOS XAR package on a Windows server using C#.
 * 2. When automating deployment scripts that must extract bundled resources from a XAR file before installation.
 * 3. When processing backup archives stored as XAR files and moving their contents to a local directory for analysis.
 * 4. When building a data ingestion pipeline that reads XAR-compressed logs and extracts them for further processing.
 * 5. When creating a desktop utility that lets users select a XAR file and extract all its entries to a chosen folder.
 */
