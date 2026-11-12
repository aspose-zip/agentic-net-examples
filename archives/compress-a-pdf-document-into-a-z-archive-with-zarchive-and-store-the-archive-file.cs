// HOW-TO: Compress a PDF into a Z Archive using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Z;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PDF and output Z archive paths
            string inputPath = "input.pdf";
            string outputPath = "output/output.z";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a Z archive, add the PDF, and save it
            using (ZArchive archive = new ZArchive())
            {
                // Set the source file to be compressed
                archive.SetSource(inputPath);
                // Save the archive to the output path
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
 * 1. When you need to reduce the size of a PDF for faster email transmission, you can compress it into a .Z archive using Aspose.Zip in C#.
 * 2. When storing large numbers of PDF reports on a server with limited storage, you can archive each PDF into a .Z file to save disk space.
 * 3. When preparing PDF documents for secure backup, you can bundle them into a .Z archive before uploading to cloud storage.
 * 4. When creating a downloadable package of PDF manuals for offline use, you can compress the PDFs into a .Z archive to simplify distribution.
 * 5. When integrating PDF compression into an automated build pipeline, you can use Aspose.Zip to generate .Z archives as part of the post‑build steps.
 */
