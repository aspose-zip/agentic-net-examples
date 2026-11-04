// HOW-TO: Create Multi‑Volume ZIP Archive with 50 MB Parts Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\Input";
            string outputDirectory = @"C:\Data\Output\MultiVolumeArchive";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Archive archive = new Archive())
            {
                string[] filePaths = Directory.GetFiles(inputDirectory);

                foreach (string filePath in filePaths)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                SplitArchiveSaveOptions splitOptions = new SplitArchiveSaveOptions(50 * 1024 * 1024);
                archive.SaveSplit(outputDirectory, splitOptions);
            }

            Console.WriteLine("Multi‑volume ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up a large directory and store it on media that only accepts 50 MB files, you can create a multi‑volume ZIP archive with Aspose.Zip in C#.
 * 2. When sending a big data set through email or a file‑sharing service that limits attachment size, splitting the ZIP into 50 MB parts ensures each part complies with the limit.
 * 3. When archiving daily logs that quickly exceed a single file size, generating 50 MB ZIP volumes lets you process and extract each segment independently.
 * 4. When distributing software packages that must fit on USB drives with a fixed capacity, using SaveSplit to produce 50 MB ZIP chunks guarantees each part fits the drive.
 * 5. When automating the archival of video recordings and you require each compressed archive to stay under a specific size for faster indexing and retrieval, a multi‑volume ZIP created with Aspose.Zip meets that need.
 */
