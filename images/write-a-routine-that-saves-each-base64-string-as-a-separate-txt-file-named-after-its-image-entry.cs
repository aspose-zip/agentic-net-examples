// HOW-TO: Save Multiple Base64 Strings To Separate Text Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output directory
            string outputDirectory = "output";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory) ?? outputDirectory);

            // Sample Base64 strings mapped to image entry names
            Dictionary<string, string> base64Entries = new Dictionary<string, string>
            {
                { "image1", "iVBORw0KGgoAAAANSUhEUgAA..." },
                { "image2", "R0lGODdhPQBEAPeoAJosM...." },
                { "image3", "UEsDBBQAAAAIAAEAA..." }
                // Add more entries as needed
            };

            // Save each Base64 string to a separate .txt file named after its entry
            foreach (KeyValuePair<string, string> entry in base64Entries)
            {
                string fileName = entry.Key + ".txt";
                string filePath = Path.Combine(outputDirectory, fileName);

                // Write the Base64 string to the file
                File.WriteAllText(filePath, entry.Value);
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
 * 1. When you need to export image data stored as Base64 in a ZIP archive to individual .txt files for later decoding or analysis.
 * 2. When a web service returns multiple Base64‑encoded images and you want to persist each payload as a separate text file using C# file I/O.
 * 3. When generating a diagnostic dump of Base64 strings from a document processing pipeline, saving each entry with its original name for troubleshooting.
 * 4. When creating a simple backup of Base64‑encoded resources extracted from a compressed package, writing each resource to a named .txt file on disk.
 * 5. When automating the preparation of test data by writing a collection of Base64 strings to separate files that can be fed into other tools or scripts.
 */
