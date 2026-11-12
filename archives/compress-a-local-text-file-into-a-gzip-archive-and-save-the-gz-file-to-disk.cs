// HOW-TO: Compress a Text File to Gzip Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "sample.txt";
            string outputPath = "sample.gz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Compress the file using GzipArchive
            using (GzipArchive archive = new GzipArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("File compressed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of log or configuration files before uploading them to a server, you can compress the text file to a .gz archive with Aspose.Zip in C#.
 * 2. When you want to store backup copies of reports in a space‑efficient format, you can create Gzip archives of the generated text files programmatically.
 * 3. When transmitting large CSV or JSON payloads over HTTP, compressing the file to Gzip first helps minimize bandwidth usage in a .NET application.
 * 4. When integrating with legacy systems that only accept .gz files, you can use this code to convert local text documents into the required format.
 * 5. When automating nightly data archiving tasks, you can schedule this C# routine to compress daily text exports into Gzip files for long‑term storage.
 */
