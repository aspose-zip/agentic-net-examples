// HOW-TO: Extract Password‑Protected Multi‑Volume 7z Archive to Directory in C# (Aspose.ZIP for .NET)
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
            string inputDirectory = @"C:\Input\Complex7z";
            // Hardcoded output directory for extraction
            string outputDirectory = @"C:\Output\Complex7zOutput";
            // Hardcoded password for the archive
            string password = "myPassword";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Get all volume files (e.g., .7z.001, .7z.002, ...)
            string[] volumeFiles = Directory.GetFiles(inputDirectory, "*.7z.*")
                                            .OrderBy(path => path) // alphabetical order matches numeric order for zero‑padded names
                                            .ToArray();

            // Verify that at least one volume file was found
            if (volumeFiles.Length == 0)
            {
                Console.Error.WriteLine($"No 7z volume files found in: {inputDirectory}");
                return;
            }

            // Verify each volume file exists (redundant but follows the rule)
            foreach (string volumePath in volumeFiles)
            {
                if (!File.Exists(volumePath))
                {
                    Console.Error.WriteLine($"File not found: {volumePath}");
                    return;
                }
            }

            // Open the multi‑volume 7z archive with the supplied password
            using (SevenZipArchive archive = new SevenZipArchive(volumeFiles, password))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDirectory);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack a split 7z backup that is secured with a password into a specific folder.
 * 2. When an application must process large encrypted archives that were divided into .7z.001, .7z.002 parts and place the extracted files in a known output path.
 * 3. When automating deployment you have to read all volume files from a directory, supply the archive password, and extract the contents for further processing.
 * 4. When a user downloads a multi‑volume encrypted archive and your C# tool must verify each part exists before extracting the complete data set.
 * 5. When integrating Aspose.Zip into a data‑migration workflow that requires ordered loading of 7z volumes and extraction to a target directory with a supplied password.
 */
