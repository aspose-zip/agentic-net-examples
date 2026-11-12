// HOW-TO: Compress CSV File to BZIP2 Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\dataset.csv";
            string outputPath = "C:\\Data\\dataset.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of a large CSV dataset for faster network transfer or storage, you can use this code to create a BZIP2 archive in C#.
 * 2. When integrating data pipelines that require BZIP2‑compressed input for downstream analytics tools, this snippet shows how to generate the required file programmatically.
 * 3. When building a backup solution that stores CSV logs in a space‑efficient format, the code demonstrates how to compress them into a .bz2 file using Aspose.Zip.
 * 4. When a SaaS application must offer downloadable reports in a compressed format compatible with Unix tools, this example provides the C# implementation for BZIP2 compression.
 * 5. When automating batch processing of multiple CSV files and you want to run several compression threads in parallel, the pattern can be extended to handle parallel BZIP2 compression with Aspose.Zip.
 */
