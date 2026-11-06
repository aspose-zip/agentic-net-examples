// HOW-TO: Decode Base64 Image File to PNGs in C# (Aspose.ZIP for .NET)
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "base64_images.txt";
        string outputFolder = "output_images";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Read all Base64 lines
            string[] lines = File.ReadAllLines(inputPath);
            int imageIndex = 1;

            foreach (string line in lines)
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                try
                {
                    // Decode Base64 to binary data
                    byte[] imageData = Convert.FromBase64String(line.Trim());

                    // Build output file path (using .png extension by default)
                    string outputPath = Path.Combine(outputFolder, $"image{imageIndex}.png");

                    // Write image file
                    File.WriteAllBytes(outputPath, imageData);
                    imageIndex++;
                }
                catch (FormatException)
                {
                    // Invalid Base64 string – report and continue
                    Console.Error.WriteLine($"Invalid Base64 data at line {imageIndex}. Skipping.");
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
 * 1. When you receive a text file containing Base64‑encoded screenshots from a mobile app and need to batch‑convert them into PNG files for review.
 * 2. When an automated email parser extracts Base64 image strings from messages and you must recreate the original images on a server using C#.
 * 3. When a web service returns a list of Base64‑encoded product photos and you need to save them locally as separate image files for further processing.
 * 4. When a data migration script stores images as Base64 in a CSV and you have to decode and write them to an output directory before importing into a new system.
 * 5. When you need to validate and extract multiple Base64‑encoded graphics embedded in a log file, handling invalid lines gracefully while writing the valid images to disk.
 */
