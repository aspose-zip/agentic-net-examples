// HOW-TO: Decode Base64 Text File to PNG Images in C# (Aspose.ZIP for .NET)
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "base64.txt";
        string outputFolder = "output_images";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Read all Base64 strings (one per line)
            string[] lines = File.ReadAllLines(inputPath);

            for (int i = 0; i < lines.Length; i++)
            {
                string base64 = lines[i].Trim();
                if (string.IsNullOrEmpty(base64))
                {
                    continue; // Skip empty lines
                }

                // Decode Base64 to binary image data
                byte[] imageBytes = Convert.FromBase64String(base64);

                // Build output file path (e.g., image_1.png, image_2.png, ...)
                string outputPath = Path.Combine(outputFolder, $"image_{i + 1}.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Write the image file
                File.WriteAllBytes(outputPath, imageBytes);
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
 * 1. When a web service returns multiple images as Base64 strings in a text file, you can use this routine to recreate the original PNG files for further processing or display.
 * 2. When migrating legacy data stored in Base64 format to a modern file system, the code lets you batch‑decode and save each image without manual conversion.
 * 3. When automating the extraction of embedded screenshots from logs or configuration files that were saved as Base64 lines, this C# script quickly restores them to usable image files.
 * 4. When building a CI/CD pipeline that needs to verify visual assets delivered as Base64 payloads, the routine decodes them into PNGs for comparison or testing.
 * 5. When receiving email attachments encoded in Base64 and saved to a text file, developers can run this code to reconstruct the original images for archival or analysis.
 */
