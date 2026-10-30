// HOW-TO: Create CAB Archive with Deferred Stream Provider and Store Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath = "C:\\Data\\example.txt";
            string deferredFilePath = "C:\\Data\\deferred.bin";
            string storedFilePath = "C:\\Data\\stored.html";
            string outputCabPath = "C:\\Output\\archive.cab";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }
            if (!File.Exists(deferredFilePath))
            {
                Console.Error.WriteLine($"File not found: {deferredFilePath}");
                return;
            }
            if (!File.Exists(storedFilePath))
            {
                Console.Error.WriteLine($"File not found: {storedFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputCabPath));

            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                archive.CreateEntry("example.txt", inputFilePath);

                archive.CreateEntry("deferred.bin", () =>
                {
                    return new FileStream(deferredFilePath, FileMode.Open, FileAccess.Read);
                });

                CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());

                archive.CreateEntry("stored.html", storedFilePath, storedSettings);

                archive.Save(outputCabPath);
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
 * 1. When you need to package multiple files into a single CAB file for Windows installation, using different compression methods per entry.
 * 2. When you want to add a large file to a CAB archive without loading it entirely into memory by providing a deferred stream.
 * 3. When you must preserve an HTML file exactly as‑is inside a CAB archive by storing it without compression.
 * 4. When you are building an automated build pipeline that creates CAB installers and must ensure all source streams are closed after compression.
 * 5. When you need to generate a CAB archive programmatically in C# for legacy Windows deployment scenarios while mixing compressed and uncompressed entries.
 */
