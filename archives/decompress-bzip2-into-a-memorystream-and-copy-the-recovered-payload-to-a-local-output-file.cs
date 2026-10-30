// HOW-TO: Decompress BZIP2 File to MemoryStream and Save to Disk in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.bz2";
        string outputPath = "decompressed.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        try
        {
            // Open the BZIP2 archive for decompression
            using (Bzip2Archive archive = new Bzip2Archive(inputPath))
            {
                // Decompress into a memory stream
                using (MemoryStream memory = new MemoryStream())
                {
                    archive.Extract(memory);
                    memory.Position = 0;

                    // Write the decompressed data to the output file
                    using (FileStream file = File.Create(outputPath))
                    {
                        memory.CopyTo(file);
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
 * 1. When you receive a .bz2 log archive from a remote server and need to extract its contents into a file without writing the intermediate data to disk.
 * 2. When a .NET application must process compressed configuration files stored as BZIP2 and write the uncompressed data to a local path for further processing.
 * 3. When you want to validate the integrity of a BZIP2 backup by decompressing it into memory and then persisting the result to a verification file.
 * 4. When an automated ETL pipeline downloads BZIP2 data feeds, decompresses them in memory for quick transformation, and finally saves the raw payload as a text file.
 * 5. When a desktop utility offers users the ability to open .bz2 documents, decompresses them using a MemoryStream, and writes the readable content to a user‑specified output location.
 */
