// HOW-TO: Create CAB Archive From File Streams With Automatic Stream Closure In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath1 = "file1.txt";
            string inputFilePath2 = "image.png";
            string cabOutputPath = "output/archive.cab";

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

            Directory.CreateDirectory(Path.GetDirectoryName(cabOutputPath));

            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                using (FileStream stream1 = new FileStream(inputFilePath1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("file1.txt", stream1);
                }

                CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());
                using (FileStream stream2 = new FileStream(inputFilePath2, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("image.png", stream2, storedSettings);
                }

                archive.Save(cabOutputPath);
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
 * 1. When you need to package multiple files into a single .cab file for Windows installation or distribution while reading the source files as streams.
 * 2. When you want to compress a text file using MS‑ZIP compression and store an image without compression inside the same CAB archive.
 * 3. When your application must ensure that file streams are closed immediately after being added to the archive to avoid file locks.
 * 4. When you are generating CAB archives programmatically in a build pipeline and need to control compression settings per entry.
 * 5. When you need to create a CAB file on the fly from user‑uploaded files in a web service without keeping the files open.
 */
