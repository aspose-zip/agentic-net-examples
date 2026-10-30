// HOW-TO: Create ZArchive From JSON FileStream And Save .Z In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Z;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.json";
            string outputPath = "output/output.z";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the JSON file as a stream
            using (FileStream sourceStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Create a ZArchive and set the source stream
                using (ZArchive archive = new ZArchive())
                {
                    archive.SetSource(sourceStream);
                    // Save the compressed .Z file
                    archive.Save(outputPath);
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
 * 1. When you need to compress a configuration JSON file into a .Z archive for efficient storage or transfer in a .NET application.
 * 2. When you want to generate a .Z compressed backup of a single data file before uploading it to a cloud service.
 * 3. When your program must create a ZArchive from a stream to integrate with legacy systems that only accept .Z files.
 * 4. When you are building a logging pipeline that archives large JSON logs into .Z format to reduce disk usage.
 * 5. When you need to automate the creation of a .Z package from a local file as part of a deployment script written in C#.
 */
