// HOW-TO: Add In-Memory Text File To Existing 7z Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.SevenZip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.7z";
            string outputPath = "output.7z";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                using (SevenZipArchive archive = new SevenZipArchive(inputStream))
                {
                    // Generate a text file in memory
                    MemoryStream textStream = new MemoryStream();
                    using (StreamWriter writer = new StreamWriter(textStream, Encoding.UTF8, 1024, true))
                    {
                        writer.Write("Hello, Aspose.Zip!");
                        writer.Flush();
                    }
                    textStream.Position = 0;

                    // Add the generated text file as a new entry
                    archive.CreateEntry("generated.txt", textStream);

                    // Save the updated archive to the output path
                    using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                    {
                        archive.Save(outputStream);
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
 * 1. When you need to programmatically insert a dynamically generated log file into an existing 7z package without extracting it first.
 * 2. When you want to update a backup archive by adding a new configuration file created on the fly in a C# application.
 * 3. When a deployment tool must embed a generated manifest into a pre‑built 7z bundle before distribution.
 * 4. When you have to augment a compressed resource archive with a temporary report generated in memory using Aspose.Zip for .NET.
 * 5. When an automated script must add a UTF‑8 text document to a 7z archive and save the modified archive to a different location.
 */
