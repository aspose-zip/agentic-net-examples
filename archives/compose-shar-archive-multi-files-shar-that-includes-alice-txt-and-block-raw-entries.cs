// HOW-TO: Create SHAR Archive With Multiple Files Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "alice.txt";
            string inputPath2 = "block.raw";
            string outputPath = "multi_files.shar";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new archive and add entries
            using (Archive archive = new Archive())
            {
                // Add alice.txt
                using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
                {
                    ArchiveEntry entry1 = archive.CreateEntry("alice.txt", fs1);
                }

                // Add block.raw
                using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
                {
                    ArchiveEntry entry2 = archive.CreateEntry("block.raw", fs2);
                }

                // Save the archive with .shar extension
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                archive.Save(outputPath, saveOptions);
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
 * 1. When you need to bundle a text file and a binary data file into a single SHAR archive for distribution on Unix‑like systems using C#.
 * 2. When automating backup of configuration and raw data files into a portable shell archive without external tools.
 * 3. When creating a self‑extracting script package that includes both documentation and binary resources for deployment scripts.
 * 4. When integrating Aspose.Zip into a .NET application to generate SHAR archives for cross‑platform file sharing.
 * 5. When simplifying the delivery of multiple files in a single archive for command‑line extraction in Linux environments.
 */
