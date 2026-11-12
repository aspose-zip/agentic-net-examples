// HOW-TO: Extract RAR Archive to Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\Archive1.rar";
            string outputPath = @"C:\Output\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (FileStream fs = File.OpenRead(inputPath))
            using (RarArchive archive = new RarArchive(fs))
            {
                archive.ExtractToDirectory(outputPath);
            }

            Console.WriteLine($"Extracted '{inputPath}' to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack a downloaded RAR file to a specific directory in a C# application.
 * 2. When your software must verify the existence of a RAR archive before extracting its contents to avoid runtime errors.
 * 3. When you want to create the output folder automatically if it does not already exist during the extraction process.
 * 4. When you require a reliable way to extract all files and subfolders from a RAR archive using the Aspose.Zip library instead of native Windows tools.
 * 5. When you need to log or display a confirmation message after successfully extracting a RAR archive to help with troubleshooting or user feedback.
 */
