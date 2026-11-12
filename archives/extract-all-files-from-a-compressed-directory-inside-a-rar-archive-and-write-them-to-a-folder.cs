// HOW-TO: Extract All Files from a RAR Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\archive.rar";
            string outputPath = "C:\\Data\\Extracted";

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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack a downloaded RAR backup and place its contents into a specific directory for further processing.
 * 2. When an application must automatically extract user‑submitted RAR files on a server before indexing or analyzing the files.
 * 3. When a deployment script has to unpack a RAR package containing configuration files into the target environment’s config folder.
 * 4. When a data migration tool extracts archived RAR datasets into a working folder to transform or load them into a database.
 * 5. When a desktop utility reads a RAR archive of images and extracts them to a local folder for display or editing.
 */
