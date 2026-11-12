// HOW-TO: Extract An ALZ Archive To A Folder Using C# Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ALZ archive path
            string inputPath = "C:\\Archives\\sample.alz";
            // Hardcoded output directory path
            string outputPath = "C:\\Extracted\\AlzOutput";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory (and its parent) exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Open the ALZ archive and extract its contents
            using (Archive archive = new Archive(inputPath))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically unpack a downloaded ALZ backup into a specific directory for further processing.
 * 2. When an application must verify that an ALZ file exists before extracting its contents to a known output folder.
 * 3. When you want to automate the extraction of multiple ALZ archives as part of a data migration workflow in C#.
 * 4. When you need to ensure the destination folder hierarchy is created automatically before extracting an ALZ package.
 * 5. When handling error‑prone extraction, you require try‑catch logic around Aspose.Zip’s ExtractToDirectory to log failures.
 */
