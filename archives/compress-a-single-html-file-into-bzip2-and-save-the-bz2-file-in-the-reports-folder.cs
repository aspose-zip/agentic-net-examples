// HOW-TO: Compress an HTML File to BZIP2 and Save in Reports Folder Using C# (Aspose.ZIP for .NET)
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
            // Hardcoded input HTML file and output BZIP2 file paths
            string inputPath = "data/input.html";
            string outputPath = "reports/output.bz2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BZIP2 archive, set the source file, and save the compressed file
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
 * 1. When you need to reduce the size of a generated HTML report before archiving it on a server.
 * 2. When you want to store a single webpage in a BZIP2 file for efficient backup or transfer.
 * 3. When an automated build process must compress HTML documentation into a .bz2 file for deployment.
 * 4. When a web application generates logs in HTML and you need to compress them to save disk space.
 * 5. When you are preparing HTML content for email attachment and want to minimize attachment size using BZIP2 compression.
 */
