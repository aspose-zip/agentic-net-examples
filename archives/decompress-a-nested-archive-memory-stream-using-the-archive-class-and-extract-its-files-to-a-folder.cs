// HOW-TO: Extract Nested ZIP From Memory Stream To Folder Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path and output directory
            string inputPath = "nested.zip";
            string outputDirectory = "ExtractedFolder";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the ZIP file, copy it into a memory stream, and extract its contents
            using (FileStream fileStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Copy the file data into the memory stream
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Position = 0; // Reset position for reading

                    // Load the archive from the memory stream
                    using (Archive archive = new Archive(memoryStream))
                    {
                        // Extract all entries to the specified folder
                        archive.ExtractToDirectory(outputDirectory);
                    }
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
 * 1. When you need to unzip a user‑uploaded ZIP that’s stored in memory without writing it to disk first.
 * 2. When processing a nested archive received from a web service and you must extract its contents to a local directory.
 * 3. When building a background job that reads large ZIP files into a MemoryStream for faster in‑memory extraction.
 * 4. When you want to validate that a ZIP file exists and then safely extract all files to a predefined folder.
 * 5. When automating deployment scripts that unpack bundled resources from a ZIP archive held in a stream.
 */
