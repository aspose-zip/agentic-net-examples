// HOW-TO: Save Image Base64 Dictionary To JSON File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output/images.json";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Dictionary of image entry names and Base64 strings
            Dictionary<string, string> imageDict = new Dictionary<string, string>
            {
                { "image1.png", "iVBORw0KGgoAAAANSUhEUgAA..." },
                { "image2.jpg", "/9j/4AAQSkZJRgABAQAAAQABAAD..." }
            };

            // Serialize the dictionary to JSON with indentation
            string json = JsonSerializer.Serialize(imageDict, new JsonSerializerOptions { WriteIndented = true });

            // Write the JSON content to the file
            File.WriteAllText(outputPath, json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple image assets into a single JSON manifest for a web API that expects Base64‑encoded images.
 * 2. When you want to generate a configuration file that maps image filenames to their Base64 data for client‑side rendering without separate image files.
 * 3. When you are creating a portable backup of image resources that can be easily restored by deserializing the JSON in a C# application.
 * 4. When you need to embed thumbnail previews inside a ZIP archive’s metadata by storing them as Base64 strings in a JSON side‑car file.
 * 5. When you are preparing image data for a machine‑learning service that requires a JSON payload containing Base64‑encoded images.
 */
