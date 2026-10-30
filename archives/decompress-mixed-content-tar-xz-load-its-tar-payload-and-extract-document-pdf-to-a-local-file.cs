// HOW-TO: Extract PDF From a .Tar.Xz Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "mixed_content.tar.xz";
            string outputPath = "output/document.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Decompress XZ layer to obtain the TAR archive in memory
            using (XzArchive xzArchive = new XzArchive(inputPath))
            {
                using (MemoryStream tarStream = new MemoryStream())
                {
                    // Extract the inner TAR payload into the memory stream
                    xzArchive.Extract(tarStream);
                    tarStream.Position = 0;

                    // Load the TAR archive from the decompressed stream
                    using (TarArchive tarArchive = new TarArchive(tarStream))
                    {
                        // Find the entry named document.pdf (case‑insensitive)
                        TarEntry pdfEntry = tarArchive.Entries
                            .FirstOrDefault(e => string.Equals(e.Name, "document.pdf", StringComparison.OrdinalIgnoreCase));

                        if (pdfEntry == null)
                        {
                            Console.Error.WriteLine("document.pdf not found in the TAR archive.");
                            return;
                        }

                        // Extract the PDF entry to the specified output file
                        using (FileStream outputFile = File.Create(outputPath))
                        {
                            pdfEntry.Extract(outputFile);
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
 * 1. When you receive a compressed .tar.xz package containing multiple files and need to programmatically retrieve a specific PDF without writing the intermediate TAR to disk.
 * 2. When an automated build pipeline must unpack a .tar.xz distribution, locate a documentation PDF, and place it in a designated output folder using C#.
 * 3. When a desktop application processes user‑uploaded .tar.xz archives and extracts a particular PDF for preview or further processing.
 * 4. When a server‑side service extracts a PDF from a .tar.xz backup archive to generate reports or send the file via email.
 * 5. When you want to combine XZ decompression and TAR extraction in a single .NET routine to avoid temporary files and improve performance.
 */
