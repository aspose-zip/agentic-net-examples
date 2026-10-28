// HOW-TO: Convert Image Byte Arrays to Base64 Strings and Save to Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded image byte arrays (example data)
            byte[] image1 = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0x00, 0x10, 0x4A, 0x46 }; // JPEG header fragment
            byte[] image2 = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }; // PNG header fragment

            // List to hold Base64 strings
            List<string> base64Strings = new List<string>();

            // Convert each byte array to Base64
            string base64Image1 = Convert.ToBase64String(image1);
            base64Strings.Add(base64Image1);

            string base64Image2 = Convert.ToBase64String(image2);
            base64Strings.Add(base64Image2);

            // Define output file path
            string outputPath = "output/base64.txt";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Write all Base64 strings to the text file, each on a new line
            File.WriteAllLines(outputPath, base64Strings);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed small JPEG or PNG images in a JSON payload, you can encode the image bytes to Base64 strings and write them to a text file for later inclusion.
 * 2. When generating a configuration file that references images, converting the images to Base64 allows you to store them directly in the file without separate binary resources.
 * 3. When sending images through a web API that only accepts text, you can pre‑process the byte arrays into Base64 strings and write them to a file for batch transmission.
 * 4. When creating a simple data‑migration script that moves image data from a legacy system to a new database, converting the bytes to Base64 and saving them to a text file provides an easy intermediate format.
 * 5. When debugging image processing code, dumping the Base64 representation of image buffers to a text file lets you compare the encoded values across runs.
 */
