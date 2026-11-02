// HOW-TO: Create CAB Archive from Multiple XML Files Using Stream Providers in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "file1.xml";
            string inputPath2 = "file2.xml";
            string inputPath3 = "file3.xml";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            string outputPath = "output/xml_entries.cab";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CabArchive archive = new CabArchive())
            {
                archive.CreateEntry(
                    Path.GetFileName(inputPath1),
                    () => new FileStream(inputPath1, FileMode.Open, FileAccess.Read),
                    new CabEntrySettings(new CabMsZipCompressionSettings()));

                archive.CreateEntry(
                    Path.GetFileName(inputPath2),
                    () => new FileStream(inputPath2, FileMode.Open, FileAccess.Read),
                    new CabEntrySettings(new CabMsZipCompressionSettings()));

                archive.CreateEntry(
                    Path.GetFileName(inputPath3),
                    () => new FileStream(inputPath3, FileMode.Open, FileAccess.Read),
                    new CabEntrySettings(new CabMsZipCompressionSettings()));

                CabSaveOptions saveOptions = new CabSaveOptions();
                saveOptions.CloseEntrySource = true;

                using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    archive.Save(outStream, saveOptions);
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
 * 1. When you need to package several configuration XML files into a single CAB archive for distribution with Microsoft deployment tools.
 * 2. When you want to compress XML resources on the fly using stream providers without loading the entire files into memory.
 * 3. When you must ensure that the source streams are automatically closed after each entry is written by setting CloseEntrySource.
 * 4. When you are building an installer that requires a CAB file containing XML manifests generated at runtime.
 * 5. When you need to create a CAB archive in a specific folder structure programmatically from local files in a C# application.
 */
