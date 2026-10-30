// HOW-TO: Compress an XML File to BZIP2 with Default Settings in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "data/input.xml";
            string outputPath = "output/input.xml.bz2";

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
 * 1. When you need to reduce the size of a large XML configuration before sending it over a network, you can compress it to a .bz2 file using C# and Aspose.Zip.
 * 2. When storing XML logs for long‑term archival, compressing each file to BZIP2 helps save disk space while keeping the data easily decompressible later.
 * 3. When integrating with a legacy system that only accepts BZIP2‑compressed XML payloads, this code creates the required .bz2 file in a single step.
 * 4. When automating backup scripts for XML data files, you can generate BZIP2 archives programmatically to ensure consistent compression without external tools.
 * 5. When preparing XML documents for email attachment where size limits apply, compressing them to BZIP2 using Aspose.Zip in C# ensures they meet the constraints.
 */
