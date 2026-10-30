// HOW-TO: Extract a File from TAR.LZMA Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.LZMA;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tar.lzma";
            string outputPath = "extractedFile.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Decompress LZMA to obtain the TAR stream
            using (LzmaArchive lzmaArchive = new LzmaArchive())
            {
                lzmaArchive.SetSource(inputPath);
                using (MemoryStream tarStream = new MemoryStream())
                {
                    lzmaArchive.Save(tarStream);
                    tarStream.Position = 0; // Reset stream position for reading

                    // Load the TAR archive from the decompressed stream
                    using (TarArchive tarArchive = new TarArchive(tarStream))
                    {
                        // Select the first entry (or specify a name)
                        TarEntry entry = tarArchive.Entries.FirstOrDefault();
                        if (entry == null)
                        {
                            Console.Error.WriteLine("No entries found in the TAR archive.");
                            return;
                        }

                        // Extract the selected entry to the output file
                        entry.Extract(outputPath);
                    }
                }
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
 * 1. When you receive a .tar.lzma backup from a Linux server and need to programmatically extract a specific text file in a C# application.
 * 2. When an automated build pipeline must decompress LZMA‑compressed tar packages and pull configuration files for further processing.
 * 3. When a desktop utility has to read a compressed archive, list its entries, and save a chosen document to the user's local folder.
 * 4. When migrating data from legacy .tar.lzma archives to a modern .NET system without using external command‑line tools.
 * 5. When implementing a server‑side service that extracts logs stored in TAR.LZMA files to generate real‑time reports.
 */
