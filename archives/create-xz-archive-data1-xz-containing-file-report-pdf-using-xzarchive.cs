// HOW-TO: Create XZ Archive of PDF File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\report.pdf";
            string outputPath = @"C:\Data\data1.xz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create XZ archive and add the file
            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine($"XZ archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a PDF report for faster network transfer or storage while preserving the original file integrity.
 * 2. When integrating automated backup scripts that archive generated documents into XZ format for long‑term retention.
 * 3. When building a C# service that bundles single files into XZ archives to meet client‑specified compression standards.
 * 4. When creating downloadable packages of PDFs that must be smaller than ZIP files and compatible with Linux tools.
 * 5. When implementing a workflow that validates the existence of a source file, creates the output directory, and generates an XZ archive programmatically.
 */
