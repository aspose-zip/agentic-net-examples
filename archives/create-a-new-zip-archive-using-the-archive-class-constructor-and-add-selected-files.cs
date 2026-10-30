// HOW-TO: Create a ZIP Archive and Add Multiple Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string inputFile1 = Path.Combine(dataDir, "file1.txt");
            string inputFile2 = Path.Combine(dataDir, "file2.txt");
            string outputZipPath = @"C:\Output\archive.zip";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create archive and add files
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            using (FileStream source1 = File.Open(inputFile1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputFile2, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.txt", source1);
                archive.CreateEntry("file2.txt", source2);

                // Save archive with options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                {
                    Encoding = Encoding.ASCII,
                    ArchiveComment = "Sample archive created with Aspose.Zip"
                };
                archive.Save(zipStream, saveOptions);
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
 * 1. When you need to bundle several text reports into a single ZIP file for email attachment using C#.
 * 2. When you want to programmatically create an archive with a custom comment and specific encoding for compliance documentation.
 * 3. When an application must generate a downloadable package of configuration files on the fly without using external tools.
 * 4. When you have to ensure the output directory exists before saving a compressed archive in a Windows service.
 * 5. When you need to validate the existence of source files and create a ZIP archive only if all required files are present.
 */
