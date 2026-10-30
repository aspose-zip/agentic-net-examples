// HOW-TO: Extract Single-File .Z Archive from Memory to Disk in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Z;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.z";
            string outputPath = "output\\extracted.dat";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath) ?? string.Empty;
            Directory.CreateDirectory(outputDir);

            // Read the .Z file into a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                // Open the Z archive from the memory stream
                using (ZArchive archive = new ZArchive(memoryStream))
                {
                    // Create the output file stream
                    using (FileStream outputStream = File.Create(outputPath))
                    {
                        // Extract the payload to the output stream
                        archive.Extract(outputStream);
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
 * 1. When you need to read a compressed .Z file received as a byte array and save its contents to a local file without writing the archive to disk first.
 * 2. When a web service returns a .Z payload in memory and your application must extract the embedded data directly to a file system location.
 * 3. When processing large log files that are packaged in a single‑file .Z archive stored in memory to avoid extra I/O overhead during extraction.
 * 4. When integrating with legacy systems that generate .Z streams and you must programmatically unpack them to a specific output directory in a .NET application.
 * 5. When automating a deployment script that extracts configuration data from an in‑memory .Z archive to a target folder before starting the service.
 */
