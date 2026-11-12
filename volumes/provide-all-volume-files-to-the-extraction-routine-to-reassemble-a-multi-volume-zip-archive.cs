// HOW-TO: Extract Multi‑Volume Split ZIP Archive by Supplying All Segments in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing the split ZIP parts
            string inputDirectory = @"C:\MultiVolumeZip\Input";
            // Hardcoded output directory where the archive will be extracted
            string outputDirectory = @"C:\MultiVolumeZip\Extracted";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Collect all files in the input directory
            string[] allFiles = Directory.GetFiles(inputDirectory);

            // Identify the main .zip segment
            string mainSegment = allFiles
                .FirstOrDefault(f => Path.GetExtension(f).Equals(".zip", StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrEmpty(mainSegment) || !File.Exists(mainSegment))
            {
                Console.Error.WriteLine("Main ZIP segment (.zip) not found.");
                return;
            }

            // Identify the additional split segments (e.g., .z01, .z02, ...)
            string[] splitSegments = allFiles
                .Where(f => !f.Equals(mainSegment, StringComparison.OrdinalIgnoreCase))
                .OrderBy(f => f)
                .ToArray();

            // Verify each split segment file exists
            foreach (string segment in splitSegments)
            {
                if (!File.Exists(segment))
                {
                    Console.Error.WriteLine($"File not found: {segment}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Open the multi‑volume archive and extract its contents
            using (Archive archive = new Archive(mainSegment, splitSegments))
            {
                archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you receive a large ZIP file that was split into .z01, .z02, … and need to combine and extract it in a C# application.
 * 2. When automating deployment of software packages delivered as multi‑volume archives and you must ensure all parts are present before extraction.
 * 3. When processing backup archives that were divided into several volumes to fit storage limits and you need to reassemble them programmatically.
 * 4. When building a file‑transfer tool that downloads split ZIP segments from a server and extracts the complete archive on the client side.
 * 5. When creating a data‑migration script that reads a multi‑part ZIP from a directory and extracts its contents to a target folder in .NET.
 */
