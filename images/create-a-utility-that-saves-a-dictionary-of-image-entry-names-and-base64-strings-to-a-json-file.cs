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
            // Hardcoded dictionary of image entry names and their Base64 strings
            Dictionary<string, string> imageDictionary = new Dictionary<string, string>
            {
                { "image1.png", "iVBORw0KGgoAAAANSUhEUgAA..." },
                { "image2.jpg", "/9j/4AAQSkZJRgABAQAAAQABAAD..." }
                // Add more entries as needed
            };

            // Hardcoded output path for the JSON file
            string outputPath = "output/images.json";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Serialize the dictionary to a formatted JSON string
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string jsonContent = JsonSerializer.Serialize(imageDictionary, options);

            // Write the JSON content to the file
            File.WriteAllText(outputPath, jsonContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a JSON manifest that maps image file names to their Base64 data for embedding resources in a web API response.
 * 2. When packaging images into a ZIP archive and want a JSON index file that lists each entry’s name and encoded content for later extraction.
 * 3. When creating a configuration file for a mobile app that stores icons as Base64 strings to avoid separate image files.
 * 4. When exporting image assets from a database to a portable JSON file that can be imported by another C# service without losing binary data.
 * 5. When building a documentation generator that includes screenshots as Base64 strings in a JSON file for easy rendering in HTML.
 */
