// HOW-TO: Extract Specific File From TAR Archive To Disk Using MemoryStream In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.tar";
            string entryName = "myfolder/data.txt";
            string outputPath = "output\\extracted_file.txt";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the TAR archive
            using (TarArchive archive = new TarArchive(inputPath))
            {
                // Locate the specific entry
                TarEntry entry = archive.Entries.FirstOrDefault(e => e.Name == entryName);
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract entry into a memory stream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    entry.Extract(memoryStream);
                    memoryStream.Position = 0;

                    // Write the memory stream to the output file
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.CopyTo(fileStream);
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
 * 1. When you need to retrieve a single text file from a large .tar backup without extracting the entire archive.
 * 2. When processing a TAR package in a web service and you must load the file into memory before saving it to a temporary location.
 * 3. When you want to validate the contents of a specific entry in a TAR archive before performing further processing.
 * 4. When automating deployment scripts that pull configuration files out of a TAR bundle and write them to the target server’s file system.
 * 5. When integrating legacy TAR archives into a .NET application that requires extracting individual resources on demand.
 */
