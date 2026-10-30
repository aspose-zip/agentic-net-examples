// HOW-TO: Extract Files From Apple Archive (.Applearchive) Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.applearchive";
            string outputPath = @"C:\Output\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (FileStream archiveStream = File.Open(inputPath, FileMode.Open))
            {
                using (Archive archive = new Archive(archiveStream))
                {
                    archive.ExtractToDirectory(outputPath);
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack an Apple Archive received from macOS backup tools into a local folder using C#.
 * 2. When your application must read a .applearchive file and extract its contents without relying on external command‑line utilities.
 * 3. When you want to determine if an Apple Archive is solid and perform a whole‑archive extraction to preserve file integrity in a .NET environment.
 * 4. When automating migration of macOS application bundles stored in Apple Archives to Windows servers via Aspose.Zip extraction.
 * 5. When handling user‑uploaded Apple Archive files in a web service and need to safely extract them to a temporary directory for further processing.
 */
