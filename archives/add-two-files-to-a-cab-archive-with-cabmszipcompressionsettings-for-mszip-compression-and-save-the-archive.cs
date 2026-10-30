// HOW-TO: Create CAB Archive with MSZip Compression and Add Multiple Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFilePath1 = "input1.txt";
            string inputFilePath2 = "input2.txt";
            string outputCabPath = "output.cab";

            // Validate input files
            if (!File.Exists(inputFilePath1))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath1}");
                return;
            }

            if (!File.Exists(inputFilePath2))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath2}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputCabPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Create CAB archive with MSZip compression settings
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add first file
                archive.CreateEntry("file1.txt", inputFilePath1);
                // Add second file
                archive.CreateEntry("file2.txt", inputFilePath2);
                // Save the archive
                archive.Save(outputCabPath);
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
 * 1. When you need to package several configuration files into a single CAB file for distribution with Windows installers using MSZip compression.
 * 2. When you want to reduce the size of log files before sending them to a remote server by creating a compressed CAB archive in a .NET application.
 * 3. When a deployment script requires bundling two resource files into a CAB archive that can be extracted by Windows Setup.
 * 4. When you are building a backup utility that stores selected documents in a CAB file with MSZip compression to preserve space.
 * 5. When you need to generate a CAB archive programmatically in C# to meet legacy software's expectation for MSZip‑compressed archives.
 */
