// HOW-TO: Extract Specific File From Apple Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input Apple Archive path
            string inputPath = @"C:\Archives\sample.aar";

            // Verify the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded name of the entry to extract
            string entryNameToExtract = "Documents/report.pdf";

            // Hardcoded output file path for the extracted entry
            string outputPath = @"C:\Extracted\report.pdf";

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the Apple Archive
            using (Archive archive = new Archive(inputPath))
            {
                // Find the desired entry
                ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryNameToExtract, StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryNameToExtract}");
                    return;
                }

                // Open the entry as a readable stream and copy to the output file
                using (Stream entryStream = entry.Open())
                {
                    using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        entryStream.CopyTo(outStream);
                    }
                }
            }

            Console.WriteLine($"Entry '{entryNameToExtract}' extracted to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to retrieve a single document, such as a PDF report, from an Apple .aar package without extracting the entire archive.
 * 2. When integrating a .NET application that processes iOS app resources and must pull out a specific file for further analysis or display.
 * 3. When automating a build pipeline that extracts configuration files from an Apple Archive to configure subsequent deployment steps.
 * 4. When creating a user‑initiated download feature that lets users select and save an individual file from a bundled .aar archive.
 * 5. When performing forensic or debugging tasks that require reading the contents of a particular entry inside an Apple Archive without modifying the original package.
 */
