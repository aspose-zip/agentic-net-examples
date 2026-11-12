// HOW-TO: Extract Specific File From TAR.XZ Archive To Disk In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Tar;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tar.xz";
            string outputPath = "output/selectedFile.bin";
            string entryName = "file.txt"; // Name of the entry to extract

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Decompress the .tar.xz into a TAR stream
            using (MemoryStream tarStream = new MemoryStream())
            {
                using (XzArchive xzArchive = new XzArchive())
                {
                    xzArchive.SetSource(inputPath);
                    xzArchive.Save(tarStream);
                }

                // Reset stream position for reading
                tarStream.Position = 0;

                // Load the TAR archive from the decompressed stream
                using (TarArchive tarArchive = new TarArchive(tarStream))
                {
                    // Locate the desired entry
                    TarEntry entry = tarArchive.Entries.FirstOrDefault(e => e.Name == entryName);
                    if (entry == null)
                    {
                        Console.Error.WriteLine($"Entry not found: {entryName}");
                        return;
                    }

                    // Extract the entry into a memory buffer
                    using (MemoryStream entryBuffer = new MemoryStream())
                    {
                        entry.Extract(entryBuffer);
                        entryBuffer.Position = 0;

                        // Persist the extracted entry to a file
                        using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                        {
                            entryBuffer.CopyTo(outputFile);
                        }
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
 * 1. When you need to retrieve a single configuration file from a compressed TAR.XZ package delivered over a network.
 * 2. When you want to extract a log file from a backup archive without decompressing the entire archive to disk.
 * 3. When a deployment script must pull a specific binary from a .tar.xz distribution and save it locally for further processing.
 * 4. When an application processes large data sets stored in TAR.XZ archives and only needs to load a particular dataset into memory.
 * 5. When you are building a tool that validates the contents of a TAR.XZ archive by extracting and inspecting a chosen entry.
 */
