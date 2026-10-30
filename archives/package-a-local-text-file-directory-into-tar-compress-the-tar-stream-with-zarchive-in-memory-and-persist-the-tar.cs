// HOW-TO: Compress Directory To TAR.Z With Zstandard Using Aspose.Zip C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Zstandard;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing text files
            string inputDir = @"C:\Temp\Input";

            // Hardcoded output path for the compressed TAR.Z archive
            string outputPath = @"C:\Temp\Output\archive.tar.zst";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Retrieve all files from the input directory
            string[] files = Directory.GetFiles(inputDir);

            // Create a new TAR archive
            using (TarArchive archive = new TarArchive())
            {
                // Add each file as an entry in the TAR archive
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Use the file name as the entry name inside the TAR
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Save the TAR archive compressed with Zstandard
                archive.SaveZstandard(outputPath);
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
 * 1. When you need to bundle a set of log or text files into a single TAR archive and compress it with Zstandard for efficient storage or transfer.
 * 2. When an application must create a portable backup of configuration files on Windows and store it as a .tar.zst file without writing intermediate files to disk.
 * 3. When a CI/CD pipeline has to package generated reports into a compressed TAR.Z stream before uploading to an artifact repository.
 * 4. When you want to send multiple documents over a network with high compression ratio, using Aspose.Zip to create an in‑memory TAR and Zstandard archive in C#.
 * 5. When a backup utility requires creating a single compressed archive from a directory of text files while ensuring the output directory is created automatically.
 */
