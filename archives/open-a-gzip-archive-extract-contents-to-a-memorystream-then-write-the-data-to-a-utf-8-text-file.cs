// HOW-TO: Extract GZIP File to UTF-8 Text File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.gz";
            string outputPath = "extracted.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Open GZIP archive and extract to a memory stream
            using (GzipArchive archive = new GzipArchive(File.OpenRead(inputPath)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (Stream unpackedStream = archive.Open())
                    {
                        unpackedStream.CopyTo(memoryStream);
                    }

                    // Convert extracted bytes to UTF-8 string
                    string extractedText = Encoding.UTF8.GetString(memoryStream.ToArray());

                    // Write the text to the output file
                    File.WriteAllText(outputPath, extractedText);
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
 * 1. When you need to decompress a .gz log file on the fly and save its contents as a readable UTF-8 text file in a .NET application.
 * 2. When a service receives GZIP-compressed configuration data via a stream and must extract it into memory before persisting it as a UTF-8 file.
 * 3. When you want to programmatically unpack a GZIP backup archive and convert the binary payload into a UTF-8 document without writing intermediate files.
 * 4. When processing user-uploaded .gz documents in a web API and you must extract the text for indexing or further analysis.
 * 5. When automating migration of legacy GZIP-compressed reports into plain-text files for integration with modern analytics tools.
 */
