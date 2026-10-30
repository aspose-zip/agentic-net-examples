// HOW-TO: Extract the Last Image from a WIM Archive Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.wim";
            string outputPath = "LastWimImage";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputPath);

            // Load the WIM archive
            using (WimArchive wim = new WimArchive(inputPath))
            {
                // Get the last image in the archive
                int lastIndex = wim.Images.Count - 1;
                if (lastIndex < 0)
                {
                    Console.Error.WriteLine("No images found in the WIM archive.");
                    return;
                }

                WimImage lastImage = wim.Images[lastIndex];

                // Extract the last image to the output directory
                lastImage.ExtractToDirectory(outputPath);
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
 * 1. When you need to retrieve the most recent Windows image from a WIM file for a deployment script.
 * 2. When automating a backup verification process that extracts only the latest snapshot stored in a WIM archive.
 * 3. When building a tool that pulls the last captured system state from a multi‑image WIM to compare against a baseline.
 * 4. When creating a CI/CD pipeline that extracts the final image in a WIM package to prepare a clean test environment.
 * 5. When developing a maintenance utility that isolates the newest Windows image in a WIM to apply patches or updates.
 */
