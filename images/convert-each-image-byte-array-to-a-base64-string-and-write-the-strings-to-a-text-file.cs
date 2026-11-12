// HOW-TO: Convert Multiple Images to Base64 Strings and Save to Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing image files
            string inputDirectory = "input_images";
            // Hardcoded output text file path
            string outputFilePath = "output/base64.txt";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Open a StreamWriter for the output file
            using (StreamWriter writer = new StreamWriter(outputFilePath, false))
            {
                // Process each file in the input directory
                string[] filePaths = Directory.GetFiles(inputDirectory);
                foreach (string filePath in filePaths)
                {
                    // Verify the file exists before reading
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Read the image bytes
                    byte[] imageBytes = File.ReadAllBytes(filePath);
                    // Convert to Base64 string
                    string base64String = Convert.ToBase64String(imageBytes);
                    // Write the Base64 string to the output file
                    writer.WriteLine(base64String);
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
 * 1. When you need to embed image data in a JSON or XML payload, you can convert each image to a Base64 string and store the strings in a text file for later inclusion.
 * 2. When preparing images for transmission over APIs that only accept plain‑text, converting them to Base64 and writing them to a file simplifies batch processing in C#.
 * 3. When creating a data‑driven report that references images stored as Base64, this code lets you generate the required strings from a folder of pictures automatically.
 * 4. When archiving image assets in a database that stores binary data as Base64, you can pre‑encode the files and save the results to a text file for bulk import.
 * 5. When sending images as email attachments via MIME‑encoded messages, converting them to Base64 and saving the output helps you assemble the email body programmatically.
 */
