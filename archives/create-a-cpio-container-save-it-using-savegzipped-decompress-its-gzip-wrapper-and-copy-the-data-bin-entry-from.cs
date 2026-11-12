// HOW-TO: Create Gzipped CPIO Archive and Extract Specific File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Cpio;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define directories and file paths
            string inputDir = "Input";
            string outputDir = "Output";
            string sourceFile = Path.Combine(inputDir, "data.bin");
            string cpioGzPath = Path.Combine(outputDir, "archive.cpio.gz");
            string extractedCpioPath = Path.Combine(outputDir, "extracted.cpio");
            string extractedDataPath = Path.Combine(outputDir, "extracted_data.bin");

            // Ensure directories exist
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create a sample source file if it does not exist
            if (!File.Exists(sourceFile))
            {
                byte[] sampleData = new byte[] { 1, 2, 3, 4, 5 };
                File.WriteAllBytes(sourceFile, sampleData);
            }

            // Ensure output directory for the gzipped archive exists
            Directory.CreateDirectory(Path.GetDirectoryName(cpioGzPath));

            // Create CPIO archive, add the data.bin entry, and save as gzipped file
            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntry("data.bin", sourceFile);
                archive.SaveGzipped(cpioGzPath);
            }

            // Verify the gzipped archive exists before decompressing
            if (!File.Exists(cpioGzPath))
            {
                Console.Error.WriteLine($"File not found: {cpioGzPath}");
                return;
            }

            // Decompress the GZIP wrapper to obtain the raw CPIO file
            using (GzipArchive gzipArchive = new GzipArchive(cpioGzPath))
            {
                using (Stream decompressed = gzipArchive.Open())
                {
                    // Ensure output directory for the extracted CPIO file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(extractedCpioPath));
                    using (FileStream fs = new FileStream(extractedCpioPath, FileMode.Create, FileAccess.Write))
                    {
                        decompressed.CopyTo(fs);
                    }
                }
            }

            // Verify the extracted CPIO file exists before loading
            if (!File.Exists(extractedCpioPath))
            {
                Console.Error.WriteLine($"File not found: {extractedCpioPath}");
                return;
            }

            // Load the CPIO archive and extract the data.bin entry to a local file
            using (CpioArchive cpioArchive = new CpioArchive(extractedCpioPath))
            {
                CpioEntry entry = cpioArchive.Entries.FirstOrDefault(e => e.Name == "data.bin");
                if (entry != null)
                {
                    using (Stream entryStream = entry.Open())
                    {
                        // Ensure output directory for the extracted data file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(extractedDataPath));
                        using (FileStream outFile = new FileStream(extractedDataPath, FileMode.Create, FileAccess.Write))
                        {
                            entryStream.CopyTo(outFile);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("Entry data.bin not found in CPIO archive.");
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
 * 1. When you need to package a binary payload into a CPIO archive, compress it with GZIP for transport, and later retrieve a single file without extracting the whole archive in a .NET application.
 * 2. When deploying firmware updates that are distributed as gzipped CPIO files, you can use this code to decompress the GZIP layer and pull out the required binary component on the target machine.
 * 3. When backing up configuration files into a compact, portable format, you can create a gzipped CPIO archive and later restore only the needed file directly in C#.
 * 4. When integrating with legacy Unix tools that expect CPIO archives, this approach lets you generate a GZIP‑compressed CPIO bundle and programmatically extract a specific entry in a Windows environment.
 * 5. When automating data pipelines that receive compressed CPIO streams, you can decompress the GZIP wrapper and copy the desired data.bin entry to a local path for further processing.
 */
