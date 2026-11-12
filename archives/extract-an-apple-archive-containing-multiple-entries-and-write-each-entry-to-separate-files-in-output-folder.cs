// HOW-TO: Extract All Files From Apple Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input Apple Archive file and output directory
            string inputPath = @"C:\Input\archive.apple";
            string outputPath = @"C:\Output\Extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the Apple Archive and extract each entry
            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Build full path for the extracted file
                    string entryOutputPath = Path.Combine(outputPath, entry.Name);

                    // Ensure the directory for the entry exists
                    Directory.CreateDirectory(Path.GetDirectoryName(entryOutputPath));

                    // Extract the entry to the file system
                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = File.Create(entryOutputPath))
                    {
                        entryStream.CopyTo(fileStream);
                    }
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
 * 1. When you need to unpack an Apple Archive received from macOS and save its contents to a local directory using C#.
 * 2. When an automated build process must extract resources from a .apple package before further processing in a .NET application.
 * 3. When a desktop utility has to read multiple files from an Apple Archive and write each file to its original folder structure on Windows.
 * 4. When a server‑side service processes uploaded Apple Archive files and stores each entry as separate files for later analysis.
 * 5. When you want to programmatically verify the integrity of each entry in an Apple Archive by extracting them to a temporary folder in C#.
 */
