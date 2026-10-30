// HOW-TO: Extract All Files from ALZ Archive with UTF‑8 Encoding in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ALZ archive path
            string inputPath = @"C:\Archives\sample.alz";
            // Hardcoded output directory for extraction
            string outputPath = @"C:\Extracted\AlzOutput";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Load the ALZ archive with UTF‑8 encoding for entry names
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.Encoding = Encoding.UTF8;

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to the output directory
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
 * 1. When you need to unpack a multilingual ALZ backup that contains file names in various languages, using UTF‑8 ensures the names are decoded correctly during extraction in a C# application.
 * 2. When migrating data from legacy ALZ archives to a new system, you can programmatically extract all entries to a target folder while preserving the original filenames.
 * 3. When building an automated deployment pipeline that pulls resources from an ALZ package, this code extracts the contents to a staging directory before further processing.
 * 4. When creating a desktop utility that lets users select an ALZ file and view its contents, you can use this approach to extract the files locally with proper name encoding.
 * 5. When performing forensic analysis on an ALZ archive, extracting every entry with UTF‑8 encoding helps ensure that evidence files retain their exact original names for accurate reporting.
 */
