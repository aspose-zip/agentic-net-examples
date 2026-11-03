// HOW-TO: Monitor Entry Compression With Aspose.Zip EntryCompressed Event In C# (Aspose.ZIP for .NET)
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
            string dataDir = @"C:\Data";
            string file1Path = Path.Combine(dataDir, "file1.txt");
            if (!File.Exists(file1Path))
            {
                Console.Error.WriteLine($"File not found: {file1Path}");
                return;
            }

            string file2Path = Path.Combine(dataDir, "file2.txt");
            if (!File.Exists(file2Path))
            {
                Console.Error.WriteLine($"File not found: {file2Path}");
                return;
            }

            string outputPath = Path.Combine(dataDir, "partial.zip");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
            saveOptions.EventsBag.EntryCompressed += (sender, e) =>
            {
                Console.WriteLine($"Compressed entry '{e.Entry.Name}'");
            };

            using (Archive archive = new Archive())
            {
                using (FileStream fs1 = File.OpenRead(file1Path))
                {
                    archive.CreateEntry("file1.txt", fs1);
                }

                using (FileStream fs2 = File.OpenRead(file2Path))
                {
                    archive.CreateEntry("file2.txt", fs2);
                }

                archive.Save(outputPath, saveOptions);
            }

            Console.WriteLine($"Archive saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to log each file as it is compressed while building a ZIP archive in a C# application.
 * 2. When you want to create a ZIP file from multiple streams and ensure the archive is saved to a specific folder using Aspose.Zip.
 * 3. When you must verify the presence of source files before adding them to an archive to avoid runtime errors.
 * 4. When you need to handle compression events to implement custom logic such as progress reporting or size checks during archive creation.
 * 5. When you are building a .NET service that generates partial ZIP archives and requires graceful error handling for missing files.
 */
