// HOW-TO: Extract All Files From TAR.GZ Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input TAR.GZ file and output directory
            string inputPath = "sample.tar.gz";
            string outputDir = "extracted_gz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the GZIP archive
            using (FileStream gzStream = File.OpenRead(inputPath))
            {
                GzipArchive gzip = new GzipArchive();
                gzip.SetSource(gzStream);

                // Decompress GZIP to obtain the TAR stream
                using (MemoryStream tarStream = new MemoryStream())
                {
                    gzip.Extract(tarStream);
                    tarStream.Position = 0;

                    // Load the TAR archive from the decompressed stream
                    using (TarArchive tar = new TarArchive(tarStream))
                    {
                        // Extract each entry to the output directory
                        foreach (TarEntry entry in tar.Entries)
                        {
                            entry.Extract(outputDir);
                        }
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
 * 1. When you receive a .tar.gz backup from a Linux server and need to unpack its contents into a local directory using C#.
 * 2. When an automated deployment pipeline must decompress a GZIP‑compressed TAR package before processing the files in a .NET application.
 * 3. When a desktop utility has to read a compressed archive uploaded by a user and extract all its entries to a specified folder without external tools.
 * 4. When you need to programmatically migrate data stored in TAR.GZ archives to a Windows file system as part of a data‑import routine.
 * 5. When a cloud service processes incoming .tar.gz logs and extracts them to a temporary directory for further analysis in C#.
 */
