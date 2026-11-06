// HOW-TO: Read Archive Comment From Parallel Compressed ZIP And Save To Text In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.zip";
            string outputPath = "report.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory());
            }

            // Load the ZIP archive and read its comment
            using (Archive archive = new Archive(inputPath))
            {
                string comment = archive.Comment;

                // Save the comment to a text report
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                {
                    writer.Write(comment);
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
 * 1. When you need to extract the descriptive comment embedded in a ZIP file created with parallel compression and store it for documentation or auditing purposes.
 * 2. When generating a compliance report that must include the archive comment of a ZIP package processed by a .NET application.
 * 3. When building a tool that validates or logs metadata from ZIP archives before further extraction or processing.
 * 4. When creating an automated script that reads ZIP comments to populate a database of file package descriptions.
 * 5. When troubleshooting deployment packages by retrieving and reviewing the comment field of a ZIP created by a parallel compression workflow.
 */
