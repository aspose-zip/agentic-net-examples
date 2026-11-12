// HOW-TO: Extract Multi-Volume 7z Archive in C# After Verifying All Parts (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing the 7z volume files
            string inputDirectory = @"C:\SevenZipParts";
            // Hardcoded output directory for extracted contents
            string outputDirectory = @"C:\Extracted";

            // Ensure the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
                return;
            }

            // Collect all 7z volume files, order them to maintain correct sequence
            string[] partFiles = Directory.GetFiles(inputDirectory, "*.7z.*")
                                          .OrderBy(f => f)
                                          .ToArray();

            if (partFiles.Length == 0)
            {
                Console.Error.WriteLine($"No 7z volume files found in: {inputDirectory}");
                return;
            }

            // Verify each part file is readable
            foreach (string part in partFiles)
            {
                if (!File.Exists(part))
                {
                    Console.Error.WriteLine($"File not found: {part}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Open the multivolume 7z archive and extract its contents
            using (SevenZipArchive archive = new SevenZipArchive(partFiles))
            {
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
 * 1. When you receive a large compressed backup split into several .7z.* files and need to ensure every segment is present before extracting the full dataset in a .NET application.
 * 2. When an automated deployment script must validate the integrity of multi‑volume 7z packages before unpacking them to a target folder on a Windows server.
 * 3. When a file‑sharing service stores large files as split 7z archives and your C# utility has to load the parts in the correct order to reconstruct the original content.
 * 4. When a data migration tool processes archived logs that were divided into multiple 7z volumes and you must extract them safely to a local directory.
 * 5. When a backup restoration process must check each 7z segment for existence and readability before using Aspose.Zip to combine and extract the complete archive.
 */
