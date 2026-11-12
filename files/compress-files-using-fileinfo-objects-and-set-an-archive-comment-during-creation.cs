// HOW-TO: Compress Multiple Files Into a ZIP Archive Using FileInfo in C# (Aspose.ZIP for .NET)
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
            string inputFilePath1 = "Data\\input1.txt";
            string inputFilePath2 = "Data\\input2.txt";
            string outputZipPath = "Output\\compressed.zip";

            if (!File.Exists(inputFilePath1))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath1}");
                return;
            }
            if (!File.Exists(inputFilePath2))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (FileStream zipFile = File.Open(outputZipPath, FileMode.Create))
            {
                FileInfo fi1 = new FileInfo(inputFilePath1);
                FileInfo fi2 = new FileInfo(inputFilePath2);

                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("input1.txt", fi1);
                    archive.CreateEntry("input2.txt", fi2);

                    ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                    {
                        Encoding = Encoding.ASCII
                    };

                    archive.Save(zipFile, saveOptions);
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
 * 1. When you need to back up several text log files on a server by compressing them into a single ZIP file using C#.
 * 2. When you want to package configuration files for deployment and ensure they are stored with correct ASCII encoding in a ZIP archive.
 * 3. When you have to send multiple documents as one email attachment and need to create the ZIP programmatically.
 * 4. When you generate daily reports and want to archive them automatically into a compressed archive for long‑term storage.
 * 5. When you need to create a portable data bundle for offline processing by bundling related files into a ZIP using FileInfo objects.
 */
