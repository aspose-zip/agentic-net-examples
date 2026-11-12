// HOW-TO: Create and Overwrite ZIP Archive from Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "data/input1.txt";
            string inputPath2 = "data/input2.txt";
            string outputPath = "output/result.zip";

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the output ZIP file with OpenOrCreate and truncate any existing data
            using (FileStream zipFile = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                zipFile.SetLength(0); // Truncate stale bytes

                // Open source files
                using (FileStream source1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
                using (FileStream source2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
                using (Archive archive = new Archive())
                {
                    // Add files to the archive
                    archive.CreateEntry("input1.txt", source1);
                    archive.CreateEntry("input2.txt", source2);

                    // Save the archive to the output stream
                    archive.Save(zipFile, new ArchiveSaveOptions());
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
 * 1. When you need to generate a fresh ZIP file from multiple local text files and ensure any previous version of the archive is completely replaced.
 * 2. When an application must programmatically bundle log or report files into a compressed archive before uploading them to a server.
 * 3. When a scheduled job creates backup archives of configuration files and must truncate old data to avoid corrupted ZIP sizes.
 * 4. When a desktop utility combines user‑selected documents into a single ZIP package while handling the output file safely with OpenOrCreate.
 * 5. When a CI/CD pipeline needs to package build artifacts into a ZIP file and guarantee that leftover bytes from earlier builds are removed.
 */
