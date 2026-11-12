// HOW-TO: Compress a Single File to BZIP2 Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.txt";
            string outputPath = "output.bz2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Create a Bzip2 archive, set the source file, and save the compressed file
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a log file before uploading it to a server, you can compress it to BZIP2 format with Aspose.Zip in C#.
 * 2. When archiving configuration files for backup purposes and require BZIP2 compression for better compression ratios, this code creates the .bz2 archive programmatically.
 * 3. When integrating a .NET application with a legacy system that only accepts BZIP2‑compressed payloads, you can generate the required .bz2 file using the Bzip2Archive class.
 * 4. When preparing data files for distribution over limited‑bandwidth connections, you can compress each file individually to BZIP2 to minimize transfer time.
 * 5. When automating a build pipeline that needs to package generated reports into BZIP2 archives for storage compliance, this snippet handles the compression step.
 */
