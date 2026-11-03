// HOW-TO: Convert GZIP File To XZ Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "data.gz";
        string outputPath = "data.xz";

        // Verify that the input GZIP file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Open the GZIP archive for reading
            using (GzipArchive gzipArchive = new GzipArchive(File.OpenRead(inputPath)))
            {
                // Obtain the decompressed payload stream
                using (Stream decompressedStream = gzipArchive.Open())
                {
                    // Copy the payload into a memory stream for recompression
                    using (MemoryStream payloadStream = new MemoryStream())
                    {
                        decompressedStream.CopyTo(payloadStream);
                        payloadStream.Position = 0; // Reset position for reading

                        // Create an XZ archive and set the payload as its source
                        using (XzArchive xzArchive = new XzArchive())
                        {
                            xzArchive.SetSource(payloadStream);
                            // Save the XZ archive to the specified output file
                            xzArchive.Save(outputPath);
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
 * 1. When you need to migrate legacy .gz logs to the more efficient .xz format for long‑term storage in a .NET application.
 * 2. When a data processing pipeline receives GZIP‑compressed payloads and must output them as XZ files for compatibility with downstream Linux tools.
 * 3. When you want to decompress a single file from a .gz archive, modify it in memory, and then recompress it to XZ without writing intermediate files.
 * 4. When you are building a backup system that converts incoming GZIP backups to XZ to reduce disk usage on Windows servers using Aspose.Zip.
 * 5. When you need to programmatically read a GZIP stream and re‑encode its contents as XZ to meet a client’s requirement for XZ‑compressed assets.
 */
