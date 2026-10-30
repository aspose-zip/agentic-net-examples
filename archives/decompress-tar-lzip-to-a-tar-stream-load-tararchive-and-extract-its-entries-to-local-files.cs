// HOW-TO: Extract Files From a .Tar.Lz Archive To Disk In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tar.lz";
            string outputDirectory = "ExtractedFiles";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Decompress the .tar.lz file into a TAR stream
            using (LzipArchive lzArchive = new LzipArchive())
            {
                lzArchive.SetSource(inputPath);
                using (MemoryStream tarStream = new MemoryStream())
                {
                    // Decompress to the memory stream
                    lzArchive.Save(tarStream);
                    tarStream.Position = 0; // Reset stream position for reading

                    // Load the TAR archive from the decompressed stream
                    using (TarArchive tarArchive = new TarArchive(tarStream))
                    {
                        // Iterate over each entry in the TAR archive
                        foreach (TarEntry entry in tarArchive.Entries)
                        {
                            string destinationPath = Path.Combine(outputDirectory, entry.Name);
                            // Ensure the directory for the entry exists
                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                            // Extract the entry to the destination file
                            using (Stream entryStream = entry.Open())
                            using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                            {
                                entryStream.CopyTo(fileStream);
                            }
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
 * 1. When you receive a .tar.lz backup from a Linux server and need to programmatically unpack its contents to a local folder using C#.
 * 2. When an automated build pipeline stores intermediate artifacts as LZIP‑compressed TAR files and you must extract them on a Windows build agent.
 * 3. When a desktop application allows users to import compressed data packages (.tar.lz) and you need to decompress and list the files for further processing.
 * 4. When you are migrating legacy archives that were compressed with LZIP and want to read them without writing temporary files to disk.
 * 5. When a cloud service delivers tar.lz payloads over HTTP and your .NET service must stream‑decompress and extract each entry to a storage directory.
 */
