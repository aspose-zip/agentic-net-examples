// HOW-TO: Read Zip Archive Comment and Save to Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.zip";
            string outputPath = "output.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (if any)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the ZIP archive and retrieve its comment
            using (Archive archive = new Archive(inputPath))
            {
                string comment = archive.Comment;

                // Write the comment to the output text file
                File.WriteAllText(outputPath, comment ?? string.Empty);
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
 * 1. When you need to extract the descriptive comment stored in a ZIP file for documentation or logging purposes.
 * 2. When a build pipeline must verify or archive the metadata comment of generated ZIP packages.
 * 3. When an application needs to display or process the ZIP archive comment to inform users about its contents.
 * 4. When migrating ZIP archives to a system that stores comments separately in a database or text repository.
 * 5. When auditing or compliance checks require capturing the original ZIP comment into a readable text file.
 */
